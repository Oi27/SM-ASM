using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Diagnostics;

namespace SM_ASM_GUI
{
    public partial class SpecialDoorID : Form
    {
        public SMASM Source { get; set; }

        public SpecialDoorID(SMASM parent)
        {
            //setup should write and load from a DoorIDgroups text file
            //populate listboxes
            InitializeComponent();
            Source = parent;

            List<string> plms = Source.GetPLMentries();
            foreach (string item in plms)
            {
                string[] tags = Source.GetPLMtags(item, out string[] mapProperties);
                if (mapProperties[1].Contains("door")) { DoorList.Items.Add(tags[0] + " - " + mapProperties[2]); }
            }
            
        }



        private void MoveToGroup(ListBox source, ListBox destination)
        {
            List<string> theseEntries = new List<string>();
            foreach (var item in source.SelectedItems)
            {
                destination.Items.Add(item);
                theseEntries.Add(item.ToString());
            }
            foreach (var item in theseEntries)
            {
                source.Items.Remove(item);
            }
            Source.SortByPLMheader(destination);
        }


        private List<DoorLink> AssignDoorGroups(List<DoorLink> doors)
        {
            List<uint> headersA = new List<uint>();
            List<uint> headersB = new List<uint>();
            List<uint> headersC = new List<uint>();
            foreach (var item in DoorsA.Items)
            {
                headersA.Add(uint.Parse(item.ToString().Substring(0, 4),NumberStyles.HexNumber));
            }
            foreach (var item in DoorsB.Items)
            {
                headersB.Add(uint.Parse(item.ToString().Substring(0, 4), NumberStyles.HexNumber));
            }
            foreach (var item in DoorsC.Items)
            {
                headersC.Add(uint.Parse(item.ToString().Substring(0, 4), NumberStyles.HexNumber));
            }



            //loop through each group list & check for the ID:
            for (int i = 0; i < doors.Count; i++)
            {
                string sideAgroup = null;
                string sideBgroup = null;
                foreach (uint plmheader in headersA)
                {
                    if (plmheader == doors[i].PLMa.ID) { sideAgroup = "A"; }
                    if (plmheader == doors[i].PLMb.ID) { sideBgroup = "A"; }
                }
                foreach (uint plmheader in headersB)
                {
                    if (plmheader == doors[i].PLMa.ID) { sideAgroup = "B"; }
                    if (plmheader == doors[i].PLMb.ID) { sideBgroup = "B"; }
                }
                foreach (uint plmheader in headersC)
                {
                    if (plmheader == doors[i].PLMa.ID) { sideAgroup = "C"; }
                    if (plmheader == doors[i].PLMb.ID) { sideBgroup = "C"; }
                }
                DoorLink A = doors[i];
                A.GroupA = sideAgroup;
                A.GroupB = sideBgroup;
                A = KeepHighByte(A);
                doors[i] = A;
            }
            return doors;
        }

        private void Execute_DoorID()
        {
            //boths halves get the same ID if the link is double sided and they're in the same door group
            //  Else, each half gets a different ID.

            //if i wanted this to work for differing door IDs in non-default states, GetMDBdoorLinks could take the desired states as a parameter... all it would change are the PLM sets it looks at.
            //as-is, doors can be REMOVED in higher room states, but not added.

            List<DoorLink> globalDoorLinks = Source.GetMDBdoorLinks();
            globalDoorLinks = AssignDoorGroups(globalDoorLinks);
            uint countID = 0;
            AssignIDsByGroup(globalDoorLinks, "A", countID, out countID);
            AssignIDsByGroup(globalDoorLinks, "B", countID, out countID);
            AssignIDsByGroup(globalDoorLinks, "C", countID, out countID);
            foreach (DoorLink item in globalDoorLinks)
            {
                Source.sm.Rom = WriteDoorLinkToROM(Source.sm, item);
                if(Source.sm.Rom == null) { Source.Close(); return; }   //this error handling is bad but it should never happen?? Just in case....
            }
            File.WriteAllBytes(Source.sm.Path, Source.sm.Rom);
            Source.AppendStatus(countID-1 + " door IDs written to ROM");
            DialogResult export = MessageBox.Show("Doors Assigned. Export MDB to ASM?", "Export to ASM?", MessageBoxButtons.YesNo);
            if(export == DialogResult.Yes)
            {
                this.Enabled = false;
                Source.ExportMdbForItemsDoors();
                this.Enabled = true;
            }
            return;
        }

