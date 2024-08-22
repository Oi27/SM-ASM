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
    public partial class DataListBox : ListBox
    {
        //the idea here is to directly link the listbox to the roomdata list so that generic functions can operate on the lists.
        //eg, I would like Delete to use the same code no matter if we Delete on PLM List, Enemy List, etc.
        //This is complicated! Giving up for now 8/20/24.
        public List<object> Link { set; get; }
        public DataListBox()
        {
            InitializeComponent();
        }
    }
}
