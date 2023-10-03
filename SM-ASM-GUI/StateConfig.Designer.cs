
namespace SM_ASM_GUI
{
    partial class StateConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StateConfig));
            this.StateSelect = new System.Windows.Forms.ComboBox();
            this.LevelShare = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FXshare = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ScrollsShare = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PLMshare = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.EnemySetShare = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.GFXshare = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BoxStateType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.BoxStateArg = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.GroupSharing = new System.Windows.Forms.GroupBox();
            this.GroupManuals = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.BoxBGY = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.BoxBGX = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.BoxPlayIndex = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.BoxSongSet = new System.Windows.Forms.TextBox();
            this.BoxTileset = new System.Windows.Forms.TextBox();
            this.BoxUnused = new System.Windows.Forms.TextBox();
            this.BoxSetupASM = new System.Windows.Forms.TextBox();
            this.BoxMainASM = new System.Windows.Forms.TextBox();
            this.BoxBackground = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ButtonHelp = new System.Windows.Forms.Button();
            this.ButtonKillState = new System.Windows.Forms.Button();
            this.ButtonAddState = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.GroupSharing.SuspendLayout();
            this.GroupManuals.SuspendLayout();
            this.SuspendLayout();
            // 
            // StateSelect
            // 
            this.StateSelect.FormattingEnabled = true;
            this.StateSelect.Location = new System.Drawing.Point(13, 13);
            this.StateSelect.Name = "StateSelect";
            this.StateSelect.Size = new System.Drawing.Size(168, 21);
            this.StateSelect.TabIndex = 0;
            this.StateSelect.SelectedIndexChanged += new System.EventHandler(this.StateSelect_SelectedIndexChanged);
            // 
            // LevelShare
            // 
            this.LevelShare.FormattingEnabled = true;
            this.LevelShare.Location = new System.Drawing.Point(6, 17);
            this.LevelShare.Name = "LevelShare";
            this.LevelShare.Size = new System.Drawing.Size(168, 21);
            this.LevelShare.TabIndex = 1;
            this.LevelShare.SelectedIndexChanged += new System.EventHandler(this.SharePointer);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Level Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Background";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "FX";
            // 
            // FXshare
            // 
            this.FXshare.FormattingEnabled = true;
            this.FXshare.Location = new System.Drawing.Point(6, 44);
            this.FXshare.Name = "FXshare";
            this.FXshare.Size = new System.Drawing.Size(168, 21);
            this.FXshare.TabIndex = 5;
            this.FXshare.SelectedIndexChanged += new System.EventHandler(this.SharePointer);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Scrolls";
            // 
            // ScrollsShare
            // 
            this.ScrollsShare.FormattingEnabled = true;
            this.ScrollsShare.Location = new System.Drawing.Point(6, 71);
            this.ScrollsShare.Name = "ScrollsShare";
            this.ScrollsShare.Size = new System.Drawing.Size(168, 21);
            this.ScrollsShare.TabIndex = 7;
            this.ScrollsShare.SelectedIndexChanged += new System.EventHandler(this.SharePointer);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "PLMs";
            // 
            // PLMshare
            // 
            this.PLMshare.FormattingEnabled = true;
            this.PLMshare.Location = new System.Drawing.Point(6, 98);
            this.PLMshare.Name = "PLMshare";
            this.PLMshare.Size = new System.Drawing.Size(168, 21);
            this.PLMshare.TabIndex = 11;
            this.PLMshare.SelectedIndexChanged += new System.EventHandler(this.SharePointer);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Enemy Set";
            // 
            // EnemySetShare
            // 
            this.EnemySetShare.FormattingEnabled = true;
            this.EnemySetShare.Location = new System.Drawing.Point(6, 125);
            this.EnemySetShare.Name = "EnemySetShare";
            this.EnemySetShare.Size = new System.Drawing.Size(168, 21);
            this.EnemySetShare.TabIndex = 13;
            this.EnemySetShare.SelectedIndexChanged += new System.EventHandler(this.SharePointer);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(147, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Enemy GFX";
            // 
            // GFXshare
            // 
            this.GFXshare.FormattingEnabled = true;
            this.GFXshare.Location = new System.Drawing.Point(6, 152);
            this.GFXshare.Name = "GFXshare";
            this.GFXshare.Size = new System.Drawing.Size(168, 21);
            this.GFXshare.TabIndex = 15;
            this.GFXshare.SelectedIndexChanged += new System.EventHandler(this.SharePointer);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(84, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Main ASM";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(79, 333);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Setup ASM";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(96, 360);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Unused";
            // 
            // BoxStateType
            // 
            this.BoxStateType.FormattingEnabled = true;
            this.BoxStateType.Location = new System.Drawing.Point(12, 66);
            this.BoxStateType.Name = "BoxStateType";
            this.BoxStateType.Size = new System.Drawing.Size(135, 21);
            this.BoxStateType.TabIndex = 26;
            this.BoxStateType.SelectedIndexChanged += new System.EventHandler(this.BoxStateType_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "State Type";
            // 
            // BoxStateArg
            // 
            this.BoxStateArg.Location = new System.Drawing.Point(12, 114);
            this.BoxStateArg.MaxLength = 2;
            this.BoxStateArg.Name = "BoxStateArg";
            this.BoxStateArg.Size = new System.Drawing.Size(59, 20);
            this.BoxStateArg.TabIndex = 28;
            this.BoxStateArg.Validating += new System.ComponentModel.CancelEventHandler(this.Hexnumber_Validating);
            this.BoxStateArg.Validated += new System.EventHandler(this.BoxStateArg_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 101);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "State Arg (Hex)";
            // 
            // GroupSharing
            // 
            this.GroupSharing.Controls.Add(this.LevelShare);
            this.GroupSharing.Controls.Add(this.FXshare);
            this.GroupSharing.Controls.Add(this.ScrollsShare);
            this.GroupSharing.Controls.Add(this.PLMshare);
            this.GroupSharing.Controls.Add(this.EnemySetShare);
            this.GroupSharing.Controls.Add(this.GFXshare);
            this.GroupSharing.Location = new System.Drawing.Point(216, 49);
            this.GroupSharing.Name = "GroupSharing";
            this.GroupSharing.Size = new System.Drawing.Size(183, 186);
            this.GroupSharing.TabIndex = 30;
            this.GroupSharing.TabStop = false;
            this.GroupSharing.Text = "Pointer Sharing";
            this.GroupSharing.Leave += new System.EventHandler(this.GroupSharing_Leave);
            // 
            // GroupManuals
            // 
            this.GroupManuals.Controls.Add(this.label18);
            this.GroupManuals.Controls.Add(this.BoxBGY);
            this.GroupManuals.Controls.Add(this.label14);
            this.GroupManuals.Controls.Add(this.BoxBGX);
            this.GroupManuals.Controls.Add(this.label15);
            this.GroupManuals.Controls.Add(this.BoxPlayIndex);
            this.GroupManuals.Controls.Add(this.label16);
            this.GroupManuals.Controls.Add(this.label17);
            this.GroupManuals.Controls.Add(this.BoxSongSet);
            this.GroupManuals.Controls.Add(this.BoxTileset);
            this.GroupManuals.Controls.Add(this.BoxUnused);
            this.GroupManuals.Controls.Add(this.BoxSetupASM);
            this.GroupManuals.Controls.Add(this.BoxMainASM);
            this.GroupManuals.Controls.Add(this.BoxBackground);
            this.GroupManuals.Location = new System.Drawing.Point(143, 256);
            this.GroupManuals.Name = "GroupManuals";
            this.GroupManuals.Size = new System.Drawing.Size(256, 131);
            this.GroupManuals.TabIndex = 22;
            this.GroupManuals.TabStop = false;
            this.GroupManuals.Text = "Manual Assignment";
            this.GroupManuals.Leave += new System.EventHandler(this.GroupManuals_Leave);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(214, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 13);
            this.label18.TabIndex = 39;
            this.label18.Text = "BG Y";
            // 
            // BoxBGY
            // 
            this.BoxBGY.Location = new System.Drawing.Point(182, 43);
            this.BoxBGY.MaxLength = 4;
            this.BoxBGY.Name = "BoxBGY";
            this.BoxBGY.Size = new System.Drawing.Size(30, 20);
            this.BoxBGY.TabIndex = 40;
            this.BoxBGY.Validating += new System.ComponentModel.CancelEventHandler(this.Hexnumber_Validating);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(214, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "BG X";
            // 
            // BoxBGX
            // 
            this.BoxBGX.Location = new System.Drawing.Point(182, 20);
            this.BoxBGX.MaxLength = 4;
            this.BoxBGX.Name = "BoxBGX";
            this.BoxBGX.Size = new System.Drawing.Size(30, 20);
            this.BoxBGX.TabIndex = 38;
            this.BoxBGX.Validating += new System.ComponentModel.CancelEventHandler(this.Hexnumber_Validating);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(115, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Play Index";
            // 
            // BoxPlayIndex
            // 
            this.BoxPlayIndex.Location = new System.Drawing.Point(82, 73);
            this.BoxPlayIndex.MaxLength = 4;
            this.BoxPlayIndex.Name = "BoxPlayIndex";
            this.BoxPlayIndex.Size = new System.Drawing.Size(30, 20);
            this.BoxPlayIndex.TabIndex = 37;
            this.BoxPlayIndex.Validating += new System.ComponentModel.CancelEventHandler(this.Hexnumber_Validating);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(115, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "Song Set";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(115, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 31;
            this.label17.Text = "Tileset";
            // 
            // BoxSongSet
            // 
            this.BoxSongSet.Location = new System.Drawing.Point(82, 47);
            this.BoxSongSet.MaxLength = 4;
            this.BoxSongSet.Name = "BoxSongSet";
            this.BoxSongSet.Size = new System.Drawing.Size(30, 20);
            this.BoxSongSet.TabIndex = 36;
            this.BoxSongSet.Validating += new System.ComponentModel.CancelEventHandler(this.Hexnumber_Validating);
            // 
            // BoxTileset
            // 
            this.BoxTileset.Location = new System.Drawing.Point(82, 21);
            this.BoxTileset.MaxLength = 4;
            this.BoxTileset.Name = "BoxTileset";
            this.BoxTileset.Size = new System.Drawing.Size(30, 20);
            this.BoxTileset.TabIndex = 35;
            this.BoxTileset.Validating += new System.ComponentModel.CancelEventHandler(this.Hexnumber_Validating);
            // 
            // BoxUnused
            // 
            this.BoxUnused.Location = new System.Drawing.Point(6, 99);
            this.BoxUnused.MaxLength = 4;
            this.BoxUnused.Name = "BoxUnused";
            this.BoxUnused.Size = new System.Drawing.Size(70, 20);
            this.BoxUnused.TabIndex = 34;
            this.BoxUnused.Validating += new System.ComponentModel.CancelEventHandler(this.Hexnumber_Validating);
            // 
            // BoxSetupASM
            // 
            this.BoxSetupASM.Location = new System.Drawing.Point(6, 73);
            this.BoxSetupASM.MaxLength = 4;
            this.BoxSetupASM.Name = "BoxSetupASM";
            this.BoxSetupASM.Size = new System.Drawing.Size(70, 20);
            this.BoxSetupASM.TabIndex = 33;
            this.BoxSetupASM.Validating += new System.ComponentModel.CancelEventHandler(this.Hexnumber_Validating);
            // 
            // BoxMainASM
            // 
            this.BoxMainASM.Location = new System.Drawing.Point(6, 47);
            this.BoxMainASM.MaxLength = 4;
            this.BoxMainASM.Name = "BoxMainASM";
            this.BoxMainASM.Size = new System.Drawing.Size(70, 20);
            this.BoxMainASM.TabIndex = 32;
            this.BoxMainASM.Validating += new System.ComponentModel.CancelEventHandler(this.Hexnumber_Validating);
            // 
            // BoxBackground
            // 
            this.BoxBackground.Location = new System.Drawing.Point(6, 21);
            this.BoxBackground.MaxLength = 4;
            this.BoxBackground.Name = "BoxBackground";
            this.BoxBackground.Size = new System.Drawing.Size(70, 20);
            this.BoxBackground.TabIndex = 31;
            this.BoxBackground.Validating += new System.ComponentModel.CancelEventHandler(this.Hexnumber_Validating);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 25);
            this.button1.TabIndex = 32;
            this.button1.Text = "↑  Reorder  ↓";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ButtonHelp
            // 
            this.ButtonHelp.Image = global::SM_ASM_GUI.Properties.Resources.question;
            this.ButtonHelp.Location = new System.Drawing.Point(364, 10);
            this.ButtonHelp.Name = "ButtonHelp";
            this.ButtonHelp.Size = new System.Drawing.Size(25, 25);
            this.ButtonHelp.TabIndex = 31;
            this.ButtonHelp.UseVisualStyleBackColor = true;
            this.ButtonHelp.Click += new System.EventHandler(this.ButtonHelp_Click);
            // 
            // ButtonKillState
            // 
            this.ButtonKillState.Image = global::SM_ASM_GUI.Properties.Resources.MinSign;
            this.ButtonKillState.Location = new System.Drawing.Point(219, 10);
            this.ButtonKillState.Name = "ButtonKillState";
            this.ButtonKillState.Size = new System.Drawing.Size(25, 25);
            this.ButtonKillState.TabIndex = 25;
            this.ButtonKillState.UseVisualStyleBackColor = true;
            this.ButtonKillState.Click += new System.EventHandler(this.ButtonKillState_Click);
            // 
            // ButtonAddState
            // 
            this.ButtonAddState.Image = global::SM_ASM_GUI.Properties.Resources.PlusSign;
            this.ButtonAddState.Location = new System.Drawing.Point(188, 10);
            this.ButtonAddState.Name = "ButtonAddState";
            this.ButtonAddState.Size = new System.Drawing.Size(25, 25);
            this.ButtonAddState.TabIndex = 24;
            this.ButtonAddState.UseVisualStyleBackColor = true;
            this.ButtonAddState.Click += new System.EventHandler(this.ButtonAddState_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(12, 145);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(128, 45);
            this.SaveButton.TabIndex = 33;
            this.SaveButton.Text = "Save Changes";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // StateConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 399);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ButtonHelp);
            this.Controls.Add(this.GroupManuals);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.BoxStateArg);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.BoxStateType);
            this.Controls.Add(this.ButtonKillState);
            this.Controls.Add(this.ButtonAddState);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StateSelect);
            this.Controls.Add(this.GroupSharing);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StateConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "State Configurator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StateConfig_FormClosing);
            this.Load += new System.EventHandler(this.StateConfig_Load);
            this.GroupSharing.ResumeLayout(false);
            this.GroupManuals.ResumeLayout(false);
            this.GroupManuals.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox StateSelect;
        private System.Windows.Forms.ComboBox LevelShare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox FXshare;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ScrollsShare;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox PLMshare;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox EnemySetShare;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox GFXshare;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button ButtonAddState;
        private System.Windows.Forms.Button ButtonKillState;
        private System.Windows.Forms.ComboBox BoxStateType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox BoxStateArg;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox GroupSharing;
        private System.Windows.Forms.GroupBox GroupManuals;
        private System.Windows.Forms.TextBox BoxUnused;
        private System.Windows.Forms.TextBox BoxSetupASM;
        private System.Windows.Forms.TextBox BoxMainASM;
        private System.Windows.Forms.TextBox BoxBackground;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox BoxBGY;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox BoxBGX;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox BoxPlayIndex;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox BoxSongSet;
        private System.Windows.Forms.TextBox BoxTileset;
        private System.Windows.Forms.Button ButtonHelp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SaveButton;
    }
}