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
using System.Diagnostics;

namespace SM_ASM_GUI
{
    public partial class pathsConfig : Form
    {
        SMASM parent;
        XmlDocument configs;
        public pathsConfig(XmlDocument config, SMASM caller)
        {
            parent = caller;
            configs = config;
            InitializeComponent();
            romBox.Text = configs.ChildNodes[1].SelectSingleNode("ROM").InnerText;
            asmBox.Text = configs.ChildNodes[1].SelectSingleNode("ASM").InnerText;
            ASARbox.Text = configs.ChildNodes[1].SelectSingleNode("ASR").InnerText;
            SMILEbox.Text = configs.ChildNodes[1].SelectSingleNode("SMILEFILE").InnerText;
            TilesetBox.Text = configs.ChildNodes[1].SelectSingleNode("TILESETTABLE").InnerText;
            romBox.SelectionStart = romBox.Text.Length;
            asmBox.SelectionStart = asmBox.Text.Length;
            ASARbox.SelectionStart = ASARbox.Text.Length;
            SMILEbox.SelectionStart = SMILEbox.Text.Length;
            TilesetBox.SelectionStart = TilesetBox.Text.Length;

            TilesetBox.Tag = TilesetBox.Text; //used for rolling back changes if not hex number.
        }


        private void pickasmButton_Click(object sender, EventArgs e)
        {
            pathpicker(sender, e, asmBox, 1, "Choose ASM");
        }
        private void pickromButton_Click(object sender, EventArgs e)
        {
            pathpicker(sender, e, romBox, 2, "Choose ROM");
        }
        private void PickAsarButton_Click(object sender, EventArgs e)
        {
            pathpicker(sender, e, ASARbox, 3, "Choose ASAR");
        }

        private void pathpicker(object sender, EventArgs e, TextBox dest, int fileExt, string caption)
        {
            Button foo = (Button)sender;
            foo.Tag = parent.FilePicker(fileExt, out DialogResult buttonPressed, caption);
            if(buttonPressed == DialogResult.Cancel) { return; }
            //button tag is populated with file path.
            //reworking old code.... not sure if this tag thing is important later on but ??? why did i do this
            dest.Text = foo.Tag.ToString();
            dest.SelectionStart = dest.Text.Length;
        }
        private void folderpicker(object sender, EventArgs e, TextBox dest)
        {
            Button foo = (Button)sender;
            FolderBrowserDialog aa = new FolderBrowserDialog();
            if (aa.ShowDialog() == DialogResult.OK)
            {
                foo.Tag = aa.SelectedPath;
                dest.Text = foo.Tag.ToString();
                dest.SelectionStart = dest.Text.Length;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string DbLocation = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            configs.ChildNodes[1].SelectSingleNode("ROM").InnerText = romBox.Text;
            configs.ChildNodes[1].SelectSingleNode("ASM").InnerText = asmBox.Text;
            configs.ChildNodes[1].SelectSingleNode("ASR").InnerText = ASARbox.Text;
            configs.ChildNodes[1].SelectSingleNode("SMILEFILE").InnerText = SMILEbox.Text;
            configs.ChildNodes[1].SelectSingleNode("TILESETTABLE").InnerText = TilesetBox.Text;
            configs.Save(DbLocation + "config.xml");
            this.Close();
        }

        private void PickSmileButton_Click(object sender, EventArgs e)
        {
            folderpicker(sender, e, SMILEbox);
        }

        private void TilesetBox_TextChanged(object sender, EventArgs e)
        {
            parent.AllowHexOnlyTEXTBOX(sender, e);
        }

        private void OpenMdbFolder_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(SMILEbox.Text))
            {
                MessageBox.Show("SMILE folder not found.", "Invalid Path", MessageBoxButtons.OK);
                return;
            }
            if (!File.Exists(romBox.Text))
            {
                MessageBox.Show("Specified ROM does not exist.", "Invalid Path", MessageBoxButtons.OK);
                return;
            }
            //GetMdbPath creates the folder as well as returning a location.
            //string mdbPath = parent.getMDBpath(out bool mdbExists);
            string mdbFolder = SMILEbox.Text + "\\Custom\\" + Path.GetFileNameWithoutExtension(romBox.Text) + "\\Data\\";
            if (!Directory.Exists(mdbFolder))
            {
                Directory.CreateDirectory(mdbFolder);
            }
            Process winExp = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    Arguments = mdbFolder,
                    FileName = "explorer.exe"
                }
            };
            winExp.Start();
        }
    }
}