        private byte[] WriteDoorLinkToROM(ROM rom, DoorLink door)
        {
            //goto room header -> PLM pointer -> PLM index * 6 -> +4 and write the variable for each door side.
            if(door.LinkPLMs == LinkPLMS.None) { return rom.Rom; }
            roomdata roomA = new roomdata(rom, door.HeaderA + 0x70000);
            roomdata roomB = new roomdata(rom, door.HeaderB + 0x70000);
            long ptrVariableA = (long)(roomA.States[roomA.StateCount].pPLMset + (door.PlmIndexA * 6) + 4 + 0x70000);
            long ptrVariableB = (long)(roomB.States[roomB.StateCount].pPLMset + (door.PlmIndexB * 6) + 4 + 0x70000);
            byte aLo = (byte)door.PLMa.Variable;
            byte aHi = (byte)(door.PLMa.Variable / 0x100);
            byte bLo = (byte)door.PLMb.Variable;
            byte bHi = (byte)(door.PLMb.Variable / 0x100);
            if (door.KeepHiByteA) { aHi = rom.Rom[ptrVariableA + 1]; }
            if (door.KeepHiByteB) { bHi = rom.Rom[ptrVariableB + 1]; }
            //only write the value if the PLM exists (sidedness)
            //case none is handled at the top of this routine.
            switch (door.LinkPLMs)
            {
                case LinkPLMS.SideA:
                    rom.Rom[ptrVariableA + 0] = aLo;
                    rom.Rom[ptrVariableA + 1] = aHi;
                    break;
                case LinkPLMS.SideB:
                    rom.Rom[ptrVariableB + 0] = bLo;
                    rom.Rom[ptrVariableB + 1] = bHi;
                    break;
                case LinkPLMS.DoubleSided:
                    rom.Rom[ptrVariableA + 0] = aLo;
                    rom.Rom[ptrVariableA + 1] = aHi;
                    rom.Rom[ptrVariableB + 0] = bLo;
                    rom.Rom[ptrVariableB + 1] = bHi;
                    break;
                default:
                    MessageBox.Show("Unassigned door sidedness!\nSee function WriteDoorLinkToROM() of SpecialDoorID.cs" +
                        "\nThis may have happened due to an invalid level header in the MDB.",
                        "Door Linking Error", MessageBoxButtons.OK);
                    return null;
            }
            return rom.Rom;
        }

        private List<DoorLink> AssignIDsByGroup(List<DoorLink> globalDoorLinks, string groupName, uint IDin, out uint IDout)
        {
            uint countID = IDin;
            for (int i = 0; i < globalDoorLinks.Count; i++)
            {
                if (globalDoorLinks[i].LinkPLMs == LinkPLMS.None) { continue; }
                DoorLink door = globalDoorLinks[i];
                PLMdata plmA = door.PLMa;
                PLMdata plmB = door.PLMb;

                //its ok to assign to both because even if plm A or B isn't there, having the ID in some garbage won't matter.
                //will used the LinkPLMs sidedness when deciding which plms to write to the ASM.
                bool assigned = false;
                if (globalDoorLinks[i].GroupA == groupName) { plmA.Variable = countID; assigned = true; }
                if (globalDoorLinks[i].GroupB == groupName) { plmB.Variable = countID; assigned = true; }
                if (assigned) { countID++; }

                door.PLMa = plmA;
                door.PLMb = plmB;
                globalDoorLinks[i] = door;
            }
            IDout = countID;
            return globalDoorLinks;
        }
        private DoorLink KeepHighByte(DoorLink doorLink)
        {
            //make element TRUE if door group has its box checked.
            if (doorLink.GroupA == "A" && KeepHiByteA.Checked) { doorLink.KeepHiByteA = true; }
            if (doorLink.GroupA == "B" && KeepHiByteB.Checked) { doorLink.KeepHiByteA = true; }
            if (doorLink.GroupA == "C" && KeepHiByteC.Checked) { doorLink.KeepHiByteA = true; }

            if (doorLink.GroupB == "A" && KeepHiByteA.Checked) { doorLink.KeepHiByteB = true; }
            if (doorLink.GroupB == "B" && KeepHiByteB.Checked) { doorLink.KeepHiByteB = true; }
            if (doorLink.GroupB == "C" && KeepHiByteC.Checked) { doorLink.KeepHiByteB = true; }
            return doorLink;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if(DoorList.Items.Count > 0) { MessageBox.Show("Assign all doors to a group before AutoID.", "Unassigned Doors", MessageBoxButtons.OK); return; }
            Execute_DoorID();
            this.Close();
        }

        private void MoveToA_Click(object sender, EventArgs e)
        {
            MoveToGroup(DoorList, DoorsA);
        }

        private void MoveToB_Click(object sender, EventArgs e)
        {
            MoveToGroup(DoorList, DoorsB);
        }

        private void MoveToC_Click(object sender, EventArgs e)
        {
            MoveToGroup(DoorList, DoorsC);
        }

        private void RtnFromA_Click(object sender, EventArgs e)
        {
            MoveToGroup(DoorsA, DoorList);
        }

        private void RtnFromB_Click(object sender, EventArgs e)
        {
            MoveToGroup(DoorsB, DoorList);
        }

        private void RtnFromC_Click(object sender, EventArgs e)
        {
            MoveToGroup(DoorsC, DoorList);
        }

        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "LIMITATIONS:\n" +
                "Doors must be in plmlist.txt" +
                "Must have the same PLM index in all roomstates."
                ,"Help:",MessageBoxButtons.OK);
        }
    }
}
