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
using System.Collections;

namespace SM_ASM_GUI
{
    public partial class LevelDataFromBmp : Form
    {
        public roomdata Room { set; get; }
        public byte[] ImageHex { set; get; }
        public Bitmap LevelImage { set; get; }
        public SMASM Source { set; get; }

        public LevelDataFromBmp(SMASM source)
        {
            InitializeComponent();
            Source = source;
            LevelImage = null;
            FillerGraphic.Tag = FillerGraphic.Text;
        }

        public roomdata RoomFromBitmap(Bitmap image, ushort whitePixelLevelData, ushort blackPixelLevelData)
        {
            uint graphicUint = uint.Parse(FillerGraphic.Text, System.Globalization.NumberStyles.HexNumber);

            byte[] tileWhite = Word2Bytes(whitePixelLevelData);
            byte[] tileBlack = Word2Bytes(blackPixelLevelData);

            uint bmpWidth =  (uint)image.Width;
            uint bmpHeight = (uint)image.Height;
            if ((short)bmpHeight < 0)
            {
                int fix = Math.Abs((short)bmpHeight);
                bmpHeight = (uint)fix;
            }
            roomdata newRoom = Source.CreateEmptyRoom(bmpWidth / 16, bmpHeight / 16);
            byte[] levelData = newRoom.States[newRoom.StateCount].LevelDataUC;
            uint levelIndex = 2;
            for (int i = 0; i < newRoom.Height * 16; i++)
            {
                for (int j = 0; j < newRoom.Width * 16; j++)
                {
                    Color pixel = image.GetPixel(j, i);
                    bool isWhite = (pixel.R & pixel.G & pixel.B) == 0xFF;
                    if (isWhite)
                    {
                        levelData[levelIndex] = tileWhite[0];
                        levelData[levelIndex + 1] = tileWhite[1];
                    }
                    else
                    {
                        levelData[levelIndex] = tileBlack[0];
                        levelData[levelIndex + 1] = tileBlack[1];
                    }
                    levelIndex += 2;
                }
            }
            //recompress the level data
            state A = newRoom.States[newRoom.StateCount];
            A.LevelDataUC = levelData;
            A.LevelDataC = Source.CompressLevelData(levelData, out uint compSize);
            A.LevelDataSizeC = compSize;
            newRoom.States[newRoom.StateCount] = A;
            return newRoom;
        }

        public byte[] Word2Bytes(ushort word)
        {
            byte[] bytes = new byte[2];
            bytes[0] = (byte)word;
            bytes[1] = (byte)(word >> 8);
            return bytes;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            //this converts the 1Bpp LevelImage into level data
            //Generate blank room with matching dimensions
            if(LevelImage == null) { return; }
            ushort graphicUint = (ushort)((ushort)0xC000 | ushort.Parse(FillerGraphic.Text, System.Globalization.NumberStyles.HexNumber));
            Room = RoomFromBitmap(LevelImage, graphicUint, (ushort)0x80FF);
            this.Hide();
            return;
        }

        private void BmpPicker_Click(object sender, EventArgs e)
        {
            //summon file picker & validate picked file
            string bmpPath = Source.FilePicker(4, out DialogResult buttonPressed, "Choose 1bpp BMP");
            if(buttonPressed == DialogResult.Cancel) { return; }
            byte[] bmpHex = File.ReadAllBytes(bmpPath);
            uint bmpWidth = ROM.readWord(0x12, bmpHex);
            int bmpHeight = (int)ROM.readWord(0x16, bmpHex);
            uint bmpDepth = ROM.readWord(0x1C, bmpHex);
            if(bmpDepth != 1)
            {
                MessageBox.Show("Selected BMP color depth is not 1bpp.\n Aborting read operation.", "Bad Color Depth", MessageBoxButtons.OK);
                return;
            }
            bool dimensionsMultipleOf16 = ((bmpWidth & 0xF) == 0) && ((bmpHeight & 0xF) == 0);
            if (!dimensionsMultipleOf16)
            {
                MessageBox.Show("Image dimensions are not multiples of 16.\n Aborting read operation.", "Bad Image Size", MessageBoxButtons.OK);
                return;
            }
            //bool dimensionsWithinSizeLimit = ((bmpWidth < 0x100)) && ((bmpHeight < 0x100));
            //if (!dimensionsWithinSizeLimit)
            //{
            //    MessageBox.Show("BMP is too large.\nMax size is 256x256px though such a room would exceed the SM engine limit of 50 screens.\n Aborting read operation.", "Bad Image Size", MessageBoxButtons.OK);
            //    return;
            //}
            LevelImage = (Bitmap)Bitmap.FromFile(bmpPath);
            ImagePreview.Image = Bitmap.FromFile(bmpPath);
            ImageHex = bmpHex;
            DoneButton.Enabled = true;
            return;
        }

        private void FillerGraphic_TextChanged(object sender, EventArgs e)
        {
            Source.AllowHexOnlyTEXTBOX(sender, e);
        }

        private void FillerGraphic_Validated(object sender, EventArgs e)
        {
            //left pad the hex with zeros out to 3 places.
            while (FillerGraphic.Text.Length < 3)
            {
                FillerGraphic.Text = "0" + FillerGraphic.Text;
            }
        }
    }
}
