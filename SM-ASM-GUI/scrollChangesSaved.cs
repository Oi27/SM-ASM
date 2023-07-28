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
    public partial class scrollChangesSaved : Form
    {
        public SMASM Source { set; get; }
        public scrollChangesSaved(SMASM source)
        {
            InitializeComponent();
            Source = source;
            Point moveWindow = new Point
            {
                X = (Source.Location.X + Source.Width/2) - (this.Width / 2),
                Y = (Source.Location.Y + Source.Height/2) - (this.Height / 2)
            };
            this.Location = moveWindow;
        }

        private void scrollChangesSaved_Leave(object sender, EventArgs e)
        {
            this.Close();
            Source.Activate();
        }

        private void scrollChangesSaved_MouseDown(object sender, MouseEventArgs e)
        {
            scrollChangesSaved_Leave(sender, null);
        }
    }
}
