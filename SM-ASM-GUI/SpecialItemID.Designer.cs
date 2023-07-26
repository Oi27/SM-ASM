
namespace SM_ASM_GUI
{
    partial class SpecialItemID
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecialItemID));
            this.PlmList = new System.Windows.Forms.ListBox();
            this.EnemyList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IdTilemap = new System.Windows.Forms.RadioButton();
            this.IdSpeed2 = new System.Windows.Forms.RadioButton();
            this.IdSpeed1 = new System.Windows.Forms.RadioButton();
            this.StartButton = new System.Windows.Forms.Button();
            this.ListBoxRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.ListBoxRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlmList
            // 
            this.PlmList.ContextMenuStrip = this.ListBoxRightClick;
            this.PlmList.FormattingEnabled = true;
            this.PlmList.ItemHeight = 16;
            this.PlmList.Location = new System.Drawing.Point(12, 39);
            this.PlmList.Name = "PlmList";
            this.PlmList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.PlmList.Size = new System.Drawing.Size(120, 164);
            this.PlmList.TabIndex = 0;
            // 
            // EnemyList
            // 
            this.EnemyList.ContextMenuStrip = this.ListBoxRightClick;
            this.EnemyList.FormattingEnabled = true;
            this.EnemyList.ItemHeight = 16;
            this.EnemyList.Location = new System.Drawing.Point(138, 39);
            this.EnemyList.Name = "EnemyList";
            this.EnemyList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.EnemyList.Size = new System.Drawing.Size(80, 164);
            this.EnemyList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "PLMs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enemies";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IdTilemap);
            this.groupBox1.Controls.Add(this.IdSpeed2);
            this.groupBox1.Controls.Add(this.IdSpeed1);
            this.groupBox1.Location = new System.Drawing.Point(224, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(101, 110);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ID in:";
            // 
            // IdTilemap
            // 
            this.IdTilemap.AutoSize = true;
            this.IdTilemap.Location = new System.Drawing.Point(6, 75);
            this.IdTilemap.Name = "IdTilemap";
            this.IdTilemap.Size = new System.Drawing.Size(79, 21);
            this.IdTilemap.TabIndex = 2;
            this.IdTilemap.Text = "TileMap";
            this.IdTilemap.UseVisualStyleBackColor = true;
            // 
            // IdSpeed2
            // 
            this.IdSpeed2.AutoSize = true;
            this.IdSpeed2.Location = new System.Drawing.Point(6, 48);
            this.IdSpeed2.Name = "IdSpeed2";
            this.IdSpeed2.Size = new System.Drawing.Size(78, 21);
            this.IdSpeed2.TabIndex = 1;
            this.IdSpeed2.Text = "Speed2";
            this.IdSpeed2.UseVisualStyleBackColor = true;
            // 
            // IdSpeed1
            // 
            this.IdSpeed1.AutoSize = true;
            this.IdSpeed1.Checked = true;
            this.IdSpeed1.Location = new System.Drawing.Point(6, 21);
            this.IdSpeed1.Name = "IdSpeed1";
            this.IdSpeed1.Size = new System.Drawing.Size(78, 21);
            this.IdSpeed1.TabIndex = 0;
            this.IdSpeed1.TabStop = true;
            this.IdSpeed1.Text = "Speed1";
            this.IdSpeed1.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(224, 156);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(101, 47);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Begin Auto-ID";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.startButton_click);
            // 
            // ListBoxRightClick
            // 
            this.ListBoxRightClick.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ListBoxRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemToolStripMenuItem,
            this.removeSelectedToolStripMenuItem});
            this.ListBoxRightClick.Name = "ListBoxRightClick";
            this.ListBoxRightClick.Size = new System.Drawing.Size(194, 52);
            // 
            // addItemToolStripMenuItem
            // 
            this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            this.addItemToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.addItemToolStripMenuItem.Text = "Add Item";
            this.addItemToolStripMenuItem.Click += new System.EventHandler(this.addItemToolStripMenuItem_Click);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Enabled = false;
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.removeSelectedToolStripMenuItem.Text = "Remove Selected";
            this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
            // 
            // SpecialItemID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 215);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnemyList);
            this.Controls.Add(this.PlmList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpecialItemID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SpecialItemID";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ListBoxRightClick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PlmList;
        private System.Windows.Forms.ListBox EnemyList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton IdTilemap;
        private System.Windows.Forms.RadioButton IdSpeed2;
        private System.Windows.Forms.RadioButton IdSpeed1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ContextMenuStrip ListBoxRightClick;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
    }
}