using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Diagnostics;

namespace SM_ASM_GUI
{
    class SMILEfcn
    {
        //contains functions for referencing data from SMILE path
        //MDBLIST = Level Header MDB to List<string>
        //List<string> to level header list
        //ASAR output to MDB list format
        public static void MDBList(string mdbPath, out List<string>RoomAddr, out List<string>RoomNames)
        {
            if (!File.Exists(mdbPath))
            {
                RoomAddr = null;
                RoomNames = null;
                return;
            }
            List<MDBentry> MDBlist = new List<MDBentry>();

            List<string> zRoomAddr = new List<string>();
            List<string> zRoomNames = new List<string>();
            string[] mdb = File.ReadAllText(mdbPath).Replace("\r",string.Empty).Split('\n');
            //if the first 5 char in the line are hex then add it to the Addr and Name lists.
            for (int i = 0; i < mdb.Length; i++)
            {
                if(int.TryParse(mdb[i].Substring(0,5), NumberStyles.HexNumber, null, out int barse))
                {
                    zRoomAddr.Add(mdb[i].Substring(0, 5));
                    if(mdb[i].Length > 6)
                    {
                        zRoomNames.Add(mdb[i].Substring(6));
                    }
                    else
                    {
                        zRoomNames.Add("");
                    }
                }
            }
            RoomAddr = zRoomAddr;
            RoomNames = zRoomNames;
        }
        public static void ASARList(string ASARpcs, out List<string> RoomAddr, out List<string> RoomNames)
        {
            List<string> zRoomAddr = new List<string>();
            List<string> zRoomNames = new List<string>();
            string[] mdb = ASARpcs.Replace("\r", string.Empty).Replace("-"," ").Split('\n');
            //if the first 5 char in the line are hex then add it to the Addr and Name lists.
            //Also account for the empty string at the end of ASAR output.
            for (int i = 0; i < mdb.Length-1; i++)
            {
                if (uint.TryParse(mdb[i].Substring(0, 6), NumberStyles.HexNumber, null, out uint barse))
                {
                    zRoomAddr.Add(string.Format("{0:X5}", LUNAR.SNEStoPC(barse)));
                    if (mdb[i].Length > 7)
                    {
                        zRoomNames.Add(mdb[i].Substring(7));
                    }
                    else
                    {
                        zRoomNames.Add("");
                    }
                }
            }
            RoomAddr = zRoomAddr;
            RoomNames = zRoomNames;
        }
    }
}
