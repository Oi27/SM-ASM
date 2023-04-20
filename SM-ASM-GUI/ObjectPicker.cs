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

namespace SM_ASM_GUI
{
    public partial class ObjectPicker : Form
    {
        //would be nice if this could auto-generate the vanilla enemy and PLM lists if none of them are found.
        uint[] output;
        string objListPath;
        List<string> objListContents;
        string exePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
        string SMILEimagesPath;

        public ObjectPicker(SMASM P, ListBox S)
        {
            InitializeComponent();
            //would handle generation of files right here
            //.
            //.
            //.
            //.
            if(P.SMILEfilesPath == "") { this.Close(); return; }
            if (S.Name.StartsWith("F")){ this.Close(); return; }
            if (S.Name.StartsWith("D")) { this.Close(); return; }

            if (S.Name.StartsWith("P"))
            {
                Xpos.MaxLength = 2;
                Ypos.MaxLength = 2;
                Xpos.Text = "00";
                Ypos.Text = "00";
                objListPath = exePath + "\\plmlist.txt";
                SMILEimagesPath = P.SMILEfilesPath + "\\PLM\\";
                this.Text = "Adding PLM";
            }
            else if (S.Name.StartsWith("E"))
            {
                Xpos.MaxLength = 4;
                Ypos.MaxLength = 4;
                Xpos.Text = "0000";
                Ypos.Text = "0000";
                objListPath = exePath + "\\enemylist.txt";
                SMILEimagesPath = P.SMILEfilesPath + "\\Enemies\\";
                this.Text = "Adding Enemy";
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
                objListPath = exePath + "\\enemylist.txt";
                SMILEimagesPath = P.SMILEfilesPath + "\\Enemies\\";
                this.Text = "Adding Enemy GFX";
            }
            objListContents = File.ReadAllLines(objListPath).ToList();
            PopulateObjList();
        }
        private void PopulateObjList(List<string> tags = null)
        {
            //call from textchange in search box after fixing the contents into comma delimited string list.
            //Entry format is HHHH,tag,tag,tag,tag...
            ObjectList.Items.Clear();
            foreach (var item in objListContents)
            {
                string[] entry = item.Split(',');
                if (tags == null)
                {
                    //EnemyDisplay.
                    this.ObjectList.Items.Add(entry[0]);
                    continue;
                }
                else
                {
                    //for each tag on that entry in the text file, check if it equals any of the given tags.
                    int matches = 0;
                    for (int i = 0; i < entry.Length; i++)
                    {
                        foreach (var tag in tags)
                        {
                            if(tag.ToUpper().Trim(' ') == entry[i].ToUpper().Trim(' '))
                            {
                                matches++;
                            }
                        }
                    }
                    if (matches == tags.Count) { this.ObjectList.Items.Add(entry[0]); }
                }
            }
            if(ObjectList.Items.Count == 0) 
            { ObjectList.Items.Add("No matches found!"); ObjectList.Enabled = false;}
            else
            {ObjectList.Enabled = true;}
        }

        private void AddObject_Click(object sender, EventArgs e)
        {
            //we don't need to do validation here if we did it in the listboxes?
            //only requirement is that they are all valid uints.

            //Close the object picker and return an array.
            uint ID, X, Y;
            if (ObjectList.SelectedIndex == -1 && uint.TryParse(SearchBox.Text, System.Globalization.NumberStyles.HexNumber, null,out uint barse)) 
            {
                ID = barse;
            }
            else if(ObjectList.SelectedIndex > -1)
            {
                ID = uint.Parse(ObjectList.SelectedItem.ToString(), System.Globalization.NumberStyles.HexNumber); ;
            }
            else
            {
                //there was no hex number in the search box AND nothing selected, so don't do anything.
                return;
            }

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

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if ENTER then negotitate the contents into a string list and pass to searchbox pop.
            if(e.KeyCode == Keys.Enter)
            {
                List<string> contents;
                if (SearchBox.Text == "") { contents = null; }
                else { contents = SearchBox.Text.Split(',').ToList(); }
                PopulateObjList(contents);
            }
        }
        private void ObjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //update the picture using the SMILE folder.
            string enemyHex = ObjectList.SelectedItem.ToString();
            try
            {
                Bitmap image = new Bitmap(SMILEimagesPath + enemyHex + ".gif");
                EnemyDisplay.Image = image;
            }
            catch
            {
                //show nothing
            }
        }

        private void ObjectPicker_FormClosed(object sender, FormClosedEventArgs e)
        {
            output = null;
        }
    }
}
