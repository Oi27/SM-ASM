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
using System.Globalization;
using System.Diagnostics;

namespace SM_ASM_GUI
{
    public partial class SpecialItemID : Form
    {
        public SMASM Source { get; set; }
        public SpecialItemID(SMASM source)
        {
            //initializes PLM list with all the "items" in plmlist.txt
            InitializeComponent();
            Source = source;
            List<string> itemPLMs = source.ListPLMsByMapShape("item");
            PlmList.Items.Clear();
            foreach (string plm in itemPLMs)
            {
                PlmList.Items.Add(plm);
            }
        }

        #region ID_Functions
        private void startButton_click(object sender, EventArgs e)
        {
            Execute_ItemID();
            this.Close();
        }
        private void Execute_ItemID()
        {
            //Get lists of every PLM & enemy that will recieve an ID
            //ID plms first & enemies second
            //the enemyVariableOffset is the position in enemy data to write to.
            uint plmVariableOffset = 4;
            uint enemyVariableOffset = 0;
            if (this.IdTilemap.Checked) { enemyVariableOffset = 3 * 2; }
            if (this.IdSpeed1.Checked) { enemyVariableOffset = 6 * 2; }
            if (this.IdSpeed2.Checked) { enemyVariableOffset = 7 * 2; }
            List<PLM4ID> PLMs = GetMDBplms4id();
            List<Enemy4ID> enemies = GetMDBenemies4id();
            int idCount = 0;
            for (int i = 0; i < PLMs.Count; i++)
            {
                PLM4ID A = PLMs[i];
                A.ID = idCount;
                PLMs[i] = A;
                idCount++;
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy4ID A = enemies[i];
                A.ID = idCount;
                enemies[i] = A;
                idCount++;
            }
            //if there was any additional processing that needed done, it would go here.
            //these void functions modify Source.sm.rom directly.
            foreach (PLM4ID plm in PLMs)
            {
                WriteItemID2ROM(plm, plmVariableOffset);
            }
            foreach (Enemy4ID enemy in enemies)
            {
                WriteItemID2ROM(enemy,enemyVariableOffset);
            }
            File.WriteAllBytes(Source.sm.Path, Source.sm.Rom);
            Source.AppendStatus(idCount - 1 + " item IDs written to ROM");
            DialogResult export = MessageBox.Show("Items Assigned. Export MDB to ASM?", "Export to ASM?", MessageBoxButtons.YesNo);
            if (export == DialogResult.Yes)
            {
                this.Enabled = false;
                Source.ExportMdbForItemsDoors();
                this.Enabled = true;
            }
        }
        private void WriteItemID2ROM(PLM4ID plm, uint variableOffset)
        {
            //locate beginning of data using bank, pointer, and index
            uint bank = 0x70000;
            uint dataSize = 6;

            uint pointer = (uint)
                (bank + plm.SetPointer + 
                dataSize * plm.PLM.Index + 
                variableOffset);

            byte aLo = (byte)plm.ID;
            byte aHi = (byte)(plm.ID / 0x100);

            Source.sm.Rom[pointer] = aLo;
            Source.sm.Rom[pointer+1] = aHi;
        }
        private void WriteItemID2ROM(Enemy4ID enemy, uint variableOffset)
        {
            uint bank = 0x100000;   //bank $A1 in PC.
            uint dataSize = 0x10;

            uint pointer = (uint)
                (bank + enemy.SetPointer +
                dataSize * enemy.Enemy.Index +
                variableOffset);

            byte aLo = (byte)enemy.ID;
            byte aHi = (byte)(enemy.ID / 0x100);

            Source.sm.Rom[pointer] = aLo;
            Source.sm.Rom[pointer + 1] = aHi;
        }
        public List<Enemy4ID> GetMDBenemies4id()
        {
            string mdbPath = Source.getMDBpath(out bool mdbexists);
            if (!mdbexists) { MessageBox.Show("Could not find\n" + mdbPath, "File not Found", MessageBoxButtons.OK); Process.Start("explorer.exe", Path.GetDirectoryName(mdbPath)); return null; }
            List<string> mdb = File.ReadAllLines(mdbPath).ToList();

            List<Enemy4ID> idEnemies = new List<Enemy4ID>();
            foreach (string entry in mdb)
            {
                if (!uint.TryParse(entry.Substring(0, 5), NumberStyles.HexNumber, null, out uint headerAddr))
                {
                    //parse can fail in case of vanilla MDB file, where there are a bunch of blanks and area names.
                    continue;
                }
                roomdata check = new roomdata(Source.sm, headerAddr);
                if (check.States == null)
                {
                    //encountered invalid room so skip it
                    continue;
                }
                for (int i = 0; i < check.States[check.StateCount].Enemies.Count; i++)
                {
                    EnemyData A = check.States[check.StateCount].Enemies[i];
                    if (EnemyOnList(A.ID))
                    {
                        idEnemies.Add(new Enemy4ID(headerAddr, check.States[check.StateCount].pEnemySet, A));
                    }
                }
            }
            return idEnemies;
        }
        public List<PLM4ID> GetMDBplms4id()
        {
            string mdbPath = Source.getMDBpath(out bool mdbexists);
            if (!mdbexists) { MessageBox.Show("Could not find\n" + mdbPath, "File not Found", MessageBoxButtons.OK); Process.Start("explorer.exe", Path.GetDirectoryName(mdbPath)); return null; }
            List<string> mdb = File.ReadAllLines(mdbPath).ToList();

            List<PLM4ID> idPLMs = new List<PLM4ID>();
            foreach (string entry in mdb)
            {
                if(!uint.TryParse(entry.Substring(0, 5), NumberStyles.HexNumber, null, out uint headerAddr))
                {
                    //parse can fail in case of vanilla MDB file, where there are a bunch of blanks and area names.
                    continue;
                }
                roomdata check = new roomdata(Source.sm, headerAddr);
                if (check.States == null)
                {
                    //encountered invalid room so skip it
                    continue;
                }
                for (int i = 0; i < check.States[check.StateCount].PLMs.Count; i++)
                {
                    PLMdata A = check.States[check.StateCount].PLMs[i];
                    if (PLMonList(A.ID))
                    {
                        idPLMs.Add(new PLM4ID(headerAddr, check.States[check.StateCount].pPLMset,A));
                    }
                }
            }
            return idPLMs;
        }

