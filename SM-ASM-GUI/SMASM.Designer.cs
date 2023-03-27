﻿
namespace SM_ASM_GUI
{
    partial class SMASM
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentRoomToNewASMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeRoomFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mDBListToASMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filePathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetFoldersToASMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rOMToTilesetFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slimGUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thisRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromMDBListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pcBox = new System.Windows.Forms.TextBox();
            this.lorombox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.HeaderBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RoomIndex = new System.Windows.Forms.TextBox();
            this.MapXLabel = new System.Windows.Forms.Label();
            this.MapX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RoomWidth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.UpScroller = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SpecialGFX = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.DnScroller = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.RoomHeight = new System.Windows.Forms.TextBox();
            this.MapYLabel = new System.Windows.Forms.Label();
            this.MapY = new System.Windows.Forms.TextBox();
            this.AreaLabel = new System.Windows.Forms.Label();
            this.AreaIndex = new System.Windows.Forms.TextBox();
            this.ASMbutton = new System.Windows.Forms.Button();
            this.StateBox = new System.Windows.Forms.ListBox();
            this.StateMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AddStateButton = new System.Windows.Forms.ToolStripMenuItem();
            this.DataListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteButton = new System.Windows.Forms.ToolStripMenuItem();
            this.BlockCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.NewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.EnemyBox = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.PlmBox = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.FXbox = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.DoorBox = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.GFXbox = new System.Windows.Forms.ListBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.StatusBox = new System.Windows.Forms.RichTextBox();
            this.DelMDB = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LevelBuffer = new System.Windows.Forms.TextBox();
            this.ImportCurrentTileset = new System.Windows.Forms.Button();
            this.ExportCurrentTileset = new System.Windows.Forms.Button();
            this.RefreshExport = new System.Windows.Forms.Button();
            this.RoomLoadTimeStamp = new System.Windows.Forms.Label();
            this.bitshift = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.TilesetBox = new System.Windows.Forms.TextBox();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.label17 = new System.Windows.Forms.Label();
            this.alltopCheckbox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.StateMenuStrip.SuspendLayout();
            this.DataListMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configToolStripMenuItem,
            this.tilesetsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentRoomToNewASMToolStripMenuItem,
            this.mergeRoomFilesToolStripMenuItem,
            this.mDBListToASMToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.fileToolStripMenuItem.Text = "ASM";
            // 
            // currentRoomToNewASMToolStripMenuItem
            // 
            this.currentRoomToNewASMToolStripMenuItem.Enabled = false;
            this.currentRoomToNewASMToolStripMenuItem.Name = "currentRoomToNewASMToolStripMenuItem";
            this.currentRoomToNewASMToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.currentRoomToNewASMToolStripMenuItem.Text = "Current Room to New ASM";
            // 
            // mergeRoomFilesToolStripMenuItem
            // 
            this.mergeRoomFilesToolStripMenuItem.Enabled = false;
            this.mergeRoomFilesToolStripMenuItem.Name = "mergeRoomFilesToolStripMenuItem";
            this.mergeRoomFilesToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.mergeRoomFilesToolStripMenuItem.Text = "Merge Room Files";
            // 
            // mDBListToASMToolStripMenuItem
            // 
            this.mDBListToASMToolStripMenuItem.Enabled = false;
            this.mDBListToASMToolStripMenuItem.Name = "mDBListToASMToolStripMenuItem";
            this.mDBListToASMToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.mDBListToASMToolStripMenuItem.Text = "MDB List to ASM";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filePathsToolStripMenuItem,
            this.tilesetSetupToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // filePathsToolStripMenuItem
            // 
            this.filePathsToolStripMenuItem.Name = "filePathsToolStripMenuItem";
            this.filePathsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.filePathsToolStripMenuItem.Text = "File Paths";
            this.filePathsToolStripMenuItem.Click += new System.EventHandler(this.filePathsToolStripMenuItem_Click);
            // 
            // tilesetSetupToolStripMenuItem
            // 
            this.tilesetSetupToolStripMenuItem.Name = "tilesetSetupToolStripMenuItem";
            this.tilesetSetupToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.tilesetSetupToolStripMenuItem.Text = "Tileset Setup";
            this.tilesetSetupToolStripMenuItem.Click += new System.EventHandler(this.tilesetSetupToolStripMenuItem_Click);
            // 
            // tilesetsToolStripMenuItem
            // 
            this.tilesetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tilesetFoldersToASMToolStripMenuItem,
            this.rOMToTilesetFoldersToolStripMenuItem,
            this.toolStripMenuItem2});
            this.tilesetsToolStripMenuItem.Name = "tilesetsToolStripMenuItem";
            this.tilesetsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.tilesetsToolStripMenuItem.Text = "Tilesets";
            // 
            // tilesetFoldersToASMToolStripMenuItem
            // 
            this.tilesetFoldersToASMToolStripMenuItem.Name = "tilesetFoldersToASMToolStripMenuItem";
            this.tilesetFoldersToASMToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.tilesetFoldersToASMToolStripMenuItem.Text = "Tileset Folders to ASM";
            this.tilesetFoldersToASMToolStripMenuItem.Click += new System.EventHandler(this.ImportTilesets_Click);
            // 
            // rOMToTilesetFoldersToolStripMenuItem
            // 
            this.rOMToTilesetFoldersToolStripMenuItem.Name = "rOMToTilesetFoldersToolStripMenuItem";
            this.rOMToTilesetFoldersToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.rOMToTilesetFoldersToolStripMenuItem.Text = "ROM to Tileset Folders";
            this.rOMToTilesetFoldersToolStripMenuItem.Click += new System.EventHandler(this.ExportTilesets_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem2.Text = "Tileset Setup";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slimGUIToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // slimGUIToolStripMenuItem
            // 
            this.slimGUIToolStripMenuItem.CheckOnClick = true;
            this.slimGUIToolStripMenuItem.Enabled = false;
            this.slimGUIToolStripMenuItem.Name = "slimGUIToolStripMenuItem";
            this.slimGUIToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.slimGUIToolStripMenuItem.Text = "Slim GUI";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createMapsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.editToolStripMenuItem.Text = "Misc.";
            // 
            // createMapsToolStripMenuItem
            // 
            this.createMapsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thisRoomToolStripMenuItem,
            this.fromMDBListToolStripMenuItem});
            this.createMapsToolStripMenuItem.Enabled = false;
            this.createMapsToolStripMenuItem.Name = "createMapsToolStripMenuItem";
            this.createMapsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.createMapsToolStripMenuItem.Text = "Create Maps";
            // 
            // thisRoomToolStripMenuItem
            // 
            this.thisRoomToolStripMenuItem.Name = "thisRoomToolStripMenuItem";
            this.thisRoomToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.thisRoomToolStripMenuItem.Text = "This Room";
            // 
            // fromMDBListToolStripMenuItem
            // 
            this.fromMDBListToolStripMenuItem.Name = "fromMDBListToolStripMenuItem";
            this.fromMDBListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fromMDBListToolStripMenuItem.Text = "From MDB List";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Enabled = false;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // pcBox
            // 
            this.pcBox.Location = new System.Drawing.Point(12, 421);
            this.pcBox.Name = "pcBox";
            this.pcBox.Size = new System.Drawing.Size(100, 20);
            this.pcBox.TabIndex = 5;
            this.pcBox.TextChanged += new System.EventHandler(this.pcBox_TextChanged);
            // 
            // lorombox
            // 
            this.lorombox.Location = new System.Drawing.Point(13, 459);
            this.lorombox.Name = "lorombox";
            this.lorombox.Size = new System.Drawing.Size(100, 20);
            this.lorombox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 405);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "PC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 443);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "LoROM";
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Location = new System.Drawing.Point(9, 40);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(94, 13);
            this.HeaderLabel.TabIndex = 10;
            this.HeaderLabel.Text = "Level Header (PC)";
            // 
            // HeaderBox
            // 
            this.HeaderBox.Location = new System.Drawing.Point(12, 56);
            this.HeaderBox.MaxLength = 5;
            this.HeaderBox.Name = "HeaderBox";
            this.HeaderBox.Size = new System.Drawing.Size(100, 20);
            this.HeaderBox.TabIndex = 9;
            this.HeaderBox.TextChanged += new System.EventHandler(this.HeaderBox_TextChanged);
            this.HeaderBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HeaderBox_KeyDown);
            this.HeaderBox.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderBox_Validating);
            this.HeaderBox.Validated += new System.EventHandler(this.HeaderBox_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Room Index";
            // 
            // RoomIndex
            // 
            this.RoomIndex.Location = new System.Drawing.Point(12, 99);
            this.RoomIndex.MaxLength = 2;
            this.RoomIndex.Name = "RoomIndex";
            this.RoomIndex.Size = new System.Drawing.Size(29, 20);
            this.RoomIndex.TabIndex = 11;
            this.RoomIndex.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            this.RoomIndex.Validated += new System.EventHandler(this.RoomIndex_Validated);
            // 
            // MapXLabel
            // 
            this.MapXLabel.AutoSize = true;
            this.MapXLabel.Enabled = false;
            this.MapXLabel.Location = new System.Drawing.Point(9, 121);
            this.MapXLabel.Name = "MapXLabel";
            this.MapXLabel.Size = new System.Drawing.Size(38, 13);
            this.MapXLabel.TabIndex = 14;
            this.MapXLabel.Text = "Map X";
            // 
            // MapX
            // 
            this.MapX.Enabled = false;
            this.MapX.Location = new System.Drawing.Point(12, 137);
            this.MapX.MaxLength = 2;
            this.MapX.Name = "MapX";
            this.MapX.Size = new System.Drawing.Size(29, 20);
            this.MapX.TabIndex = 13;
            this.MapX.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(9, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Width";
            // 
            // RoomWidth
            // 
            this.RoomWidth.Enabled = false;
            this.RoomWidth.Location = new System.Drawing.Point(12, 178);
            this.RoomWidth.MaxLength = 2;
            this.RoomWidth.Name = "RoomWidth";
            this.RoomWidth.Size = new System.Drawing.Size(29, 20);
            this.RoomWidth.TabIndex = 15;
            this.RoomWidth.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(9, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "U Scroller";
            // 
            // UpScroller
            // 
            this.UpScroller.Enabled = false;
            this.UpScroller.Location = new System.Drawing.Point(12, 226);
            this.UpScroller.MaxLength = 2;
            this.UpScroller.Name = "UpScroller";
            this.UpScroller.Size = new System.Drawing.Size(29, 20);
            this.UpScroller.TabIndex = 17;
            this.UpScroller.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(9, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Special GFX";
            // 
            // SpecialGFX
            // 
            this.SpecialGFX.Enabled = false;
            this.SpecialGFX.Location = new System.Drawing.Point(12, 269);
            this.SpecialGFX.MaxLength = 2;
            this.SpecialGFX.Name = "SpecialGFX";
            this.SpecialGFX.Size = new System.Drawing.Size(29, 20);
            this.SpecialGFX.TabIndex = 19;
            this.SpecialGFX.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(80, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "D Scroller";
            // 
            // DnScroller
            // 
            this.DnScroller.Enabled = false;
            this.DnScroller.Location = new System.Drawing.Point(83, 226);
            this.DnScroller.MaxLength = 2;
            this.DnScroller.Name = "DnScroller";
            this.DnScroller.Size = new System.Drawing.Size(29, 20);
            this.DnScroller.TabIndex = 27;
            this.DnScroller.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(80, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Height";
            // 
            // RoomHeight
            // 
            this.RoomHeight.Enabled = false;
            this.RoomHeight.Location = new System.Drawing.Point(83, 178);
            this.RoomHeight.MaxLength = 2;
            this.RoomHeight.Name = "RoomHeight";
            this.RoomHeight.Size = new System.Drawing.Size(29, 20);
            this.RoomHeight.TabIndex = 25;
            this.RoomHeight.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            // 
            // MapYLabel
            // 
            this.MapYLabel.AutoSize = true;
            this.MapYLabel.Enabled = false;
            this.MapYLabel.Location = new System.Drawing.Point(80, 121);
            this.MapYLabel.Name = "MapYLabel";
            this.MapYLabel.Size = new System.Drawing.Size(38, 13);
            this.MapYLabel.TabIndex = 24;
            this.MapYLabel.Text = "Map Y";
            // 
            // MapY
            // 
            this.MapY.Enabled = false;
            this.MapY.Location = new System.Drawing.Point(83, 137);
            this.MapY.MaxLength = 2;
            this.MapY.Name = "MapY";
            this.MapY.Size = new System.Drawing.Size(29, 20);
            this.MapY.TabIndex = 23;
            this.MapY.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            // 
            // AreaLabel
            // 
            this.AreaLabel.AutoSize = true;
            this.AreaLabel.Location = new System.Drawing.Point(80, 83);
            this.AreaLabel.Name = "AreaLabel";
            this.AreaLabel.Size = new System.Drawing.Size(58, 13);
            this.AreaLabel.TabIndex = 22;
            this.AreaLabel.Text = "Area Index";
            // 
            // AreaIndex
            // 
            this.AreaIndex.Location = new System.Drawing.Point(83, 99);
            this.AreaIndex.MaxLength = 2;
            this.AreaIndex.Name = "AreaIndex";
            this.AreaIndex.Size = new System.Drawing.Size(29, 20);
            this.AreaIndex.TabIndex = 21;
            this.AreaIndex.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            this.AreaIndex.Validated += new System.EventHandler(this.RoomIndex_Validated);
            // 
            // ASMbutton
            // 
            this.ASMbutton.Location = new System.Drawing.Point(162, 178);
            this.ASMbutton.Name = "ASMbutton";
            this.ASMbutton.Size = new System.Drawing.Size(121, 41);
            this.ASMbutton.TabIndex = 35;
            this.ASMbutton.Text = "Export to ASM";
            this.ASMbutton.UseVisualStyleBackColor = true;
            this.ASMbutton.Click += new System.EventHandler(this.ASMbutton_Click);
            // 
            // StateBox
            // 
            this.StateBox.ContextMenuStrip = this.StateMenuStrip;
            this.StateBox.FormattingEnabled = true;
            this.StateBox.Location = new System.Drawing.Point(144, 56);
            this.StateBox.Name = "StateBox";
            this.StateBox.Size = new System.Drawing.Size(139, 69);
            this.StateBox.TabIndex = 38;
            this.StateBox.SelectedIndexChanged += new System.EventHandler(this.StateBox_SelectedIndexChanged);
            this.StateBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.lst_DragDrop);
            this.StateBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.lst_DragEnter);
            this.StateBox.DragOver += new System.Windows.Forms.DragEventHandler(this.lst_DragOver);
            this.StateBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Duplicate_Item);
            this.StateBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lst_MouseDown);
            // 
            // StateMenuStrip
            // 
            this.StateMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StateMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.AddStateButton});
            this.StateMenuStrip.Name = "contextMenuStrip1";
            this.StateMenuStrip.Size = new System.Drawing.Size(156, 48);
            this.StateMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.StateMenuStrip_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem1.Text = "Delete Item";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.BlockDelete_Click);
            // 
            // AddStateButton
            // 
            this.AddStateButton.Name = "AddStateButton";
            this.AddStateButton.Size = new System.Drawing.Size(155, 22);
            this.AddStateButton.Text = "Add/Edit States";
            this.AddStateButton.Click += new System.EventHandler(this.AddStateButton_Click);
            // 
            // DataListMenu
            // 
            this.DataListMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DataListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteButton,
            this.BlockCopy,
            this.NewItem});
            this.DataListMenu.Name = "contextMenuStrip1";
            this.DataListMenu.Size = new System.Drawing.Size(135, 70);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(134, 22);
            this.DeleteButton.Text = "Delete Item";
            this.DeleteButton.Click += new System.EventHandler(this.BlockDelete_Click);
            // 
            // BlockCopy
            // 
            this.BlockCopy.Name = "BlockCopy";
            this.BlockCopy.Size = new System.Drawing.Size(134, 22);
            this.BlockCopy.Text = "Duplicate";
            this.BlockCopy.Click += new System.EventHandler(this.BlockCopy_Click);
            // 
            // NewItem
            // 
            this.NewItem.Name = "NewItem";
            this.NewItem.Size = new System.Drawing.Size(134, 22);
            this.NewItem.Text = "New Item";
            this.NewItem.Click += new System.EventHandler(this.NewItem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(141, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "State";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Enabled = false;
            this.label11.Location = new System.Drawing.Point(302, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Enemies";
            // 
            // EnemyBox
            // 
            this.EnemyBox.AllowDrop = true;
            this.EnemyBox.ContextMenuStrip = this.DataListMenu;
            this.EnemyBox.FormattingEnabled = true;
            this.EnemyBox.Location = new System.Drawing.Point(305, 56);
            this.EnemyBox.Name = "EnemyBox";
            this.EnemyBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.EnemyBox.Size = new System.Drawing.Size(96, 56);
            this.EnemyBox.TabIndex = 40;
            this.EnemyBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.lst_DragDrop);
            this.EnemyBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.lst_DragEnter);
            this.EnemyBox.DragOver += new System.Windows.Forms.DragEventHandler(this.lst_DragOver);
            this.EnemyBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Duplicate_Item);
            this.EnemyBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lst_MouseDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Enabled = false;
            this.label12.Location = new System.Drawing.Point(303, 190);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 43;
            this.label12.Text = "PLMs";
            // 
            // PlmBox
            // 
            this.PlmBox.AllowDrop = true;
            this.PlmBox.ContextMenuStrip = this.DataListMenu;
            this.PlmBox.FormattingEnabled = true;
            this.PlmBox.Location = new System.Drawing.Point(305, 202);
            this.PlmBox.Name = "PlmBox";
            this.PlmBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.PlmBox.Size = new System.Drawing.Size(96, 56);
            this.PlmBox.TabIndex = 42;
            this.PlmBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.lst_DragDrop);
            this.PlmBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.lst_DragEnter);
            this.PlmBox.DragOver += new System.Windows.Forms.DragEventHandler(this.lst_DragOver);
            this.PlmBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Duplicate_Item);
            this.PlmBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lst_MouseDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Enabled = false;
            this.label13.Location = new System.Drawing.Point(303, 262);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 13);
            this.label13.TabIndex = 45;
            this.label13.Text = "FX";
            // 
            // FXbox
            // 
            this.FXbox.AllowDrop = true;
            this.FXbox.ContextMenuStrip = this.DataListMenu;
            this.FXbox.FormattingEnabled = true;
            this.FXbox.Location = new System.Drawing.Point(305, 275);
            this.FXbox.Name = "FXbox";
            this.FXbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.FXbox.Size = new System.Drawing.Size(96, 56);
            this.FXbox.TabIndex = 44;
            this.FXbox.DragDrop += new System.Windows.Forms.DragEventHandler(this.lst_DragDrop);
            this.FXbox.DragEnter += new System.Windows.Forms.DragEventHandler(this.lst_DragEnter);
            this.FXbox.DragOver += new System.Windows.Forms.DragEventHandler(this.lst_DragOver);
            this.FXbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Duplicate_Item);
            this.FXbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lst_MouseDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.Location = new System.Drawing.Point(303, 335);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 47;
            this.label14.Text = "Doors";
            // 
            // DoorBox
            // 
            this.DoorBox.AllowDrop = true;
            this.DoorBox.ContextMenuStrip = this.DataListMenu;
            this.DoorBox.FormattingEnabled = true;
            this.DoorBox.Location = new System.Drawing.Point(305, 348);
            this.DoorBox.Name = "DoorBox";
            this.DoorBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.DoorBox.Size = new System.Drawing.Size(96, 56);
            this.DoorBox.TabIndex = 46;
            this.DoorBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.lst_DragDrop);
            this.DoorBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.lst_DragEnter);
            this.DoorBox.DragOver += new System.Windows.Forms.DragEventHandler(this.lst_DragOver);
            this.DoorBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Duplicate_Item);
            this.DoorBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lst_MouseDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Enabled = false;
            this.label15.Location = new System.Drawing.Point(302, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 49;
            this.label15.Text = "Enemy GFX";
            // 
            // GFXbox
            // 
            this.GFXbox.AllowDrop = true;
            this.GFXbox.ContextMenuStrip = this.DataListMenu;
            this.GFXbox.FormattingEnabled = true;
            this.GFXbox.Location = new System.Drawing.Point(305, 131);
            this.GFXbox.Name = "GFXbox";
            this.GFXbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.GFXbox.Size = new System.Drawing.Size(96, 56);
            this.GFXbox.TabIndex = 48;
            this.GFXbox.DragDrop += new System.Windows.Forms.DragEventHandler(this.lst_DragDrop);
            this.GFXbox.DragEnter += new System.Windows.Forms.DragEventHandler(this.lst_DragEnter);
            this.GFXbox.DragOver += new System.Windows.Forms.DragEventHandler(this.lst_DragOver);
            this.GFXbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Duplicate_Item);
            this.GFXbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lst_MouseDown);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(162, 226);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(121, 41);
            this.ApplyButton.TabIndex = 50;
            this.ApplyButton.Text = "Apply to ROM";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // StatusBox
            // 
            this.StatusBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.StatusBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBox.ForeColor = System.Drawing.SystemColors.Window;
            this.StatusBox.Location = new System.Drawing.Point(407, 56);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(231, 423);
            this.StatusBox.TabIndex = 51;
            this.StatusBox.Text = "";
            this.StatusBox.TextChanged += new System.EventHandler(this.StatusBox_TextChanged);
            // 
            // DelMDB
            // 
            this.DelMDB.AutoSize = true;
            this.DelMDB.Checked = true;
            this.DelMDB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DelMDB.Location = new System.Drawing.Point(12, 359);
            this.DelMDB.Name = "DelMDB";
            this.DelMDB.Size = new System.Drawing.Size(167, 30);
            this.DelMDB.TabIndex = 52;
            this.DelMDB.Text = "On Apply: Delete MDB entries\r\nif not in ASM file";
            this.DelMDB.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Level Data Buffer";
            // 
            // LevelBuffer
            // 
            this.LevelBuffer.Location = new System.Drawing.Point(12, 330);
            this.LevelBuffer.MaxLength = 4;
            this.LevelBuffer.Name = "LevelBuffer";
            this.LevelBuffer.Size = new System.Drawing.Size(56, 20);
            this.LevelBuffer.TabIndex = 53;
            this.LevelBuffer.Text = "1000";
            // 
            // ImportCurrentTileset
            // 
            this.ImportCurrentTileset.Location = new System.Drawing.Point(162, 287);
            this.ImportCurrentTileset.Name = "ImportCurrentTileset";
            this.ImportCurrentTileset.Size = new System.Drawing.Size(121, 41);
            this.ImportCurrentTileset.TabIndex = 55;
            this.ImportCurrentTileset.Text = "Current Tileset Folder to ASM";
            this.ImportCurrentTileset.UseVisualStyleBackColor = true;
            this.ImportCurrentTileset.Click += new System.EventHandler(this.ImportCurrentTileset_Click);
            // 
            // ExportCurrentTileset
            // 
            this.ExportCurrentTileset.Location = new System.Drawing.Point(162, 334);
            this.ExportCurrentTileset.Name = "ExportCurrentTileset";
            this.ExportCurrentTileset.Size = new System.Drawing.Size(121, 19);
            this.ExportCurrentTileset.TabIndex = 56;
            this.ExportCurrentTileset.Text = "ROM to TSet Folder";
            this.ExportCurrentTileset.UseVisualStyleBackColor = true;
            this.ExportCurrentTileset.Click += new System.EventHandler(this.ExportCurrentTileset_Click);
            // 
            // RefreshExport
            // 
            this.RefreshExport.Location = new System.Drawing.Point(162, 131);
            this.RefreshExport.Name = "RefreshExport";
            this.RefreshExport.Size = new System.Drawing.Size(121, 41);
            this.RefreshExport.TabIndex = 57;
            this.RefreshExport.Text = "Refresh from ROM and Export to ASM";
            this.RefreshExport.UseVisualStyleBackColor = true;
            this.RefreshExport.Click += new System.EventHandler(this.RefreshExport_Click);
            // 
            // RoomLoadTimeStamp
            // 
            this.RoomLoadTimeStamp.AutoSize = true;
            this.RoomLoadTimeStamp.Location = new System.Drawing.Point(116, 131);
            this.RoomLoadTimeStamp.Name = "RoomLoadTimeStamp";
            this.RoomLoadTimeStamp.Size = new System.Drawing.Size(37, 13);
            this.RoomLoadTimeStamp.TabIndex = 58;
            this.RoomLoadTimeStamp.Text = "          ";
            // 
            // bitshift
            // 
            this.bitshift.Location = new System.Drawing.Point(304, 418);
            this.bitshift.Name = "bitshift";
            this.bitshift.Size = new System.Drawing.Size(97, 21);
            this.bitshift.TabIndex = 60;
            this.bitshift.Text = "test";
            this.bitshift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bitshift.UseVisualStyleBackColor = true;
            this.bitshift.Click += new System.EventHandler(this.bitshift_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Enabled = false;
            this.label16.Location = new System.Drawing.Point(120, 282);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 62;
            this.label16.Text = "Tileset";
            // 
            // TilesetBox
            // 
            this.TilesetBox.Enabled = false;
            this.TilesetBox.Location = new System.Drawing.Point(126, 298);
            this.TilesetBox.MaxLength = 2;
            this.TilesetBox.Name = "TilesetBox";
            this.TilesetBox.Size = new System.Drawing.Size(29, 20);
            this.TilesetBox.TabIndex = 61;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Enabled = false;
            this.label17.Location = new System.Drawing.Point(404, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 63;
            this.label17.Text = "Status";
            // 
            // alltopCheckbox
            // 
            this.alltopCheckbox.AutoSize = true;
            this.alltopCheckbox.Location = new System.Drawing.Point(12, 388);
            this.alltopCheckbox.Name = "alltopCheckbox";
            this.alltopCheckbox.Size = new System.Drawing.Size(96, 17);
            this.alltopCheckbox.TabIndex = 3;
            this.alltopCheckbox.Text = "Always on Top";
            this.alltopCheckbox.UseVisualStyleBackColor = true;
            this.alltopCheckbox.CheckedChanged += new System.EventHandler(this.alltopCheckbox_CheckedChanged);
            // 
            // SMASM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 491);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.TilesetBox);
            this.Controls.Add(this.bitshift);
            this.Controls.Add(this.RefreshExport);
            this.Controls.Add(this.ExportCurrentTileset);
            this.Controls.Add(this.ImportCurrentTileset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LevelBuffer);
            this.Controls.Add(this.DelMDB);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.PlmBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.GFXbox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.DoorBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.FXbox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.EnemyBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.StateBox);
            this.Controls.Add(this.ASMbutton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DnScroller);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.RoomHeight);
            this.Controls.Add(this.MapYLabel);
            this.Controls.Add(this.MapY);
            this.Controls.Add(this.AreaLabel);
            this.Controls.Add(this.AreaIndex);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SpecialGFX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.UpScroller);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RoomWidth);
            this.Controls.Add(this.MapXLabel);
            this.Controls.Add(this.MapX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RoomIndex);
            this.Controls.Add(this.HeaderLabel);
            this.Controls.Add(this.HeaderBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lorombox);
            this.Controls.Add(this.pcBox);
            this.Controls.Add(this.alltopCheckbox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.RoomLoadTimeStamp);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(700, 530);
            this.MinimumSize = new System.Drawing.Size(420, 530);
            this.Name = "SMASM";
            this.Text = "SM-ASM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SMASM_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.StateMenuStrip.ResumeLayout(false);
            this.DataListMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filePathsToolStripMenuItem;
        private System.Windows.Forms.TextBox pcBox;
        private System.Windows.Forms.TextBox lorombox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.TextBox HeaderBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RoomIndex;
        private System.Windows.Forms.Label MapXLabel;
        private System.Windows.Forms.TextBox MapX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox RoomWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox UpScroller;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox SpecialGFX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox DnScroller;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox RoomHeight;
        private System.Windows.Forms.Label MapYLabel;
        private System.Windows.Forms.TextBox MapY;
        private System.Windows.Forms.Label AreaLabel;
        private System.Windows.Forms.TextBox AreaIndex;
        private System.Windows.Forms.Button ASMbutton;
        private System.Windows.Forms.ListBox StateBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox EnemyBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox PlmBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox FXbox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox DoorBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox GFXbox;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.RichTextBox StatusBox;
        private System.Windows.Forms.ContextMenuStrip DataListMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteButton;
        private System.Windows.Forms.ToolStripMenuItem BlockCopy;
        private System.Windows.Forms.ToolStripMenuItem NewItem;
        private System.Windows.Forms.CheckBox DelMDB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LevelBuffer;
        private System.Windows.Forms.ContextMenuStrip StateMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem AddStateButton;
        private System.Windows.Forms.ToolStripMenuItem tilesetSetupToolStripMenuItem;
        private System.Windows.Forms.Button ImportCurrentTileset;
        private System.Windows.Forms.Button ExportCurrentTileset;
        private System.Windows.Forms.Button RefreshExport;
        private System.Windows.Forms.Label RoomLoadTimeStamp;
        private System.Windows.Forms.Button bitshift;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TilesetBox;
        private System.Windows.Forms.ToolStripMenuItem tilesetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilesetFoldersToASMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rOMToTilesetFoldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ToolStripMenuItem currentRoomToNewASMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeRoomFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mDBListToASMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem slimGUIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createMapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thisRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromMDBListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox alltopCheckbox;
    }
}
