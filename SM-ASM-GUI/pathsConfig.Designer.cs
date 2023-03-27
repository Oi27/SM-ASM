
namespace SM_ASM_GUI
{
    partial class pathsConfig
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
            this.romBox = new System.Windows.Forms.TextBox();
            this.asmBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ASARbox = new System.Windows.Forms.TextBox();
            this.PickAsarButton = new System.Windows.Forms.Button();
            this.pickasmButton = new System.Windows.Forms.Button();
            this.pickromButton = new System.Windows.Forms.Button();
            this.PickSmileButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SMILEbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // romBox
            // 
            this.romBox.Location = new System.Drawing.Point(54, 24);
            this.romBox.Name = "romBox";
            this.romBox.Size = new System.Drawing.Size(357, 20);
            this.romBox.TabIndex = 0;
            // 
            // asmBox
            // 
            this.asmBox.Location = new System.Drawing.Point(54, 69);
            this.asmBox.Name = "asmBox";
            this.asmBox.Size = new System.Drawing.Size(357, 20);
            this.asmBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ROM path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ASM Path";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(30, 222);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(105, 37);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save and Close";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "ASAR Path";
            // 
            // ASARbox
            // 
            this.ASARbox.Location = new System.Drawing.Point(54, 110);
            this.ASARbox.Name = "ASARbox";
            this.ASARbox.Size = new System.Drawing.Size(357, 20);
            this.ASARbox.TabIndex = 7;
            // 
            // PickAsarButton
            // 
            this.PickAsarButton.Image = global::SM_ASM_GUI.Properties.Resources.Bitmap1;
            this.PickAsarButton.Location = new System.Drawing.Point(30, 110);
            this.PickAsarButton.Name = "PickAsarButton";
            this.PickAsarButton.Size = new System.Drawing.Size(24, 20);
            this.PickAsarButton.TabIndex = 9;
            this.PickAsarButton.UseVisualStyleBackColor = true;
            this.PickAsarButton.Click += new System.EventHandler(this.PickAsarButton_Click);
            // 
            // pickasmButton
            // 
            this.pickasmButton.Image = global::SM_ASM_GUI.Properties.Resources.Bitmap1;
            this.pickasmButton.Location = new System.Drawing.Point(30, 69);
            this.pickasmButton.Name = "pickasmButton";
            this.pickasmButton.Size = new System.Drawing.Size(24, 20);
            this.pickasmButton.TabIndex = 6;
            this.pickasmButton.UseVisualStyleBackColor = true;
            this.pickasmButton.Click += new System.EventHandler(this.pickasmButton_Click);
            // 
            // pickromButton
            // 
            this.pickromButton.Image = global::SM_ASM_GUI.Properties.Resources.Bitmap1;
            this.pickromButton.Location = new System.Drawing.Point(30, 24);
            this.pickromButton.Name = "pickromButton";
            this.pickromButton.Size = new System.Drawing.Size(24, 20);
            this.pickromButton.TabIndex = 5;
            this.pickromButton.UseVisualStyleBackColor = true;
            this.pickromButton.Click += new System.EventHandler(this.pickromButton_Click);
            // 
            // PickSmileButton
            // 
            this.PickSmileButton.Image = global::SM_ASM_GUI.Properties.Resources.Bitmap1;
            this.PickSmileButton.Location = new System.Drawing.Point(30, 151);
            this.PickSmileButton.Name = "PickSmileButton";
            this.PickSmileButton.Size = new System.Drawing.Size(24, 20);
            this.PickSmileButton.TabIndex = 12;
            this.PickSmileButton.UseVisualStyleBackColor = true;
            this.PickSmileButton.Click += new System.EventHandler(this.PickSmileButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "SMILE Files Folder";
            // 
            // SMILEbox
            // 
            this.SMILEbox.Location = new System.Drawing.Point(54, 151);
            this.SMILEbox.Name = "SMILEbox";
            this.SMILEbox.Size = new System.Drawing.Size(357, 20);
            this.SMILEbox.TabIndex = 10;
            // 
            // pathsConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 271);
            this.Controls.Add(this.PickSmileButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SMILEbox);
            this.Controls.Add(this.PickAsarButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ASARbox);
            this.Controls.Add(this.pickasmButton);
            this.Controls.Add(this.pickromButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.asmBox);
            this.Controls.Add(this.romBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "pathsConfig";
            this.Text = "File Paths";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox romBox;
        private System.Windows.Forms.TextBox asmBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button pickromButton;
        private System.Windows.Forms.Button pickasmButton;
        private System.Windows.Forms.Button PickAsarButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ASARbox;
        private System.Windows.Forms.Button PickSmileButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SMILEbox;
    }
}