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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMASM));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBlankRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentRoomToNewASMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCurrentRoomFromASMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeRoomFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mDBListToASMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialDoorIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialItemIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportLinkedRoomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshRoomFromROMF5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filePathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetFoldersToASMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rOMToTilesetFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slimGUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thisRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areasFromMDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.walkthoughToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importLevelDataFromBMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HeaderLabel = new System.Windows.Forms.Label();
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
            this.OpenRoomViaDoor = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteButton = new System.Windows.Forms.ToolStripMenuItem();
            this.BlockCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.NewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScrollPLMedit = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToGFXList = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToEnemyList = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specifiyIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ImportCurrentTileset = new System.Windows.Forms.Button();
            this.ExportCurrentTileset = new System.Windows.Forms.Button();
            this.RefreshExport = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.TilesetBox = new System.Windows.Forms.TextBox();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.label17 = new System.Windows.Forms.Label();
            this.LevelPicMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditLevelScrollsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.alltopCheckbox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LevelBuffer = new System.Windows.Forms.TextBox();
            this.DelMDB = new System.Windows.Forms.CheckBox();
            this.ZoomPicIn = new System.Windows.Forms.Button();
            this.ZoomPicOut = new System.Windows.Forms.Button();
            this.HeaderDropdown = new System.Windows.Forms.ComboBox();
            this.OpenMDB = new System.Windows.Forms.Button();
            this.testbutton = new System.Windows.Forms.Button();
            this.HeaderInfo = new System.Windows.Forms.GroupBox();
            this.RoomPicture = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.StateMenuStrip.SuspendLayout();
            this.DataListMenu.SuspendLayout();
            this.LevelPicMenu.SuspendLayout();
            this.HeaderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomPicture)).BeginInit();
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
            this.helpToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(681, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadBlankRoomToolStripMenuItem,
            this.currentRoomToNewASMToolStripMenuItem,
            this.deleteCurrentRoomFromASMToolStripMenuItem,
            this.mergeRoomFilesToolStripMenuItem,
            this.mDBListToASMToolStripMenuItem,
            this.specialDoorIDToolStripMenuItem,
            this.specialItemIDToolStripMenuItem,
            this.exportLinkedRoomsToolStripMenuItem,
            this.refreshRoomFromROMF5ToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.fileToolStripMenuItem.Text = "ASM";
            // 
            // loadBlankRoomToolStripMenuItem
            // 
            this.loadBlankRoomToolStripMenuItem.Name = "loadBlankRoomToolStripMenuItem";
            this.loadBlankRoomToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.loadBlankRoomToolStripMenuItem.Text = "Load Blank Room";
            this.loadBlankRoomToolStripMenuItem.Click += new System.EventHandler(this.loadBlankRoomToolStripMenuItem_Click);
            // 
            // currentRoomToNewASMToolStripMenuItem
            // 
            this.currentRoomToNewASMToolStripMenuItem.Name = "currentRoomToNewASMToolStripMenuItem";
            this.currentRoomToNewASMToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.currentRoomToNewASMToolStripMenuItem.Text = "Current Room to New ASM";
            this.currentRoomToNewASMToolStripMenuItem.Click += new System.EventHandler(this.currentRoomToNewASMToolStripMenuItem_Click);
            // 
            // deleteCurrentRoomFromASMToolStripMenuItem
            // 
            this.deleteCurrentRoomFromASMToolStripMenuItem.Name = "deleteCurrentRoomFromASMToolStripMenuItem";
            this.deleteCurrentRoomFromASMToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.deleteCurrentRoomFromASMToolStripMenuItem.Text = "Delete Current Room from ASM";
            this.deleteCurrentRoomFromASMToolStripMenuItem.Click += new System.EventHandler(this.deleteCurrentRoomFromASMToolStripMenuItem_Click);
            // 
            // mergeRoomFilesToolStripMenuItem
            // 
            this.mergeRoomFilesToolStripMenuItem.Name = "mergeRoomFilesToolStripMenuItem";
            this.mergeRoomFilesToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.mergeRoomFilesToolStripMenuItem.Text = "Merge Room Files";
            this.mergeRoomFilesToolStripMenuItem.Click += new System.EventHandler(this.mergeRoomFilesToolStripMenuItem_Click);
            // 
            // mDBListToASMToolStripMenuItem
            // 
            this.mDBListToASMToolStripMenuItem.Name = "mDBListToASMToolStripMenuItem";
            this.mDBListToASMToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.mDBListToASMToolStripMenuItem.Text = "MDB List to ASM";
            this.mDBListToASMToolStripMenuItem.Click += new System.EventHandler(this.mDBListToASMToolStripMenuItem_Click);
            // 
            // specialDoorIDToolStripMenuItem
            // 
            this.specialDoorIDToolStripMenuItem.Name = "specialDoorIDToolStripMenuItem";
            this.specialDoorIDToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.specialDoorIDToolStripMenuItem.Text = "Special Door ID";
            this.specialDoorIDToolStripMenuItem.Click += new System.EventHandler(this.specialDoorIDToolStripMenuItem_Click);
            // 
            // specialItemIDToolStripMenuItem
            // 
            this.specialItemIDToolStripMenuItem.Name = "specialItemIDToolStripMenuItem";
            this.specialItemIDToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.specialItemIDToolStripMenuItem.Text = "Special Item ID";
            this.specialItemIDToolStripMenuItem.Click += new System.EventHandler(this.specialItemIDToolStripMenuItem_Click);
            // 
            // exportLinkedRoomsToolStripMenuItem
            // 
            this.exportLinkedRoomsToolStripMenuItem.Name = "exportLinkedRoomsToolStripMenuItem";
            this.exportLinkedRoomsToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.exportLinkedRoomsToolStripMenuItem.Text = "Export Linked Rooms";
            this.exportLinkedRoomsToolStripMenuItem.ToolTipText = "Bulk export all rooms in door list of current room.";
            this.exportLinkedRoomsToolStripMenuItem.Click += new System.EventHandler(this.exportLinkedRoomsToolStripMenuItem_Click);
            // 
            // refreshRoomFromROMF5ToolStripMenuItem
            // 
            this.refreshRoomFromROMF5ToolStripMenuItem.Name = "refreshRoomFromROMF5ToolStripMenuItem";
            this.refreshRoomFromROMF5ToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.refreshRoomFromROMF5ToolStripMenuItem.Text = "Refresh Room from ROM (F5)";
            this.refreshRoomFromROMF5ToolStripMenuItem.Click += new System.EventHandler(this.Dropdown_LoadRoom);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filePathsToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // filePathsToolStripMenuItem
            // 
            this.filePathsToolStripMenuItem.Name = "filePathsToolStripMenuItem";
            this.filePathsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.filePathsToolStripMenuItem.Text = "File Paths";
            this.filePathsToolStripMenuItem.Click += new System.EventHandler(this.FilePaths_Open);
            // 
            // tilesetsToolStripMenuItem
            // 
            this.tilesetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tilesetFoldersToASMToolStripMenuItem,
            this.rOMToTilesetFoldersToolStripMenuItem});
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
            this.thisRoomToolStripMenuItem,
            this.areasFromMDBToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.editToolStripMenuItem.Text = "Mapping";
            // 
            // thisRoomToolStripMenuItem
            // 
            this.thisRoomToolStripMenuItem.Name = "thisRoomToolStripMenuItem";
            this.thisRoomToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.thisRoomToolStripMenuItem.Text = "This Room";
            this.thisRoomToolStripMenuItem.Click += new System.EventHandler(this.thisRoomToolStripMenuItem_Click);
            // 
            // areasFromMDBToolStripMenuItem
            // 
            this.areasFromMDBToolStripMenuItem.Name = "areasFromMDBToolStripMenuItem";
            this.areasFromMDBToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.areasFromMDBToolStripMenuItem.Text = "Areas from MDB";
            this.areasFromMDBToolStripMenuItem.Click += new System.EventHandler(this.fromMDBListToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.walkthoughToolStripMenuItem,
            this.creditsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Enabled = false;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Visible = false;
            // 
            // walkthoughToolStripMenuItem
            // 
            this.walkthoughToolStripMenuItem.Name = "walkthoughToolStripMenuItem";
            this.walkthoughToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.walkthoughToolStripMenuItem.Text = "Walkthough";
            this.walkthoughToolStripMenuItem.Click += new System.EventHandler(this.walkthoughToolStripMenuItem_Click);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importLevelDataFromBMPToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // importLevelDataFromBMPToolStripMenuItem
            // 
            this.importLevelDataFromBMPToolStripMenuItem.Name = "importLevelDataFromBMPToolStripMenuItem";
            this.importLevelDataFromBMPToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.importLevelDataFromBMPToolStripMenuItem.Text = "Import Level Data from BMP";
            this.importLevelDataFromBMPToolStripMenuItem.Click += new System.EventHandler(this.importLevelDataFromBMPToolStripMenuItem_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Room Index";
            // 
            // RoomIndex
            // 
            this.RoomIndex.Location = new System.Drawing.Point(8, 18);
            this.RoomIndex.MaxLength = 2;
            this.RoomIndex.Name = "RoomIndex";
            this.RoomIndex.Size = new System.Drawing.Size(29, 20);
            this.RoomIndex.TabIndex = 11;
            this.RoomIndex.TextChanged += new System.EventHandler(this.AllowHexOnlyTEXTBOX);
            this.RoomIndex.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            this.RoomIndex.Validated += new System.EventHandler(this.RoomIndex_Validated);
            // 
            // MapXLabel
            // 
            this.MapXLabel.AutoSize = true;
            this.MapXLabel.Location = new System.Drawing.Point(17, 123);
            this.MapXLabel.Name = "MapXLabel";
            this.MapXLabel.Size = new System.Drawing.Size(38, 13);
            this.MapXLabel.TabIndex = 14;
            this.MapXLabel.Text = "Map X";
            // 
            // MapX
            // 
            this.MapX.Location = new System.Drawing.Point(8, 56);
            this.MapX.MaxLength = 2;
            this.MapX.Name = "MapX";
            this.MapX.Size = new System.Drawing.Size(29, 20);
            this.MapX.TabIndex = 13;
            this.MapX.TextChanged += new System.EventHandler(this.AllowHexOnlyTEXTBOX);
            this.MapX.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            this.MapX.Validated += new System.EventHandler(this.RoomHeader_Change);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(17, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Width";
            // 
            // RoomWidth
            // 
            this.RoomWidth.Enabled = false;
            this.RoomWidth.Location = new System.Drawing.Point(8, 97);
            this.RoomWidth.MaxLength = 2;
            this.RoomWidth.Name = "RoomWidth";
            this.RoomWidth.Size = new System.Drawing.Size(29, 20);
            this.RoomWidth.TabIndex = 15;
            this.RoomWidth.TextChanged += new System.EventHandler(this.AllowHexOnlyTEXTBOX);
            this.RoomWidth.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            this.RoomWidth.Validated += new System.EventHandler(this.RoomHeader_Change);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "U Scroller";
            // 
            // UpScroller
            // 
            this.UpScroller.Location = new System.Drawing.Point(8, 145);
            this.UpScroller.MaxLength = 2;
            this.UpScroller.Name = "UpScroller";
            this.UpScroller.Size = new System.Drawing.Size(29, 20);
            this.UpScroller.TabIndex = 17;
            this.UpScroller.TextChanged += new System.EventHandler(this.AllowHexOnlyTEXTBOX);
            this.UpScroller.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            this.UpScroller.Validated += new System.EventHandler(this.RoomHeader_Change);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Special GFX";
            // 
            // SpecialGFX
            // 
            this.SpecialGFX.Location = new System.Drawing.Point(8, 188);
            this.SpecialGFX.MaxLength = 2;
            this.SpecialGFX.Name = "SpecialGFX";
            this.SpecialGFX.Size = new System.Drawing.Size(29, 20);
            this.SpecialGFX.TabIndex = 19;
            this.SpecialGFX.TextChanged += new System.EventHandler(this.AllowHexOnlyTEXTBOX);
            this.SpecialGFX.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            this.SpecialGFX.Validated += new System.EventHandler(this.RoomHeader_Change);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(88, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "D Scroller";
            // 
            // DnScroller
            // 
            this.DnScroller.Location = new System.Drawing.Point(79, 145);
            this.DnScroller.MaxLength = 2;
            this.DnScroller.Name = "DnScroller";
            this.DnScroller.Size = new System.Drawing.Size(29, 20);
            this.DnScroller.TabIndex = 27;
            this.DnScroller.TextChanged += new System.EventHandler(this.AllowHexOnlyTEXTBOX);
            this.DnScroller.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            this.DnScroller.Validated += new System.EventHandler(this.RoomHeader_Change);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(88, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Height";
            // 
            // RoomHeight
            // 
            this.RoomHeight.Enabled = false;
            this.RoomHeight.Location = new System.Drawing.Point(79, 97);
            this.RoomHeight.MaxLength = 2;
            this.RoomHeight.Name = "RoomHeight";
            this.RoomHeight.Size = new System.Drawing.Size(29, 20);
            this.RoomHeight.TabIndex = 25;
            this.RoomHeight.TextChanged += new System.EventHandler(this.AllowHexOnlyTEXTBOX);
            this.RoomHeight.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            this.RoomHeight.Validated += new System.EventHandler(this.RoomHeader_Change);
            // 
            // MapYLabel
            // 
            this.MapYLabel.AutoSize = true;
            this.MapYLabel.Location = new System.Drawing.Point(88, 123);
            this.MapYLabel.Name = "MapYLabel";
            this.MapYLabel.Size = new System.Drawing.Size(38, 13);
            this.MapYLabel.TabIndex = 24;
            this.MapYLabel.Text = "Map Y";
            // 
            // MapY
            // 
            this.MapY.Location = new System.Drawing.Point(79, 56);
            this.MapY.MaxLength = 2;
            this.MapY.Name = "MapY";
            this.MapY.Size = new System.Drawing.Size(29, 20);
            this.MapY.TabIndex = 23;
            this.MapY.TextChanged += new System.EventHandler(this.AllowHexOnlyTEXTBOX);
            this.MapY.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            this.MapY.Validated += new System.EventHandler(this.RoomHeader_Change);
            // 
            // AreaLabel
            // 
            this.AreaLabel.AutoSize = true;
            this.AreaLabel.Location = new System.Drawing.Point(86, 84);
            this.AreaLabel.Name = "AreaLabel";
            this.AreaLabel.Size = new System.Drawing.Size(58, 13);
            this.AreaLabel.TabIndex = 22;
            this.AreaLabel.Text = "Area Index";
            // 
            // AreaIndex
            // 
            this.AreaIndex.Location = new System.Drawing.Point(79, 18);
            this.AreaIndex.MaxLength = 2;
            this.AreaIndex.Name = "AreaIndex";
            this.AreaIndex.Size = new System.Drawing.Size(29, 20);
            this.AreaIndex.TabIndex = 21;
            this.AreaIndex.TextChanged += new System.EventHandler(this.AllowHexOnlyTEXTBOX);
            this.AreaIndex.Validating += new System.ComponentModel.CancelEventHandler(this.HeaderData_Validating);
            this.AreaIndex.Validated += new System.EventHandler(this.RoomIndex_Validated);
            // 
            // ASMbutton
            // 
            this.ASMbutton.Location = new System.Drawing.Point(144, 178);
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
            this.StateBox.Size = new System.Drawing.Size(121, 69);
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
            this.OpenRoomViaDoor,
            this.DeleteButton,
            this.BlockCopy,
            this.NewItem,
            this.ScrollPLMedit,
            this.AddToGFXList,
            this.AddToEnemyList,
            this.MoveIndex});
            this.DataListMenu.Name = "contextMenuStrip1";
            this.DataListMenu.Size = new System.Drawing.Size(181, 202);
            this.DataListMenu.Opening += new System.ComponentModel.CancelEventHandler(this.DataListMenu_Opening);
            // 
            // OpenRoomViaDoor
            // 
            this.OpenRoomViaDoor.Name = "OpenRoomViaDoor";
            this.OpenRoomViaDoor.Size = new System.Drawing.Size(180, 22);
            this.OpenRoomViaDoor.Text = "Open Room";
            this.OpenRoomViaDoor.Click += new System.EventHandler(this.openRoomToolStripMenuItem_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(180, 22);
            this.DeleteButton.Text = "Delete Item";
            this.DeleteButton.Click += new System.EventHandler(this.BlockDelete_Click);
            // 
            // BlockCopy
            // 
            this.BlockCopy.Name = "BlockCopy";
            this.BlockCopy.Size = new System.Drawing.Size(180, 22);
            this.BlockCopy.Text = "Duplicate";
            this.BlockCopy.Click += new System.EventHandler(this.BlockCopy_Click);
            // 
            // NewItem
            // 
            this.NewItem.Name = "NewItem";
            this.NewItem.Size = new System.Drawing.Size(180, 22);
            this.NewItem.Text = "New Item";
            this.NewItem.Click += new System.EventHandler(this.NewItem_Click);
            // 
            // ScrollPLMedit
            // 
            this.ScrollPLMedit.Name = "ScrollPLMedit";
            this.ScrollPLMedit.Size = new System.Drawing.Size(180, 22);
            this.ScrollPLMedit.Text = "Edit Scroll PLMs";
            this.ScrollPLMedit.Visible = false;
            this.ScrollPLMedit.Click += new System.EventHandler(this.ScrollPLMedit_Click);
            // 
            // AddToGFXList
            // 
            this.AddToGFXList.Name = "AddToGFXList";
            this.AddToGFXList.Size = new System.Drawing.Size(180, 22);
            this.AddToGFXList.Text = "Add to GFX List";
            this.AddToGFXList.Visible = false;
            this.AddToGFXList.Click += new System.EventHandler(this.AddToGFXList_Click);
            // 
            // AddToEnemyList
            // 
            this.AddToEnemyList.Name = "AddToEnemyList";
            this.AddToEnemyList.Size = new System.Drawing.Size(180, 22);
            this.AddToEnemyList.Text = "Add to Enemy List";
            this.AddToEnemyList.Visible = false;
            this.AddToEnemyList.Click += new System.EventHandler(this.AddToEnemyList_Click);
            // 
            // MoveIndex
            // 
            this.MoveIndex.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToTopToolStripMenuItem,
            this.sendToBottomToolStripMenuItem,
            this.specifiyIndexToolStripMenuItem});
            this.MoveIndex.Enabled = false;
            this.MoveIndex.Name = "MoveIndex";
            this.MoveIndex.Size = new System.Drawing.Size(180, 22);
            this.MoveIndex.Text = "Move Index";
            // 
            // sendToTopToolStripMenuItem
            // 
            this.sendToTopToolStripMenuItem.Name = "sendToTopToolStripMenuItem";
            this.sendToTopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendToTopToolStripMenuItem.Text = "Send to Top";
            this.sendToTopToolStripMenuItem.Click += new System.EventHandler(this.sendToTopToolStripMenuItem_Click);
            // 
            // sendToBottomToolStripMenuItem
            // 
            this.sendToBottomToolStripMenuItem.Name = "sendToBottomToolStripMenuItem";
            this.sendToBottomToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendToBottomToolStripMenuItem.Text = "Send to Bottom";
            // 
            // specifiyIndexToolStripMenuItem
            // 
            this.specifiyIndexToolStripMenuItem.Name = "specifiyIndexToolStripMenuItem";
            this.specifiyIndexToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.specifiyIndexToolStripMenuItem.Text = "Specifiy Index";
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
            this.ApplyButton.Location = new System.Drawing.Point(144, 226);
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
            this.StatusBox.Size = new System.Drawing.Size(231, 348);
            this.StatusBox.TabIndex = 51;
            this.StatusBox.Text = "";
            this.StatusBox.TextChanged += new System.EventHandler(this.StatusBox_TextChanged);
            // 
            // ImportCurrentTileset
            // 
            this.ImportCurrentTileset.Location = new System.Drawing.Point(144, 273);
            this.ImportCurrentTileset.Name = "ImportCurrentTileset";
            this.ImportCurrentTileset.Size = new System.Drawing.Size(121, 41);
            this.ImportCurrentTileset.TabIndex = 55;
            this.ImportCurrentTileset.Text = "Current Tileset Folder to ASM";
            this.ImportCurrentTileset.UseVisualStyleBackColor = true;
            this.ImportCurrentTileset.Click += new System.EventHandler(this.ImportCurrentTileset_Click);
            // 
            // ExportCurrentTileset
            // 
            this.ExportCurrentTileset.Location = new System.Drawing.Point(144, 320);
            this.ExportCurrentTileset.Name = "ExportCurrentTileset";
            this.ExportCurrentTileset.Size = new System.Drawing.Size(121, 19);
            this.ExportCurrentTileset.TabIndex = 56;
            this.ExportCurrentTileset.Text = "ROM to TSet Folder";
            this.ExportCurrentTileset.UseVisualStyleBackColor = true;
            this.ExportCurrentTileset.Click += new System.EventHandler(this.ExportCurrentTileset_Click);
            // 
            // RefreshExport
            // 
            this.RefreshExport.Location = new System.Drawing.Point(144, 131);
            this.RefreshExport.Name = "RefreshExport";
            this.RefreshExport.Size = new System.Drawing.Size(121, 41);
            this.RefreshExport.TabIndex = 57;
            this.RefreshExport.Text = "Refresh from ROM and Export to ASM";
            this.RefreshExport.UseVisualStyleBackColor = true;
            this.RefreshExport.Click += new System.EventHandler(this.RefreshExport_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Enabled = false;
            this.label16.Location = new System.Drawing.Point(86, 254);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 62;
            this.label16.Text = "Tileset";
            // 
            // TilesetBox
            // 
            this.TilesetBox.Enabled = false;
            this.TilesetBox.Location = new System.Drawing.Point(79, 188);
            this.TilesetBox.MaxLength = 2;
            this.TilesetBox.Name = "TilesetBox";
            this.TilesetBox.Size = new System.Drawing.Size(29, 20);
            this.TilesetBox.TabIndex = 61;
            this.TilesetBox.TextChanged += new System.EventHandler(this.AllowHexOnlyTEXTBOX);
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
            // LevelPicMenu
            // 
            this.LevelPicMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.LevelPicMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditLevelScrollsButton});
            this.LevelPicMenu.Name = "contextMenuStrip1";
            this.LevelPicMenu.Size = new System.Drawing.Size(162, 26);
            this.LevelPicMenu.Opening += new System.ComponentModel.CancelEventHandler(this.StateMenuStrip_Opening);
            // 
            // EditLevelScrollsButton
            // 
            this.EditLevelScrollsButton.Name = "EditLevelScrollsButton";
            this.EditLevelScrollsButton.Size = new System.Drawing.Size(161, 22);
            this.EditLevelScrollsButton.Text = "Edit Level Scrolls";
            this.EditLevelScrollsButton.Click += new System.EventHandler(this.EditLevelScrollsButton_Click);
            // 
            // alltopCheckbox
            // 
            this.alltopCheckbox.AutoSize = true;
            this.alltopCheckbox.Location = new System.Drawing.Point(644, 358);
            this.alltopCheckbox.Name = "alltopCheckbox";
            this.alltopCheckbox.Size = new System.Drawing.Size(96, 17);
            this.alltopCheckbox.TabIndex = 3;
            this.alltopCheckbox.Text = "Always on Top";
            this.alltopCheckbox.UseVisualStyleBackColor = true;
            this.alltopCheckbox.Visible = false;
            this.alltopCheckbox.CheckedChanged += new System.EventHandler(this.alltopCheckbox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(642, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Level Data Buffer";
            this.label4.Visible = false;
            // 
            // LevelBuffer
            // 
            this.LevelBuffer.Location = new System.Drawing.Point(644, 398);
            this.LevelBuffer.MaxLength = 4;
            this.LevelBuffer.Name = "LevelBuffer";
            this.LevelBuffer.Size = new System.Drawing.Size(56, 20);
            this.LevelBuffer.TabIndex = 53;
            this.LevelBuffer.Text = "1000";
            this.LevelBuffer.Visible = false;
            // 
            // DelMDB
            // 
            this.DelMDB.AutoSize = true;
            this.DelMDB.Checked = true;
            this.DelMDB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DelMDB.Location = new System.Drawing.Point(644, 322);
            this.DelMDB.Name = "DelMDB";
            this.DelMDB.Size = new System.Drawing.Size(167, 30);
            this.DelMDB.TabIndex = 52;
            this.DelMDB.Text = "On Apply: Delete MDB entries\r\nif not in ASM file";
            this.DelMDB.UseVisualStyleBackColor = true;
            this.DelMDB.Visible = false;
            // 
            // ZoomPicIn
            // 
            this.ZoomPicIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomPicIn.Location = new System.Drawing.Point(110, 297);
            this.ZoomPicIn.Name = "ZoomPicIn";
            this.ZoomPicIn.Size = new System.Drawing.Size(29, 27);
            this.ZoomPicIn.TabIndex = 65;
            this.ZoomPicIn.Text = "+";
            this.ZoomPicIn.UseVisualStyleBackColor = true;
            this.ZoomPicIn.Click += new System.EventHandler(this.ZoomPicIn_Click);
            // 
            // ZoomPicOut
            // 
            this.ZoomPicOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomPicOut.Location = new System.Drawing.Point(110, 323);
            this.ZoomPicOut.Name = "ZoomPicOut";
            this.ZoomPicOut.Size = new System.Drawing.Size(29, 27);
            this.ZoomPicOut.TabIndex = 66;
            this.ZoomPicOut.Text = "-";
            this.ZoomPicOut.UseVisualStyleBackColor = true;
            this.ZoomPicOut.Click += new System.EventHandler(this.ZoomPicOut_Click);
            // 
            // HeaderDropdown
            // 
            this.HeaderDropdown.FormattingEnabled = true;
            this.HeaderDropdown.Location = new System.Drawing.Point(12, 56);
            this.HeaderDropdown.MaxLength = 5;
            this.HeaderDropdown.Name = "HeaderDropdown";
            this.HeaderDropdown.Size = new System.Drawing.Size(121, 21);
            this.HeaderDropdown.TabIndex = 1;
            this.HeaderDropdown.DropDown += new System.EventHandler(this.HeaderDropdown_DropDown);
            this.HeaderDropdown.SelectedIndexChanged += new System.EventHandler(this.HeaderDropdown_SelectedIndexChanged);
            this.HeaderDropdown.TextChanged += new System.EventHandler(this.HeaderDropdown_TextChanged);
            this.HeaderDropdown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HeaderBox_KeyDown);
            this.HeaderDropdown.Validated += new System.EventHandler(this.Dropdown_LoadRoom);
            // 
            // OpenMDB
            // 
            this.OpenMDB.Location = new System.Drawing.Point(109, 32);
            this.OpenMDB.Name = "OpenMDB";
            this.OpenMDB.Size = new System.Drawing.Size(24, 21);
            this.OpenMDB.TabIndex = 67;
            this.OpenMDB.Text = "M";
            this.OpenMDB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OpenMDB.UseVisualStyleBackColor = true;
            this.OpenMDB.Click += new System.EventHandler(this.OpenMDB_Click);
            // 
            // testbutton
            // 
            this.testbutton.Location = new System.Drawing.Point(447, 32);
            this.testbutton.Name = "testbutton";
            this.testbutton.Size = new System.Drawing.Size(85, 21);
            this.testbutton.TabIndex = 68;
            this.testbutton.Text = "test";
            this.testbutton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.testbutton.UseVisualStyleBackColor = true;
            this.testbutton.Visible = false;
            this.testbutton.Click += new System.EventHandler(this.testbutton_Click);
            // 
            // HeaderInfo
            // 
            this.HeaderInfo.Controls.Add(this.TilesetBox);
            this.HeaderInfo.Controls.Add(this.DnScroller);
            this.HeaderInfo.Controls.Add(this.RoomHeight);
            this.HeaderInfo.Controls.Add(this.MapY);
            this.HeaderInfo.Controls.Add(this.AreaIndex);
            this.HeaderInfo.Controls.Add(this.SpecialGFX);
            this.HeaderInfo.Controls.Add(this.UpScroller);
            this.HeaderInfo.Controls.Add(this.RoomWidth);
            this.HeaderInfo.Controls.Add(this.MapX);
            this.HeaderInfo.Controls.Add(this.RoomIndex);
            this.HeaderInfo.Location = new System.Drawing.Point(12, 81);
            this.HeaderInfo.Margin = new System.Windows.Forms.Padding(2);
            this.HeaderInfo.Name = "HeaderInfo";
            this.HeaderInfo.Padding = new System.Windows.Forms.Padding(2);
            this.HeaderInfo.Size = new System.Drawing.Size(128, 211);
            this.HeaderInfo.TabIndex = 69;
            this.HeaderInfo.TabStop = false;
            // 
            // RoomPicture
            // 
            this.RoomPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RoomPicture.ContextMenuStrip = this.LevelPicMenu;
            this.RoomPicture.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.RoomPicture.Location = new System.Drawing.Point(12, 298);
            this.RoomPicture.Name = "RoomPicture";
            this.RoomPicture.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.RoomPicture.Size = new System.Drawing.Size(100, 106);
            this.RoomPicture.TabIndex = 64;
            this.RoomPicture.TabStop = false;
            this.RoomPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RoomPicture_MouseMove);
            this.RoomPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RoomPicture_MouseUp);
            // 
            // SMASM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 409);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.testbutton);
            this.Controls.Add(this.MapYLabel);
            this.Controls.Add(this.OpenMDB);
            this.Controls.Add(this.HeaderDropdown);
            this.Controls.Add(this.ZoomPicOut);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ZoomPicIn);
            this.Controls.Add(this.RoomPicture);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.RefreshExport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ExportCurrentTileset);
            this.Controls.Add(this.ImportCurrentTileset);
            this.Controls.Add(this.MapXLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LevelBuffer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DelMDB);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.AreaLabel);
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
            this.Controls.Add(this.HeaderLabel);
            this.Controls.Add(this.alltopCheckbox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.HeaderInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(698, 448);
            this.MinimumSize = new System.Drawing.Size(420, 448);
            this.Name = "SMASM";
            this.Text = "SM-ASM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SMASM_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SMASM_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.StateMenuStrip.ResumeLayout(false);
            this.DataListMenu.ResumeLayout(false);
            this.LevelPicMenu.ResumeLayout(false);
            this.HeaderInfo.ResumeLayout(false);
            this.HeaderInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomPicture)).EndInit();
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
        private System.Windows.Forms.Label HeaderLabel;
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
        private System.Windows.Forms.ContextMenuStrip StateMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem AddStateButton;
        private System.Windows.Forms.Button ImportCurrentTileset;
        private System.Windows.Forms.Button ExportCurrentTileset;
        private System.Windows.Forms.Button RefreshExport;
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
        private System.Windows.Forms.ToolStripMenuItem slimGUIToolStripMenuItem;
        private System.Windows.Forms.PictureBox RoomPicture;
        private System.Windows.Forms.CheckBox alltopCheckbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LevelBuffer;
        private System.Windows.Forms.CheckBox DelMDB;
        private System.Windows.Forms.Button ZoomPicIn;
        private System.Windows.Forms.Button ZoomPicOut;
        private System.Windows.Forms.ToolStripMenuItem thisRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem areasFromMDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScrollPLMedit;
        private System.Windows.Forms.ContextMenuStrip LevelPicMenu;
        private System.Windows.Forms.ToolStripMenuItem EditLevelScrollsButton;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.ComboBox HeaderDropdown;
        private System.Windows.Forms.ToolStripMenuItem walkthoughToolStripMenuItem;
        private System.Windows.Forms.Button OpenMDB;
        private System.Windows.Forms.Button testbutton;
        private System.Windows.Forms.GroupBox HeaderInfo;
        private System.Windows.Forms.ToolStripMenuItem specialDoorIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specialItemIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCurrentRoomFromASMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadBlankRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importLevelDataFromBMPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportLinkedRoomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshRoomFromROMF5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddToGFXList;
        private System.Windows.Forms.ToolStripMenuItem AddToEnemyList;
        private System.Windows.Forms.ToolStripMenuItem MoveIndex;
        private System.Windows.Forms.ToolStripMenuItem sendToTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToBottomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specifiyIndexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenRoomViaDoor;
    }
}

