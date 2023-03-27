using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Diagnostics;



namespace SM_ASM_GUI
{
    public enum StateType : uint
    {
        Default = 0xE5E6,
        Door = 0xE5EB,
        BossMain = 0xE5FF,
        Event = 0xE612,
        BossChoose = 0xE629,
        GotMorph = 0xE640,
        GotMorphMissiles = 0xE652,
        GotPowerbomb = 0xE669,
        GotSpeed = 0xE678
    }
    public struct state
    {//will contain all the room pointers as SNES addresses.
        public unsafe state(ROM sm, uint statetype, uint statepointer, uint statearg, uint roomsize)
        {
            if (!LUNAR.OpenFile(sm.Path)) { MessageBox.Show("LUNAR ROM LOAD FAIL!"); }
            byte[] rom = sm.Rom;
            Type = statetype;
            DataPointer = statepointer;
            StateArg = statearg;

            uint i = statepointer;
            pLevelData = ROM.readLong(i, rom); i = i + 3;   //CHECK

            TileSet = rom[i]; i++;                          //CHECK
            SongSet = rom[i]; i++;                          //CHECK
            PlayInd = rom[i]; i++;                          //CHECK

            pFX = ROM.readWord(i, rom); i = i + 2;          
            pEnemySet = ROM.readWord(i, rom); i = i + 2;    //CHECK
            pEnemyGFX = ROM.readWord(i, rom); i = i + 2;    //CHECK

            BGxScroll = rom[i]; i++;                        //CHECK
            BGyScroll = rom[i]; i++;                        //CHECK

            pScrolls = ROM.readWord(i, rom); i = i + 2;     //CHECK
            pUnused = ROM.readWord(i, rom); i = i + 2;      //CHECK
            pMainASM = ROM.readWord(i, rom); i = i + 2;     //CHECK
            pPLMset = ROM.readWord(i, rom); i = i + 2;      //CHECK
            pBackground = ROM.readWord(i, rom); i = i + 2;  //CHECK
            pSetupASM = ROM.readWord(i, rom); i = i + 2;    //CHECK

            uint pcLevelPointer = LUNAR.SNEStoPC(pLevelData);
            uint addr2 = 0; //this will be assigned the end of the compressed data; compressed data size = addr2 - level data pointer
            byte[] levelUC = new byte[0xA000];    //reserve max level data size. Landing site is 0x5A00 bytes for reference.
            fixed (void* ptr = levelUC)
            LUNAR.Decompress(ptr, pcLevelPointer, &addr2);    //decompression takes a PC address.
            //levelUC is populated with uncompressed level data.

            byte[] levelC = new byte[0x5000];
            Buffer.BlockCopy(rom, (int)pcLevelPointer, levelC, 0, (int)(addr2 - pcLevelPointer));

            LevelDataUC = levelUC;
            LevelDataC  = levelC;
            LevelDataSizeUC = ROM.readWord(0,levelUC);
            LevelDataSizeC = addr2 - pcLevelPointer;

            LUNAR.CloseFile();

            //parse enemy set; cap at 0x20 entries; FFFF terminator.
            uint j = LUNAR.SNEStoPC(pEnemySet + 0xA10000);
            List<EnemyData> theseenemies = new List<EnemyData>();
            for (i = 0; i < 0x20; i++)
            {
                if (ROM.readWord(j, sm.Rom) == 0xFFFF) { break; }
                theseenemies.Add(new EnemyData(sm, j));
                j = j + 0x10;
            }
            Enemies = theseenemies;
            j += 2;
            //EnemyCount is the Enemies-to-Clear value.
            EnemyCount = sm.Rom[j];

            //parse enemy gfx set; cap at 4 entries; FFFF terminator.
            j = LUNAR.SNEStoPC(pEnemyGFX + 0xB40000);
            List<EnemyGFX> thesegfx = new List<EnemyGFX>();
            for (i = 0; i < 4; i++)
            {
                if (ROM.readWord(j, sm.Rom) == 0xFFFF) { break; }
                thesegfx.Add(new EnemyGFX(sm, j));
                j = j + 4;
            }
            EnemiesAllowed = thesegfx;

            //parse room PLM set; cap at d.40; 0000 terminator.
            j = LUNAR.SNEStoPC(pPLMset + 0x8F0000);
            List<PLMdata> theseplms = new List<PLMdata>();
            for (i = 0; i < 0x28; i++)
            {
                if (ROM.readWord(j, sm.Rom) == 0x0000) { break; }
                theseplms.Add(new PLMdata(sm, j));
                j += 6;
            }
            PLMs = theseplms;

            //parse scrolls for total number of screens in the room
            j = LUNAR.SNEStoPC(pScrolls + 0x8F0000);
            List<uint> thesescrolls = new List<uint>();    //the intial size of the list needs to be an int for some reason.
            for (i = 0; i < roomsize; i++)
            {
                thesescrolls.Add(sm.Rom[j]);
                j++;
            }
            Scrolls = thesescrolls.ToArray();

            //Parse FX Data. 16 Bytes each, terminated by a final entry with a Door Select of 0000.
            //Technically each door could have its own FX, so the FX limit is the door limit.
            //Also, a pointer will always contain at least the default room FX, so there will always be an entry.
            j = LUNAR.SNEStoPC(pFX + 0x830000);
            List<FXdata> theseFX = new List<FXdata>();
            for (i = 0; i < 0x100; i++)
            {
                if (ROM.readWord(j, sm.Rom) == 0x0000) { break; }
                theseFX.Add(new FXdata(sm, j));
                j += 0x10;
            }
            theseFX.Add(new FXdata(sm, j));
            FX = theseFX;

            pmLevelData = null;
                   pmFX = null;
             pmEnemySet = null;
             pmEnemyGFX = null;
              pmScrolls = null;
               pmPLMset = null;

            int argbytes;
            if (statetype == 0xE612 || statetype == 0xE629)
            {
                argbytes = 1;
            }     //events and boss bits take 1 byte arg
            else if (statetype == 0xE5EB)
            {
                argbytes = 2;
            }     //the door room state needs a special one for its two-byte arg.
            else if (statetype == 0xE5E6)
            {
                argbytes = -2;
            }     //default state lacks a pointer, so this adjusts the count accordingly.
            else
            {
                argbytes = 0;
            }

            //for determining level header size,
            //sum size of each state
            //plus default state
            //plus door data
            Bytes8F =
                argbytes +
                4 +     //Word state type and word state pointer are global
                26      //26 is size of mandatory pointer block in bytes
                ;

        }
        public uint Type { get; set; }
        public uint DataPointer { get; set; }
        public uint StateArg { get; set; }
        public int Bytes8F { get; set; }

        public uint[] Scrolls { get; }
        public uint LevelDataSizeUC { get; }
        public uint LevelDataSizeC { get; }
        public uint pLevelData { get; set; }
        public uint TileSet { get; set; }
        public uint SongSet { get; set; }
        public uint PlayInd { get; set; }
        public uint pFX { get; set; }
        public uint pEnemySet { get; set; }
        public uint pEnemyGFX { get; set; }
        public uint BGxScroll { get; set; }
        public uint BGyScroll { get; set; }
        public uint pScrolls { get; set; }
        public uint pUnused { get; set; }
        public uint pMainASM { get; set; }
        public uint pPLMset { get; set; }
        public uint pBackground { get; set; }
        public uint pSetupASM { get; set; }
        public byte[] LevelDataUC { get; }
        public byte[] LevelDataC { get; }
        public List<EnemyData> Enemies { get; set; }
        public uint EnemyCount { get; set; }
        public List<EnemyGFX> EnemiesAllowed { get; set; }
        public List<PLMdata> PLMs { get; set; }
        public List<FXdata> FX { get; set; }

        //might need to make pm versions of all the other pointers for the state configuration...
        public string pmLevelData {get; set;}
        public string pmFX { get; set; }
        public string pmEnemySet { get; set; }
        public string pmEnemyGFX { get; set; }
        public string pmScrolls { get; set; }
        public string pmPLMset { get; set; }
    }


    public struct roomdata
    {//contains top header properties and sub-structs for each state.
        public roomdata(ROM sm, uint pheader)
        {
            byte [] rom = sm.Rom;
            Header = pheader;

            RoomIndex = rom[pheader + 0];
            AreaIndex = rom[pheader + 1];
                 MapX = rom[pheader + 2];
                 MapY = rom[pheader + 3];
                Width = rom[pheader + 4];
               Height = rom[pheader + 5];
           UpScroller = rom[pheader + 6];
           DnScroller = rom[pheader + 7];
           SpecialGFX = rom[pheader + 8];
              DoorOut = ROM.readWord(pheader + 9, rom);    //this one is still in $8F; points to list of pointers that point to $83.
            Label = ".R" + asmFCN.WByte(RoomIndex) + "A" + string.Format("{0:X1}", AreaIndex);
            LabelM = "R" + asmFCN.WByte(RoomIndex) + "A" + string.Format("{0:X1}", AreaIndex);



            uint i, j = LUNAR.SNEStoPC(DoorOut + 0x8F0000); //this short pointer is in $8F.
            //i is to limit this to max doors
            //j is pointer to read in $8F.
            List<DoorData> thesedoors = new List<DoorData>();
            for (i = 0; i < 0x100; i++)
            {
                thesedoors.Add(new DoorData(sm, LUNAR.SNEStoPC(ROM.readWord(j,sm.Rom)+0x830000)));    //Readword passes the pointer at this address
                j++; j++;
                if (ROM.readWord(j, sm.Rom) < 0x8000) { break; }
            }
            Doors = thesedoors;
            //mandatory header is 11 bytes, door list is that many words plus terminator.
            Bytes8F = 11 + thesedoors.Count * 2 + 2;



            //count how many words after the Doorout pointer that Std. State $E5E6 is found.
            uint statecount = 0;
            i = 0;
            uint x = ROM.readWord(pheader + 11 + i,rom);
            uint[,] statepointers = new uint[255,3];
            //               0           1              2
            //statepointers [Event type, Event Pointer, Optional Arg.] for each state.
            while (x != (uint)StateType.Default)          //As pc address
            {
                statepointers[statecount, 0] = x;
                if (x == (uint)StateType.Event || x == (uint)StateType.BossChoose) { 
                    statepointers[statecount, 1] = ROM.readWord(pheader + 11 + i + 3, rom) + 0x70000;
                    statepointers[statecount, 2] = rom[pheader + 11 + i + 2];
                    i = i + 5; }     //events and boss bits take 1 byte arg
                else if(x == (uint)StateType.Door) { 
                    statepointers[statecount, 1] = ROM.readWord(pheader + 11 + i + 4, rom) + 0x70000;
                    statepointers[statecount, 2] = ROM.readWord(pheader + 11 + i + 2, rom);
                    i = i + 6; }                //the door room state needs a special one for its two-byte arg.
                else { 
                    statepointers[statecount, 1] = ROM.readWord(pheader + 11 + i + 2, rom) + 0x70000; 
                    i = i + 4; }                                                        //all the other ones are 4 bytes.
                x = ROM.readWord(pheader + 11 + i, rom);
                statecount++;
            }
            StateCount = (int)statecount;            //this weird assignment is so we can have roomdata.statecount = #
            uint stdstate = pheader + 11 + i;
            //[pheader + 11 + i] is currently the address of the std. state pointer.
            //If there were room states, they are organized in reverse order; IE state 0 is the one with highest priority.
            //to create the state array, we pass information from StatePointers array.
            //All 3 parts of the state are accounted for.
            uint roomsize = Width * Height;
            States = new List<state>();                //reserve array of states.
            for (i = 0; i < statecount; i++)        //this loop is skipped if there are is ONLY a default state because statecount will be 0.
            {
                States.Add(new state(sm, statepointers[i,0], statepointers[i,1], statepointers[i,2], roomsize));    //states need revised to include their own info? Or we can have it on the main header.
            }
            //have a special assignment for std. state
            //Event pointer is stdstate+2 because stdstate is the beginning of 0xE5E6.
            //                   0           1              2
            //    statepointers [Event type, Event Pointer, Optional Arg.] for each state.
            States.Add(new state(sm,  x,          stdstate+2,    0, roomsize));



        }
        //public byte[] ROM { get; }
        public int Bytes8F { get; set; }
        public string LabelM { get; set; }
        public string Label { get; set; }
        public uint Header { get; set; }
        public uint RoomIndex { get; set; }
        public uint AreaIndex { get; set; }
        public uint MapX { get; set; }
        public uint MapY { get; set; }
        public uint Width { get; set; }
        public uint Height { get; set; }
        public uint UpScroller { get; set; }
        public uint DnScroller { get; set; }
        public uint SpecialGFX { get; set; }
        public uint DoorOut { get; set; }
        public int StateCount { get; set; }


