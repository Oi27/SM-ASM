
namespace SM_ASM_GUI
{
    partial class ScrollEditor
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
            this.PLMlayer = new System.Windows.Forms.PictureBox();
            this.ScrollLayer = new System.Windows.Forms.PictureBox();
            this.LevelPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PLMlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // PLMlayer
            // 
            this.PLMlayer.BackColor = System.Drawing.Color.Transparent;
            this.PLMlayer.Location = new System.Drawing.Point(206, 126);
            this.PLMlayer.Name = "PLMlayer";
            this.PLMlayer.Size = new System.Drawing.Size(100, 50);
            this.PLMlayer.TabIndex = 2;
            this.PLMlayer.TabStop = false;
            this.PLMlayer.Visible = false;
            // 
            // ScrollLayer
            // 
            this.ScrollLayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ScrollLayer.Location = new System.Drawing.Point(174, 101);
            this.ScrollLayer.Name = "ScrollLayer";
            this.ScrollLayer.Size = new System.Drawing.Size(100, 50);
            this.ScrollLayer.TabIndex = 1;
            this.ScrollLayer.TabStop = false;
            this.ScrollLayer.Visible = false;
            // 
            // LevelPicture
            // 
            this.LevelPicture.Location = new System.Drawing.Point(0, 0);
            this.LevelPicture.Name = "LevelPicture";
            this.LevelPicture.Size = new System.Drawing.Size(100, 50);
            this.LevelPicture.TabIndex = 0;
            this.LevelPicture.TabStop = false;
            // 
            // ScrollEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 198);
            this.Controls.Add(this.PLMlayer);
            this.Controls.Add(this.ScrollLayer);
            this.Controls.Add(this.LevelPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ScrollEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScrollEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScrollEditor_FormClosing);
            this.Load += new System.EventHandler(this.ScrollEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PLMlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollLayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox LevelPicture;
        private System.Windows.Forms.PictureBox ScrollLayer;
        private System.Windows.Forms.PictureBox PLMlayer;
    }
}