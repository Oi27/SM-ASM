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
    public partial class ScrollEditor : Form
    {
        //overlayFolder must contain all the scroll pictures, named 0.png, 1.png, 2.png
        public string overlayFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
        MouseButtons LastUsed = MouseButtons.None;

        public enum Mode
        {
            Normal = 0,
            PLM = 1
        }

        public ScrollEditor(roomdata room, int state, int scale, Mode mode, SMASM parent)
        {
            InitializeComponent();

            EditMode = mode;
            Room = room;
            StateNumber = state;
            Scaler = scale;
            SelectedPLM = -1;
            this.Size = new Size(0,0);
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.AutoSize = true;
            Bitmap map = parent.LevelData2Bitmap(room, state);
            LevelPicture.Image = map;
            LevelPicture.SizeMode = PictureBoxSizeMode.Zoom;
            LevelPicture.Size = new Size(map.Width*scale, map.Height*scale);

            if (room.States[state].pScrolls < 0x8000)
            {
                MessageBox.Show("This room uses library scrolls.\nFix this in the main editor and try again.", "No Scroll Data", MessageBoxButtons.OK);
                this.Close();
                return;
            }

            PopulateRoomScrolls();
            //if in scroll editor mode, then it needs to do additional things.
            //-Add list of scroll PLMs
            //-pick them from listbox to edit their data
                //-when picked, clear all scroll related pictureboxes and repopulate them
            if(mode == Mode.Normal) { return; }
            ListBox scrollSelector = new ListBox
            {
                Location = new Point(this.Size.Width, 10),
                Width = 75,
                Height = 100,
                SelectionMode = SelectionMode.One,
                Visible = true,
                Name = "scrollSelector"
            };
            scrollSelector.SelectedIndexChanged += ScrollSelector_SelectedIndexChanged;
            this.Controls.Add(scrollSelector);
            this.PerformAutoScale();
            for (int k = 0; k < room.States[state].PLMs.Count; k++)
            {
                PLMdata plm = room.States[state].PLMs[k];
                if (plm.ScrollData != null) { scrollSelector.Items.Add(asmFCN.WWord(plm.ID) + "-" + asmFCN.WByte((uint)k)); }
            }
            if(scrollSelector.Items.Count == 0)
            {
                MessageBox.Show("This room does not contain any scroll PLMs!\nAdd at least one and try again.", "No Scroll PLMs!", MessageBoxButtons.OK);
                this.Close();
                return;
            }

        }

        private void ScrollSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox A = (ListBox)sender;
            SelectedPLM = int.Parse(A.SelectedItem.ToString().Split('-')[1],System.Globalization.NumberStyles.HexNumber);
            PopulateRoomScrolls(SelectedPLM);
        }

        private void PopulateRoomScrolls(int plmIndex = -1)
        {
            //clear the whole level box and repopulate all the scrolls, but spawn the plm boxes as well.
            //default value -1 indicates normal mode
            LevelPicture.Controls.Clear();
            uint[] scrollsDisplay = Room.States[StateNumber].Scrolls;
            PictureBox test, plmScroll = null;
            for (int i = 0; i < Room.Height; i++)
            {
                for (int j = 0; j < Room.Width; j++)
                {
                    int scrollNumber = (i * (int)Room.Width) + j;
                    uint scrollColor = scrollsDisplay[scrollNumber];
                    string colorPath = overlayFolder + scrollColor.ToString() + ".png";
                    int plmDataScrollColor = -1;
                    if (plmIndex > -1)
                    {
                        //if editing PLM, check if this scroll needs a color
                        //-read the byte array to see if this screen is being changed.
                        plmDataScrollColor = GetPLMscrollColor(plmIndex, scrollNumber);
                    }

                    string plmOverlayPath = overlayFolder + "s" + plmDataScrollColor.ToString() + ".png";
                    test = new PictureBox
                    {
                        Tag = scrollNumber.ToString(),
                        Image = new Bitmap(colorPath),
                        BackColor = Color.Transparent,
                        Size = new Size(16 * Scaler, 16 * Scaler),
                        Location = new Point(j * 16 * Scaler, i * 16 * Scaler),
                        Visible = true,
                        SizeMode = PictureBoxSizeMode.Zoom,
                    };

                    if (EditMode == Mode.PLM)
                    {
                        plmScroll = new PictureBox
                        {
                            Tag = scrollNumber.ToString(),
                            BackColor = Color.Transparent,
                            Size = new Size(16 * Scaler, 16 * Scaler),
                            Location = new Point(0,0),
                            Visible = true,
                            SizeMode = PictureBoxSizeMode.Zoom,
                        };
                        if(plmDataScrollColor > -1)
                        {
                            plmScroll.Image = new Bitmap(plmOverlayPath);
                        }
                    }


                    //these should only have click events if editing room scrolls.
                    if (EditMode == Mode.Normal)
                    {
                        test.MouseUp += LevelScrollClickUp;
                        test.MouseDown += ShortcutClickDown;
                    }
                    else
                    {
                        plmScroll.MouseUp += PlmScroll_MouseUp;
                        plmScroll.MouseDown += ShortcutClickDown;
                    }

                    LevelPicture.Controls.Add(test);

                    if(EditMode == Mode.PLM)
                    {
                        test.Controls.Add(plmScroll);
                        plmScroll.BringToFront();

                    }
                    
                }
            }
        }

        private void PlmScroll_MouseUp(object sender, MouseEventArgs e)
        {
            //change the scroll data for the screen you clicked on
            PictureBox A = (PictureBox)sender;
            ShortcutClickUp(sender, e);
            if(SelectedPLM == -1) { return; }

            PLMdata scrollPlm = Room.States[StateNumber].PLMs[SelectedPLM];
            int scrollNumber = int.Parse(A.Tag.ToString());
            int currentColor = GetPLMscrollColor(SelectedPLM, scrollNumber);

            int newColor;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    newColor = currentColor + 1;
                    if (newColor > 2)
                    {
                        newColor = -1;
                    }
                    break;
                case MouseButtons.Right:
                    newColor = currentColor - 1;
                    if (newColor < -1)
                    {
                        newColor = 2;
                    }
                    break;
                default:
                    //only right and left click should do anything.
                    return;
            }
            string colorPath = overlayFolder + "s" + newColor.ToString() + ".png";
            if(newColor == -1)
            {
                //get rid of the image and remove this screen from the scroll data array
                A.Image = new Bitmap(1,1);
                scrollPlm = RemoveScrollData(scrollPlm, scrollNumber);
            }
            else
            {
                //newcolor is a valid scroll, so change the data.
                if (ExistsInPLMdata(scrollPlm, scrollNumber))
                {
                    scrollPlm = ChangePLMscroll(scrollPlm, scrollNumber, (byte)newColor);
                }
                else
                {
                    scrollPlm = AddNewPLMscroll(scrollPlm, scrollNumber, (byte)newColor);
                }
                A.Image = new Bitmap(colorPath);
            }
            Room.States[StateNumber].PLMs[SelectedPLM] = scrollPlm;
            return;
        }

        private PLMdata AddNewPLMscroll(PLMdata scrollPlm, int scrollNumber, byte newcolor)
        {
            //add it to the end of the list
            List<byte> scrollData = scrollPlm.ScrollData.ToList();
            scrollData.RemoveAt(scrollData.Count-1);
            scrollData.Add((byte)scrollNumber);
            scrollData.Add(newcolor);
            scrollData.Add(0x80);
            scrollPlm.ScrollData = scrollData.ToArray();
            return scrollPlm;
        }

        private PLMdata ChangePLMscroll(PLMdata scrollPlm, int scrollNumber, byte newcolor)
        {
            List<byte> scrollData = scrollPlm.ScrollData.ToList();
            for (int i = 0; i < scrollData.Count; i += 2)
            {
                if (scrollData[i] == scrollNumber)
                {
                    scrollData[i+1] = newcolor;
                    break;
                }
            }
            scrollPlm.ScrollData = scrollData.ToArray();
            return scrollPlm;
        }

        private PLMdata RemoveScrollData(PLMdata scrollPlm, int scrollNumber)
        {
            //search scroll data for this screen and remove it if found
            //else, do nothing (this might need changed later)
            List<byte> scrollData = scrollPlm.ScrollData.ToList();
            for (int i = 0; i < scrollData.Count; i += 2)
            {
                if(scrollData[i] == scrollNumber) 
                { 
                    scrollData.RemoveRange(i,2); 
                    break; 
                }
            }
            scrollPlm.ScrollData = scrollData.ToArray();
            return scrollPlm;
        }

        private bool ExistsInPLMdata(PLMdata scrollPlm, int scrollNumber)
        {
            bool exists = false;
            List<byte> scrollData = scrollPlm.ScrollData.ToList();
            for (int i = 0; i < scrollData.Count; i += 2)
            {
                if (scrollData[i] == scrollNumber)
                {
                    exists = true;
                    break;
                }
            }
            return exists;
        }

        public roomdata Room { get; set; }
        public int StateNumber { get; set; }
        public int Scaler { get; set; }
        private int SelectedPLM { get; set; }
        public Mode EditMode { get; set; }

        public int GetPLMscrollColor(int plmIndex, int scrollNumber)
        {
            //check if this scroll number is in the PLM data and if so return its color
            PLMdata scrollPlm = Room.States[StateNumber].PLMs[plmIndex];
            int scrollColor = -1;
            for (int i = 0; i < scrollPlm.ScrollData.Length-1; i += 2)
            {
                if(scrollPlm.ScrollData[i] == scrollNumber)
                {
                    scrollColor = scrollPlm.ScrollData[i + 1];
                    break;
                }
            }
            return scrollColor;
        }

        public void ShortcutClickDown(object sender, MouseEventArgs e)
        {
            //if 2 mouse buttons pressed at once, exit scroll editor.
            if(LastUsed != MouseButtons.None) { this.Visible = false; }
            else
            {
                LastUsed = e.Button;
            }
        }

        public void ShortcutClickUp(object sender, MouseEventArgs e)
        {
            //clear the buffer for the mouse-close shortcut.
            LastUsed = MouseButtons.None;
        }

            public void LevelScrollClickUp(object sender, MouseEventArgs e)
        {
            ShortcutClickUp(sender, e);
            PictureBox A = (PictureBox)sender;
            int scrollNumber = int.Parse(A.Tag.ToString());
            int currentColor = (int)Room.States[StateNumber].Scrolls[scrollNumber];
            int newColor;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    newColor = currentColor + 1;
                    if (newColor > 2)
                    {
                        newColor = 0;
                    }
                    break;
                case MouseButtons.Right:
                    newColor = currentColor - 1;
                    if (newColor < 0)
                    {
                        newColor = 2;
                    }
                    break;
                default:
                    //only right and left click should do anything.
                    return;
            }
            string colorPath = overlayFolder + "\\" + newColor.ToString() + ".png";
            A.Image = new Bitmap(colorPath);
            Room.States[StateNumber].Scrolls[scrollNumber] = (uint)newColor;
            return;
        }

        private void ScrollEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if closing from UI, hide it so that parent form can read data and close it later.
            if (this.Visible == true)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private void ScrollEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
