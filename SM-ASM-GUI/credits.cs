﻿using System;
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
    public partial class credits : Form
    {
        public credits()
        {
            InitializeComponent();
            VersionLabel.Text = "Version " + Application.ProductVersion;
        }

        private void credits_Load(object sender, EventArgs e)
        {

        }
    }
}
