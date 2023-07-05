
namespace SM_ASM_GUI
{
    partial class SpecialDoorID
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
            this.DoorList = new System.Windows.Forms.ListBox();
            this.DoorsC = new System.Windows.Forms.ListBox();
            this.doorGroups = new System.Windows.Forms.GroupBox();
            this.DoorsB = new System.Windows.Forms.ListBox();
            this.DoorsA = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonHelp = new System.Windows.Forms.Button();
            this.RtnFromA = new System.Windows.Forms.Button();
            this.RtnFromB = new System.Windows.Forms.Button();
            this.RtnFromC = new System.Windows.Forms.Button();
            this.MoveToA = new System.Windows.Forms.Button();
            this.DoneButton = new System.Windows.Forms.Button();
            this.MoveToB = new System.Windows.Forms.Button();
            this.MoveToC = new System.Windows.Forms.Button();
            this.KeepHiByteA = new System.Windows.Forms.CheckBox();
            this.KeepHiByteB = new System.Windows.Forms.CheckBox();
            this.KeepHiByteC = new System.Windows.Forms.CheckBox();
            this.HiByteHover = new System.Windows.Forms.ToolTip(this.components);
            this.doorGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // DoorList
            // 
            this.DoorList.FormattingEnabled = true;
            this.DoorList.Location = new System.Drawing.Point(12, 5);
            this.DoorList.Name = "DoorList";
            this.DoorList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.DoorList.Size = new System.Drawing.Size(98, 108);
            this.DoorList.TabIndex = 0;
            // 
            // DoorsC
            // 
            this.DoorsC.FormattingEnabled = true;
            this.DoorsC.Location = new System.Drawing.Point(219, 12);
            this.DoorsC.Name = "DoorsC";
            this.DoorsC.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.DoorsC.Size = new System.Drawing.Size(98, 134);
            this.DoorsC.TabIndex = 3;
            // 
            // doorGroups
            // 
            this.doorGroups.Controls.Add(this.DoorsB);
            this.doorGroups.Controls.Add(this.DoorsC);
            this.doorGroups.Controls.Add(this.DoorsA);
            this.doorGroups.Location = new System.Drawing.Point(146, 19);
            this.doorGroups.Name = "doorGroups";
            this.doorGroups.Size = new System.Drawing.Size(329, 158);
            this.doorGroups.TabIndex = 4;
            this.doorGroups.TabStop = false;
            // 
            // DoorsB
            // 
            this.DoorsB.FormattingEnabled = true;
            this.DoorsB.Location = new System.Drawing.Point(115, 12);
            this.DoorsB.Name = "DoorsB";
            this.DoorsB.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.DoorsB.Size = new System.Drawing.Size(98, 134);
            this.DoorsB.TabIndex = 2;
            // 
            // DoorsA
            // 
            this.DoorsA.FormattingEnabled = true;
            this.DoorsA.Location = new System.Drawing.Point(11, 12);
            this.DoorsA.Name = "DoorsA";
            this.DoorsA.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.DoorsA.Size = new System.Drawing.Size(98, 134);
            this.DoorsA.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(294, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(397, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "C";
            // 
            // ButtonHelp
            // 
            this.ButtonHelp.Image = global::SM_ASM_GUI.Properties.Resources.question;
            this.ButtonHelp.Location = new System.Drawing.Point(116, 3);
            this.ButtonHelp.Name = "ButtonHelp";
            this.ButtonHelp.Size = new System.Drawing.Size(25, 25);
            this.ButtonHelp.TabIndex = 32;
            this.ButtonHelp.UseVisualStyleBackColor = true;
            this.ButtonHelp.Click += new System.EventHandler(this.ButtonHelp_Click);
            // 
            // RtnFromA
            // 
            this.RtnFromA.Location = new System.Drawing.Point(159, 2);
            this.RtnFromA.Name = "RtnFromA";
            this.RtnFromA.Size = new System.Drawing.Size(27, 22);
            this.RtnFromA.TabIndex = 33;
            this.RtnFromA.Text = "<--";
            this.RtnFromA.UseVisualStyleBackColor = true;
            this.RtnFromA.Click += new System.EventHandler(this.RtnFromA_Click);
            // 
            // RtnFromB
            // 
            this.RtnFromB.Location = new System.Drawing.Point(261, 2);
            this.RtnFromB.Name = "RtnFromB";
            this.RtnFromB.Size = new System.Drawing.Size(27, 22);
            this.RtnFromB.TabIndex = 34;
            this.RtnFromB.Text = "<--";
            this.RtnFromB.UseVisualStyleBackColor = true;
            this.RtnFromB.Click += new System.EventHandler(this.RtnFromB_Click);
            // 
            // RtnFromC
            // 
            this.RtnFromC.Location = new System.Drawing.Point(365, 2);
            this.RtnFromC.Name = "RtnFromC";
            this.RtnFromC.Size = new System.Drawing.Size(27, 22);
            this.RtnFromC.TabIndex = 35;
            this.RtnFromC.Text = "<--";
            this.RtnFromC.UseVisualStyleBackColor = true;
            this.RtnFromC.Click += new System.EventHandler(this.RtnFromC_Click);
            // 
            // MoveToA
            // 
            this.MoveToA.Location = new System.Drawing.Point(116, 31);
            this.MoveToA.Name = "MoveToA";
            this.MoveToA.Size = new System.Drawing.Size(25, 25);
            this.MoveToA.TabIndex = 36;
            this.MoveToA.Text = "A";
            this.MoveToA.UseVisualStyleBackColor = true;
            this.MoveToA.Click += new System.EventHandler(this.MoveToA_Click);
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(13, 127);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(97, 38);
            this.DoneButton.TabIndex = 37;
            this.DoneButton.Text = "Start Auto-ID";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // MoveToB
            // 
            this.MoveToB.Location = new System.Drawing.Point(116, 59);
            this.MoveToB.Name = "MoveToB";
            this.MoveToB.Size = new System.Drawing.Size(25, 25);
            this.MoveToB.TabIndex = 38;
            this.MoveToB.Text = "B";
            this.MoveToB.UseVisualStyleBackColor = true;
            this.MoveToB.Click += new System.EventHandler(this.MoveToB_Click);
            // 
            // MoveToC
            // 
            this.MoveToC.Location = new System.Drawing.Point(116, 88);
            this.MoveToC.Name = "MoveToC";
            this.MoveToC.Size = new System.Drawing.Size(25, 25);
            this.MoveToC.TabIndex = 39;
            this.MoveToC.Text = "C";
            this.MoveToC.UseVisualStyleBackColor = true;
            this.MoveToC.Click += new System.EventHandler(this.MoveToC_Click);
            // 
            // KeepHiByteA
            // 
            this.KeepHiByteA.AutoSize = true;
            this.KeepHiByteA.Location = new System.Drawing.Point(215, 7);
            this.KeepHiByteA.Name = "KeepHiByteA";
            this.KeepHiByteA.Size = new System.Drawing.Size(40, 18);
            this.KeepHiByteA.TabIndex = 40;
            this.KeepHiByteA.Text = "HH";
            this.HiByteHover.SetToolTip(this.KeepHiByteA, "Keep existing high byte in ROM");
            this.KeepHiByteA.UseCompatibleTextRendering = true;
            this.KeepHiByteA.UseVisualStyleBackColor = false;
            // 
            // KeepHiByteB
            // 
            this.KeepHiByteB.AutoSize = true;
            this.KeepHiByteB.Location = new System.Drawing.Point(317, 7);
            this.KeepHiByteB.Name = "KeepHiByteB";
            this.KeepHiByteB.Size = new System.Drawing.Size(40, 18);
            this.KeepHiByteB.TabIndex = 41;
            this.KeepHiByteB.Text = "HH";
            this.HiByteHover.SetToolTip(this.KeepHiByteB, "Keep existing high byte in ROM");
            this.KeepHiByteB.UseCompatibleTextRendering = true;
            this.KeepHiByteB.UseVisualStyleBackColor = false;
            // 
            // KeepHiByteC
            // 
            this.KeepHiByteC.AutoSize = true;
            this.KeepHiByteC.Location = new System.Drawing.Point(421, 7);
            this.KeepHiByteC.Name = "KeepHiByteC";
            this.KeepHiByteC.Size = new System.Drawing.Size(40, 18);
            this.KeepHiByteC.TabIndex = 42;
            this.KeepHiByteC.Text = "HH";
            this.HiByteHover.SetToolTip(this.KeepHiByteC, "Keep existing high byte in ROM");
            this.KeepHiByteC.UseCompatibleTextRendering = true;
            this.KeepHiByteC.UseVisualStyleBackColor = false;
            // 
            // HiByteHover
            // 
            this.HiByteHover.AutomaticDelay = 0;
            this.HiByteHover.AutoPopDelay = 0;
            this.HiByteHover.InitialDelay = 0;
            this.HiByteHover.ReshowDelay = 0;
            this.HiByteHover.UseAnimation = false;
            this.HiByteHover.UseFading = false;
            // 
            // SpecialDoorID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 187);
            this.Controls.Add(this.KeepHiByteC);
            this.Controls.Add(this.KeepHiByteB);
            this.Controls.Add(this.KeepHiByteA);
            this.Controls.Add(this.MoveToC);
            this.Controls.Add(this.MoveToB);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.MoveToA);
            this.Controls.Add(this.RtnFromC);
            this.Controls.Add(this.RtnFromB);
            this.Controls.Add(this.RtnFromA);
            this.Controls.Add(this.ButtonHelp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.doorGroups);
            this.Controls.Add(this.DoorList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SpecialDoorID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Special Door ID";
            this.doorGroups.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox DoorList;
        private System.Windows.Forms.ListBox DoorsC;
        private System.Windows.Forms.GroupBox doorGroups;
        private System.Windows.Forms.ListBox DoorsB;
        private System.Windows.Forms.ListBox DoorsA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonHelp;
        private System.Windows.Forms.Button RtnFromA;
        private System.Windows.Forms.Button RtnFromB;
        private System.Windows.Forms.Button RtnFromC;
        private System.Windows.Forms.Button MoveToA;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Button MoveToB;
        private System.Windows.Forms.Button MoveToC;
        private System.Windows.Forms.CheckBox KeepHiByteA;
        private System.Windows.Forms.ToolTip HiByteHover;
        private System.Windows.Forms.CheckBox KeepHiByteB;
        private System.Windows.Forms.CheckBox KeepHiByteC;
    }
}