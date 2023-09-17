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
    public partial class newRoomSize : Form
    {
        public newRoomSize(SMASM source)
        {
            InitializeComponent();
            Source = source;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            RoomHeight = uint.Parse(HeightBox.Text, System.Globalization.NumberStyles.HexNumber);
            RoomWidth = uint.Parse(WidthBox.Text, System.Globalization.NumberStyles.HexNumber);
            this.Hide();
        }

        public uint RoomHeight { get; set; }
        public uint RoomWidth { set; get; }
        public SMASM Source { set; get; }

        private void AllowHexOnly(object sender, EventArgs e)
        {
            Source.AllowHexOnlyTEXTBOX(sender, e);
        }
    }
}
