
namespace SM_ASM_GUI
{
    partial class ObjectPicker
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
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.AddObject = new System.Windows.Forms.Button();
            this.EnemyDisplay = new System.Windows.Forms.PictureBox();
            this.Xpos = new System.Windows.Forms.TextBox();
            this.Ypos = new System.Windows.Forms.TextBox();
            this.Xlabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.DescLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(12, 21);
            this.SearchBox.MaxLength = 40;
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(100, 20);
            this.SearchBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 47);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(100, 225);
            this.listBox1.TabIndex = 2;
            // 
            // AddObject
            // 
            this.AddObject.Location = new System.Drawing.Point(118, 21);
            this.AddObject.Name = "AddObject";
            this.AddObject.Size = new System.Drawing.Size(139, 41);
            this.AddObject.TabIndex = 3;
            this.AddObject.Text = "Add";
            this.AddObject.UseVisualStyleBackColor = true;
            this.AddObject.Click += new System.EventHandler(this.AddObject_Click);
            // 
            // EnemyDisplay
            // 
            this.EnemyDisplay.Location = new System.Drawing.Point(118, 69);
            this.EnemyDisplay.Name = "EnemyDisplay";
            this.EnemyDisplay.Size = new System.Drawing.Size(139, 125);
            this.EnemyDisplay.TabIndex = 4;
            this.EnemyDisplay.TabStop = false;
            // 
            // Xpos
            // 
            this.Xpos.Location = new System.Drawing.Point(118, 213);
            this.Xpos.MaxLength = 4;
            this.Xpos.Name = "Xpos";
            this.Xpos.Size = new System.Drawing.Size(48, 20);
            this.Xpos.TabIndex = 5;
            this.Xpos.Text = "def";
            // 
            // Ypos
            // 
            this.Ypos.Location = new System.Drawing.Point(118, 252);
            this.Ypos.MaxLength = 4;
            this.Ypos.Name = "Ypos";
            this.Ypos.Size = new System.Drawing.Size(48, 20);
            this.Ypos.TabIndex = 6;
            this.Ypos.Text = "def";
            // 
            // Xlabel
            // 
            this.Xlabel.AutoSize = true;
            this.Xlabel.Location = new System.Drawing.Point(118, 197);
            this.Xlabel.Name = "Xlabel";
            this.Xlabel.Size = new System.Drawing.Size(35, 13);
            this.Xlabel.TabIndex = 7;
            this.Xlabel.Text = "X Pos";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(118, 236);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(35, 13);
            this.yLabel.TabIndex = 8;
            this.yLabel.Text = "Y Pos";
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Location = new System.Drawing.Point(172, 197);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(98, 52);
            this.DescLabel.TabIndex = 9;
            this.DescLabel.Text = "Other properties\r\nshould be changed\r\nusing the \r\nmain editor";
            // 
            // ObjectPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 296);
            this.Controls.Add(this.DescLabel);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.Xlabel);
            this.Controls.Add(this.Ypos);
            this.Controls.Add(this.Xpos);
            this.Controls.Add(this.EnemyDisplay);
            this.Controls.Add(this.AddObject);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ObjectPicker";
            this.Text = "Default";
            ((System.ComponentModel.ISupportInitialize)(this.EnemyDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button AddObject;
        private System.Windows.Forms.PictureBox EnemyDisplay;
        private System.Windows.Forms.TextBox Xpos;
        private System.Windows.Forms.TextBox Ypos;
        private System.Windows.Forms.Label Xlabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label DescLabel;
    }
}