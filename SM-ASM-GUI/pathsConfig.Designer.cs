
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
            this.label4 = new System.Windows.Forms.Label();
            this.SMILEbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TilesetBox = new System.Windows.Forms.TextBox();
            this.PickSmileButton = new System.Windows.Forms.Button();
            this.PickAsarButton = new System.Windows.Forms.Button();
            this.pickasmButton = new System.Windows.Forms.Button();
            this.pickromButton = new System.Windows.Forms.Button();
            this.AsmSetupLabel = new System.Windows.Forms.Label();
            this.OpenMdbFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // romBox
            // 
            this.romBox.Location = new System.Drawing.Point(72, 30);
            this.romBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.romBox.Name = "romBox";
            this.romBox.Size = new System.Drawing.Size(475, 22);
            this.romBox.TabIndex = 0;
            // 
            // asmBox
            // 
            this.asmBox.Location = new System.Drawing.Point(72, 85);
            this.asmBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.asmBox.Name = "asmBox";
            this.asmBox.Size = new System.Drawing.Size(475, 22);
            this.asmBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "ROM path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "ASM Path";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(40, 225);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(140, 46);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save and Close";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "ASAR Path";
            // 
            // ASARbox
            // 
            this.ASARbox.Location = new System.Drawing.Point(72, 135);
            this.ASARbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ASARbox.Name = "ASARbox";
            this.ASARbox.Size = new System.Drawing.Size(475, 22);
            this.ASARbox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "SMILE Files Folder";
            // 
            // SMILEbox
            // 
            this.SMILEbox.Location = new System.Drawing.Point(72, 186);
            this.SMILEbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SMILEbox.Name = "SMILEbox";
            this.SMILEbox.Size = new System.Drawing.Size(432, 22);
            this.SMILEbox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(319, 225);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 51);
            this.label5.TabIndex = 15;
            this.label5.Text = "SMASM will tweak $82DF03 \r\n(pointer to tileset list) to\r\nmatch the given address." +
    "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 225);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tileset Table";
            // 
            // TilesetBox
            // 
            this.TilesetBox.Location = new System.Drawing.Point(224, 245);
            this.TilesetBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TilesetBox.MaxLength = 4;
            this.TilesetBox.Name = "TilesetBox";
            this.TilesetBox.Size = new System.Drawing.Size(85, 22);
            this.TilesetBox.TabIndex = 13;
            this.TilesetBox.Text = "ERR";
            this.TilesetBox.TextChanged += new System.EventHandler(this.TilesetBox_TextChanged);
            // 
            // PickSmileButton
            // 
            this.PickSmileButton.Image = global::SM_ASM_GUI.Properties.Resources.Bitmap1;
            this.PickSmileButton.Location = new System.Drawing.Point(40, 186);
            this.PickSmileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PickSmileButton.Name = "PickSmileButton";
            this.PickSmileButton.Size = new System.Drawing.Size(32, 25);
            this.PickSmileButton.TabIndex = 12;
            this.PickSmileButton.UseVisualStyleBackColor = true;
            this.PickSmileButton.Click += new System.EventHandler(this.PickSmileButton_Click);
            // 
            // PickAsarButton
            // 
            this.PickAsarButton.Image = global::SM_ASM_GUI.Properties.Resources.Bitmap1;
            this.PickAsarButton.Location = new System.Drawing.Point(40, 135);
            this.PickAsarButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PickAsarButton.Name = "PickAsarButton";
            this.PickAsarButton.Size = new System.Drawing.Size(32, 25);
            this.PickAsarButton.TabIndex = 9;
            this.PickAsarButton.UseVisualStyleBackColor = true;
            this.PickAsarButton.Click += new System.EventHandler(this.PickAsarButton_Click);
            // 
            // pickasmButton
            // 
            this.pickasmButton.Image = global::SM_ASM_GUI.Properties.Resources.Bitmap1;
            this.pickasmButton.Location = new System.Drawing.Point(40, 85);
            this.pickasmButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pickasmButton.Name = "pickasmButton";
            this.pickasmButton.Size = new System.Drawing.Size(32, 25);
            this.pickasmButton.TabIndex = 6;
            this.pickasmButton.UseVisualStyleBackColor = true;
            this.pickasmButton.Click += new System.EventHandler(this.pickasmButton_Click);
            // 
            // pickromButton
            // 
            this.pickromButton.Image = global::SM_ASM_GUI.Properties.Resources.Bitmap1;
            this.pickromButton.Location = new System.Drawing.Point(40, 30);
            this.pickromButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pickromButton.Name = "pickromButton";
            this.pickromButton.Size = new System.Drawing.Size(32, 25);
            this.pickromButton.TabIndex = 5;
            this.pickromButton.UseVisualStyleBackColor = true;
            this.pickromButton.Click += new System.EventHandler(this.pickromButton_Click);
            // 
            // AsmSetupLabel
            // 
            this.AsmSetupLabel.AutoSize = true;
            this.AsmSetupLabel.Location = new System.Drawing.Point(117, 65);
            this.AsmSetupLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AsmSetupLabel.Name = "AsmSetupLabel";
            this.AsmSetupLabel.Size = new System.Drawing.Size(184, 17);
            this.AsmSetupLabel.TabIndex = 16;
            this.AsmSetupLabel.Text = "(Leave blank to create new)";
            // 
            // OpenMdbFolder
            // 
            this.OpenMdbFolder.Location = new System.Drawing.Point(512, 186);
            this.OpenMdbFolder.Margin = new System.Windows.Forms.Padding(4);
            this.OpenMdbFolder.Name = "OpenMdbFolder";
            this.OpenMdbFolder.Size = new System.Drawing.Size(82, 44);
            this.OpenMdbFolder.TabIndex = 17;
            this.OpenMdbFolder.Text = "MDB Folder";
            this.OpenMdbFolder.UseVisualStyleBackColor = true;
            this.OpenMdbFolder.Click += new System.EventHandler(this.OpenMdbFolder_Click);
            // 
            // pathsConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 297);
            this.Controls.Add(this.OpenMdbFolder);
            this.Controls.Add(this.AsmSetupLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TilesetBox);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TilesetBox;
        private System.Windows.Forms.Label AsmSetupLabel;
        private System.Windows.Forms.Button OpenMdbFolder;
    }
}