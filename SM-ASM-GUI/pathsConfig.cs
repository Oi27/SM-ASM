using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SM_ASM_GUI
{
    public partial class pathsConfig : Form
    {
        SMASM parent;
        XmlDocument configs;
        public pathsConfig(XmlDocument config)
        {
            configs = config;
            InitializeComponent();
            romBox.Text = configs.ChildNodes[1].SelectSingleNode("ROM").InnerText;
            asmBox.Text = configs.ChildNodes[1].SelectSingleNode("ASM").InnerText;
            ASARbox.Text = configs.ChildNodes[1].SelectSingleNode("ASR").InnerText;
            SMILEbox.Text = configs.ChildNodes[1].SelectSingleNode("SMILEFILE").InnerText;
            romBox.SelectionStart = romBox.Text.Length;
            asmBox.SelectionStart = asmBox.Text.Length;
            ASARbox.SelectionStart = ASARbox.Text.Length;
            SMILEbox.SelectionStart = SMILEbox.Text.Length;
        }


        private void pickasmButton_Click(object sender, EventArgs e)
        {
            pathpicker(sender, e, asmBox);
        }

        private void pickromButton_Click(object sender, EventArgs e)
        {
            pathpicker(sender, e, romBox);
        }
        private void PickAsarButton_Click(object sender, EventArgs e)
        {
            pathpicker(sender, e, ASARbox);
        }

        private void pathpicker(object sender, EventArgs e, TextBox dest)
        {
            Button foo = (Button)sender;
            this.parent = new SMASM();
            parent.openFilemenu(sender, e);
            //button tag is populated with file path.
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
            configs.Save(DbLocation + "config.xml");
            this.Close();
        }

        private void PickSmileButton_Click(object sender, EventArgs e)
        {
            folderpicker(sender, e, SMILEbox);
        }
    }
}
