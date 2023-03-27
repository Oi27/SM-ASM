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
    public partial class Bar : Form
    {
        public int doneMax { get; set; }
        public Bar(string topLabel, string bottomLabel, int maxSize)
        {
            InitializeComponent();
            DoneMeterLabel.Text = topLabel;
            DoneMeterDesc.Text = bottomLabel;
            doneMax = maxSize;

            DoneMeter.Maximum = maxSize;
        }

        public void AddToBar(int value)
        {
            DoneMeter.Value += value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