        public List<state> States
        {
            get; set;
        }

        public List<DoorData> Doors { get; set; }

        public void Rename(uint roomnum, uint areanum)
        {
            RoomIndex = roomnum;
            AreaIndex = areanum;
            Label = ".R" + asmFCN.WByte(RoomIndex) + "A" + string.Format("{0:X1}", AreaIndex);
            LabelM = "R" + asmFCN.WByte(RoomIndex) + "A" + string.Format("{0:X1}", AreaIndex);
        }

        public void DupChek()
            //assigns the pm strings for each state (which data is duplicated, if any)
        {
            //if (this.StateCount == 0) { return; }
            //the only data types that need checked for the same pointer are the ones that take up data space.
            for (int j = 0; j <= this.StateCount; j++)
            {
                state A = States[j];
                for (int i = 0; i <= this.StateCount; i++)
                {
                    state B = States[i];
                    if (i == j) { continue; }
                    if (States[i].pLevelData == States[j].pLevelData)
                    {
                        if (j == this.StateCount)
                        {
                            B.pmLevelData = "default";
                        }
                        else
                        {
                            B.pmLevelData = "state" + j;
                        }
                    }
                    if (States[i].pFX == States[j].pFX)
                    {
                        if (j == this.StateCount)
                        {
                            B.pmFX = "default";
                        }
                        else
                        {
                            B.pmFX = "state" + j;
                        }
                    }
                    if (States[i].pEnemySet == States[j].pEnemySet)
                    {
                        if (j == this.StateCount)
                        {
                            B.pmEnemySet = "default";
                        }
                        else
                        {
                            B.pmEnemySet = "state" + j;
                        }
                    }
                    if (States[i].pEnemyGFX == States[j].pEnemyGFX)
                    {
                        if (j == this.StateCount)
                        {
                            B.pmEnemyGFX = "default";
                        }
                        else
                        {
                            B.pmEnemyGFX = "state" + j;
                        }
                    }
                    if (States[i].pScrolls == States[j].pScrolls)
                    {
                        if (j == this.StateCount)
                        {
                            B.pmScrolls = "default";
                        }
                        else
                        {
                            B.pmScrolls = "state" + j;
                        }
                    }
                    if (States[i].pPLMset == States[j].pPLMset)
                    {
                        if (j == this.StateCount)
                        {
                            B.pmPLMset = "default";
                        }
                        else
                        {
                            B.pmPLMset = "state" + j;
                        }
                    }
                    States[i] = B;
                }
                //if the pm string was not reassigned, then it is a unique state.
                //this must be done here because the state type initializer does not know how many states are in the room.
                //unique states are assigned their own state number.
                if (A.pmLevelData == null) 
                    { A.pmLevelData = "state" + j; }
                if (A.pmFX == null) 
                    { A.pmFX = "state" + j; }
                if (A.pmEnemySet == null) 
                    { A.pmEnemySet = "state" + j; }
                if (A.pmEnemyGFX == null) 
                    { A.pmEnemyGFX = "state" + j; }
                if (A.pmScrolls == null) 
                    { A.pmScrolls = "state" + j; }
                if (States[j].pmPLMset == null) 
                    { A.pmPLMset = "state" + j; }
                States[j] = A;
            }
            //after all this looping, force default state to have its own pointers.
            state correction = States[this.StateCount];
            correction.pmLevelData = "default";
            correction.pmFX = "default";
            correction.pmEnemySet = "default";
            correction.pmEnemyGFX = "default";
            correction.pmScrolls = "default";
            correction.pmPLMset = "default";
            States[this.StateCount] = correction;
        }
    }

    public struct DoorData
    {//this type will store each of the door entries. Input short pointer.
     //   ;Map/Elevator Bitflag  Cap X    scrn x      spawn dist.
     //   ; Dest.header | drction |  Cap Y  |  scrn y     |    door ASM
     //   ;  |          |    |    |    |    |    |        |      |     
     //dw $91F8 : db $00, $04, $01, $26, $00, $02 : dw $8000, $B997
        public DoorData(ROM sm, uint pointer)   //pointer in PC
        {
            Destination = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            Bitflag = sm.Rom[pointer]; pointer++;
            Direction = sm.Rom[pointer]; pointer++;
            CapX = sm.Rom[pointer]; pointer++;
            CapY = sm.Rom[pointer]; pointer++;
            ScrnX = sm.Rom[pointer]; pointer++;
            ScrnY = sm.Rom[pointer]; pointer++;
            SpawnDist = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            DoorASM = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
        }

        public uint Destination { set; get; }
        public uint Bitflag { set; get; }
        public uint Direction { set; get; }
        public uint CapX { set; get; }
        public uint CapY { set; get; }
        public uint ScrnX { set; get; }
        public uint ScrnY { set; get; }
        public uint SpawnDist { set; get; }
        public uint DoorASM { set; get; }

    }

    public struct EnemyGFX
    {
        public EnemyGFX(ROM sm, uint pointer)
        {
            ID = ROM.readWord(pointer, sm.Rom); pointer += 2;
            Palette = ROM.readWord(pointer, sm.Rom);
        }
        //private string _match;
        public uint ID { get; set; }
        public uint Palette { get; set; }

    }

    public struct EnemyData
    {
        public EnemyData(ROM sm, uint pointer)
        {
            ID = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            PosX = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            PosY = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            TileMap = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            Special = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            SpecGFX = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            Speed1 = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            Speed2 = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
        }
        public uint ID { get; set; }
        public uint PosX { get; set; }
        public uint PosY { get; set; }
        public uint TileMap { get; set; }
        public uint Special { get; set; }
        public uint SpecGFX { get; set; }
        public uint Speed1 { get; set; }
        public uint Speed2 { get; set; }
    }
    public struct PLMdata
    {
        public PLMdata(ROM sm, uint pointer)
        {
            ID = ROM.readWord(pointer, sm.Rom); pointer += 2;
            PosX = sm.Rom[pointer]; pointer++;
            PosY = sm.Rom[pointer]; pointer++;
            Variable = ROM.readWord(pointer, sm.Rom);
        }

        public uint ID { get; set; }
        public uint PosX { get; set; }
        public uint PosY { get; set; }
        public uint Variable { get; set; }
    }
    public struct FXdata
    {
        public FXdata(ROM sm, uint pointer)
        {
            DoorSelect = ROM.readWord(pointer, sm.Rom); pointer += 2;
            LiqStart = ROM.readWord(pointer, sm.Rom); pointer += 2;
            LiqEnd = ROM.readWord(pointer, sm.Rom); pointer += 2;
            LiqSpeed = ROM.readWord(pointer, sm.Rom); pointer += 2;
            LiqDelay = sm.Rom[pointer]; pointer++;
            Type = sm.Rom[pointer]; pointer++;
            BitA = sm.Rom[pointer]; pointer++;
            BitB = sm.Rom[pointer]; pointer++;
            BitC = sm.Rom[pointer]; pointer++;
            PalFXflags = sm.Rom[pointer]; pointer++;
            TileAnimFlags = sm.Rom[pointer]; pointer++;
            PalBlend = sm.Rom[pointer];
        }
        public uint DoorSelect { get; set; }
        public uint LiqStart { get; set; }
        public uint LiqEnd { get; set; }
        public uint LiqSpeed { get; set; }
        public uint LiqDelay { get; set; }
        public uint Type { get; set; }
        public uint BitA { get; set; }
        public uint BitB { get; set; }
        public uint BitC { get; set; }
        public uint PalFXflags { get; set; }
        public uint TileAnimFlags { get; set; }
        public uint PalBlend { get; set; }
    }
 
//-----------------------------


    public partial class SMASM : Form
    {
        string DbLocation;
        XmlDocument config = new XmlDocument();

        public ROM sm;
        roomdata thisroom;

        const int MaxEnemies = 32;
        const int     MaxGFX = 04;
        const int    MaxPLMs = 40;
        const int      MaxFX = 255;
        const int   MaxDoors = 255;
        const int  MaxStates = 255;


        public unsafe SMASM()
        {
            InitializeComponent();
            DbLocation = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            //Console.WriteLine(DbLocation);
            //if config does not exist, create it
            if (!File.Exists(DbLocation + "config.xml")) 
            {
                
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "   ";

                using (XmlWriter writer = XmlWriter.Create(DbLocation + "config.xml", settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("config");
                    writer.WriteElementString("ROM", " ");
                    writer.WriteElementString("ASM", " ");
                    writer.WriteElementString("ASR", " ");
                    writer.WriteElementString("SMILEFILE", " ");
                    writer.WriteElementString("ROOMLIST", " ");
                    writer.WriteElementString("TILESETTABLE", "E6A2");
                    writer.WriteElementString("ONTOP", "0");
                    writer.Close();
                }
                
            }
            //if it DOES exist, we should probably verify it with a schema... oh well!
            config.Load(DbLocation + "config.xml");
            if (config.ChildNodes[1].SelectSingleNode("ONTOP").InnerText == "True") { this.TopMost = true; this.alltopCheckbox.Checked = true; }

            sm = new ROM(config.ChildNodes[1].SelectSingleNode("ROM").InnerText);
            

            //pcBox.Text = string.Format("{0:X6}", readWord(0x10, sm));
            //string az = config.ChildNodes[1].SelectSingleNode("ROM").InnerText + null;
            //if (!LUNAR.OpenFile(az)) { MessageBox.Show ("LUNAR rom load failed"); }
        }



        public void openFilemenu(object sender, EventArgs e)
        {
            {
                Button foo = (Button)sender;

                var filePath = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = DbLocation;
                    openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        //Read the contents of the file into a stream
                        //fails if the file is already open in SMILE...?
                        var fileStream = openFileDialog.OpenFile();

                    }
                }
                foo.Tag = filePath;
            }
        }

