using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SM_ASM_GUI
{
    public partial class AddStateDialog : Form
    {
        public bool[] Uniques { get; set; }
        public bool CreateNewState = false;
        //on close: returns an array for the uniqueness checkboxes
        //          and a bool for creating a new state or not.
        //          this CreateNewState is needed so using the X to
        //          close the window can run different code in the
        //          parent form than closing it in State-Creating ways.
        public AddStateDialog()
        {
            InitializeComponent();
        }

        private void AddStateDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
            {
                SaveBools();
                this.Close(); 
            }
        }

        private void AddStateDialog_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) 
            {
                SaveBools();
                this.Close(); 
            }
        }

        private void SaveBools()
        {
            CreateNewState = true;
            bool[] Uni = new bool[6];
            Uni[0] = LevelCheckBox.Checked;
            Uni[1] = FXCheckBox.Checked;
            Uni[2] = ScrollCheckBox.Checked;
            Uni[3] = PLMCheckBox.Checked;
            Uni[4] = EnemySetCheckBox.Checked;
            Uni[5] = EnemyGFXCheckBox.Checked;
            this.Uniques = Uni;
        }


    }
}
