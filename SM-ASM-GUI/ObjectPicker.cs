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
    public partial class ObjectPicker : Form
    {
        uint[] output;

        public ObjectPicker(SMASM P, ListBox S)
        {
            InitializeComponent();
            if (S.Name.StartsWith("P"))
            {
                Xpos.MaxLength = 2;
                Ypos.MaxLength = 2;
                Xpos.Text = "00";
                Ypos.Text = "00";
            }
            else if (S.Name.StartsWith("E"))
            {
                Xpos.MaxLength = 4;
                Ypos.MaxLength = 4;
                Xpos.Text = "0000";
                Ypos.Text = "0000";
            }
            else if (S.Name.StartsWith("G"))
            {
                DescLabel.Visible = false;

                Xpos.Visible = true ;
                Ypos.Visible = false;

                Xlabel.Visible = true;
                yLabel.Visible = false;

                Xlabel.Text = "Palette Index";
                Xpos.Text = "0000";

                Ypos.Text = "0000"; //dummy value for the GFX field.
            }
        }

        private void AddObject_Click(object sender, EventArgs e)
        {
            //we don't need to do validation here if we did it in the listboxes?
            //only requirement is that they are all valid uints.

            //Close the object picker and return an array.
            Bitmap myimage = new Bitmap("D:\\Downloads\\Varia_Suit_Upgrade_sm.gif");
            EnemyDisplay.Image = myimage;

            uint ID, X, Y;
            ID = uint.Parse(SearchBox.Text,System.Globalization.NumberStyles.HexNumber);
            X = uint.Parse(Xpos.Text, System.Globalization.NumberStyles.HexNumber);
            Y = uint.Parse(Ypos.Text, System.Globalization.NumberStyles.HexNumber);

            uint[] a = { ID, X, Y };
            output = a;
            this.Hide();
        }

        public uint[] Results()
        {
            return output;
        }
    }
}