        private bool PLMonList(uint plmID)
        {
            foreach (string plmheader in PlmList.Items)
            {
                uint header = uint.Parse(plmheader.Substring(0, 4), NumberStyles.HexNumber);
                if(header == plmID) { return true; }
            }
            return false;
        }
        private bool EnemyOnList(uint enemyID)
        {
            foreach (string enemyHeader in EnemyList.Items)
            {
                uint header = uint.Parse(enemyHeader.Substring(0, 4), NumberStyles.HexNumber);
                if (header == enemyID) { return true; }
            }
            return false;
        }

        public struct PLM4ID
        {
            public PLM4ID(uint roomHeader, uint setPointer, PLMdata plm)
            {
                Room = roomHeader;
                SetPointer = setPointer;
                PLM = plm;
                ID = -1;
            }
            public int ID { set; get; }
            public uint Room { set; get; }
            public uint SetPointer { set; get; }
            public PLMdata PLM { set; get; }   
        }
        public struct Enemy4ID
        {
            public Enemy4ID(uint roomHeader, uint setPointer, EnemyData enemy)
            {
                Room = roomHeader;
                SetPointer = setPointer;
                Enemy = enemy;
                ID = -1;
            }
            public int ID { set; get; }
            public uint Room { get; set; }
            public uint SetPointer { set; get; }
            public EnemyData Enemy { get; set; }
        }
        #endregion

        #region RightClickMenu
        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListBox B = (ListBox)ListBoxRightClick.SourceControl;
            ObjectPicker A = new ObjectPicker(Source, B);
            uint[] n;

            A.ShowDialog();
            n = A.Results();
            A.Close();
            if (n == null) { return; }
            B.Items.Add(asmFCN.WWord(n[0]));
            Source.SortByPLMheader(B);
        }

        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //uuuggh couldn't get this to work for now >_<;

            //has to convert selectedindices into a more sane thing to work with xwx
            //the selected indices are always in ascending order.
            ListBox B = (ListBox)ListBoxRightClick.SourceControl;
            if(B.SelectedIndices.Count == 0) { return; }
            List<int> selectedIndices = new List<int>();
            foreach (int index in B.SelectedIndices)
            {
                B.Items.RemoveAt(index);
            }

        }
        #endregion

    }
}
