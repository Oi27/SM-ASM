
namespace SM_ASM_GUI
{
    partial class Bar
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
            this.DoneMeter = new System.Windows.Forms.ProgressBar();
            this.DoneMeterLabel = new System.Windows.Forms.Label();
            this.DoneMeterDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DoneMeter
            // 
            this.DoneMeter.Location = new System.Drawing.Point(13, 24);
            this.DoneMeter.Name = "DoneMeter";
            this.DoneMeter.Size = new System.Drawing.Size(275, 23);
            this.DoneMeter.TabIndex = 0;
            // 
            // DoneMeterLabel
            // 
            this.DoneMeterLabel.AutoSize = true;
            this.DoneMeterLabel.Location = new System.Drawing.Point(12, 8);
            this.DoneMeterLabel.Name = "DoneMeterLabel";
            this.DoneMeterLabel.Size = new System.Drawing.Size(39, 13);
            this.DoneMeterLabel.TabIndex = 1;
            this.DoneMeterLabel.Text = "default";
            // 
            // DoneMeterDesc
            // 
            this.DoneMeterDesc.AutoSize = true;
            this.DoneMeterDesc.Location = new System.Drawing.Point(12, 53);
            this.DoneMeterDesc.Name = "DoneMeterDesc";
            this.DoneMeterDesc.Size = new System.Drawing.Size(39, 13);
            this.DoneMeterDesc.TabIndex = 2;
            this.DoneMeterDesc.Text = "default";
            // 
            // Bar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 75);
            this.Controls.Add(this.DoneMeterDesc);
            this.Controls.Add(this.DoneMeterLabel);
            this.Controls.Add(this.DoneMeter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Bar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Default";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar DoneMeter;
        private System.Windows.Forms.Label DoneMeterLabel;
        private System.Windows.Forms.Label DoneMeterDesc;
    }
}