        private void alltopCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SMASM.ActiveForm == null) { return; }
            SMASM.ActiveForm.TopMost = !SMASM.ActiveForm.TopMost;
        }

        private void filePathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pathsConfig nw = new pathsConfig(config);
            nw.ShowDialog();
            nw.Dispose();
            sm = new ROM(config.ChildNodes[1].SelectSingleNode("ROM").InnerText);
        }

        private void SMASM_FormClosing(object sender, FormClosingEventArgs e)
        {
            //save any UI config changes
            config.ChildNodes[1].SelectSingleNode("ONTOP").InnerText = alltopCheckbox.Checked.ToString();
            config.Save(DbLocation + "config.xml");
            LUNAR.CloseFile();
        }

        private void pcBox_TextChanged(object sender, EventArgs e)
        {
            //needs to do number validation first to make sure it's valid hex
            if (pcBox.Text == "" || pcBox.Text == null) { return; }
            uint pcaddr = uint.Parse(pcBox.Text, System.Globalization.NumberStyles.HexNumber);
            lorombox.Text = string.Format("{0:X6}", LUNAR.LunarPCtoSNES(pcaddr, 0x10, 0));
            //lorombox.Text = pcaddr.ToString();  //hex to dec converter
        }

        private void HeaderBox_TextChanged(object sender, EventArgs e)
        {
            int x = HeaderBox.SelectionStart;
            HeaderBox.Text = HeaderBox.Text.ToUpper();
            HeaderBox.SelectionStart = x;
        }

        private void HeaderBox_Validated(object sender, EventArgs e)
        {
            LoadRoomToGUI();
        }

        private void LoadRoomToGUI()
        {
            sm = new ROM(config.ChildNodes[1].SelectSingleNode("ROM").InnerText);
            uint headeraddr = uint.Parse(HeaderBox.Text, System.Globalization.NumberStyles.HexNumber);
            thisroom = new roomdata(sm, headeraddr);

            RoomIndex.Text = string.Format("{0:X2}", thisroom.RoomIndex);
            AreaIndex.Text = string.Format("{0:X2}", thisroom.AreaIndex);
            MapX.Text = string.Format("{0:X2}", thisroom.MapX);
            MapY.Text = string.Format("{0:X2}", thisroom.MapY);
            RoomWidth.Text = string.Format("{0:X2}", thisroom.Width);
            RoomHeight.Text = string.Format("{0:X2}", thisroom.Height);
            UpScroller.Text = string.Format("{0:X2}", thisroom.UpScroller);
            DnScroller.Text = string.Format("{0:X2}", thisroom.DnScroller);
            SpecialGFX.Text = string.Format("{0:X2}", thisroom.SpecialGFX);

            thisroom.DupChek();

            StateBox.Items.Clear();
            for (int i = 0; i < thisroom.StateCount; i++)
            {
                StateBox.Items.Add("State " + i);
            }
            StateBox.Items.Add("Default");
            StateBox.SelectedIndex = StateBox.Items.Count - 1;

            AppendStatus("Loaded R" + asmFCN.WByte(thisroom.RoomIndex) + "A" + asmFCN.WByte(thisroom.RoomIndex) + " - " + DateTime.Now.ToLongTimeString());
            //RoomLoadTimeStamp.Text = DateTime.Now.ToShortDateString() + "\n" + DateTime.Now.ToLongTimeString();
        }
        public void AppendStatus(string text)
        {
            StatusBox.Text += text + "\n";
            StatusBox.SelectionStart = StatusBox.Text.Length;
            StatusBox.ScrollToCaret();
            if (StatusBox.Lines.Length < 200) { return; }
            List<string> fixLen = StatusBox.Lines.ToList();
            fixLen.RemoveAt(0);
            StatusBox.Lines = fixLen.ToArray();
        }
        private void StateBox_SelectedIndexChanged(object sender, EventArgs e)
        //populate all the state data boxes.
        {
            EnemyBox.Items.Clear();
            for (int i = 0; i < thisroom.States[StateBox.SelectedIndex].Enemies.Count(); i++)
            {
                EnemyBox.Items.Add(asmFCN.WByte((uint)i) + " - " + asmFCN.WWord(thisroom.States[StateBox.SelectedIndex].Enemies[i].ID));
            }

            PlmBox.Items.Clear();
            for (int i = 0; i < thisroom.States[StateBox.SelectedIndex].PLMs.Count(); i++)
            {
                PlmBox.Items.Add(asmFCN.WByte((uint)i) + " - " + asmFCN.WWord(thisroom.States[StateBox.SelectedIndex].PLMs[i].ID));
            }

            FXbox.Items.Clear();
            for (int i = 0; i < thisroom.States[StateBox.SelectedIndex].FX.Count(); i++)
            {
                FXbox.Items.Add(asmFCN.WByte((uint)i) + " - " + asmFCN.WWord(thisroom.States[StateBox.SelectedIndex].FX[i].Type));
            }

            DoorBox.Items.Clear();
            for (int i = 0; i < thisroom.Doors.Count(); i++)
            {
                DoorBox.Items.Add(asmFCN.WByte((uint)i) + " - " + asmFCN.WWord(thisroom.Doors[i].Destination));
            }

            GFXbox.Items.Clear();
            for (int i = 0; i < thisroom.States[StateBox.SelectedIndex].EnemiesAllowed.Count(); i++)
            {
                GFXbox.Items.Add(asmFCN.WByte((uint)i) + " - " + asmFCN.WWord(thisroom.States[StateBox.SelectedIndex].EnemiesAllowed[i].ID));
            }

            TilesetBox.Clear();
            TilesetBox.Text = asmFCN.WByte(thisroom.States[StateBox.SelectedIndex].TileSet);
            
        }

        private void HeaderBox_Validating(object sender, CancelEventArgs e)
        {
            //make sure it only contains numbers and ABCDEF
            if(int.TryParse(HeaderBox.Text, System.Globalization.NumberStyles.HexNumber, new CultureInfo("en-US"), out int resul) && HeaderBox.Text.Length == 5)
            {
                return;
            }
            TextBox header = (TextBox)sender;
            header.Text = "";
            e.Cancel = true;
        }

        private void Duplicate_Item(object sender, MouseEventArgs e)
        {
            ListBox A = (ListBox)sender;

            //disallow copy if max limit reached
            //determine data type based on first letter of control name
            //Enemies, GFX, PLM, FX, Doors, State
            if (A.Name.Substring(0, 1) == "E" && A.Items.Count < MaxEnemies)
            {
                thisroom.States[StateBox.SelectedIndex].Enemies.Add(thisroom.States[StateBox.SelectedIndex].Enemies[A.SelectedIndex]);
            }
            else if (A.Name.Substring(0, 1) == "G" && A.Items.Count < MaxGFX)
            {
                thisroom.States[StateBox.SelectedIndex].EnemiesAllowed.Add(thisroom.States[StateBox.SelectedIndex].EnemiesAllowed[A.SelectedIndex]);
            }
            else if (A.Name.Substring(0, 1) == "P" && A.Items.Count < MaxPLMs)
            {
                thisroom.States[StateBox.SelectedIndex].PLMs.Add(thisroom.States[StateBox.SelectedIndex].PLMs[A.SelectedIndex]);
            }
            else if (A.Name.Substring(0, 1) == "F" && A.Items.Count < MaxFX)
            {
                thisroom.States[StateBox.SelectedIndex].FX.Add(thisroom.States[StateBox.SelectedIndex].FX[A.SelectedIndex]);
            }
            else if (A.Name.Substring(0, 1) == "D" && A.Items.Count < MaxDoors)
            {
                thisroom.Doors.Add(thisroom.Doors[A.SelectedIndex]);
            }
            else if (A.Name.Substring(0, 1) == "S" && A.Items.Count < MaxStates)
            {
                MessageBox.Show("State addition not yet supported!");
            }


            StateBox_SelectedIndexChanged(sender, e);
        }

        private void BlockDelete_Click(object sender, EventArgs e)
        {
            ListBox A = (ListBox)((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl;

            int count = A.Items.Count;
            //determine data type based on first letter of control name
            //Enemies, GFX, PLM, FX, Doors, State
            if (A.Name.Substring(0, 1) == "E" && A.Items.Count < MaxEnemies)
            {
                for (int i = A.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    thisroom.States[StateBox.SelectedIndex].Enemies.RemoveAt((int)A.SelectedIndices[i]);
                }
            }
            else if (A.Name.Substring(0, 1) == "G" && A.Items.Count < MaxGFX)
            {
                for (int i = A.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    thisroom.States[StateBox.SelectedIndex].EnemiesAllowed.RemoveAt((int)A.SelectedIndices[i]);
                }
            }
            else if (A.Name.Substring(0, 1) == "P" && A.Items.Count < MaxPLMs)
            {
                for (int i = A.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    thisroom.States[StateBox.SelectedIndex].PLMs.RemoveAt((int)A.SelectedIndices[i]);
                }
            }
            else if (A.Name.Substring(0, 1) == "F" && A.Items.Count < MaxFX && A.Items.Count > 1)
            {
                for (int i = A.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    count--;
                    if (count < 1) { MessageBox.Show("Room must have at least one FX."); break; }
                    thisroom.States[StateBox.SelectedIndex].FX.RemoveAt((int)A.SelectedIndices[i]);
                }
            }
            else if (A.Name.Substring(0, 1) == "D" && A.Items.Count < MaxDoors && A.Items.Count > 1)
            {
                for (int i = A.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    count--;
                    if (count < 1) { MessageBox.Show("Room must have at least one Door."); break; }
                    thisroom.Doors.RemoveAt((int)A.SelectedIndices[i]);

                }
            }
            else if (A.Name.Substring(0, 1) == "S" && A.Items.Count < MaxStates && A.Items.Count > 1)
            {
                //redraw state list since the function at the end of this one does not handle that.
                //Also forces the last thing in the list to be default state.
                for (int i = A.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    if (thisroom.States[(int)A.SelectedIndices[i]].Type == 0xE5E6)
                    {
                        DialogResult delState = MessageBox.Show("Deleting default state. State " + (thisroom.StateCount - 1) + " will be casted as new default state.","Delete Default State",MessageBoxButtons.YesNo);
                        if (delState == DialogResult.No) { return; }
                        if (delState == DialogResult.Yes) { break; }
                    }
                }
                    
                for (int i = A.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    thisroom.States.RemoveAt((int)A.SelectedIndices[i]);
                    thisroom.StateCount--;
                    StateBox.Items.Clear();
                    for (int j = 0; j < thisroom.StateCount; j++)
                    {
                        StateBox.Items.Add("State " + j);
                    }
                    StateBox.Items.Add("Default");
                    StateBox.SelectedIndex = StateBox.Items.Count - 1;
                    state T = thisroom.States[thisroom.StateCount];
                    T.Type = 0xE5E6;
                    thisroom.States[thisroom.StateCount] = T;
                }
            }

            //alt approach that also worked
            //for(int i = PlmBox.Items.Count-1; i >=0; i--)
            //{
            //    if (PlmBox.GetSelected(i))
            //    {
            //        thisroom.states[StateBox.SelectedIndex].PLMs.RemoveAt(i);
            //    }
            //}

            StateBox_SelectedIndexChanged(sender, e);
        }

        private void HeaderBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) { SendKeys.Send("\t"); }
        }
        public void CreateNewSMASMspace(string asmPath)
        {
            string tASM = File.ReadAllText(asmPath);
            string smasmspace =
                "\n" +
                ";SMASM-START--------" + "\n" +
                "org !smasm8F" + "\n" +
                "ROOMS:" + "\n" +
                "{" + "\n" +
                "\n" +
                "}" + "\n" +
                "org !smasm83" + "\n" +
                "DOORS:" + "\n" +
                "{" + "\n" +
                "\n" +
                "}" + "\n" +
                "ROOMFX:" + "\n" +
                "{" + "\n" +
                "\n" +
                "}" + "\n" +
                "org !smasmA1" + "\n" +
                "ENEMYSET:" + "\n" +
                "{" + "\n" +
                "\n" +
                "}" + "\n" +
                "org !smasmB4" + "\n" +
                "ENEMYGFX:" + "\n" +
                "{" + "\n" +
                "\n" +
                "}" + "\n" +
                "org !smasmLevels" + "\n" +
                "check bankcross off" + "\n" +
                "TILESETS:" + "\n" +
                "{" + "\n" +
                "\n" +
                "}" + "\n" +
                "LEVELS:" + "\n" +
                "{" + "\n" +
                "\n" +
                "}" + "\n" +
                "check bankcross on" + "\n" +
                "org !smasmTilesetTable" + "\n" +
                "TILESETTABLE:" + "\n" +
                "{" + "\n" +
                "\n" +
                "}" + "\n" +
                ";SMASM-END----------" + "\n" +
                "";

            tASM += smasmspace;
            File.AppendAllText(asmPath,tASM);
        }

        public List<string> ASM2List(string asmPath)
        {
            string tASM = File.ReadAllText(asmPath);
            string[] delimchars = { "\r\n", "\n" };
            return tASM.Split(delimchars, StringSplitOptions.None).ToList();
        }

        public List<string> Parse_SMASM_ASM(string asmPath, out int smasmStartLine, out int smasmEndLine, out bool roomExists)
            //return string list of each line in the SMASM space, along with the starting and ending lines of SMASM-Space.
        {
            parsefile:
            List<string> pASM = ASM2List(asmPath);
            //get rid of any lone \r's because Windows >_<;
            for (int i = 0; i < pASM.Count; i++)
            {
                pASM[i] = pASM[i].Trim();
            }
            int startline = 0;
            int endline = 0;
            //Search file for beginning and end of SMASM. If they are not found, then show the user and create it.
            //Each start and end needs to be this verbatim.
            for (int i = 0; i < pASM.Count; i++)
            {
                if (pASM[i].Trim() == ";SMASM-START--------") { startline = i; }
                if (pASM[i].Trim() == ";SMASM-END----------") { endline = i; break; }
            }
            if (startline == 0 || endline == 0)
            {
                DialogResult a = MessageBox.Show("SMASM space not found. Create it at end of file?", "SMASM not Found", MessageBoxButtons.YesNo);
                if (a == DialogResult.Yes)
                {
                    CreateNewSMASMspace(asmPath);
                    goto parsefile;
                }
                else
                {
                    MessageBox.Show("SMASM creation aborted. Source operation will be cancelled.", "Creation Denied",MessageBoxButtons.OK);
                    smasmStartLine = 0;
                    smasmEndLine = 0;
                    roomExists = false;
                    return null;
                }
            }
            //We now have the starting and ending lines of the space in the ASM file.
            //This is only needed when we go to insert the room into the ASM.
            //So, create a substring array of all the SMASM stuff.
            smasmStartLine = startline;
            smasmEndLine = endline;

            List<string> newsmasm = new List<string>();


            roomExists = false;
            for (int i = startline; i < endline+1; i++)
            {
                if (pASM[i].Trim() == thisroom.Label && !roomExists)
                {
                    roomExists = true;
                }
                newsmasm.Add(pASM[i]);
            }

            return newsmasm;
        }
        public void GetSMASMsections(List<string> smasmSpace, out List<string> smasm8F, out List<string> smasm83d, out List<string> smasm83f, out List<string> smasmA1, out List<string> smasmB4, out List<string> smasmLV, out List<string> smasmTilesets, out List<string> smasmTilesetTable)
            //this function exists to raise a compile error when adding new sections, because they need added everywhere in the code.
        {
            smasm8F = FindSection("ROOMS:", smasmSpace);
            smasm83d = FindSection("DOORS:", smasmSpace);
            smasm83f = FindSection("ROOMFX:", smasmSpace);
            smasmA1 = FindSection("ENEMYSET:", smasmSpace);
            smasmB4 = FindSection("ENEMYGFX:", smasmSpace);
            smasmLV = FindSection("LEVELS:", smasmSpace);
            smasmTilesets = FindSection("TILESETS:", smasmSpace);
            smasmTilesetTable = FindSection("TILESETTABLE:", smasmSpace);
            //prevent tilesets from being null if not found, but this should never happen if the template is used.
            if(smasmTilesets == null)
            {
                smasmTilesets = new List<string>(1);
            }
        }
        public string ConcatASMsections(List<string> asm8F, List<string> asm83d, List<string> asm83f, List<string> asmA1, List<string> asmB4, List<string> asmLV, List<string> asmTilesets, List<string> asmTilesetTable)
            //all the sections also need added here.
        {
            string final = ";SMASM-START--------\n" +
               "org !smasm8F\n";
            foreach (var item in asm8F)
            {
                final += item + "\n";
            }
            final += "org !smasm83\n";
            foreach (var item in asm83d)
            {
                final += item + "\n";
            }
            foreach (var item in asm83f)
            {
                final += item + "\n";
            }
            final += "org !smasmA1\n";
            foreach (var item in asmA1)
            {
                final += item + "\n";
            }
            final += "org !smasmB4\n";
            foreach (var item in asmB4)
            {
                final += item + "\n";
            }
            final += "org !smasmLevels\n";
            final += "check bankcross off\n";
            foreach (var item in asmTilesets)
            {
                final += item + "\n";
            }
            foreach (var item in asmLV)
            {
                final += item + "\n";
            }
            final += "check bankcross on\n";
            final += "org !smasmTilesetTable\n";
            foreach (var item in asmTilesetTable)
            {
                final += item + "\n";
            }
            final += ";SMASM-END----------";
            return final;
        }
        public void Export_Room(List<string> smasmSpace, int startline, int endline, string asmPath, bool checkRoomOverwrite)
        {
            List<string> pASM = ASM2List(asmPath);
            //newsmasm list of all the lines, which we can now insert things to as needed.
            //But first, parse out all the separate regions.
            //$83 is the only one that will need multiple R##A# sublabels per room.
            List<string> smasm8F = new List<string>();
            List<string> smasm83d = new List<string>();
            List<string> smasm83f = new List<string>();
            List<string> smasmA1 = new List<string>();
            List<string> smasmB4 = new List<string>();
            List<string> smasmLV = new List<string>();
            List<string> smasmTilesets = new List<string>();

            GetSMASMsections(smasmSpace, out smasm8F, out smasm83d, out smasm83f, out smasmA1, out smasmB4, out smasmLV, out smasmTilesets, out List<string> smasmTilesetTable);

            bool roomExists = false;
            for (int i = startline; i < endline; i++)
            {
                if (pASM[i].Trim() == thisroom.Label && !roomExists)
                //if thisroom already exists in the ASM file, then overwrite it...
                {
                    roomExists = true;
                    //show additional messageboxes if the confirmation is enabled.
                    if (checkRoomOverwrite)
                    {
                        DialogResult a = MessageBox.Show("Room already exists. Overwrite ASM?", "Overwrite Room?", MessageBoxButtons.YesNo);
                        if (a == DialogResult.No)
                        {
                            MessageBox.Show("Operation cancelled.", "Overwrite Room?", MessageBoxButtons.OK);
                            return;
                        }
                    }
                }
            }

            string[] export = asmFCN.Room2ASM(thisroom, int.Parse(LevelBuffer.Text));
            //export  = 8F, 83d, 83f, A1, B4, LEVELS
            //Place each export at the end of each section.
            if (!roomExists)
            {
                smasm8F.Insert(smasm8F.Count - 1, export[0]);
                smasm83d.Insert(smasm83d.Count - 1, export[1]);
                smasm83f.Insert(smasm83f.Count - 1, export[2]);
                smasmA1.Insert(smasmA1.Count - 1, export[3]);
                smasmB4.Insert(smasmB4.Count - 1, export[4]);
                smasmLV.Insert(smasmLV.Count - 1, export[5]);
            }
            else //isolate the room labels in each section, delete, and replace.
            {
                //these are all +2 to delete the closing bracket and the following empty line.
                FindSection(thisroom.Label, smasm8F, out int st, out int ed);
                if (st == 0 || ed == 0) { MessageBox.Show("roomlabel not found!"); }
                smasm8F.RemoveRange(st, ed - st + 2);
                smasm8F.Insert(st, export[0]);

                FindSection(thisroom.Label, smasm83d, out st, out ed);
                if (st == 0 || ed == 0) { MessageBox.Show("doorlabel not found!"); }
                smasm83d.RemoveRange(st, ed - st + 2);
                smasm83d.Insert(st, export[1]);

                FindSection(thisroom.Label, smasm83f, out st, out ed);
                if (st == 0 || ed == 0) { MessageBox.Show("fxlabel not found!"); }
                smasm83f.RemoveRange(st, ed - st + 2);
                smasm83f.Insert(st, export[2]);

                FindSection(thisroom.Label, smasmA1, out st, out ed);
                if (st == 0 || ed == 0) { MessageBox.Show("enemylabel not found!"); }
                smasmA1.RemoveRange(st, ed - st + 2);
                smasmA1.Insert(st, export[3]);

                FindSection(thisroom.Label, smasmB4, out st, out ed);
                if (st == 0 || ed == 0) { MessageBox.Show("gfxlabel not found!"); }
                smasmB4.RemoveRange(st, ed - st + 2);
                smasmB4.Insert(st, export[4]);

                FindSection(thisroom.Label, smasmLV, out st, out ed);
                if (st == 0 || ed == 0) { MessageBox.Show("levellabel not found!"); }
                smasmLV.RemoveRange(st, ed - st + 2);
                smasmLV.Insert(st, export[5]);

            }

            //use loops to compile all these into a single output string for the text file.
            string final = ConcatASMsections(smasm8F, smasm83d, smasm83f, smasmA1, smasmB4, smasmLV, smasmTilesets, smasmTilesetTable);
            //we need to delete everything between the SMASM start and end of the original file, and insert this final string...
            pASM.RemoveRange(startline, (endline+1) - startline);
            pASM.Insert(startline, final);
            try
            {
                File.WriteAllLines(asmPath, pASM);
            }
            catch
            {
                MessageBox.Show("Write to ASM failed. Is it open in another program?", "Write Fail", MessageBoxButtons.OK);
            }
        }

        private void ASMbutton_Click(object sender, EventArgs e)
        {
            string asmPath = config.ChildNodes[1].SelectSingleNode("ASM").InnerText;
            List<string> smasmSpace = Parse_SMASM_ASM(asmPath, out int smasmStartLine, out int smasmEndLine, out bool roomExists);
            if(smasmSpace == null) { return; }
            Export_Room(smasmSpace, smasmStartLine, smasmEndLine, asmPath, true);
            return;
        }
        public List<string> FindSection(string query, List<string> fulltext)
        //Given a list of strings:
        //  Find query text - needs 100% match.
        //      Return null if the following line is not an {
        //  Read until the matching } is found
        //  Return contents with query label and brackets included.
        {
            int startline = 0, endline = 0, level = 0, i = 0;
            List<string> subset = new List<string>();

            foreach(string a in fulltext)
            {
                if (a.Trim() == query) { startline = i; break; }
                i++;
            }
            //return null if query was not found or the following line is not an open bracket.
            if (startline == 0) { return null; }
            if (fulltext[startline+1].Trim() != "{") { return null; }


            //now find endline: look for a lone } at the same level as the original {
            
            for (i = startline+2; i < fulltext.Count; i++)
            {
                string a = fulltext[i].Trim();
                if (a == "{")               { level++; }

                if (a == "}" && level != 0) { level--; }

                else if (a == "}" && level == 0) { endline = i; break; }
            }

            //start and end found; commit to subset.
            for (i = startline; i < endline; i++)
            {
                subset.Add(fulltext[i]);
            }
            //get the end bracket too:
            subset.Add(fulltext[i]);
            return subset;

        }
        public List<string> FindSection(string query, List<string> fulltext, out int st, out int ed)
        //same as above but it outputs the start and end line of the query within the full text.
        //
        {
            int startline = 0, endline = 0, level = 0, i = 0;
            List<string> subset = new List<string>();
            st = 0; ed = 0;
            foreach (string a in fulltext)
            {
                if (a.Trim() == query) { startline = i; break; }
                i++;
            }
            //return null if query was not found or the following line is not an open bracket.
            if (startline == 0) { return null; }
            if (fulltext[startline + 1].Trim() != "{") { return null; }


            //now find endline: look for a lone } at the same level as the original {

            for (i = startline + 2; i < fulltext.Count; i++)
            {
                string a = fulltext[i].Trim();
                if (a == "{") { level++; }

                if (a == "}" && level != 0) { level--; }

                else if (a == "}" && level == 0) { endline = i; break; }
            }

            //start and end found; commit to subset.
            for (i = startline; i < endline; i++)
            {
                subset.Add(fulltext[i]);
            }
            //get the end bracket too:
            subset.Add(fulltext[i]);
            st = startline;
            ed = endline;
            return subset;

        }

        //Drag and drop tutorial:
        //http://csharphelper.com/howtos/howto_drag_inside_listbox.html
        private void lst_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox lst = sender as ListBox;

            // Only use the right mouse button.
            if (e.Button != MouseButtons.Middle) return;
            int index = lst.IndexFromPoint(e.Location);
            lst.SelectionMode = SelectionMode.One;
            // Find the item under the mouse.
            

            //index = IndexFromScreenPoint(lst, new Point(e.X, e.Y));

            lst.SelectedIndex = index;
            if (index < 0) return;
            // Drag the item.
            DragItem drag_item = new DragItem(lst, index, lst.Items[index]);
            lst.DoDragDrop(drag_item, DragDropEffects.Move);
        }

        // See if we should allow this kind of drag.
        private void lst_DragEnter(object sender, DragEventArgs e)
        {
            ListBox lst = sender as ListBox;

            // Allow a Move for DragItem objects that are
            // dragged to the control that started the drag.
            if (!e.Data.GetDataPresent(typeof(DragItem)))
            {
                // Not a DragItem. Don't allow it.
                e.Effect = DragDropEffects.None;
            }
            else if ((e.AllowedEffect & DragDropEffects.Move) == 0)
            {
                // Not a Move. Do not allow it.
                e.Effect = DragDropEffects.None;
            }
            else
            {
                // Get the DragItem.
                DragItem drag_item = (DragItem)e.Data.GetData(typeof(DragItem));

                // Verify that this is the control that started the drag.
                if (drag_item.Client != lst)
                {
                    // Not the control that started the drag. Do not allow it.
                    e.Effect = DragDropEffects.None;
                }
                else
                {
                    // Allow it.
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        // Select the item under the mouse during a drag.
        private void lst_DragOver(object sender, DragEventArgs e)
        {
            // Do nothing if the drag is not allowed.
            if (e.Effect != DragDropEffects.Move) return;

            ListBox lst = sender as ListBox;

            // Select the item at this screen location.
            lst.SelectedIndex =
                IndexFromScreenPoint(lst, new Point(e.X, e.Y));
        }

        // Return the index of the item that is
        // under the point in screen coordinates.
        public static int IndexFromScreenPoint(ListBox lst, Point point)
        {
            // Convert the location to the ListBox's coordinates.
            point = lst.PointToClient(point);

            // Return the index of the item at that position.
            return lst.IndexFromPoint(point);
        }

        // Drop the item here.
        private void lst_DragDrop(object sender, DragEventArgs e)
        {
            ListBox lst = sender as ListBox;

            // Get the ListBox item data.
            DragItem drag_item = (DragItem)e.Data.GetData(typeof(DragItem));

            // Get the index of the item at this position.
            int new_index =
                IndexFromScreenPoint(lst, new Point(e.X, e.Y));

            // If the item was dropped after all
            // of the items, move it to the end.
            if (new_index == -1) new_index = lst.Items.Count - 1;

            
            // Remove the item from its original position.
            lst.Items.RemoveAt(drag_item.Index);
            

            // Insert the item in its new position.
            lst.Items.Insert(new_index, drag_item.Item);

            //determine data type to move based on first letter of control name
            //Enemies, GFX, PLM, FX, Doors
            if (lst.Name.Substring(0, 1) == "E")
            {
                EnemyData t = thisroom.States[StateBox.SelectedIndex].Enemies[drag_item.Index];
                thisroom.States[StateBox.SelectedIndex].Enemies.RemoveAt(drag_item.Index);
                thisroom.States[StateBox.SelectedIndex].Enemies.Insert(new_index, t);
            }
            else if (lst.Name.Substring(0, 1) == "G")
            {
                EnemyGFX t = thisroom.States[StateBox.SelectedIndex].EnemiesAllowed[drag_item.Index];
                thisroom.States[StateBox.SelectedIndex].EnemiesAllowed.RemoveAt(drag_item.Index);
                thisroom.States[StateBox.SelectedIndex].EnemiesAllowed.Insert(new_index, t);
            }
            else if (lst.Name.Substring(0, 1) == "P")
            {
                PLMdata t = thisroom.States[StateBox.SelectedIndex].PLMs[drag_item.Index];
                thisroom.States[StateBox.SelectedIndex].PLMs.RemoveAt(drag_item.Index);
                thisroom.States[StateBox.SelectedIndex].PLMs.Insert(new_index, t);
            }
            else if (lst.Name.Substring(0, 1) == "F")
            {
                FXdata t = thisroom.States[StateBox.SelectedIndex].FX[drag_item.Index];
                thisroom.States[StateBox.SelectedIndex].FX.RemoveAt(drag_item.Index);
                thisroom.States[StateBox.SelectedIndex].FX.Insert(new_index, t);
            }
            else if (lst.Name.Substring(0, 1) == "D")
            {
                DoorData t = thisroom.Doors[drag_item.Index];
                thisroom.Doors.RemoveAt(drag_item.Index);
                thisroom.Doors.Insert(new_index, t);
            }
            else if (lst.Name.Substring(0, 1) == "S")
            {
                MessageBox.Show("State order not yet supported!");
            }

            // Select the item.
            lst.SelectedIndex = new_index;
            lst.SelectionMode = SelectionMode.MultiExtended;

            EventArgs dummy = new EventArgs();
            StateBox_SelectedIndexChanged(sender, dummy);
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            string q = @"" + (char)34;
            string rom = config.ChildNodes[1].SelectSingleNode("ROM").InnerText;
            string asm = config.ChildNodes[1].SelectSingleNode("ASM").InnerText;
            string asr = config.ChildNodes[1].SelectSingleNode("ASR").InnerText;

            //romname is the file path minus the extension
            string romname = rom.Substring(rom.LastIndexOf('\\')+1); romname = romname.Substring(0, romname.Length - 4);
            string customF = config.ChildNodes[1].SelectSingleNode("SMILEFILE").InnerText + "\\Custom\\" + romname + "\\Data\\";
            Directory.CreateDirectory(customF);
            string mdbpath = customF + "mdb.txt";



            string strCmdText = string.Format(@" {0}{1}{0} {0}{2}{0}", q, asm, rom);
            try
            {
                using (Process patch = new Process())
                {
                    patch.StartInfo.UseShellExecute = false;
                    patch.StartInfo.FileName = asr;
                    patch.StartInfo.Arguments = strCmdText;
                    patch.StartInfo.CreateNoWindow = true;
                    patch.StartInfo.RedirectStandardOutput = true;
                    patch.Start();
                    // This code assumes the process you are starting will terminate itself.
                    // Given that it is started without a window so you cannot terminate it
                    // on the desktop, it must terminate itself or you can do it programmatically
                    // from this application using the Kill method.
                    patch.WaitForExit();
                    StreamReader a = patch.StandardOutput;
                    //StatusBox.Text = a.ReadToEnd();
                    string asarOut = a.ReadToEnd();
                    a.Close();

                    List<string> sRooms = new List<string>();
                    List<string> sNames = new List<string>();
                    List<string> aRooms = new List<string>();
                    List<string> aNames = new List<string>();
                    SMILEfcn.ASARList(asarOut, out aRooms, out aNames);
                    //if the MBDpath does not exist then it will just be the ASAR output
                    if (File.Exists(mdbpath))
                    {
                        SMILEfcn.MDBList(mdbpath, out sRooms, out sNames);
                    }
                    List<string> oldRooms = new List<string>(sRooms);
                    List<string> oldNames = new List<string>(sNames);
                    //Since we're using the custom folder, it makes sense for it to delete all the MDB that isn't in SMASM.
                    if (DelMDB.Checked)
                    {
                        for (int x = 0; x < sNames.Count; x++)
                        {
                            bool matchfound = false;
                            for (int y = 0; y < aNames.Count; y++)
                            {
                                if (sNames[x] == aNames[y]) { matchfound = true; }
                            }
                            if (!matchfound) { sNames.RemoveAt(x); sRooms.RemoveAt(x); x--; }
                        }
                    }
                    //then, check the room names.
                    //if our R1A1 is on the list, replace that entry with the new header location.
                    //Else, add it to the top of the sRooms and sNames.
                    //No sorting is necessary because the MDB.txt does not need to be in an order
                    for (int x = 0; x < aNames.Count; x++)
                    {
                        //if the sNames list is empty, as in a blank MDB, then this is give an index OOB error.
                        //Catch this case so that remaining entries in aNames will be added to the top of the list with no checks.
                        //In the edge case that the MDB exists but it's just smaller than the aLists, this try will work up until it doesn't, and then catch the rest.
                        try
                        {
                            bool matchfound = false;
                            for (int y = 0; y < sNames.Count; y++)
                            {
                                matchfound = false;
                                if (sNames[y] == aNames[x])
                                {
                                    matchfound = true;
                                    sRooms[y] = aRooms[x];
                                    break;
                                }
                            }
                            if (!matchfound)
                            {
                                sNames.Insert(0, aNames[x]);
                                sRooms.Insert(0, aRooms[x]);
                            }
                        }
                        catch
                        {
                            sNames.Insert(0, aNames[x]);
                            sRooms.Insert(0, aRooms[x]);
                        }
                    }


                    //sNames and sRooms now contain the ASAR generated entries.
                    //recombine them into a valid MBD.txt:
                    //the area names in the vanilla MDB seem optional.
                    string res = "";
                    for (int i = 0; i < sNames.Count; i++)
                    {
                        res += sRooms[i] + " " + sNames[i] + "\r\n";
                    }
                    //need to shorten it so the last character in the string is not whitespace...
                    res = res.Substring(0, res.Length - 2);


                    //------------------------------------------------
                    //Stuff for repointing the doors
                    //
                    List<string> smasmASM = Parse_SMASM_ASM(asm, out int startline, out int endline, out bool roomExists);

                    List<string> smasm8F = new List<string>();
                    List<string> smasm83d = new List<string>();
                    List<string> smasm83f = new List<string>();
                    List<string> smasmA1 = new List<string>();
                    List<string> smasmB4 = new List<string>();
                    List<string> smasmLV = new List<string>();
                    List<string> smasmTilesets = new List<string>();

                    GetSMASMsections(smasmASM, out smasm8F, out smasm83d, out smasm83f, out smasmA1, out smasmB4, out smasmLV, out smasmTilesets, out List<string> smasmTilesetTable);

                    oldRooms.Reverse();
                    oldNames.Reverse();

                    //make the doors section into a single string for easy searching
                    string single_string_83d = "";
                    foreach (string item in smasm83d)
                    {
                        single_string_83d += item + "@";
                    }

                    //for each item in oldNames, find and replace "dw $oldRooms :" in the door section of the ASM file.
                    //NOTE: this only catches valid door links. eg, the room header in the door data MUST be in the list, else it gets ignored.
                    for (int i = 0; i < oldRooms.Count; i++)
                    {
                        string find = "dw $" + oldRooms[i].Substring(1) + " :";
                        string replace = "dw $" + aRooms[i].Substring(1) + " :";
                        single_string_83d = ReplaceAllOccurences(single_string_83d,find, replace);
                    }
                    List<string> new83d = single_string_83d.Split('@').ToList<string>();
                    new83d.RemoveAt(new83d.Count-1);
                    //^^^this gets rid of a blank entry that appears due to the last @ in the file.

                    //to insert this new $83, the easiest way would be to rebuild the whole ASM file in the same way that Export to ASM does.
                    string final = ConcatASMsections(smasm8F, new83d, smasm83f, smasmA1, smasmB4, smasmLV, smasmTilesets, smasmTilesetTable);
                    List<string> pASM = ASM2List(asm);
                    pASM.RemoveRange(startline, (endline + 1) - startline);
                    pASM.Insert(startline, final);
                    try
                    {
                        File.WriteAllLines(asm, pASM);
                    }
                    catch
                    {
                        MessageBox.Show("Write to ASM failed. Is it open in another program?", "Write Fail", MessageBoxButtons.OK);
                    }
                    //Then apply using ASAR and we're done!
                    patch.StartInfo.UseShellExecute = false;
                    patch.StartInfo.FileName = asr;
                    patch.StartInfo.Arguments = strCmdText;
                    patch.StartInfo.CreateNoWindow = true;
                    patch.StartInfo.RedirectStandardOutput = true;
                    patch.Start();
                    patch.WaitForExit();



                    File.WriteAllText(mdbpath, res);
                   // StatusBox.Clear();
                    StatusBox.AppendText(
                        "-------------------\n" +
                        "ROOMS APPLIED\n" +
                        DateTime.Now.ToLongTimeString() + "\n" +
                        ""
                        );
                    StatusBox.Text += res + "\n-------------------\n";

                }
            }
            catch (Exception eg)
            {
                StatusBox.Text = "Fail";
                Console.WriteLine(eg.Message);
            }
        }

        private string ReplaceAllOccurences(string Source, string Find, string Replace)
        {
            loop:
            if(Find == Replace) { return Source; }
            int Place = Source.IndexOf(Find);
            if(Place == -1) { return Source; }
            Source = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            goto loop;
        }


        private void HeaderData_Validating(object sender, CancelEventArgs e)
        {
            TextBox a = (TextBox)sender;
            uint barse;
            if (uint.TryParse(RoomIndex.Text, NumberStyles.HexNumber, null, out barse))
            {
                
            }
            else
            {
                a.Text = "";
                e.Cancel = true;
            }
        }

        private void RoomIndex_Validated(object sender, EventArgs e)
        {
            thisroom.Rename(uint.Parse(RoomIndex.Text, NumberStyles.HexNumber), uint.Parse(AreaIndex.Text, NumberStyles.HexNumber));
        }

        private void BlockCopy_Click(object sender, EventArgs e)
        {
            ListBox A = (ListBox)DataListMenu.SourceControl;

            //disallow copy if max limit reached
            //determine data type based on first letter of control name
            //Enemies, GFX, PLM, FX, Doors, State
            foreach (var item in A.SelectedIndices)
            {
                if (A.Name.Substring(0, 1) == "E" && A.Items.Count < MaxEnemies)
                {
                    thisroom.States[StateBox.SelectedIndex].Enemies.Add(thisroom.States[StateBox.SelectedIndex].Enemies[(int)item]);
                }
                else if (A.Name.Substring(0, 1) == "G" && A.Items.Count < MaxGFX)
                {
                    thisroom.States[StateBox.SelectedIndex].EnemiesAllowed.Add(thisroom.States[StateBox.SelectedIndex].EnemiesAllowed[(int)item]);
                }
                else if (A.Name.Substring(0, 1) == "P" && A.Items.Count < MaxPLMs)
                {
                    thisroom.States[StateBox.SelectedIndex].PLMs.Add(thisroom.States[StateBox.SelectedIndex].PLMs[(int)item]);
                }
                else if (A.Name.Substring(0, 1) == "F" && A.Items.Count < MaxFX)
                {
                    thisroom.States[StateBox.SelectedIndex].FX.Add(thisroom.States[StateBox.SelectedIndex].FX[(int)item]);
                }
                else if (A.Name.Substring(0, 1) == "D" && A.Items.Count < MaxDoors)
                {
                    thisroom.Doors.Add(thisroom.Doors[(int)item]);
                }
                else if (A.Name.Substring(0, 1) == "S" && A.Items.Count < MaxStates)
                {
                    MessageBox.Show("State addition not yet supported!");
                }
            }



            StateBox_SelectedIndexChanged(sender, e);
        }
        private void NewItem_Click(object sender, EventArgs e)
        {
            ListBox B = (ListBox)DataListMenu.SourceControl;
            ObjectPicker A = new ObjectPicker(this,B);
            uint[] n;

            if (B.Name.Substring(0, 1) == "E" && B.Items.Count < MaxEnemies)
            {
                A.ShowDialog();
                n = A.Results();
                A.Close();
                thisroom.States[StateBox.SelectedIndex].Enemies.Add(CreateEnemy(sm, n[0], n[1], n[2]));
            }
            else if (B.Name.Substring(0, 1) == "G" && B.Items.Count < MaxGFX)
            {
                A.ShowDialog();
                n = A.Results();
                A.Close();
                thisroom.States[StateBox.SelectedIndex].EnemiesAllowed.Add(CreateGFX(sm, n[0], n[1]));
            }
            else if (B.Name.Substring(0, 1) == "P" && B.Items.Count < MaxPLMs)
            {
                A.ShowDialog();
                n = A.Results();
                A.Close();
                thisroom.States[StateBox.SelectedIndex].PLMs.Add(CreatePLM(sm, n[0], n[1], n[2]));
            }
            else if (B.Name.Substring(0, 1) == "F" && B.Items.Count < MaxPLMs)
            {
                thisroom.States[StateBox.SelectedIndex].FX.Add(CreateFX());
            }
            else if (B.Name.Substring(0, 1) == "D" && B.Items.Count < MaxPLMs)
            {
                thisroom.Doors.Add(CreateDoor());
            }



            StateBox_SelectedIndexChanged(sender, e);

        }
        public EnemyData CreateEnemy(ROM sm, uint ID, uint X, uint Y)
        {
            //public EnemyData(ROM sm, uint pointer)
            //{
            //    ID = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            //    PosX = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            //    PosY = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            //    TileMap = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            //    Special = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            //    SpecGFX = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            //    Speed1 = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            //    Speed2 = ROM.readWord(pointer, sm.Rom); pointer = pointer + 2;
            //}
            EnemyData crate = new EnemyData()
            {
                ID = ID,
                PosX = X,
                PosY = Y,
                TileMap = 0x0000,
                Special = 0x2000,
                SpecGFX = 0x0000,
                Speed1 = 0x0000,
                Speed2 = 0x0000
            };
            return crate;
        }
        public PLMdata CreatePLM(ROM sm, uint ID, uint X, uint Y)
        {
            //public PLMdata(ROM sm, uint pointer)
            //{
            //    ID = ROM.readWord(pointer, sm.Rom); pointer += 2;
            //    PosX = sm.Rom[pointer]; pointer++;
            //    PosY = sm.Rom[pointer]; pointer++;
            //    Variable = ROM.readWord(pointer, sm.Rom);
            //}
            PLMdata crate = new PLMdata()
            {
                ID = ID,
                PosX = X,
                PosY = Y,
                Variable = 0x0000
            };
            return crate;
        }
        public EnemyGFX CreateGFX(ROM sm, uint ID, uint PAL)
        {
            EnemyGFX crate = new EnemyGFX()
            {
                ID = ID,
                Palette = PAL
            };
            return crate;
        }
        public FXdata CreateFX()
        {
            //create a default FX with hardcoded values.
            FXdata crate = new FXdata()
            {
                DoorSelect = 0xFFFF,
                LiqStart = 0xFFFF,
                LiqEnd = 0xFFFF,
                LiqSpeed = 0x0000,
                LiqDelay = 0x00,
                Type = 0x00,
                BitA = 0x02,
                BitB = 0x18,
                BitC = 0x00,
                PalFXflags = 0x00,
                TileAnimFlags = 0x00,
                PalBlend = 0x00
            };
            return crate;
        }
        public DoorData CreateDoor()
        {
        //create door using hardcoded values
            DoorData crate = new DoorData()
            {
                Destination = 0,
                Bitflag = 0,
                Direction = 0,
                CapX = 0,
                CapY = 0,
                ScrnX = 0,
                ScrnY = 0,
                SpawnDist = 0x8000,
                DoorASM = 0
            };
            return crate;
        }

        private void AddStateButton_Click(object sender, EventArgs e)
        {
            StateConfig A = new StateConfig(thisroom, StateBox.SelectedIndex);
            A.ShowDialog();

            thisroom = A.ModdedRoom;

            StateBox.Items.Clear();
            for (int i = 0; i < thisroom.StateCount; i++)
            {
                StateBox.Items.Add("State " + i);
            }
            StateBox.Items.Add("Default");
            StateBox.SelectedIndex = StateBox.Items.Count - 1;
        }

        private void StateMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip A = (ContextMenuStrip)sender;
            if(StateBox.Items.Count < 1)
            {
                foreach (ToolStripMenuItem B in A.Items)
                {
                    B.Enabled = false;
                }
            }
            else
            {
                foreach (ToolStripMenuItem B in A.Items)
                {
                    B.Enabled = true;
                }
            }
        }
        private void HexLeave_Textbox(object sender, EventArgs e)
        {
            //Call on textbox validation or leaving.
            //If the box has a valid hex number, it will execute the VisibleChanged event of the control.
            //Else, it will clear the text.

            //Or, i wanted it to execute that event but you can't just call any event freely..................................... >_<;
            TextBox A = (TextBox)sender;
            if(uint.TryParse(A.Text,NumberStyles.HexNumber,null,out uint barse))
            {

            }
            else
            {
                
            }
        }

        private void RefreshExport_Click(object sender, EventArgs e)
        {
            //load room based on current address in Headerbox.
            LoadRoomToGUI();
            ASMbutton_Click(sender, e);
        }

        private void ExportTilesets_Click(object sender, EventArgs e)
        {
            Tilesets2folders(true, true, true);            
        }
        private void ExportTTBs_Click(object sender, EventArgs e)
        {
            //somehow this broke? it zeroed out all the ttb files!
            Tilesets2folders(false, false, true);
        }

        private void Tilesets2folders(bool sceExp, bool palExp, bool ttbExp, int singleset = -1)
        {
            //do nothing if none of the bools are true
            if (!(sceExp || palExp || ttbExp)) 
            { 
                MessageBox.Show("None of the tileset export bools were true. Something went wrong?", "No Args"); 
                return; 
            }

            if (!uint.TryParse(config.ChildNodes[1].SelectSingleNode("TILESETTABLE").InnerText, NumberStyles.HexNumber, null, out uint tilesetTableAddress))
            {
                MessageBox.Show("Invalid Tileset Address in Config!", "Bad Address");
                return;
            }
            //Go to the set location in $8F and get the entries out of the pointer table
            List<TilesetEntry> tileSetTable = new List<TilesetEntry>();
            tileSetTable = GetTilesetPointers(sm, tilesetTableAddress);
            if (tileSetTable == null) { return; }

            //Creates folders for the tilesets to live in each time.
            //It makes them next to the ROM for now
            uint folderIndex = 0;
            string tilesDir = GetTilesetDir();
            Directory.CreateDirectory(tilesDir);
            LUNAR.OpenFile(sm.Path);
            foreach (TilesetEntry item in tileSetTable)
            {
                if ((singleset != -1) && ((uint)singleset != folderIndex)) { return; }

                string currentDirectory = (tilesDir + "\\" + folderIndex + "-" + asmFCN.WByte(folderIndex));
                Directory.CreateDirectory(currentDirectory);
                if (sceExp) { ExportTileset(item.SCE, currentDirectory, ".gfx", folderIndex); }
                if (palExp) { ExportTileset(item.Palette, currentDirectory, ".pal", folderIndex); }
                if (ttbExp) { ExportTileset(item.TileTable, currentDirectory, ".ttb", folderIndex); }
                folderIndex++;
            }
            LUNAR.CloseFile();



            StatusBox.Clear();
            foreach (TilesetEntry item in tileSetTable)
            {
                StatusBox.AppendText(asmFCN.WWord(item.Pointer) + " - " + asmFCN.WLong(item.TileTable) + ", " + asmFCN.WLong(item.SCE) + ", " + asmFCN.WLong(item.Palette) + "\r\n");
            }
        }
        private unsafe void ExportTileset(uint compDataPointer, string destpath, string fileExtension, uint tilesetIndex)
        {
            byte[] dataUC;    //reserve max data size. Norfair gfx are 0x4800 for reference.
            switch (fileExtension)
            {
                case ".gfx":
                    dataUC = new byte[0x5000];
                    break;
                case ".pal":
                    dataUC = new byte[0x0300];//300... hardware limitation! But we need to make it in 256 color depth...
                    break;
                case ".ttb":
                    dataUC = new byte[0x2000];//1800.... but Ceres is $2000 because it doesn't have CRE!
                    break;
                default:
                    //do nothing if the function is not called with a valid file extension
                    return;
                    //break;
            }
            destpath += "\\" + asmFCN.WByte(tilesetIndex) + fileExtension;
            uint pcPointer = LUNAR.SNEStoPC(compDataPointer);
            uint addr2 = 0; //this will be assigned the end of the compressed data; compressed data size = addr2 - pointer

            fixed (void* ptr = dataUC)
            LUNAR.Decompress(ptr, pcPointer, &addr2);    //decompression takes a PC address.
            uint dataCompressedSize = addr2 - pcPointer;

            switch (fileExtension)
            //post processing on the data if needed
            {
                case ".pal":
                    //want to separate each color into its own place in a uint list
                    //then LUNAR snes2pc RGB it
                    //then write the list of output byes to a bin.
                   // File.WriteAllBytes(destpath+"uc", dataUC);
                    List<uint> SNES_5bit = new List<uint>();
                    List<uint> PC_24bit = new List<uint>();
                    for (uint i = 0; i < dataUC.Length; i += 2)
                    {
                        SNES_5bit.Add(ROM.readWord(i, dataUC));
                    }
                    foreach (uint item in SNES_5bit)
                    {
                        PC_24bit.Add(LUNAR.LunarSNEStoPCRGB(item));
                    }
                    byte[] PC_Result = new byte[0x300];
                    byte[] temp = new byte[3];
                    int j = 0;
                    foreach (uint item in PC_24bit)
                    {
                        temp = BitConverter.GetBytes(item);
                        Array.Resize(ref temp, 3);
                        Array.Reverse(temp);
                        for (int i = 0; i < 3; i++)
                        {
                            try
                            {
                                PC_Result[j+i] = temp[i];
                            }
                            catch
                            {
                                break;
                            }
                        }
                        j += 3;
                    }
                    dataUC = PC_Result;
                    break;
                case ".ttb":
                    //Fix the TTB to the normal max size.
                    Array.Resize(ref dataUC, 0x1800 );
                    break;
                default:
                    break;
            }


            File.WriteAllBytes(destpath, dataUC);

        }
        private string GetTilesetDir()
        {
            string romDir = sm.Path.Substring(0, sm.Path.LastIndexOf('\\'));
            string tilesDir = romDir + "\\Tilesets";
            return tilesDir;
        }
        private unsafe string TilesetFolders2ASM(int singleSet = -1)
        {
            //still needs data validation for what to do when there are unexpected items in a folder.
            string tilesetFolder = GetTilesetDir();
            int dircount = Directory.GetDirectories(tilesetFolder).Length;

            Bar TilesetMeter = new Bar("Loading Tilesets:", "This may take a while...",  dircount * 3);
            TilesetMeter.Show();

            List<string> TilesetSection = new List<string>();
            StringBuilder tilesets = new StringBuilder(1000000);    //1MB stringbuilder
            foreach (string item in Directory.EnumerateDirectories(tilesetFolder))
            {
                string name = Path.GetFileName(item);
                string[] nameParse = name.Split('-');
                if(nameParse.Length < 2) 
                { 
                    MessageBox.Show("invalid folder name detected - everything in the Tilesets folder must be named in DD-HH number format.\nAborting Tileset import.", "invalid name");
                    return null;
                }

                //continue to next if singleSet was specified AND the current folder is not the correct set.
                if (
                    (singleSet != -1)
                    &&
                    (singleSet != int.Parse(nameParse[0]))
                   )
                {
                    continue;
                }

                //if singleset != -1 then only grab the set that it specifies.
                tilesets.Append(
                    ".T" + nameParse[1] + "\n" +
                    "{" + "\n" 
                    );
                foreach (string tilesetcomponent in Directory.EnumerateFiles(item))
                {
                    //continue to next if singleSet was specified AND the current folder is not the correct set.
                    //if (
                    //    (singleSet != -1) 
                    //    && 
                    //    (singleSet != int.Parse(nameParse[0]))
                    //   )
                    //{
                    //    continue;
                    //}

                    string label = "";
                    StringBuilder db = new StringBuilder("db ",100000);
                    byte[] source;
                    byte[] compress = new byte[0x10000];
                    uint dataSize;
                    uint compSize;
                    char[] trimChars = { ',', ' ' };
                    bool skipfile = false;
                    //uint pcLevelPointer = LUNAR.SNEStoPC(pLevelData);
                    //uint addr2 = 0; //this will be assigned the end of the compressed data; compressed data size = addr2 - level data pointer
                    //byte[] levelUC = new byte[0xA000];    //reserve max level data size. Landing site is 0x5A00 bytes for reference.
                    //fixed (void* ptr = levelUC)
                    //    LUNAR.Decompress(ptr, pcLevelPointer, &addr2);    //decompression takes a PC address.
                    //levelUC is populated with uncompressed level data.
                    //path.Getextension give it to us in ".###" format.
                    source = File.ReadAllBytes(tilesetcomponent);
                    dataSize = (uint)source.Length;

                    //if .pal then it does some extra preprocessing on the source
                    if (Path.GetExtension(tilesetcomponent) == ".pal")
                    {
                        //needs converted back to SNES color, compressed, then to db
                        List<uint> SNES_5bit = new List<uint>();
                        List<uint> PC_24bit = new List<uint>();

                        //first i need to turn the 3 bytes RGB into a single number?
                        //this can be done with bit shifting.
                        //or with BitConverter!
                        //Note that 0x300 is the max supported palette size for the SNES
                        byte[] temp = new byte[4];
                        int k = 0;

                        for (int j = 0; j < 0x300; j += 3)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                temp[i] = source[i + j];
                            }
                            //if needed this is where we would trim the array down to 3 entries and then reverse it
                            //YES this is needed because toUint32 endianness put it in BGR.

                            //toUint32 appears to natively have the correct endianness..... higher indices in the array are higher powers of the number.
                            //so the first 3 indices are what contain our RGB.
                            uint total = BitConverter.ToUInt32(temp, 0);
                            uint r = total & 0x0000FF;
                            uint g = total & 0x00FF00;
                            uint b = total & 0xFF0000;
                            r <<= 16;
                            b >>= 16;
                            total = r + g + b;
                            PC_24bit.Add(total);
                        }

                        foreach (uint color in PC_24bit)
                        {
                            SNES_5bit.Add(LUNAR.LunarPCtoSNESRGB(color));
                        }

                        //each palette should be 2 bytes uncompressed
                        source = new byte[SNES_5bit.Count];
                        k = 0;
                        for (int i = 0; i < SNES_5bit.Count - 1; i++)
                        {
                            temp = BitConverter.GetBytes(SNES_5bit[i]);
                            for (int j = 0; j < 2; j++)
                            {
                                try
                                {
                                    source[k + j] = temp[j];
                                }
                                catch
                                {
                                    //do nothing
                                    //needs this try catch because the +2 indexing will escape the array by 1.
                                    //source is only 256 bytes long.
                                    //I think??? not sure on that.
                                }

                            }
                            k += 2;
                        }
                        //ready to compress source using the same thing as the other ones.
                    }

                    switch (Path.GetExtension(tilesetcomponent))
                    {
                        case ".gfx":
                            //only needs decompressed to a db.
                            label = "..sce\n";

                            break;

                        case ".pal":
                            label = "..pal\n";

                            break;

                        case ".ttb":
                            label = "..ttb\n";

                            break;

                        default:
                            skipfile = true;
                            break;
                    }

                    if (skipfile) { continue; }
                    fixed (void* sourcePtr = source)
                    fixed (void* destPtr = compress)
                        compSize = LUNAR.Compress(sourcePtr, destPtr, dataSize);
                    for (int i = 0; i < compSize; i++)
                    {
                        db.Append("$" + asmFCN.WByte(compress[i]) + ",");
                    }
                    db = db.Remove(db.Length-1,1);

                    db.Append("\n");
                    tilesets.Append(label + db);
                    TilesetMeter.AddToBar(1);
                }
                //Append the closing parenthesis
                tilesets.Append(
                    "}" + "\n"
                    );

            }
            //Console.WriteLine("a");
            //File.WriteAllText(@"tilesets.txt", tilesets.ToString(),Encoding.UTF8);
            TilesetMeter.Close();
            return tilesets.ToString();
        }

        public List<TilesetEntry> GetTilesetPointers(ROM sm, uint tstAddress)
        {
            //this function assumes the list of pointers comes after the tileset entries.
            List<TilesetEntry> tileSetTable = new List<TilesetEntry>();
            //read 9 bytes per entry, 3 bytes per pointer until value read = tstAddress OR loop > 1000, in which case error.
            //Start with tstAddress converted to PC:
            uint reader = tstAddress + 0x70000;

            do
            {
                tileSetTable.Add(new TilesetEntry(reader,sm));
                reader += 9;
            } 
            while 
            (
            (ROM.readWord(reader,sm.Rom) != tstAddress)
            ||
            (reader < tstAddress + 500)
            );

            if(reader < tstAddress + 500)
            {
                MessageBox.Show("Tileset Table Read error: Following List not found!", "Terminator not Found");
                return null;
            }

            return tileSetTable;
        }

        public List<string> ClearSection(List<string> input)
        {
            //return the query label and brackets with the inners removed.
            //i might not actually need this for the tileset thing because it generates the query label + brackets.
            return null;
        }

        private void ImportTilesets_Click(object sender, EventArgs e)
        {
            //Thread t = new Thread(new ThreadStart(this.ImportTileSets()));
            ImportTileSets();
        }

        public void ImportTileSets(int singleSet = -1)
        {
            //missing arg or -1 will import ALL
            //specifying a number will export only THAT tileset.
            string asmPath = config.ChildNodes[1].SelectSingleNode("ASM").InnerText;
            string tilesets = TilesetFolders2ASM(singleSet);
            List<string> smasmList = Parse_SMASM_ASM(asmPath, out int smasmStartLine, out int smasmEndLine, out bool Room);
            GetSMASMsections(smasmList, out List<string> smasm8F, out List<string> smasm83d, out List<string> smasm83f, out List<string> smasmA1, out List<string> smasmB4, out List<string> smasmLV, out List<string> smasmTilesets, out List<string> smasmTilesetTable);
            //when adding functionality for singles, it needs to locate and replace only the .T## that we selected.
            //This simple solution will be contained in an IF that makes sure we want to overwrite all.
            if (singleSet == -1)
            {
                //overwrite the entire tileset section
                smasmTilesets.RemoveRange(2, smasmTilesets.Count - 2);
                smasmTilesets.Add(tilesets);
                smasmTilesets.Add("}");
            }
            else
            {
                //do some cleanup to account for the single section not needing the top-level labels.

                //search the list for the singleSet and insert it
                List<string> singleSection = FindSection(".T" + asmFCN.WByte((uint)singleSet), smasmTilesets, out int startline, out int endline);
                smasmTilesets.RemoveRange(startline, (endline - startline)+1);
                smasmTilesets.Insert(startline, tilesets);
            }

            //for the tileset table, it's small so it can replace the whole thing every time.
            smasmTilesetTable.RemoveRange(2, smasmTilesetTable.Count - 2);
            smasmTilesetTable.Add(GenerateTilesetTable());
            smasmTilesetTable.Add("}");

            string final = ConcatASMsections(smasm8F, smasm83d, smasm83f, smasmA1, smasmB4, smasmLV, smasmTilesets, smasmTilesetTable);
            List<string> pASM = ASM2List(asmPath);
            pASM.RemoveRange(smasmStartLine, (smasmEndLine + 1) - smasmStartLine);
            pASM.Insert(smasmStartLine, final);
            try
            {
                File.WriteAllLines(asmPath, pASM);
            }
            catch
            {
                MessageBox.Show("Write to ASM failed. Is it open in another program?", "Write Fail", MessageBoxButtons.OK);
            }
        }

        private void ImportCurrentTileset_Click(object sender, EventArgs e)
        {
            if(TilesetBox.Text == "") { MessageBox.Show("No room is currently loaded! Open a room first.", "No Room Loaded", MessageBoxButtons.OK); return; }
            ImportTileSets(int.Parse(TilesetBox.Text));
        }

        private string GenerateTilesetTable()
        {
            StringBuilder tilesetTable = new StringBuilder(100);
            StringBuilder tilesetPointers = new StringBuilder("dw ", 100);

            //for each directory in the Tilesets folder,
            //TILESETTABLE:
            //dw .T##, .T##, .T##, ...
            //.T##
            //dl TILESETS_t##_ttb, TILESETS_t##_sce, TILESETS_t##_pal
            //.
            //.
            //.
            string tilesetFolder = GetTilesetDir();
            int forceOrder = 0;
            //tilesetPointers.Append("TILESETTABLE:\n ");
            foreach (string item in Directory.EnumerateDirectories(tilesetFolder))
            {
                //for each folder, check each folder to see if it's the right one.
                foreach (string item2 in Directory.EnumerateDirectories(tilesetFolder))
                {
                    string name = Path.GetFileName(item2);
                    string[] nameParse = name.Split('-');
                    if (nameParse.Length < 2)
                    {
                        //MessageBox.Show("invalid folder name detected - everything in the Tilesets folder must be named in DD-HH number format.\nAborting Tileset import.", "invalid name");
                        return null;
                    }
                    if (int.Parse(nameParse[0]) == forceOrder)
                    {
                        string tilesetIndex = nameParse[1];
                        tilesetTable.Append(".T" + tilesetIndex + "\n" + "dl TILESETS_T" + tilesetIndex + "_ttb" + ", " + "TILESETS_T" + tilesetIndex + "_sce" + ", " + "TILESETS_T" + tilesetIndex + "_pal" + "\n");
                        tilesetPointers.Append(".T" + tilesetIndex + ", ");
                        forceOrder++;
                        break;
                    }
                }

            }
            tilesetPointers.Remove(tilesetPointers.Length - 2, 2);
            tilesetTable.Remove(tilesetTable.Length - 1, 1);
            tilesetTable.Append("\n");
            tilesetTable.Append(".POINTERS\n");
            tilesetTable.Append(tilesetPointers);
            return tilesetTable.ToString();
        }

            private void bitshift_Click(object sender, EventArgs e)
        {
            //StatusBox.Text = asmFCN.WLong(RollASL(uint.Parse(StatusBox.Text, NumberStyles.HexNumber, null), 8, 3));
            for (int i = 0; i < 500; i++)
            {
                AppendStatus(i.ToString());
            }
        }
        public uint RollASL(uint operand, int shiftby, int dataBytes)
        {

            //not sure how i can make it wrap around....
            //got stuck when trying to separate bytes of A that wrapped when B became less than A.
            //Depends on how many bits we're shifting at once.
            //but there's no bit data type...
            //so we need to find a way to work with just those bits, which depends on the size of the int being worked with.
            //BITMASK!

            int bitsize = (int)(dataBytes * 8);
            int bitmask = 0xFF;
            for (int i = 0; i < dataBytes; i++)
            {
                bitmask *= 0x100;
            }
            bitmask = ~bitmask;

            uint a = operand;
            uint b;
            uint c;

            b = (uint)(a << shiftby) & (uint)bitmask;

            c = (uint)(a >> bitsize - shiftby);
            b = (uint)(b | c);

            return b;
        }

        private void ExportCurrentTileset_Click(object sender, EventArgs e)
        {
            Tilesets2folders(true, true, true, int.Parse(TilesetBox.Text, NumberStyles.HexNumber));
        }

        private void tilesetSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StatusBox_TextChanged(object sender, EventArgs e)
        {
            //if not typing on empty row in most recent line, revert the character change.
            RichTextBox A = (RichTextBox)sender;
             
        }
    }

    public class TilesetEntry
    {
        public TilesetEntry(uint pointer, ROM sm)
        {
            Pointer = pointer;
            TileTable = ROM.readLong(pointer,sm.Rom);
            pointer += 3;
            SCE = ROM.readLong(pointer, sm.Rom);
            pointer += 3;
            Palette = ROM.readLong(pointer, sm.Rom);
        }
        public uint TileTable { get; set; }
        public uint SCE { get; set; }
        public uint Palette { get; set; }
        public uint Pointer { get; set; }
    }
    public class MDBentry
    {
        public string Pointer { get; set; }
        public string Name { get; set; }
    }

    public static class LUNAR
    {
        //LUNAR prefixed names are straight from DLL
        //Unprefixed names are wrapped for convenience regarding SM ROM type, headeredness, etc.

        public static uint PCtoSNES(uint pc)
        {
            //0x10 for Lorom, 0 for headerless.
            return LunarPCtoSNES(pc, 0x10, 0);
        }

        public static uint SNEStoPC(uint snes)
        {
            return LunarSNEStoPC(snes, 0x10, 0);
        }

        public static unsafe bool OpenFile(string filename)
        {
            //open ROM as UTF8.
            return LunarOpenFile(filename, 0x40);
        }

        public static bool CloseFile()
        {
            return LunarCloseFile();
        }

        public static unsafe uint Decompress(void* dest, uint pc, uint* end)
        {
            return LunarDecompress(dest, pc, 0x5000, 4, 0, end);  //not sure if this will work since the last var ROMPOSITION is supposed to be a pointer....
        }
        public static unsafe uint Compress(void* source, void* dest, uint source_size)
        {
            //LunarRecompress(*byte[] .GFX_File, *byte[] Compressed_Array, GFX_File.Length, 0x10000, 4, 0)
            return LunarRecompress(source, dest, source_size, 0x10000, 4, 0); 
        }


        [DllImport("C:\\Users\\oi23\\source\\repos\\SM-ASM-GUI\\SM-ASM-GUI\\LCompress\\Lunar Compress.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint LunarVersion();

        [DllImport("C:\\Users\\oi23\\source\\repos\\SM-ASM-GUI\\SM-ASM-GUI\\LCompress\\Lunar Compress.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.StdCall)]

        public static extern uint LunarPCtoSNES(uint pc, uint romtype, uint header);

        [DllImport("C:\\Users\\oi23\\source\\repos\\SM-ASM-GUI\\SM-ASM-GUI\\LCompress\\Lunar Compress.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint LunarSNEStoPC(uint snes, uint romtype, uint header);
        //typedef unsigned int (WINAPI *LCPROC7)(unsigned int Pointer, unsigned int ROMType, unsigned int Header);


        [DllImport("C:\\Users\\oi23\\source\\repos\\SM-ASM-GUI\\SM-ASM-GUI\\LCompress\\Lunar Compress.dll", SetLastError = true)]
        private static unsafe extern bool LunarOpenFile([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, uint filemode);
        //typedef BOOL(WINAPI* LCPROC3)(char* FileName, unsigned int FileMode);
        //extern LCPROC3 LunarOpenFile;
        /**************************************************************************

Open file for access by the DLL.  Files of any size can be opened, since the 
DLL does not load the entire file into RAM for manipulations.
If another file is already open, LunarCloseFile() will be used to close it 
first.  

The DLL does not prevent other applications from reading/writing to the 
file at the same time, though of course that isn't recommended.

char* FileName        - Null terminated string for name of file to open.
unsigned int FileMode - Indicates the mode to open the file in, plus optional
                        flags.  The modes and flags available are:
 LC_READONLY        : Open existing file in read-only mode (default).
 LC_READWRITE       : Open existing file in read and write mode.
 LC_CREATEREADWRITE : Create a new file in read and write mode, erase the
                      existing file (if any).
 LC_UTF8            : The FileName argument will be in UTF-8 format.  If
                      this flag is not specified, it is assumed to use
                      the current "ANSI" code page of the OS instead.

Returns true on success, false on fail.

file flags
#define LC_READONLY         0x00
#define LC_READWRITE        0x01
#define LC_CREATEREADWRITE  0x02
#define LC_LOCKARRAYSIZE    0x04
#define LC_LOCKARRAYSIZE_2  0x08
#define LC_CREATEARRAY      0x10
#define LC_SAVEONCLOSE      0x20
#define LC_UTF8             0x40

**************************************************************************/


        [DllImport("C:\\Users\\oi23\\source\\repos\\SM-ASM-GUI\\SM-ASM-GUI\\LCompress\\Lunar Compress.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool LunarCloseFile();
        //typedef BOOL(WINAPI* LCPROC2)();
        //extern LCPROC2 LunarCloseFile;



        [DllImport("C:\\Users\\oi23\\source\\repos\\SM-ASM-GUI\\SM-ASM-GUI\\LCompress\\Lunar Compress.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        private static unsafe extern uint LunarDecompress(void* array, uint pointer, uint maxsize, uint format, uint format2, uint* LastROMposition);
        [DllImport("C:\\Users\\oi23\\source\\repos\\SM-ASM-GUI\\SM-ASM-GUI\\LCompress\\Lunar Compress.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        //LunarDecompress(dest, pc, 0x5000, 4, 0, null)
        private static unsafe extern uint LunarRecompress(void* source, void* destination, uint datasize, uint maxDatasize, uint format, uint format2);
        //LunarRecompress(*byte[] .GFX_File, *byte[] Compressed_Array, GFX_File.Length, 0x10000, 4, 0)
        //
        //LC_LZ5 = 4 Metroid3[GD]   A slightly enhanced form of LZ2.
        //typedef unsigned int (WINAPI* LCPROC9) (void* Destination, unsigned int AddressToStart, unsigned int MaxDataSize, unsigned int Format, unsigned int Format2, unsigned int* LastROMPosition);
        //extern LCPROC9 LunarDecompress;
        /*        Decompress data from the currently open file into an array.

        void* Destination             - destination byte array for decompressed data.
        unsigned int AddressToStart   - file offset to start at.
        unsigned int MaxDataSize      - maximum number of bytes to copy into dest.
        unsigned int Format           - compression format (see table below).
        unsigned int Format2          - must be zero unless otherwise stated.
        unsigned int* LastROMPosition - an optional pointer that the function will
           use to store the file offset of the next byte that comes after the
           compressed data.This could be used to calculate the size of the
           compressed data after calling the function, using the simple formula
           LastROMPosition-AddressToStart.You can pass NULL if you don't need
           this value.

        Returns the size of the decompressed data.A value of zero indicates either
        failure or a decompressed structure of size 0.

        If the size of the decompressed data is greater than MaxDataSize, the data
        will be truncated to fit into the array.  Note however that the size value
        returned by the function will not be the truncated size.  

        If Destination = NULL and/or MaxDataSize = 0, no data will be copied to the
        array but the function will still decompress the data so it can return the
        size and store the LastROMPosition.

        In general, a max limit of 0x10000 bytes is supported for the uncompressed
        data, which is the size of a HiROM SNES bank.A few formats may have lower
        limits depending on their design.
        */
        /**************************************************************************

        Compress data from a byte array and place it into another array. 

        void* Source               - source byte array of data to compress.
        void* Destination          - destination byte array for compressed data.
        unsigned int DataSize      - size of the data to compress in bytes.
        unsigned int MaxDataSize   - maximum number of bytes to copy into dest.
        unsigned int Format        - compression format (see LunarDecompress() table)
        unsigned int Format2       - must be zero unless otherwise stated.

        Returns the size of the compressed data.  A value of zero indicates
        failure.

        The Source and Destination variables can point to the same array.

        If the size of the compressed data is greater than MaxDataSize, the data 
        will be truncated to fit into the array.  Note however that the size value 
        returned by the function will not be the truncated size.  

        In general, a max limit of 0x10000 bytes is supported for the uncompressed
        data, which is the size of a HiROM SNES bank.  A few formats may have lower 
        limits depending on their design.

        If Destination=NULL and/or MaxDataSize=0, no data will be copied to the
        array but the function will still compress the data so it can return the
        size of it.

        **************************************************************************/
        //extern LCPROC9 LunarDecompress;
        //typedef unsigned int (WINAPI* LCPROC9) (void* Destination, unsigned int AddressToStart, unsigned int MaxDataSize, unsigned int Format, unsigned int Format2, unsigned int* LastROMPosition);

        //typedef unsigned int (WINAPI* LCPROC10) (void* Source, void* Destination, unsigned int DataSize, unsigned int MaxDataSize, unsigned int Format, unsigned int Format2);
        //extern LCPROC10 LunarRecompress;
        //extern "C" unsigned int WINAPI _export LunarRecompress(void* Source, void* Destination,unsigned int DataSize, unsigned int MaxDataSize, unsigned int Format, unsigned int Format2)


        [DllImport("C:\\Users\\oi23\\source\\repos\\SM-ASM-GUI\\SM-ASM-GUI\\LCompress\\Lunar Compress.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static unsafe extern uint LunarSNEStoPCRGB(uint SNESColor);

        [DllImport("C:\\Users\\oi23\\source\\repos\\SM-ASM-GUI\\SM-ASM-GUI\\LCompress\\Lunar Compress.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static unsafe extern uint LunarPCtoSNESRGB(uint PCColor);
        /**************************************************************************

Converts a standard SNES 15-bit color into a PC 24-bit color.

unsigned int SNESColor - SNES RGB value.
                         (???????? ???????? ?bbbbbgg gggrrrrr)

Returns PC color value. (00000000 rrrrr000 ggggg000 bbbbb000)

**************************************************************************/

        //        typedef unsigned int (WINAPI* LCPROC16) (unsigned int SNESColor);
        //        extern LCPROC16 LunarSNEStoPCRGB;
        //extern "C" unsigned int WINAPI _export LunarSNEStoPCRGB(unsigned int SNESColor)




        /**************************************************************************

        Converts a standard PC 24-bit color into the nearest SNES 15-bit color, by
        rounding each color component to the nearest 5-bit value.

        unsigned int PCColor - PC RGB value. 
                               (???????? rrrrrrrr gggggggg bbbbbbbb)

        Returns SNES color value. (00000000 00000000 0bbbbbgg gggrrrrr)

        **************************************************************************/

        //        typedef unsigned int (WINAPI* LCPROC17) (unsigned int PCColor);
        //        extern LCPROC17 LunarPCtoSNESRGB;
        //extern "C" unsigned int WINAPI _export LunarPCtoSNESRGB(unsigned int PCColor)
    }
    public class ROM
    {
        public string Path;
        public byte[] Rom;
        public ROM(string FilePath)
        {
            Path = FilePath;
            try { Rom = File.ReadAllBytes(FilePath); }
            catch 
            { 
                Rom = null;
                MessageBox.Show("ROM could not be opened.");
            }   //message box for no rom selected; open file picker for them
        }



        public static uint readWord(uint pc, byte[] rom)
        {
            byte hi, lo;
            lo = rom[pc];
            hi = rom[pc + 1];
            uint word = (uint)hi * 0x100 + (uint)lo;
            return word;
        }

        public static uint readLong(uint pc, byte[] rom)
        {
            byte hi, lo, bk;
            lo = rom[pc];
            hi = rom[pc + 1];
            bk = rom[pc + 2];
            uint longaddr = (uint)bk * 0x100 * 0x100 + (uint)hi * 0x100 + (uint)lo;
            return longaddr;
        }

    }


}
