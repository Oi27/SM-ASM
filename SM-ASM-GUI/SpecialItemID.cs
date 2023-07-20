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
            List<PLM4ID> PLMs = GetMDBplms4id();
            List<Enemy4ID> enemies = GetMDBenemies4id();
            Console.WriteLine("A");
        }
        public List<Enemy4ID> GetMDBenemies4id()
        {
            string mdbPath = Source.getMDBpath(out bool mdbexists);
            if (!mdbexists) { MessageBox.Show("Could not find\n" + mdbPath, "File not Found", MessageBoxButtons.OK); Process.Start("explorer.exe", Path.GetDirectoryName(mdbPath)); return null; }
            List<string> mdb = File.ReadAllLines(mdbPath).ToList();

            List<Enemy4ID> idEnemies = new List<Enemy4ID>();
            foreach (string entry in mdb)
            {
                uint headerAddr = uint.Parse(entry.Substring(0, 5), NumberStyles.HexNumber);
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
                        idEnemies.Add(new Enemy4ID(headerAddr, A));
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
                uint headerAddr = uint.Parse(entry.Substring(0, 5), NumberStyles.HexNumber);
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
                        idPLMs.Add(new PLM4ID(headerAddr, A));
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
            public PLM4ID(uint roomHeader, PLMdata plm)
            {
                Room = roomHeader;
                PLM = plm;
            }
            public uint Room { set; get; }
            public PLMdata PLM { set; get; }   
        }
        public struct Enemy4ID
        {
            public Enemy4ID(uint roomHeader, EnemyData enemy)
            {
                Room = roomHeader;
                Enemy = enemy;
            }
            public uint Room { get; set; }
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
