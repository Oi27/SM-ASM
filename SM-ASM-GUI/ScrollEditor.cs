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
            bool[] scrolldatafailures = new bool[room.States[state].PLMs.Count];
            for (int k = 0; k < room.States[state].PLMs.Count; k++)
            {
                PLMdata plm = room.States[state].PLMs[k];
                if (plm.ScrollData != null) 
                { 
                    //only add valid scroll plms to the editor box. Give opportunity to make invalid ones into valid ones.
                    if (BadScrollData(plm, out bool[] specifics))
                    {
                        const int tooManyScrolls = 0;
                        const int indexOutOfBounds = 1;

                        scrolldatafailures[k] = true;
                        if (specifics[tooManyScrolls])
                        {
                            //error message here
                        }
                        if (specifics[indexOutOfBounds])
                        {
                            //error message here
                        }
                        DialogResult A = MessageBox.Show("Reset PLM " + k + "'s scroll data to default values?", "Bad Scroll Data", MessageBoxButtons.YesNo);
                        if(A == DialogResult.Yes)
                        {
                            plm.ScrollData = new byte[] { 0, 0, 0x80 };
                            room.States[state].PLMs[k] = plm;
                            scrolldatafailures[k] = false;
                            scrollSelector.Items.Add(asmFCN.WWord(plm.ID) + "-" + asmFCN.WByte((uint)k));
                        }
                    }
                    else
                    {
                        scrollSelector.Items.Add(asmFCN.WWord(plm.ID) + "-" + asmFCN.WByte((uint)k));
                    }
                }
            }

            bool badScrollDataPresent = false;
            foreach (bool scrolldata in scrolldatafailures)
            {
                badScrollDataPresent |= scrolldata;
            }

            if (badScrollDataPresent)
            {
                MessageBox.Show("PLMs with bad scroll data will not be shown in list.", "Bad Scroll Data", MessageBoxButtons.OK);
            }

            if(scrollSelector.Items.Count == 0)
            {
                MessageBox.Show("This room does not contain any valid scroll PLMs!\nAdd at least one and try again.", "No Scroll PLMs!", MessageBoxButtons.OK);
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
                //SaveWindowTF();
                e.Cancel = true;
                this.Visible = false;
            }
        }


        private bool BadScrollData(PLMdata scrollPlm, out bool[] specifics)
        {
            //if plm scrolldata size is bigger than room scroll array throw an error & ask to reset the PLM.
            //do the same if any of the scroll change screens are outside the bounds of the room.
            //reminder that plm scrolldata is SS VV, SS VV, SS VV....
            //where SS is the screen to change and VV is what to change it to.
            
            uint roomSize = Room.Width * Room.Height;

            List<byte> plmChangeScreenNumbers = new List<byte>();
            for (int i = 0; i < scrollPlm.ScrollData.Length-1; i+=2)
            {
                plmChangeScreenNumbers.Add(scrollPlm.ScrollData[i]);
            }

            uint largestNumberInScrollChanges = plmChangeScreenNumbers.Max();

            bool tooManyScreens = plmChangeScreenNumbers.Count > roomSize;
            bool indexOutOfBounds = largestNumberInScrollChanges > roomSize;
            if (tooManyScreens)
            {
                //error here
            }
            if (indexOutOfBounds)
            {
                //error here
            }
            //fixing the scrolldata in the PLM can be handled outside this routine
            //and so should the error messages...
            specifics = new bool[] { tooManyScreens, indexOutOfBounds };
            return tooManyScreens || indexOutOfBounds;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void SaveWindowTF()
        {
            this.Controls.Clear();
            this.saveLabel1 = new System.Windows.Forms.Label();
            this.saveLabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.saveLabel1.AutoSize = true;
            this.saveLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.saveLabel1.Location = new System.Drawing.Point(10, 13);
            this.saveLabel1.Name = "label1";
            this.saveLabel1.Size = new System.Drawing.Size(213, 25);
            this.saveLabel1.TabIndex = 0;
            this.saveLabel1.Text = "Scroll Changes Saved.";
            // 
            // label2
            // 
            this.saveLabel2.AutoSize = true;
            this.saveLabel2.Location = new System.Drawing.Point(22, 38);
            this.saveLabel2.Name = "label2";
            this.saveLabel2.Size = new System.Drawing.Size(184, 17);
            this.saveLabel2.TabIndex = 1;
            this.saveLabel2.Text = "(click anywhere to continue)";
            // 
            // scrollChangesSaved
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 77);
            this.Controls.Add(this.saveLabel2);
            this.Controls.Add(this.saveLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "scrollChangesSaved";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "scrollChangesSaved";
            this.Leave += new System.EventHandler(this.scrollChangesSaved_Leave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrollChangesSaved_MouseDown);
            this.saveLabel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrollChangesSaved_MouseDown);
            this.saveLabel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrollChangesSaved_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void scrollChangesSaved_Leave(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void scrollChangesSaved_MouseDown(object sender, MouseEventArgs e)
        {
            this.Visible = false;
        }
        #endregion

        private System.Windows.Forms.Label saveLabel1;
        private System.Windows.Forms.Label saveLabel2;
    }
}
