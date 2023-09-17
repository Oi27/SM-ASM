
namespace SM_ASM_GUI
{
    partial class LevelDataFromBmp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelDataFromBmp));
            this.DoneButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BmpPicker = new System.Windows.Forms.Button();
            this.FillerGraphic = new System.Windows.Forms.TextBox();
            this.ImagePreview = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Enabled = false;
            this.DoneButton.Location = new System.Drawing.Point(240, 112);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(91, 36);
            this.DoneButton.TabIndex = 0;
            this.DoneButton.Text = "Go!";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 106);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bitmap must be 1bit color depth and dimensions must \r\nbe multiples of 16.\r\n\r\nWhit" +
    "e pixels are replaced with air.\r\nBlack pixels are replaced with solids.";
            // 
            // BmpPicker
            // 
            this.BmpPicker.Location = new System.Drawing.Point(12, 96);
            this.BmpPicker.Name = "BmpPicker";
            this.BmpPicker.Size = new System.Drawing.Size(91, 52);
            this.BmpPicker.TabIndex = 2;
            this.BmpPicker.Text = "Pick BMP";
            this.BmpPicker.UseVisualStyleBackColor = true;
            this.BmpPicker.Click += new System.EventHandler(this.BmpPicker_Click);
            // 
            // FillerGraphic
            // 
            this.FillerGraphic.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FillerGraphic.Location = new System.Drawing.Point(109, 116);
            this.FillerGraphic.MaxLength = 3;
            this.FillerGraphic.Name = "FillerGraphic";
            this.FillerGraphic.Size = new System.Drawing.Size(61, 30);
            this.FillerGraphic.TabIndex = 3;
            this.FillerGraphic.Text = "0FF";
            this.FillerGraphic.TextChanged += new System.EventHandler(this.FillerGraphic_TextChanged);
            this.FillerGraphic.Validated += new System.EventHandler(this.FillerGraphic_Validated);
            // 
            // ImagePreview
            // 
            this.ImagePreview.InitialImage = null;
            this.ImagePreview.Location = new System.Drawing.Point(240, 21);
            this.ImagePreview.Name = "ImagePreview";
            this.ImagePreview.Size = new System.Drawing.Size(91, 85);
            this.ImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagePreview.TabIndex = 4;
            this.ImagePreview.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Graphic";
            // 
            // LevelDataFromBmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 160);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ImagePreview);
            this.Controls.Add(this.FillerGraphic);
            this.Controls.Add(this.BmpPicker);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LevelDataFromBmp";
            this.Text = "Level Data from BMP";
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BmpPicker;
        private System.Windows.Forms.TextBox FillerGraphic;
        private System.Windows.Forms.PictureBox ImagePreview;
        private System.Windows.Forms.Label label2;
    }
}