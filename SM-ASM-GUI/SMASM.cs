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
    public struct Tile
    {
        //tile in the context of the map drawing tool
        //BTS unused for now, but could be used to draw super missile blocks differently from others/ etc.
        //the endianness of the tiledata must be correct prior to calling.
        public Tile(uint tileIndex, byte[]levelDataUncompressed)
        {
            uint levelSize = (uint)levelDataUncompressed[0] + (uint)levelDataUncompressed[1] * 0x100;
            uint btsPosition = 1 + levelSize + tileIndex/2;

            uint tileData = (uint)levelDataUncompressed[tileIndex] + (uint)levelDataUncompressed[tileIndex + 1] * 0x100;
            sbyte bts = (sbyte)levelDataUncompressed[btsPosition];
            Raw = tileData;
            BTS = bts;
            BTS_unsigned = (uint)levelDataUncompressed[btsPosition];
            Index = tileIndex;
            Color black = Color.FromArgb(255, 0, 0, 0);
            Color white = Color.FromArgb(255, 255, 255, 255);
            Color alpha = Color.LightGray;

            Color powerbomb = Color.FromArgb(255, 128, 0);
            Color supermissile = Color.FromArgb(0, 200, 0);
            Color missile = Color.FromArgb(215,32,155);
            Color blueDoor = Color.FromArgb(40,160,240);

            Color doorTube = Color.Brown;

            Color crumble = Color.Gray;
            Color speed = Color.Aquamarine;

            Color grapple = Color.LightSlateGray;

            Color bombblock = Color.White;

            //this sets up the default colors for each tile type - another switch for BTS after this one.
            tileData &= 0xF000;
            switch (tileData)
            {
                case (uint)TileType.Air:
                    Type = TileType.Air;
                    DrawColor = alpha;
                    break;
                case (uint)TileType.Slope:
                    Type = TileType.Slope;
                    DrawColor = alpha;
                    break;
                case (uint)TileType.AirSpike:
                    Type = TileType.AirSpike;
                    DrawColor = alpha;
                    break;
                case (uint)TileType.AirShootable:
                    Type = TileType.AirShootable;
                    DrawColor = alpha;
                    break;
                case (uint)TileType.Hcopy:
                    Type = TileType.Hcopy;
                    DrawColor = alpha;
                    break;
                case (uint)TileType.AirUnused:
                    Type = TileType.AirUnused;
                    DrawColor = alpha;
                    break;
                case (uint)TileType.AirBombable:
                    Type = TileType.AirBombable;
                    DrawColor = alpha;
                    break;
                case (uint)TileType.Solid:
                    Type = TileType.Solid;
                    DrawColor = black;
                    break;
                case (uint)TileType.Door:
                    Type = TileType.Door;
                    DrawColor = doorTube;
                    break;
                case (uint)TileType.Spike:
                    Type = TileType.Spike;
                    DrawColor = black;
                    break;
                case (uint)TileType.Special:
                    Type = TileType.Special;
                    DrawColor = black; //the BTS will fix this later if an important type.
                    break;
                case (uint)TileType.Shot:
                    Type = TileType.Shot;
                    DrawColor = white;
                    break;
                case (uint)TileType.Vcopy:
                    Type = TileType.Vcopy;
                    DrawColor = alpha;
                    break;
                case (uint)TileType.Grapple:
                    Type = TileType.Grapple;
                    DrawColor = grapple;
                    break;
                case (uint)TileType.Bomb:
                    Type = TileType.Bomb;
                    DrawColor = bombblock;
                    break;
                default:
                    Type = TileType.Air;
                    DrawColor = alpha;
                    break;
            }
            //Type has been assigned:
            switch (Type)
            {
                case TileType.Air:
                    switch (BTS)
                    {
                        default:
                            break;
                    }
                    break;
                //slope + $40 = H flip
                //slope + $80 = V Flip
                case TileType.Slope:
                    bool squareSlope = false;
                    if (IsBetween(7 + 0x00, 0xE + 0x00, BTS_unsigned)) { squareSlope = true;}
               else if (IsBetween(7 + 0x40, 0xE + 0x40, BTS_unsigned)) { squareSlope = true;}
               else if (IsBetween(7 + 0x80, 0xE + 0x80, BTS_unsigned)) { squareSlope = true;}
               else if (IsBetween(7 + 0xC0, 0xE + 0xC0, BTS_unsigned)) { squareSlope = true;}
               else if (BTS_unsigned == 0x13 + 0x00) { squareSlope = true;}
               else if (BTS_unsigned == 0x13 + 0x40) { squareSlope = true;}
               else if (BTS_unsigned == 0x13 + 0x80) { squareSlope = true;}
               else if (BTS_unsigned == 0x13 + 0xC0) { squareSlope = true;}

                    if (squareSlope)
                    {
                        DrawColor = black; break;
                    }
                    //if we want to color any other kinds of slopes, it's here...
                    switch (BTS)
                    {
                        default:
                            break;
                    }
                    break;
                case TileType.AirSpike:
                    switch (BTS)
                    {
                        default:
                            break;
                    }
                    break;
                case TileType.AirSpecial:
                    switch (BTS)
                    {
                        default:
                            break;
                    }
                    break;
                case TileType.AirShootable:
                    switch (BTS)
                    {
                        default:
                            break;
                    }
                    break;
                case TileType.Hcopy:
                    switch (BTS)
                    {
                        default:
                            break;
                    }
                    break;
                case TileType.AirUnused:
                    switch (BTS)
                    {
                        default:
                            break;
                    }
                    break;
                case TileType.AirBombable:
                    switch (BTS)
                    {
                        default:
                            break;
                    }
                    break;
                case TileType.Solid:
                    switch (BTS)
                    {
                        default:
                            break;
                    }
                    break;
                case TileType.Door:
                    switch (BTS)
                    {
                        default:
                            break;
                    }
                    break;
                case TileType.Spike:
                    switch (BTS)
                    {
                        default:
                            break;
                    }
                    break;
                case TileType.Special:
                    switch (BTS)
                    {
                        case 0x0:
                        case 0x1:
                        case 0x2:
                        case 0x3:
                        case 0x4:
                        case 0x7:
                            DrawColor = crumble; break;
                        case 0X8:
                        case 0X9:
                        case 0XA:
                        case 0XB:
                            DrawColor = alpha; break;
                        case 0xE:
                        case 0xF:
                            DrawColor = speed; break;
                        default:
                            break;
                    }
                    break;
                case TileType.Shot:
                    switch (BTS)
                    {
                        case 0x8:
                        case 0x9:
                            DrawColor = powerbomb; break;
                        case 0xA:
                        case 0xB:
                            DrawColor = supermissile; break;
                        case 0xC:
                            DrawColor = missile; break;
                        case 0x40:
                        case 0x41:
                        case 0x42:
                        case 0x43:
                            DrawColor = blueDoor; break;
                        default:
                            break;
                    }
                    break;
                case TileType.Vcopy:
                    switch (BTS)
                    {
                        default:
                            break;
                    }
                    break;
                case TileType.Grapple:
                    switch (BTS)
                    { 
                        default:
                            break;
                    }
                    break;
                case TileType.Bomb:
                    switch (BTS)
                    {
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        public uint Raw { get; set; }
        public sbyte BTS { get; set; }
        public uint BTS_unsigned { get; set; }
        public uint Index { get; set; }
        public TileType Type { get; set; }
        public Color DrawColor { get; set; }
        private bool IsBetween(uint lower, uint higher, uint input)
        {
            if((input < higher) && (input > lower)) { return true; }
            else { return false; }
        }
    }
    public enum TileType : uint
    {
        Air = 0x0000,
        Slope = 0x1000,
        AirSpike = 0x2000,
        AirSpecial = 0x3000,
        AirShootable = 0x4000,
        Hcopy = 0x5000,
        AirUnused = 0x6000,
        AirBombable = 0x7000,
        Solid = 0x8000,
        Door = 0x9000,
        Spike = 0xA000,
        Special = 0xB000,
        Shot = 0xC000,
        Vcopy = 0xD000,
        Grapple = 0xE000,
        Bomb = 0xF000
    }
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
            //#################################################################################
            //THIS MAX LEVEL SIZE MUST AGREE WITH THE MAX DECOMPRESSION SIZE IN THE LUNAR CLASS
            //#################################################################################
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
                if (ROM.readWord(j, sm.Rom) == 0xFFFF) { break; }
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


            try
            {
                uint i, j = LUNAR.SNEStoPC(DoorOut + 0x8F0000); //this short pointer is in $8F.
                                                                //i is to limit this to max doors
                                                                //j is pointer to read in $8F.
                List<DoorData> thesedoors = new List<DoorData>();
                for (i = 0; i < 0x100; i++)
                {
                    thesedoors.Add(new DoorData(sm, LUNAR.SNEStoPC(ROM.readWord(j, sm.Rom) + 0x830000)));    //Readword passes the pointer at this address
                    j++; j++;
                    if (ROM.readWord(j, sm.Rom) < 0x8000) { break; }
                }
                Doors = thesedoors;
                //mandatory header is 11 bytes, door list is that many words plus terminator.
                Bytes8F = 11 + thesedoors.Count * 2 + 2;



                //count how many words after the Doorout pointer that Std. State $E5E6 is found.
                uint statecount = 0;
                i = 0;
                uint x = ROM.readWord(pheader + 11 + i, rom);
                uint[,] statepointers = new uint[255, 3];
                //               0           1              2
                //statepointers [Event type, Event Pointer, Optional Arg.] for each state.
                while (x != (uint)StateType.Default)          //As pc address
                {
                    statepointers[statecount, 0] = x;
                    if (x == (uint)StateType.Event || x == (uint)StateType.BossChoose)
                    {
                        statepointers[statecount, 1] = ROM.readWord(pheader + 11 + i + 3, rom) + 0x70000;
                        statepointers[statecount, 2] = rom[pheader + 11 + i + 2];
                        i = i + 5;
                    }     //events and boss bits take 1 byte arg
                    else if (x == (uint)StateType.Door)
                    {
                        statepointers[statecount, 1] = ROM.readWord(pheader + 11 + i + 4, rom) + 0x70000;
                        statepointers[statecount, 2] = ROM.readWord(pheader + 11 + i + 2, rom);
                        i = i + 6;
                    }                //the door room state needs a special one for its two-byte arg.
                    else
                    {
                        statepointers[statecount, 1] = ROM.readWord(pheader + 11 + i + 2, rom) + 0x70000;
                        i = i + 4;
                    }                                                        //all the other ones are 4 bytes.
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
                    States.Add(new state(sm, statepointers[i, 0], statepointers[i, 1], statepointers[i, 2], roomsize));    //states need revised to include their own info? Or we can have it on the main header.
                }
                //have a special assignment for std. state
                //Event pointer is stdstate+2 because stdstate is the beginning of 0xE5E6.
                //                   0           1              2
                //    statepointers [Event type, Event Pointer, Optional Arg.] for each state.
                States.Add(new state(sm, x, stdstate + 2, 0, roomsize));
            }
            //return;
            catch
            {
                Bytes8F = 0;
                StateCount = 0;
                States = null;
                Doors = null;
                MessageBox.Show("Invalid level header. Aborting read operation.", "Invalid Level Header.", MessageBoxButtons.OK);
            }


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
            ScrollData = null;
            Index = -1;
            //index is initialized during some operations
            //  -export to ASM
            ScrollLabel = "";
            //scrolldata will be intialialized once control returns to SMASM itself, since we need to reference config to know what the scroll PLM is...
            //unless we read from ROM to check the instruction list for scroll PLM things??
            //that seems more reasonable tbh
            ScrollData = ReadScrollPLM(ID, Variable, sm);
        }
        
        byte[] ReadScrollPLM(uint id, uint variable, ROM sm)
        {
            //read the instruction list to see if it's a scroll PLM (contains pointer 0x8B55)
            //if so, return its data
            //else, return null
            bool scrollPLM = false;
            uint headerAddr = LUNAR.SNEStoPC(0x840000 + id);
            uint instructionPointer = (uint)LUNAR.SNEStoPC((uint)0x840000 + (uint)sm.Rom[headerAddr + 2] + (uint)(sm.Rom[headerAddr + 3]*0x100));
            uint[] instructionlist = new uint[5];
            //scroll instruction should be within the first 5 words of the list.
            int j = 0;
            for (int i = 0; i < 10; i += 2)
            {
                instructionlist[j] = (uint)(sm.Rom[instructionPointer + i] + (sm.Rom[instructionPointer + i + 1] * 0x100));
                j++;
            }
            for (int i = 0; i < 5; i++)
            {
                if (instructionlist[i] == 0x8B55) { scrollPLM = true; }
            }

            if (!scrollPLM) { return null; }

            uint dataAddr = LUNAR.SNEStoPC(0x8F0000 + variable);
            List<byte> scrollData = new List<byte>();
            for (int i = 0; i < 1000; i++)
            {
                byte scroll = sm.Rom[dataAddr + i];
                scrollData.Add(scroll);
                if(scroll == 0x80) { break; }
            }
            return scrollData.ToArray();
        }

        public uint ID { get; set; }
        public uint PosX { get; set; }
        public uint PosY { get; set; }
        public uint Variable { get; set; }
        public byte[] ScrollData { get; set; }
        public int Index { set; get; }
        public string ScrollLabel { get; set; }
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

        Bitmap roomPic;
        int imageScale;

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
            CreateImages();
            //Console.WriteLine(DbLocation);
            //if config does not exist, create it
            if (!File.Exists(DbLocation + "config.xml")) 
            {

                CreateNewConfig();
                
            }
            //if it DOES exist, we should probably verify it with a schema... oh well!
            config.Load(DbLocation + "config.xml");
            if (config.ChildNodes[1].SelectSingleNode("ONTOP").InnerText == "True") { this.TopMost = true; this.alltopCheckbox.Checked = true; }
            SMILEfilesPath = config.ChildNodes[1].SelectSingleNode("SMILEFILE").InnerText;
            sm = new ROM(config.ChildNodes[1].SelectSingleNode("ROM").InnerText);
            PopulateHeaderList();
            

            //pcBox.Text = string.Format("{0:X6}", readWord(0x10, sm));
            //string az = config.ChildNodes[1].SelectSingleNode("ROM").InnerText + null;
            //if (!LUNAR.OpenFile(az)) { MessageBox.Show ("LUNAR rom load failed"); }
        }

        private void CreateImages()
        {
            //generate the s1s2s3... bitmaps for the scroll editor
            
        }
        public void CreateNewConfig()
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
                writer.WriteElementString("SCROLLPLM", "B703");
                writer.WriteElementString("ONTOP", "0");
                writer.WriteElementString("SHOWSETUP", "TRUE");
                writer.Close();
            }
            config.Load(DbLocation + "config.xml");
            //also call the popup to populate all the file paths.
            FilePaths_Open(null, null);
            config.Load(DbLocation + "config.xml");
            string rompath = config.ChildNodes[1].SelectSingleNode("ROM").InnerText;
            string asmpath = config.ChildNodes[1].SelectSingleNode("ASM").InnerText;
            bool shorterThanFive = asmpath.Length < 5;
            if (shorterThanFive) 
            {
                string savePath = Path.GetDirectoryName(rompath) + "\\" + Path.GetFileNameWithoutExtension(rompath) + ".asm";
                MessageBox.Show("No ASM file specified. Creating new file at:\n" + savePath,"No ASM",MessageBoxButtons.OK);
                CreateNewASMfile(savePath);
                CreateNewSMASMspace(savePath);
                config.ChildNodes[1].SelectSingleNode("ASM").InnerText = savePath;
                config.Save(DbLocation + "config.xml");
            }
        }

        public string FilePicker(int extensionSelect, out DialogResult buttonPressed, string windowCaption = "Open File", string startPath = "")
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = DbLocation;
                string filter;
                switch (extensionSelect)
                {
                    case 0:
                        filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                        break;
                    case 1:
                        filter = "ASM files (*.asm)|*.asm|All files (*.*)|*.*";
                        break;
                    case 2:
                        filter = "ROM files (*.smc, *.sfc)|*.smc;*.sfc|All files (*.*)|*.*";
                        break;
                    case 3:
                        filter = "EXE files (*.exe)|*.exe|All files (*.*)|*.*";
                        break;
                    default:
                        filter = "All files(*.*)|*.*|";
                        break;
                }
                openFileDialog.InitialDirectory = startPath;
                openFileDialog.Filter = filter;
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = windowCaption;

                buttonPressed = openFileDialog.ShowDialog();
                if (buttonPressed == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    //fails if the file is already open in SMILE...?
                    var fileStream = openFileDialog.OpenFile();

                }
            }
            return filePath;
        }

        private void alltopCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SMASM.ActiveForm == null) { return; }
            SMASM.ActiveForm.TopMost = !SMASM.ActiveForm.TopMost;
        }

        private void FilePaths_Open(object sender, EventArgs e)
        {
            pathsConfig nw = new pathsConfig(config, this);
            nw.ShowDialog();
            nw.Dispose();
            config.Load(DbLocation + "config.xml");
            sm = new ROM(config.ChildNodes[1].SelectSingleNode("ROM").InnerText);
        }

        private void SMASM_FormClosing(object sender, FormClosingEventArgs e)
        {
            //save any UI config changes
            config.ChildNodes[1].SelectSingleNode("ONTOP").InnerText = alltopCheckbox.Checked.ToString();
            config.Save(DbLocation + "config.xml");
            LUNAR.CloseFile();
        }

        //private void pcBox_TextChanged(object sender, EventArgs e)
        //{
        //    //needs to do number validation first to make sure it's valid hex
        //    if (pcBox.Text == "" || pcBox.Text == null) { return; }
        //    uint pcaddr = uint.Parse(pcBox.Text, System.Globalization.NumberStyles.HexNumber);
        //    lorombox.Text = string.Format("{0:X6}", LUNAR.LunarPCtoSNES(pcaddr, 0x10, 0));
        //    //lorombox.Text = pcaddr.ToString();  //hex to dec converter
        //}

        //private void HeaderBox_TextChanged(object sender, EventArgs e)
        //{
        //    int x = HeaderBox.SelectionStart;
        //    HeaderBox.Text = HeaderBox.Text.ToUpper();
        //    HeaderBox.SelectionStart = x;
        //}

        private void HeaderBox_Validated(object sender, EventArgs e)
        {
            //LoadRoomToGUI();
        }

        private void LoadRoomToGUI(uint headeraddr)
        {
            sm = new ROM(config.ChildNodes[1].SelectSingleNode("ROM").InnerText);
            if(HeaderDropdown.Text == "") { return; }
            thisroom = new roomdata(sm, headeraddr);
            if(thisroom.States == null) { return; }

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

            AppendStatus("Loaded R" + asmFCN.WByte(thisroom.RoomIndex) + "A" + asmFCN.WByte(thisroom.AreaIndex) + " - " + DateTime.Now.ToLongTimeString());
            Bitmap test = LevelData2Bitmap(thisroom,thisroom.StateCount);
            roomPic = test;
            RoomPicture.Image = test;
            imageScale = 1;
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
                if(thisroom.States[StateBox.SelectedIndex].FX[i].DoorSelect == 0xFFFF)
                {
                    FXbox.Items.Add("No Room FX");
                }
                else
                {
                    FXbox.Items.Add(asmFCN.WByte((uint)i) + " - " + asmFCN.WWord(thisroom.States[StateBox.SelectedIndex].FX[i].DoorSelect));
                }
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

        //private void HeaderBox_Validating(object sender, CancelEventArgs e)
        //{
        //    //make sure it only contains numbers and ABCDEF
        //    return;
        //    if(int.TryParse(HeaderBox.Text, System.Globalization.NumberStyles.HexNumber, new CultureInfo("en-US"), out int resul) && HeaderBox.Text.Length == 5)
        //    {
        //        return;
        //    }
        //    TextBox header = (TextBox)sender;
        //    header.Text = "";
        //    e.Cancel = true;
        //}

        public void AllowHexOnlyCOMBO(object sender, EventArgs e)
        {
            //if entry is not a hex number, roll it back to its tag.
            ComboBox A = (ComboBox)sender;
            if (A.Text.Length < 1) { A.Tag = "";  return; }
            if (A.Tag == null) { A.Tag = ""; }
            A.Text = A.Text.ToUpper();

            int inValidnum = 0;
            for (int i = 0; i < A.Text.Length; i++)
            {
                int lastchar = (int)A.Text[i];
                bool isNumber = lastchar >= 48 && lastchar <= 57;
                bool hexLetter = (lastchar >= 65 && lastchar <= 70);
                if (isNumber || hexLetter)
                {
                }
                else
                {
                    inValidnum++;
                }
            }
            if(inValidnum > 0)
            {
                A.Text = A.Tag.ToString();
                A.SelectionStart = A.Text.Length;
                return;
            }
            //valid number
            A.Tag = A.Text;
            A.SelectionStart = A.Text.Length;
            return;
        }

        public void AllowHexOnlyTEXTBOX(object sender, EventArgs e)
        {
            //if entry is not a hex number, roll it back to its tag.
            TextBox A = (TextBox)sender;
            if (A.Text.Length < 1) { A.Tag = ""; return; }
            if (A.Tag == null) { A.Tag = ""; }
            A.Text = A.Text.ToUpper();

            int inValidnum = 0;
            for (int i = 0; i < A.Text.Length; i++)
            {
                int lastchar = (int)A.Text[i];
                bool isNumber = lastchar >= 48 && lastchar <= 57;
                bool hexLetter = (lastchar >= 65 && lastchar <= 70);
                if (isNumber || hexLetter)
                {
                }
                else
                {
                    inValidnum++;
                }
            }
            if (inValidnum > 0)
            {
                A.Text = A.Tag.ToString();
                A.SelectionStart = A.Text.Length;
                return;
            }
            //valid number
            A.Tag = A.Text;
            A.SelectionStart = A.Text.Length;
            return;
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
                if(thisroom.States[StateBox.SelectedIndex].FX[0].DoorSelect == 0xFFFF)
                {
                    //if room didn't have any FX data, make some and get rid of the garbage data.
                    thisroom.States[StateBox.SelectedIndex].FX.Add(CreateFX(0x0000));
                    thisroom.States[StateBox.SelectedIndex].FX.RemoveAt(0);
                }
                else
                {
                    //else, the extant data is legit
                    //and if the default FX was copied, it should give itself a door ID.
                    FXdata newFX;
                    if (thisroom.States[StateBox.SelectedIndex].FX[A.SelectedIndex].DoorSelect == 0x0000)
                    {
                        newFX = new FXdata
                        {
                            DoorSelect = thisroom.Doors[0].Destination,
                            LiqStart = thisroom.States[StateBox.SelectedIndex].FX[A.SelectedIndex].LiqStart,
                              LiqEnd = thisroom.States[StateBox.SelectedIndex].FX[A.SelectedIndex].LiqEnd,
                            LiqSpeed = thisroom.States[StateBox.SelectedIndex].FX[A.SelectedIndex].     LiqSpeed,
                            LiqDelay = thisroom.States[StateBox.SelectedIndex].FX[A.SelectedIndex].     LiqDelay,
                                Type = thisroom.States[StateBox.SelectedIndex].FX[A.SelectedIndex].         Type,
                                BitA = thisroom.States[StateBox.SelectedIndex].FX[A.SelectedIndex].         BitA,
                                BitB = thisroom.States[StateBox.SelectedIndex].FX[A.SelectedIndex].         BitB,
                                BitC = thisroom.States[StateBox.SelectedIndex].FX[A.SelectedIndex].         BitC,
                          PalFXflags = thisroom.States[StateBox.SelectedIndex].FX[A.SelectedIndex].   PalFXflags,
                       TileAnimFlags = thisroom.States[StateBox.SelectedIndex].FX[A.SelectedIndex].TileAnimFlags,
                            PalBlend = thisroom.States[StateBox.SelectedIndex].FX[A.SelectedIndex].     PalBlend,
                    };
                    }
                    else
                    {
                        newFX = thisroom.States[StateBox.SelectedIndex].FX[A.SelectedIndex];
                    }
                    //thisroom.States[StateBox.SelectedIndex].FX.Add(newFX);
                    //order matters in this list:
                    FXdata terminator = thisroom.States[StateBox.SelectedIndex].FX[thisroom.States[StateBox.SelectedIndex].FX.Count-1];
                    thisroom.States[StateBox.SelectedIndex].FX.RemoveAt(thisroom.States[StateBox.SelectedIndex].FX.Count-1);
                    thisroom.States[StateBox.SelectedIndex].FX.Add(newFX);
                    thisroom.States[StateBox.SelectedIndex].FX.Add(terminator);
                }
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
        private void DataListMenu_Opening(object sender, CancelEventArgs e)
        {
            ListBox A = (ListBox)((sender as ContextMenuStrip).SourceControl);
            string firstletter = A.Name.Substring(0, 1);
            if (firstletter == "P") { ScrollPLMedit.Visible = true; }
            else { ScrollPLMedit.Visible = false; }
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
            else if (A.Name.Substring(0, 1) == "F" && A.Items.Count < MaxFX && A.Items.Count >= 1)
            {
                for (int i = A.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    count--;
                    if (count < 1) 
                    {
                        //make the door select into FFFF; rest is handled by the asm write process/GUI load
                        FXdata terminator = CreateFX(0xFFFF);
                        thisroom.States[StateBox.SelectedIndex].FX.Clear();
                        thisroom.States[StateBox.SelectedIndex].FX.Add(terminator);
                        break; 
                    }
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
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("\t"); }
            else
            {
                //AllowHexOnlyCOMBO(sender, e);
            }
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
                ".POINTERS" + "\n" +
                "}" + "\n" +
                ";SMASM-END----------" + "\n" +
                "";

            tASM += smasmspace;
            File.WriteAllText(asmPath,tASM);
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
        public void Export_Room(List<string> smasmSpace, int startline, int endline, string asmPath, bool checkRoomOverwrite, roomdata room)
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
                if (pASM[i].Trim() == room.Label && !roomExists)
                //if room already exists in the ASM file, then overwrite it...
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

            string[] export = asmFCN.Room2ASM(room, int.Parse(LevelBuffer.Text));
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
                FindSection(room.Label, smasm8F, out int st, out int ed);
                if (st == 0 || ed == 0) { MessageBox.Show("roomlabel not found!"); }
                smasm8F.RemoveRange(st, ed - st + 2);
                smasm8F.Insert(st, export[0]);

                FindSection(room.Label, smasm83d, out st, out ed);
                if (st == 0 || ed == 0) { MessageBox.Show("doorlabel not found!"); }
                smasm83d.RemoveRange(st, ed - st + 2);
                smasm83d.Insert(st, export[1]);

                FindSection(room.Label, smasm83f, out st, out ed);
                if (st == 0 || ed == 0) { MessageBox.Show("fxlabel not found!"); }
                smasm83f.RemoveRange(st, ed - st + 2);
                smasm83f.Insert(st, export[2]);

                FindSection(room.Label, smasmA1, out st, out ed);
                if (st == 0 || ed == 0) { MessageBox.Show("enemylabel not found!"); }
                smasmA1.RemoveRange(st, ed - st + 2);
                smasmA1.Insert(st, export[3]);

                FindSection(room.Label, smasmB4, out st, out ed);
                if (st == 0 || ed == 0) { MessageBox.Show("gfxlabel not found!"); }
                smasmB4.RemoveRange(st, ed - st + 2);
                smasmB4.Insert(st, export[4]);

                FindSection(room.Label, smasmLV, out st, out ed);
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
        public void Export_Room(List<string> smasmSpace, int startline, int endline, string asmPath, bool checkRoomOverwrite, roomdata room, out string smasmOut)
        {
            //This overload outputs to the provided string instead of saving to the ASM file.
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
                if (pASM[i].Trim() == room.Label && !roomExists)
                //if room already exists in the ASM file, then overwrite it...
                {
                    roomExists = true;
                    //show additional messageboxes if the confirmation is enabled.
                    if (checkRoomOverwrite)
                    {
                        DialogResult a = MessageBox.Show("Room already exists. Overwrite ASM?", "Overwrite Room?", MessageBoxButtons.YesNo);
                        if (a == DialogResult.No)
                        {
                            MessageBox.Show("Operation cancelled.", "Overwrite Room?", MessageBoxButtons.OK);
                            smasmOut = null;
                            return;
                        }
                    }
                }
            }

            string[] export = asmFCN.Room2ASM(room, int.Parse(LevelBuffer.Text));
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
                FindSection(room.Label, smasm8F, out int st, out int ed);
                if (st == 0 || ed == 0) { MessageBox.Show("roomlabel not found!"); }
                smasm8F.RemoveRange(st, ed - st + 2);
                smasm8F.Insert(st, export[0]);

                FindSection(room.Label, smasm83d, out st, out ed);
                if (st == 0 || ed == 0) { MessageBox.Show("doorlabel not found!"); }
                smasm83d.RemoveRange(st, ed - st + 2);
                smasm83d.Insert(st, export[1]);

                FindSection(room.Label, smasm83f, out st, out ed);
                if (st == 0 || ed == 0) { MessageBox.Show("fxlabel not found!"); }
                smasm83f.RemoveRange(st, ed - st + 2);
                smasm83f.Insert(st, export[2]);

                FindSection(room.Label, smasmA1, out st, out ed);
                if (st == 0 || ed == 0) { MessageBox.Show("enemylabel not found!"); }
                smasmA1.RemoveRange(st, ed - st + 2);
                smasmA1.Insert(st, export[3]);

                FindSection(room.Label, smasmB4, out st, out ed);
                if (st == 0 || ed == 0) { MessageBox.Show("gfxlabel not found!"); }
                smasmB4.RemoveRange(st, ed - st + 2);
                smasmB4.Insert(st, export[4]);

                FindSection(room.Label, smasmLV, out st, out ed);
                if (st == 0 || ed == 0) { MessageBox.Show("levellabel not found!"); }
                smasmLV.RemoveRange(st, ed - st + 2);
                smasmLV.Insert(st, export[5]);

            }

            //use loops to compile all these into a single output string for the text file.
            string final = ConcatASMsections(smasm8F, smasm83d, smasm83f, smasmA1, smasmB4, smasmLV, smasmTilesets, smasmTilesetTable);
            smasmOut = final;
        }

        private void ASMbutton_Click(object sender, EventArgs e)
        {
            string asmPath = config.ChildNodes[1].SelectSingleNode("ASM").InnerText;
            List<string> smasmSpace = Parse_SMASM_ASM(asmPath, out int smasmStartLine, out int smasmEndLine, out bool roomExists);
            if(smasmSpace == null) { return; }
            Export_Room(smasmSpace, smasmStartLine, smasmEndLine, asmPath, true, thisroom);
            AppendStatus("Exported R" + asmFCN.WByte(thisroom.RoomIndex) + "A" + asmFCN.WByte(thisroom.AreaIndex));
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

        public string getMDBpath(out bool mdbExists)
        {
            //new MDB is created on ASM-apply if it did not already exist.
            //romname is the file path minus the extension
            string rom = config.ChildNodes[1].SelectSingleNode("ROM").InnerText;
            string romname = rom.Substring(rom.LastIndexOf('\\') + 1); romname = romname.Substring(0, romname.Length - 4);
            string customF = config.ChildNodes[1].SelectSingleNode("SMILEFILE").InnerText + "\\Custom\\" + romname + "\\Data\\";
            Directory.CreateDirectory(customF);
            string mdbpath = customF + "mdb.txt";
            mdbExists = File.Exists(mdbpath);
            return mdbpath;
        }

        public void updateTilesetAddress(string asmPath, string tstAddr)
        {
            //search with regex for the !smasmTilesetTable = $8F#### label and replace the numbers
            string searchPattern = @"!smasmTilesetTable = \$8F....";
            string replacement = "!smasmTilesetTable = $8F" + tstAddr;
            System.Text.RegularExpressions.Regex nameFormat = new System.Text.RegularExpressions.Regex(searchPattern);
            string asm = File.ReadAllText(asmPath);
            System.Text.RegularExpressions.Match a = nameFormat.Match(asm);
            asm = asm.Replace(a.Value, replacement);
            File.WriteAllText(asmPath,asm);
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            string q = @"" + (char)34;
            string rom = config.ChildNodes[1].SelectSingleNode("ROM").InnerText;
            string asmPath = config.ChildNodes[1].SelectSingleNode("ASM").InnerText;
            string asr = config.ChildNodes[1].SelectSingleNode("ASR").InnerText;
            string tstAddr = config.ChildNodes[1].SelectSingleNode("TILESETTABLE").InnerText;
            string mdbpath = getMDBpath(out bool mdbExists);

            updateTilesetAddress(asmPath, tstAddr);

            string strCmdText = string.Format(@"{0}{1}{0} {0}{2}{0}", q, asmPath, rom);
            //try
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
                    if (aRooms.Count == 0) { MessageBox.Show("MDB Error: ASAR output not detected. Was there an assembler error?\n You can check by using ASAR.exe with the command line to patch the ROM.", "ASAR Error", MessageBoxButtons.OK); return; }
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
                    List<string> smasmASM = Parse_SMASM_ASM(asmPath, out int startline, out int endline, out bool roomExists);

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
                        try
                        {
                            string find = "dw $" + oldRooms[i].Substring(1) + " :";
                            string replace = "dw $" + aRooms[i].Substring(1) + " :";
                            single_string_83d = ReplaceAllOccurences(single_string_83d, find, replace);
                        }
                        catch
                        {
                            //this is in a try-catch because it was giving an index oob error and idk why
                        }
                    }
                    List<string> new83d = single_string_83d.Split('@').ToList<string>();
                    new83d.RemoveAt(new83d.Count-1);
                    //^^^this gets rid of a blank entry that appears due to the last @ in the file.

                    //to insert this new $83, the easiest way would be to rebuild the whole ASM file in the same way that Export to ASM does.
                    string final = ConcatASMsections(smasm8F, new83d, smasm83f, smasmA1, smasmB4, smasmLV, smasmTilesets, smasmTilesetTable);
                    List<string> pASM = ASM2List(asmPath);
                    pASM.RemoveRange(startline, (endline + 1) - startline);
                    pASM.Insert(startline, final);
                    try
                    {
                        File.WriteAllLines(asmPath, pASM);
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
                    //AppendStatus(asarOut);
                    // StatusBox.Clear();
                    StatusBox.AppendText(
                        "-------------------\n" +
                        "ROOMS APPLIED\n" +
                        DateTime.Now.ToLongTimeString() + "\n" +
                        ""
                        );
                    StatusBox.Text += res + "\n-------------------";
                    AppendStatus("");   //to scroll the caret
                    //also account for the MDB changing
                    PopulateHeaderList();
                    //and reload ROM to be safe? this might fix the insconsistent crashes with tileset I/O.
                    sm = new ROM(sm.Path);
                }
            }
            //catch (Exception eg)
            //{
            //    AppendStatus("Fail");
            //    Console.WriteLine(eg.Message);
            //}
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
            //AllowHexOnlyTEXTBOX(sender, null);
            return;
            //TextBox a = (TextBox)sender;
            //uint barse;
            //if (uint.TryParse(RoomIndex.Text, NumberStyles.HexNumber, null, out barse))
            //{
                
            //}
            //else
            //{
            //    a.Text = "";
            //    e.Cancel = true;
            //}
        }

        private void RoomIndex_Validated(object sender, EventArgs e)
        {
            if(
                RoomIndex.Text.Length < 2 
                && 
                AreaIndex.Text.Length < 2
                ||
                thisroom.States == null
                ) { return; }
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
                if(n == null) { return; }
                thisroom.States[StateBox.SelectedIndex].Enemies.Add(CreateEnemy(sm, n[0], n[1], n[2]));
            }
            else if (B.Name.Substring(0, 1) == "G" && B.Items.Count < MaxGFX)
            {
                A.ShowDialog();
                n = A.Results();
                A.Close();
                if (n == null) { return; }
                thisroom.States[StateBox.SelectedIndex].EnemiesAllowed.Add(CreateGFX(sm, n[0], n[1]));
            }
            else if (B.Name.Substring(0, 1) == "P" && B.Items.Count < MaxPLMs)
            {
                A.ShowDialog();
                n = A.Results();
                A.Close();
                if (n == null) { return; }
                thisroom.States[StateBox.SelectedIndex].PLMs.Add(CreatePLM(sm, n[0], n[1], n[2]));
            }
            //doors and FX don't have hardcoded maximums but they should probably be limited anyway?
            else if (B.Name.Substring(0, 1) == "F" && B.Items.Count < MaxPLMs)
            {
                //order matters in this list:
                A.Close();
                FXdata terminator = thisroom.States[StateBox.SelectedIndex].FX[thisroom.States[StateBox.SelectedIndex].FX.Count-1];
                thisroom.States[StateBox.SelectedIndex].FX.RemoveAt(thisroom.States[StateBox.SelectedIndex].FX.Count-1);
                thisroom.States[StateBox.SelectedIndex].FX.Add(CreateFX(thisroom.Doors[0].Destination));
                thisroom.States[StateBox.SelectedIndex].FX.Add(terminator);
            }
            else if (B.Name.Substring(0, 1) == "D" && B.Items.Count < MaxPLMs)
            {
                A.Close();
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
        public FXdata CreateFX(uint doorSelect)
        {
            //create a default FX with hardcoded values.
            FXdata crate = new FXdata()
            {
                DoorSelect = doorSelect,
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
            string headerNumbers = HeaderDropdown.Text.Substring(0, 5);
            uint headerAddr = uint.Parse(headerNumbers, NumberStyles.HexNumber);
            LoadRoomToGUI(headerAddr);
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
                if ((singleset != -1) && ((uint)singleset != folderIndex)) { folderIndex++; continue; }

                string currentDirectory = (tilesDir + "\\" + folderIndex + "-" + asmFCN.WByte(folderIndex));
                Directory.CreateDirectory(currentDirectory);
                if (sceExp) { ExportTileset(item.SCE, currentDirectory, ".gfx", folderIndex); }
                if (palExp) { ExportTileset(item.Palette, currentDirectory, ".pal", folderIndex); }
                if (ttbExp) { ExportTileset(item.TileTable, currentDirectory, ".ttb", folderIndex); }
                folderIndex++;
            }
            LUNAR.CloseFile();



            StatusBox.AppendText(
            "-------------------\n" +
            tileSetTable.Count + " TILESETS IN ROM:\n" +
            DateTime.Now.ToLongTimeString() + "\n" +
            ""
            );
            foreach (TilesetEntry item in tileSetTable)
            {
                StatusBox.AppendText(asmFCN.WWord(item.Pointer) + " - " + asmFCN.WLong(item.TileTable) + ", " + asmFCN.WLong(item.SCE) + ", " + asmFCN.WLong(item.Palette) + "\r\n");
            }
            StatusBox.AppendText(
            "-------------------\n"
            );
        }
        private unsafe void ExportTileset(uint compDataPointer, string destpath, string fileExtension, uint tilesetIndex)
        {
            byte[] dataUC;    //reserve max data size. Norfair gfx are 0x4800 for reference.
            if(tilesetIndex == 17) { Console.WriteLine("A"); }
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
            LUNAR.TilesetDecompress(ptr, pcPointer, &addr2);    //decompression takes a PC address.
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
            if (!Directory.Exists(tilesetFolder)) { MessageBox.Show("Export at least one tileset first.\nExport all (Tilesets > ROM to Tileset Folders) is recommended.", "No Tileset Folder", MessageBoxButtons.OK); return null; }
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

                    string padbyte = "fillbyte $FF\n" +
                                    "fill 10\n";

                    db.Append("\n" + padbyte);
                    tilesets.Append(label + db);
                    TilesetMeter.AddToBar(1);
                }
                tilesets.Append(
                    "}"
                    );
                //only needs the \n if everything being added.
                if(singleSet == -1)
                {
                    tilesets.Append("\n");
                }
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

        private void ImportTilesets_Click(object sender, EventArgs e)
        {
            //Thread t = new Thread(new ThreadStart(this.ImportTileSets()));
            string tilesetFolder = GetTilesetDir();
            if (!Directory.Exists(tilesetFolder)) { MessageBox.Show("No tileset folder found!\nUse Export Tileset from ROM first"); }
            ImportTileSets();
            AppendStatus("Tileset Folders imported to ASM.");
        }

        public void ImportTileSets(int singleSet = -1)
        {
            //missing arg or -1 will import ALL
            //specifying a number will export only THAT tileset.
            string asmPath = config.ChildNodes[1].SelectSingleNode("ASM").InnerText;
            string tilesets = TilesetFolders2ASM(singleSet);
            if(tilesets == null) { return; } //no tileset folders
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
            AppendStatus("Imported Tileset " + TilesetBox.Text + " from folders.");
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
            //for (int i = 0; i < 500; i++)
            //{
            //    AppendStatus(i.ToString());
            //}
            //Bitmap test = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //test = LevelData2Bitmap(thisroom, thisroom.StateCount);
            //RoomPicture.Image = test;
            //test.Save("C:\\Users\\oi23\\source\\repos\\SM-ASM-GUI\\SM-ASM-GUI\\bin\\Unsafe\\test.bmp");
            ScrollEditor A = new ScrollEditor(
                thisroom, 
                StateBox.SelectedIndex, 
                4, 
                ScrollEditor.Mode.PLM, 
                this
                );
            try
            {
                A.ShowDialog();
                thisroom = A.Room;
                A.Close();
            }
            catch { }

            //for (int i = 0; i < thisroom.States[StateBox.SelectedIndex].PLMs[0].ScrollData.Length; i++)
            //{
            //    AppendStatus(thisroom.States[StateBox.SelectedIndex].PLMs[0].ScrollData[i].ToString() + ", ");
            //}
        }

        public Bitmap LevelData2Bitmap(roomdata room, int state)
        {
            //read the uncompressed level data for tile types:
            int roomTilesX = (int)room.Width * 16;
            int roomTilesY = (int)room.Height * 16;
            Bitmap roomPic = new Bitmap(roomTilesX, roomTilesY, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int levelSize = room.States[state].LevelDataUC[0] + room.States[state].LevelDataUC[1] * 0x100;

            //LP initialized to 2 to skip size statement
            uint levelPosition = 2;
            int btsPosition = 2 + levelSize;
            byte[] leveldata = room.States[state].LevelDataUC;
            for (int i = 0; i < roomTilesY; i++)
            {
                for (int j = 0; j < roomTilesX; j++)
                {
                    Tile drawthis = new Tile(levelPosition, leveldata);
                    //modify drawthis to match the color the copy tiles are pointing to
                    if (drawthis.Type == TileType.Hcopy || drawthis.Type == TileType.Vcopy) 
                    {
                        drawthis = TraceCopyTiles(drawthis, room, state);
                    }
                    roomPic.SetPixel(j, i, drawthis.DrawColor);
                    levelPosition += 2;
                    btsPosition += 1;
                }
            }
            //next, draw in the PLMs!
            //items are IDs < $EED7; 1x1.
            //doors should be defined in a file somewhere... maybe the PLM tag list anything with a "door" tag gets drawn?
            //gates should work the same way?
            //skip PLMs that are offscreen.
            roomPic = DrawPLMs(roomPic,room, room.StateCount);
            return roomPic;
        }
         Bitmap DrawPLMs(Bitmap roomPic, roomdata room, int statenumber)
        {
            //final tag in list should have mapProperties info
            string PLMListPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + "\\plmlist.txt";
            List<string> plmTagList = File.ReadAllLines(PLMListPath).ToList();
            foreach (PLMdata plm in room.States[statenumber].PLMs)
            {
                bool plmInList = false;
                //bool drawPLM = true;
                string[] tags = null;   //initialized to make it happy i guess...
                string[] mapProperties;
                //for each entry in the PLM tag list...
                foreach (string entry in plmTagList)
                {
                    tags = entry.Split(',');
                    try
                    {
                        if (plm.ID == uint.Parse(tags[0], NumberStyles.HexNumber)) { plmInList = true; break; }
                    }
                    catch
                    {
                        MessageBox.Show("Invalid PLM ID detected in plmlist.txt! Header address must be first in the list and use hex representation.\nPLM drawing aborted.", "PLM Error", MessageBoxButtons.OK);
                        return roomPic;
                    }
                }
                mapProperties = tags[tags.Length - 1].Split(':');
                try
                {
                    //mapProperties breakout
                    //[0] "mapProperties" here so people know what it is in the text editor
                    //[1] shape
                    //[2] color0
                    //[3] color1
                    //[4] color3
                    //.
                    //.
                    //.
                    if (mapProperties[1].ToUpper().Trim(' ') == "EXCLUDE") { continue; }
                    //move the draw instruction up here as a function.
                    if ((plm.PosX < room.Width * 16 && plm.PosY < room.Height * 16) && plmInList)
                    {
                        roomPic = DrawMapShape(plm, mapProperties, roomPic);
                    }
                }
                catch
                {
                    MessageBox.Show("Error reading mapProperties array for PLM " + asmFCN.WWord(plm.ID) + "\nAborting PLM draw.", "Invalid Property", MessageBoxButtons.OK);
                    return roomPic;
                }
            }
            return roomPic;
        }
        private Bitmap DrawMapShape(PLMdata plm, string[] mapProperties, Bitmap target)
        {
            //switch statement contains shape definitions for each keyword.
            switch (mapProperties[1].ToLower())
            {
                case "doorlr":
                    //expects one color to be listed in mP[2].
                    //wound need error handling for if they forgot some color tags....
                    target.SetPixel((int)plm.PosX, (int)plm.PosY+0, Color.FromName(mapProperties[2]));
                    target.SetPixel((int)plm.PosX, (int)plm.PosY+1, Color.FromName(mapProperties[2]));
                    target.SetPixel((int)plm.PosX, (int)plm.PosY+2, Color.FromName(mapProperties[2]));
                    target.SetPixel((int)plm.PosX, (int)plm.PosY+3, Color.FromName(mapProperties[2]));
                    break;

                case "doorud":
                    target.SetPixel((int)plm.PosX + 0, (int)plm.PosY, Color.FromName(mapProperties[2]));
                    target.SetPixel((int)plm.PosX + 1, (int)plm.PosY, Color.FromName(mapProperties[2]));
                    target.SetPixel((int)plm.PosX + 2, (int)plm.PosY, Color.FromName(mapProperties[2]));
                    target.SetPixel((int)plm.PosX + 3, (int)plm.PosY, Color.FromName(mapProperties[2]));
                    break;

                case "downgate":
                    target.SetPixel((int)plm.PosX, (int)plm.PosY + 0, Color.FromName(mapProperties[2]));
                    target.SetPixel((int)plm.PosX, (int)plm.PosY + 1, Color.FromName(mapProperties[2]));
                    target.SetPixel((int)plm.PosX, (int)plm.PosY + 2, Color.FromName(mapProperties[2]));
                    target.SetPixel((int)plm.PosX, (int)plm.PosY + 3, Color.FromName(mapProperties[2]));
                    target.SetPixel((int)plm.PosX, (int)plm.PosY + 4, Color.FromName(mapProperties[2]));
                    break;

                case "upgate":
                    target.SetPixel((int)plm.PosX, (int)plm.PosY, Color.FromName(mapProperties[2]));
                    break;

                case "gateswitch":
                    //this one needs to read the PLM to determine color!
                    //it also gets 4 color args and will error otherwise.
                    //first color in list will be default case.
                    int offset;
                    Color gateColor;
                    //2's bit specifies right facing gate.
                    if ((plm.Variable & 2) == 2)
                    {
                        offset = 1;
                    }
                    else
                    {
                        offset = -1;
                    }
                    uint a = plm.Variable & 0xD;
                    switch (plm.Variable & 0xD)
                    {
                        case 0x00:
                            gateColor = Color.FromName(mapProperties[2]); break;
                        case 0x04:
                            gateColor = Color.FromName(mapProperties[3]); break;
                        case 0x08:
                            gateColor = Color.FromName(mapProperties[4]); break;
                        case 0x0C:
                            gateColor = Color.FromName(mapProperties[5]); break;
                        default:
                            gateColor = Color.Black; //should never happen...
                            break;
                    }
                    target.SetPixel((int)plm.PosX + offset, (int)plm.PosY, gateColor);
                    break;

                case "item":
                    target.SetPixel((int)plm.PosX, (int)plm.PosY, Color.FromName(mapProperties[2]));
                    break;

                default:
                    //draw a single yellow pixel on the PLM position.
                    target.SetPixel((int)plm.PosX, (int)plm.PosY, Color.Yellow);
                    break;
            }
            return target;
        }
        private Tile TraceCopyTiles(Tile copytile, roomdata room, int state)
        {
            byte[] levelsUncompressed = room.States[state].LevelDataUC;
            Tile original = copytile;
            if(copytile.BTS == 0) { return copytile; }
            int recursionlimit = 1000;
            int recursionCount = 0;
        CHAIN:
            recursionCount++;
            if (recursionCount == recursionlimit)
            {
                MessageBox.Show(
                  "Recursion Limit reached: copy tile failure tracing from tile index " +
                  (original.Index - 2),
                  "Copy Tile Limit",
                  MessageBoxButtons.OK);
                return original;
            }
            Tile[] follow = AdjacentTiles(copytile, room, state);
            //Follow indices:
            //# 1 #
            //0 T 2
            //# 3 #
            if(copytile.Type == TileType.Vcopy)
            {
                //Vcopy only needs to worry about going up and down
                bool goingUP = copytile.BTS < 0;
                if (goingUP)
                {
                    //check if it will go to another copy tile, or if it reached the destination
                    if(follow[1].Type == TileType.Vcopy || follow[1].Type == TileType.Hcopy)
                    {
                        //loop must continue
                        copytile = follow[1];
                        goto CHAIN;
                    }
                    else
                    {
                        //destination reached
                        return follow[1];
                    }
                }
                else //going down
                {
                    //check if it will go to another copy tile, or if it reached the destination
                    if (follow[3].Type == TileType.Vcopy || follow[3].Type == TileType.Hcopy)
                    {
                        //loop must continue
                        copytile = follow[3];
                        goto CHAIN;
                    }
                    else
                    {
                        //destination reached
                        return follow[3];
                    }
                }
            }
            if (copytile.Type == TileType.Hcopy)
            {
                //Vcopy only needs to worry about going up and down
                bool goingLEFT = copytile.BTS < 0;
                if (goingLEFT)
                {
                    //check if it will go to another copy tile, or if it reached the destination
                    if (follow[0].Type == TileType.Vcopy || follow[0].Type == TileType.Hcopy)
                    {
                        //loop must continue
                        copytile = follow[0];
                        goto CHAIN;
                    }
                    else
                    {
                        //destination reached
                        return follow[0];
                    }
                }
                else //going down
                {
                    //check if it will go to another copy tile, or if it reached the destination
                    if (follow[2].Type == TileType.Vcopy || follow[2].Type == TileType.Hcopy)
                    {
                        //loop must continue
                        copytile = follow[2];
                        goto CHAIN;
                    }
                    else
                    {
                        //destination reached
                        return follow[2];
                    }
                }
            }
            return copytile;
        }
        private Tile[] AdjacentTiles(Tile tile, roomdata room, int state)
        {
            //# 1 #
            //0 T 2
            //# 3 #
            byte[] levelsUncompressed = room.States[state].LevelDataUC;
            int levelsize = levelsUncompressed[0] + levelsUncompressed[1] * 0x100;
            Tile[] rtn = new Tile[4];
            //the 2's in here are because each level data tile is 2 bytes; we're working in 1-byte increments.
            rtn[0] = new Tile(tile.Index - 2, levelsUncompressed);
            rtn[1] = new Tile(tile.Index - thisroom.Width*16*2, levelsUncompressed);
            rtn[2] = new Tile(tile.Index + 2, levelsUncompressed);
            rtn[3] = new Tile(tile.Index + thisroom.Width*16*2, levelsUncompressed);
            return rtn;
        }
        private TileType GetTileType(uint levelWord)
        {
            //all possibilities are accounted for, so the default case should never be reached... oh well!
            levelWord &= 0xF000;
            switch (levelWord)
            {
                case (uint)TileType.Air:
                    return TileType.Air;
                case (uint)TileType.Slope:
                    return TileType.Slope;
                case (uint)TileType.AirSpike:
                    return TileType.AirSpike;
                case (uint)TileType.AirShootable:
                    return TileType.AirShootable;
                case (uint)TileType.Hcopy:
                    return TileType.Hcopy;
                case (uint)TileType.AirUnused:
                    return TileType.AirUnused;
                case (uint)TileType.AirBombable:
                    return TileType.AirBombable;
                case (uint)TileType.Solid:
                    return TileType.Solid;
                case (uint)TileType.Door:
                    return TileType.Door;
                case (uint)TileType.Spike:
                    return TileType.Spike;
                case (uint)TileType.Special:
                    return TileType.Special;
                case (uint)TileType.Shot:
                    return TileType.Shot;
                case (uint)TileType.Vcopy:
                    return TileType.Vcopy;
                case (uint)TileType.Grapple:
                    return TileType.Grapple;
                case (uint)TileType.Bomb:
                    return TileType.Bomb;
                default:
                    return TileType.Air;
                    //break;
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
            AppendStatus("Exported Tileset " + TilesetBox.Text + " from ROM to folders.");
        }

        private void tilesetSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StatusBox_TextChanged(object sender, EventArgs e)
        {
            //if not typing on empty row in most recent line, revert the character change.
            RichTextBox A = (RichTextBox)sender;
             
        }

        public string SMILEfilesPath { get; set; }

        private void RoomPicture_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox A = (PictureBox)sender;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    break;
                case MouseButtons.Right:
                    break;
                case MouseButtons.Middle:
                    break;
                default:
                    //update the mouse position even when then mouse is not held down to prevent odd jumping around
                    if (A.Tag == null) { A.Tag = e.X.ToString() + "," + e.Y.ToString() + "," + 0 + "," + 0; return; }
                    int scrlX = int.Parse(A.Tag.ToString().Split(',')[2]);
                    int scrlY = int.Parse(A.Tag.ToString().Split(',')[3]);
                    A.Tag = e.X.ToString() + "," + e.Y.ToString() + "," + scrlX + "," + scrlY;
                    return;
            }
            if(A.Tag == null) { A.Tag = e.X.ToString() + "," + e.Y.ToString() + "," + 0 + "," + 0; return; }
            //picture must also be bigger than picturebox to allow scrolling in that direction.
            int prevX = int.Parse(A.Tag.ToString().Split(',')[0]);
            int prevY = int.Parse(A.Tag.ToString().Split(',')[1]);
            int scrollX = int.Parse(A.Tag.ToString().Split(',')[2]);
            int scrollY = int.Parse(A.Tag.ToString().Split(',')[3]);
            int delX = e.X - prevX;
            int delY = e.Y - prevY;
            scrollX += delX;
            scrollY += delY;
            if(roomPic.Width <= A.Width) { scrollX = 0; }
            if(scrollX < 0) { scrollX = 0; }    //disallow scrolling left OOB
            if (scrollX >= roomPic.Width-A.Width + 4 && (roomPic.Width > A.Width + 4)) { scrollX = roomPic.Width - A.Width + 4; }    //not sure why this +4 is needed...

            if (roomPic.Height <= A.Height) { scrollY = 0; }
            if (scrollY < 0) { scrollY = 0; }
            if (scrollY >= roomPic.Height - A.Height + 4 && (roomPic.Height > A.Height + 4)) { scrollY = roomPic.Height - A.Height + 4; }

            Rectangle cropArea = new Rectangle(scrollX, scrollY, roomPic.Width-scrollX, roomPic.Height-scrollY);
            A.Image = roomPic.Clone(cropArea, roomPic.PixelFormat);
            A.Tag = e.X.ToString() + "," + e.Y.ToString() + "," + scrollX + "," + scrollY; //store location to compare with next processing event.
        }

        private void ZoomPicIn_Click(object sender, EventArgs e)
        {
            if (imageScale >= 4) { return; }
            Bitmap original = roomPic;
            roomPic = new Bitmap(original, new Size(original.Width * 2, original.Height *2));
            imageScale++;
            RoomPicture.Image = roomPic;
        }

        private void ZoomPicOut_Click(object sender, EventArgs e)
        {
            if (imageScale <= 1) { return; }
            Bitmap original = roomPic;
            roomPic = new Bitmap(original, new Size(original.Width / 2, original.Height / 2));
            imageScale--;
            RoomPicture.Image = roomPic;
        }
        private Bitmap ZoomBMP(Bitmap input, int scale)
        {
            //float width = input.Width * scale;
            //float height = input.Height * scale;
            //var brush = new SolidBrush(Color.Black);

            //var bmp = new Bitmap(input.Width*scale, input.Height*scale);
            //var graph = Graphics.FromImage(bmp);

            //// uncomment for higher quality output
            ////graph.InterpolationMode = InterpolationMode.High;
            ////graph.CompositingQuality = CompositingQuality.HighQuality;
            ////graph.SmoothingMode = SmoothingMode.AntiAlias;

            //var scaleWidth = (int)(input.Width * scale);
            //var scaleHeight = (int)(input.Height * scale);

            //graph.FillRectangle(brush, new RectangleF(0, 0, width, height));
            //graph.DrawImage(input, ((int)width - scaleWidth) / 2, ((int)height - scaleHeight) / 2, scaleWidth, scaleHeight);
            

            return null;
        }

        private void fromMDBListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAreaMaps();
        }
        private void thisRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSingleRoomMap(thisroom);
        }


        private void SaveSingleRoomMap(roomdata mapThis)
        {
            roomdata origRoom = thisroom;
            thisroom = mapThis;
            string saveFolder = Path.GetDirectoryName(sm.Path);
            Bitmap map = LevelData2Bitmap(thisroom, thisroom.StateCount);
            map.Save(saveFolder + "\\" + asmFCN.WLong(mapThis.Header) + ".png");
            thisroom = origRoom;
            DialogResult openFolder = MessageBox.Show("Room map saved to:\n" + saveFolder + "\nOpen folder?", "Map Saved", MessageBoxButtons.YesNo);
            if (openFolder == DialogResult.Yes) { Process.Start("explorer.exe", saveFolder); }
        }
        public void CreateAreaMaps()
        {
            //for some reason, the room export only works if the rooms are set to thisroom...... messy! That should be fixed.

            //aside from that it needs to detect how many areas are listed in the MDB and make different pngs
            roomdata origRoom = thisroom;
            string saveFolder = Path.GetDirectoryName(sm.Path);
            string mdbPath = getMDBpath(out bool mdbexists);
            if (!mdbexists) { MessageBox.Show("Could not find\n" + mdbPath, "File not Found", MessageBoxButtons.OK); return; }
            List<string> mdb = File.ReadAllLines(mdbPath).ToList();
            //need to make lists of each area in the game... a new data type?
            //but first i need a uint list of all the unique area numbers found in the MDB.
            List<uint> areasFound = new List<uint>();
            foreach (string entry in mdb)
            {
                uint headerAddr = uint.Parse(entry.Substring(0, 5), NumberStyles.HexNumber);
                roomdata check = new roomdata(sm, headerAddr);
                bool areaInList = false;
                foreach (uint areaNum in areasFound)
                {
                    if (check.AreaIndex == areaNum) { areaInList = true; }
                }
                if (!areaInList) { areasFound.Add(check.AreaIndex); }
            }
            List<MapArea> areaList = new List<MapArea>();
            foreach (uint area in areasFound)
            {
                areaList.Add(new MapArea(area));
            }
            foreach (string entry in mdb)
            {
                uint headerAddr = uint.Parse(entry.Substring(0, 5), NumberStyles.HexNumber);
                roomdata check = new roomdata(sm, headerAddr);
                foreach (MapArea area in areaList)
                {
                    if (check.AreaIndex == area.AreaIndex) { area.Rooms.Add(check); }
                }
            }
            //AreaList is now populated with all the areas and their contained rooms.
            foreach (MapArea area in areaList)
            {
                Bitmap areaMap = new Bitmap(64 * 8 * 2, 32 * 8 * 2);
                foreach (roomdata room in area.Rooms)
                {
                    thisroom = room;
                    Bitmap map = LevelData2Bitmap(thisroom, thisroom.StateCount);
                    Graphics g = Graphics.FromImage(areaMap);
                    g.DrawImage(map, thisroom.MapX * 16, thisroom.MapY * 16);
                }
                areaMap.Save(saveFolder + "\\area" + asmFCN.WByte(area.AreaIndex) + ".png");
            }
            DialogResult openFolder = MessageBox.Show("Area maps saved to:\n" + saveFolder + "\nOpen folder?", "Maps Saved", MessageBoxButtons.YesNo);
            if (openFolder == DialogResult.Yes) { Process.Start("explorer.exe", saveFolder); }
            thisroom = origRoom;

        }

        private void ScrollPLMedit_Click(object sender, EventArgs e)
        {
            ScrollEditor A = new ScrollEditor(
                thisroom,
                StateBox.SelectedIndex,
                4,
                ScrollEditor.Mode.PLM,
                this
                );
                try
                {
                    A.ShowDialog();
                    thisroom = A.Room;
                    A.Close();
                }
                catch { }
        }

        private void EditLevelScrollsButton_Click(object sender, EventArgs e)
        {
           ScrollEditor A = new ScrollEditor(
                thisroom,
                StateBox.SelectedIndex,
                4,
                ScrollEditor.Mode.Normal,
                this
                );
                try
                {
                    A.ShowDialog();
                    thisroom = A.Room;
                    A.Close();
                }
                catch { }
        }

        private void RoomPicture_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { LevelPicMenu.Show(); }
        }

        private void currentRoomToNewASMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //generate new ASM file named like the room, with default values.
            //string a = Path.GetDirectoryName(sm.Path);
            string savePath = Path.GetDirectoryName(sm.Path) + "\\" + Path.GetFileNameWithoutExtension(sm.Path) + "R" + asmFCN.WByte(thisroom.RoomIndex) + "A" + thisroom.AreaIndex + ".asm"; 
            CreateNewASMfile(savePath);
            CreateNewSMASMspace(savePath);

            List<string> smasmSpace = Parse_SMASM_ASM(savePath, out int startline, out int endline, out bool roomExists);
            GetSMASMsections(smasmSpace, out List<string> smasm8F, out List<string> smasm83d, out List<string> smasm83f, out List<string> smasmA1, out List<string> smasmB4, out List<string> smasmLV, out List<string> smasmTilesets, out List<string> smasmTilesetTable);
            Export_Room(smasmSpace, startline, endline, savePath, false, thisroom);
            //DialogResult exportTilesets = MessageBox.Show("Include tileset with room file?","Tilesets",MessageBoxButtons.YesNo);
            //if(exportTilesets == DialogResult.Yes)
            //{
            //    List<uint> usedTilesets = new List<uint>();
            //}
            AppendStatus("File saved to:\n" + savePath);
            //Export_Room() takes the smasm space as a list, so it will need re-read from the ASM file, or assigned to an out variable.
            //and it also saves to the file path with that function.
        }
        public void CreateNewASMfile(string savePath)
        {
            //SavePath should include the .asm suffix
            //only needs to create the defines and stuff outside SMASM space.
            string newline = "\r\n";
            string header =
                "lorom" + newline +
                newline +
                "!smasm8F = $8F8000" + newline +
                "!smasm83 = $83AD66" + newline +
                "!smasmA1 = $A18000" + newline +
                "!smasmB4 = $B48000" + newline +
                "!smasmLevels = $BAC629; Start of vanilla tilesets; overwrites with tileset exports and then level data." + newline +
                "!smasmTilesetTable = $8FE6A2; must agree with the tileset table location in SMASM config." + newline +
                newline +
                "org $82DF02; repoints the tileset table to the address of !smasmTilesetTable" + newline +
                "LDX.w TILESETTABLE_POINTERS, y" + newline +
                newline
                ;
            File.WriteAllText(savePath, header);
            return;
        }

        private void mergeRoomFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MergeRooms();
        }

        private void MergeRooms()
        {
            //create lists of SMASM room objects for each ASM file and combine, making necessary room renames.

            //file picker should start at same folder ROM is in, and then second file picker should start at folder of first file.
            string firstFile = FilePicker(1, out DialogResult firstButton, "First File", Path.GetDirectoryName(sm.Path));
            if (firstButton == DialogResult.Cancel) { return; }
            string secondFile = FilePicker(1, out DialogResult secondButton, "Second File", Path.GetDirectoryName(firstFile));
            if (secondButton == DialogResult.Cancel) { return; }

            List<SmasmRoom> firstContents;
            List<SmasmRoom> secondContents;
            try
            {
                firstContents = GetRoomsInASM(firstFile);
                secondContents = GetRoomsInASM(secondFile);
                Console.WriteLine("A");
            }
            catch
            {
                MessageBox.Show("Problem reading the files! They may not contain any rooms, or the ones found were incomplete.", "Read Error", MessageBoxButtons.OK);
                return;
            }

            //rename each room from secondcontents to the highest room index in its given area.
            List<int> firstAreas = new List<int>();
            foreach (SmasmRoom item in firstContents)
            {
                bool matchfound = false;
                foreach (int area in firstAreas)
                {
                    if (area == item.AreaIndex) { matchfound = true; }
                }
                if (matchfound) { continue; }
                firstAreas.Add(item.AreaIndex);
            }
            List<int> highestRoomIndices = new List<int>();
            for (int i = 0; i < firstAreas.Count; i++)
            {
                highestRoomIndices.Add(0);
            }
            for (int i = 0; i < firstAreas.Count; i++)
            {
                foreach (SmasmRoom room in firstContents)
                {
                    if (room.AreaIndex != i) { continue; }
                    if (room.RoomIndex > highestRoomIndices[i]) { highestRoomIndices[i] = room.RoomIndex; }
                }
            }
            for (int i = 0; i < secondContents.Count; i++)
            {
                SmasmRoom room = secondContents[i];
                bool areaExists = false;
                foreach (int area in firstAreas)
                {
                    if (room.AreaIndex == area) { areaExists = true; break; }
                }
                if (!areaExists) { room.AreaIndex = 0; }
                //area index can be constant from here on out.
                room.RoomIndex = highestRoomIndices[room.AreaIndex] + 1;
                room.UpdateLabel();
                //also need to manually update all of the section labels in the room object.
                //also needs to update the print pc's in $8F!
                room.Asm8F[0] = room.Label;
                room.Asm8F[2] = room.PrintPC;
                room.Asm83d[0] = room.Label;
                room.Asm83f[0] = room.Label;
                room.AsmA1[0] = room.Label;
                room.AsmB4[0] = room.Label;
                room.AsmLV[0] = room.Label;
                highestRoomIndices[room.AreaIndex]++;
            }
            //the secondContents are all renamed and ready to be added to the first file.
            //add everything from secondcontents into firstcontents
            foreach (SmasmRoom room in secondContents)
            {
                firstContents.Add(room);
            }
            //write firstContents to a new ASM file using firstFile's header.
            //so to do that, read firstFile and then delete/replace the contents of all the sections
            List<string> smasmSpace = Parse_SMASM_ASM(firstFile, out int startline, out int endline, out bool roomExists);

            string finalSMASM = RoomList2string(smasmSpace, firstContents);

            string[] splitEscs = { "\n", "\r\n" };
            List<string> firstFileList = File.ReadAllText(firstFile).Split(splitEscs, StringSplitOptions.None).ToList<string>();
            List<string> firstNonSmasm = firstFileList.GetRange(0, startline);
            firstNonSmasm.Add(finalSMASM);
            StringBuilder output = new StringBuilder(5000);
            foreach (string line in firstNonSmasm)
            {
                output.Append(line + '\n');
            }
            string backup = File.ReadAllText(firstFile);
            File.WriteAllText(Path.GetDirectoryName(firstFile) + "\\" + "ASMbackup.asm", backup);
            //can't do this write because the ASM file is "in use by another process". How to fix??
            string destinationName = Path.GetDirectoryName(firstFile) + "\\" + Path.GetFileNameWithoutExtension(firstFile) + "_merge.asm";
            File.WriteAllText(destinationName, output.ToString());
            AppendStatus("Saved to " + destinationName);
        }

        private string RoomList2string(List<string> smasmSpace, List<SmasmRoom> roomList)
        {
            GetSMASMsections(smasmSpace, out List<string> smasm8F, out List<string> smasm83d, out List<string> smasm83f, out List<string> smasmA1, out List<string> smasmB4, out List<string> smasmLV, out List<string> smasmTilesets, out List<string> smasmTilesetTable);
            //Clearsection keeps the section label and opening bracket.
            smasm8F = ClearSection(smasm8F);
            smasm83d = ClearSection(smasm83d);
            smasm83f = ClearSection(smasm83f);
            smasmA1 = ClearSection(smasmA1);
            smasmB4 = ClearSection(smasmB4);
            smasmLV = ClearSection(smasmLV);
            foreach (SmasmRoom room in roomList)
            {
                StringBuilder conc = new StringBuilder(500);
                foreach (string line in room.Asm8F)
                {
                    conc.Append(line + "\n");
                }
                smasm8F.Add(conc.ToString());
                conc.Clear();
                foreach (string line in room.Asm83d)
                {
                    conc.Append(line + "\n");
                }
                smasm83d.Add(conc.ToString());
                conc.Clear();
                foreach (string line in room.Asm83f)
                {
                    conc.Append(line + "\n");
                }
                smasm83f.Add(conc.ToString());
                conc.Clear();
                foreach (string line in room.AsmA1)
                {
                    conc.Append(line + "\n");
                }
                smasmA1.Add(conc.ToString());
                conc.Clear();
                foreach (string line in room.AsmB4)
                {
                    conc.Append(line + "\n");
                }
                smasmB4.Add(conc.ToString());
                conc.Clear();
                foreach (string line in room.AsmLV)
                {
                    conc.Append(line + "\n");
                }
                smasmLV.Add(conc.ToString());
                conc.Clear();
            }
            smasm8F.Add("}");
            smasm83d.Add("}");
            smasm83f.Add("}");
            smasmA1.Add("}");
            smasmB4.Add("}");
            smasmLV.Add("}");
            string finalSMASM = ConcatASMsections(smasm8F, smasm83d, smasm83f, smasmA1, smasmB4, smasmLV, smasmTilesets, smasmTilesetTable);
            return finalSMASM;
        }

        private List<string> ClearSection(List<string> section)
        {
            //remove everything in a section while keeping the highest level label and opening bracket
            List<string> rtn = new List<string>();
            rtn.Add(section[0]);
            rtn.Add(section[1]);
            return rtn;
        }

        private List<SmasmRoom> GetRoomsInASM(string asmPath)
        {
            string namePattern = @"\.R\d{2}A\d";
            System.Text.RegularExpressions.Regex nameFormat = new System.Text.RegularExpressions.Regex(namePattern);
            List<string> smasmSpace = Parse_SMASM_ASM(asmPath, out int startline, out int endline, out bool roomExists);
            GetSMASMsections(smasmSpace, out List<string> smasm8F, out List<string> smasm83d, out List<string> smasm83f, out List<string> smasmA1, out List<string> smasmB4, out List<string> smasmLV, out List<string> smasmTilesets, out List<string> smasmTilesetTable);
            List<string> roomNames = new List<string>();
            foreach (string line in smasm8F)
            {
                if (nameFormat.IsMatch(line))
                {
                    roomNames.Add(line);
                }
            }
            List<SmasmRoom> asmContents = new List<SmasmRoom>();
            foreach (string roomName in roomNames)
            {
                asmContents.Add(new SmasmRoom(roomName, smasmSpace, this));
            }
            return asmContents;
        }

        private List<SmasmRoom> GetRoomsInString(string smasmDoc)
        {
            string namePattern = @"\.R\S{2}A\d";
            System.Text.RegularExpressions.Regex nameFormat = new System.Text.RegularExpressions.Regex(namePattern);

            List<string> smasmSpace = smasmDoc.Split('\n').ToList();
            GetSMASMsections(smasmSpace, out List<string> smasm8F, out List<string> smasm83d, out List<string> smasm83f, out List<string> smasmA1, out List<string> smasmB4, out List<string> smasmLV, out List<string> smasmTilesets, out List<string> smasmTilesetTable);
            List<string> roomNames = new List<string>();
            foreach (string line in smasm8F)
            {
                if (nameFormat.IsMatch(line))
                {
                    roomNames.Add(line);
                }
            }
            List<SmasmRoom> asmContents = new List<SmasmRoom>();
            foreach (string roomName in roomNames)
            {
                asmContents.Add(new SmasmRoom(roomName, smasmSpace, this));
            }
            return asmContents;
        }

        private void mDBListToASMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //for some reason, the room export only works if the rooms are set to thisroom...... messy! That should be fixed.
            //also this is doomed to be a horribly slow function unless the Export_Room function is reworked to output to string instead of save to file.

            QuickMDBtoASM(); return;

            //old code below:

            //roomdata origRoom = thisroom;
            //string saveFolder = Path.GetDirectoryName(sm.Path);
            //string savePath = Path.GetDirectoryName(sm.Path) + "\\" + Path.GetFileNameWithoutExtension(sm.Path) + "_rooms.asm";
            //string mdbPath = getMDBpath(out bool mdbexists);
            //if (!mdbexists) { MessageBox.Show("Could not find\n" + mdbPath, "File not Found", MessageBoxButtons.OK); return; }
            //List<string> mdb = File.ReadAllLines(mdbPath).ToList();
            //StringBuilder asmFile = new StringBuilder(5000);

            ////maaaaaan it needs to be async for this to work. the sep progressbar isn't in the main windows, so that's why it works.
            //string statusBar = 
            //    "\n-------------------\n" +
            //    "MDB to ASM Progress:\n";
            //string endStatus = "\n-------------------\n";
            //char[] progress = new string('.', mdb.Count).ToCharArray();

            //CreateNewASMfile(savePath);
            //CreateNewSMASMspace(savePath);
            //int i = 0;
            //foreach (string entry in mdb)
            //{
            //    uint headerAddr = uint.Parse(entry.Substring(0, 5), NumberStyles.HexNumber);
            //    roomdata room = new roomdata(sm, headerAddr);
            //    room.DupChek();

            //    List<string> smasmSpace = Parse_SMASM_ASM(savePath, out int startline, out int endline, out bool roomExists);
            //    GetSMASMsections(smasmSpace, out List<string> smasm8F, out List<string> smasm83d, out List<string> smasm83f, out List<string> smasmA1, out List<string> smasmB4, out List<string> smasmLV, out List<string> smasmTilesets, out List<string> smasmTilesetTable);
            //    Export_Room(smasmSpace, startline, endline, savePath, false, room);

            //    progress[i] = '/';
            //    i++;
            //    StatusBox.Text = statusBar + new string(progress) + endStatus;
            //}

            //DialogResult openFolder = MessageBox.Show("ASM File saved to:\n" + saveFolder + "\nOpen folder?", "ASM Saved", MessageBoxButtons.YesNo);
            //if (openFolder == DialogResult.Yes) { Process.Start("explorer.exe", saveFolder); }

            //thisroom = origRoom;
            //AppendStatus("File saved to:\n" + savePath);
        }
        private void QuickMDBtoASM()
        {
            roomdata origRoom = thisroom;
            string saveFolder = Path.GetDirectoryName(sm.Path);
            string savePath = Path.GetDirectoryName(sm.Path) + "\\" + Path.GetFileNameWithoutExtension(sm.Path) + "_rooms.asm";
            string mdbPath = getMDBpath(out bool mdbexists);
            if (!mdbexists) { MessageBox.Show("Could not find\n" + mdbPath, "File not Found", MessageBoxButtons.OK); return; }
            List<string> mdb = File.ReadAllLines(mdbPath).ToList();
            StringBuilder asmFile = new StringBuilder(5000);

            //maaaaaan it needs to be async for this to work. the sep progressbar isn't in the main windows, so that's why it works.
            string statusBar =
                "\n-------------------\n" +
                "MDB to ASM Progress:\n";
            string endStatus = "\n-------------------\n";
            char[] progress = new string('.', mdb.Count).ToCharArray();

            CreateNewASMfile(savePath);
            CreateNewSMASMspace(savePath);
            int j = 0;
            //for this new and improved version:
            //after creating new ASM file, all the threads will draw from it.
            //Preallocate an array of the MDB count
            //Export Room will give us a SMASMSPACE with a single room for each in the game.
            //Stick each of these into the thread number [i] in the preallocated array.
            //threading part is over with
            //process the MDB smasm spaces to merge all the rooms into one.
            //(can use existing ASM merge function??)
            //MIGHT execute faster than the singlethreaded approach.
            string[] manySmasms = new string[mdb.Count];
            List<roomdata> mdbRooms = new List<roomdata>();
            foreach (string entry in mdb)
            {
                uint headerAddr = uint.Parse(entry.Substring(0, 5), NumberStyles.HexNumber);
                roomdata room = new roomdata(sm, headerAddr);
                room.DupChek();
                mdbRooms.Add(room);
            }

            List<string> smasmSpace = Parse_SMASM_ASM(savePath, out int startline, out int endline, out bool roomExists);
            GetSMASMsections(smasmSpace, out List<string> smasm8F, out List<string> smasm83d, out List<string> smasm83f, out List<string> smasmA1, out List<string> smasmB4, out List<string> smasmLV, out List<string> smasmTilesets, out List<string> smasmTilesetTable);
            //everything is the same up to this point, for each thread.

            //Export_Room(smasmSpace, startline, endline, savePath, false, room, out string roomASM);

            //any arguments need passed via the class constructor?
            //ok ok so all the threads need to be created from the main program(?) they cannot live in the sub-class.
            List<ThreadedRoomExporter> A = new List<ThreadedRoomExporter>();

            foreach (roomdata room in mdbRooms)
            {//pretty sure the mdbindex is unused... placeholder 0.
                A.Add(new ThreadedRoomExporter(this, room, 0, smasmSpace, savePath, startline, endline));
            }

            List<ThreadStart> B = new List<ThreadStart>(new ThreadStart[A.Count]);
            List<Thread> C = new List<Thread>(new Thread[A.Count]);
            for (int i = 0; i < A.Count; i++)
            {
                B[i] = new ThreadStart(A[i].ExportRoom);
                C[i] = new Thread(B[i]);
            }
            foreach (Thread item in C)
            {
                item.Start();
            }
            //now, everything we want to use the threads for will run in parallel, populating each RoomExporter.Result with the desired string
            //so, the main thread should just wait for everything to be done.
            bool allComplete = true;
            while (allComplete)
            {
                bool incompleteFound = false;
                foreach (ThreadedRoomExporter item in A)
                {
                    if (item.Finished == false) { incompleteFound = true; break; }
                }
                if (!incompleteFound) { allComplete = false; }
                Thread.Sleep(500);
            }

            List<SmasmRoom> allRooms = new List<SmasmRoom>();
            foreach (ThreadedRoomExporter item in A)
            {
                //each .Result goes into manySmasms for manipulation.
                //it will only have one room in each thread.
                List<SmasmRoom> roomExported = GetRoomsInString(item.Result);
                allRooms.Add(roomExported[0]);
            }

            string finalSMASM = RoomList2string(smasmSpace, allRooms);

            string[] splitEscs = { "\n", "\r\n" };
            List<string> firstFileList = File.ReadAllText(savePath).Split(splitEscs, StringSplitOptions.None).ToList<string>();
            List<string> firstNonSmasm = firstFileList.GetRange(0, startline);
            firstNonSmasm.Add(finalSMASM);
            StringBuilder output = new StringBuilder(5000);
            foreach (string line in firstNonSmasm)
            {
                output.Append(line + '\n');
            }
            //string backup = File.ReadAllText(savePath);
            File.WriteAllText(savePath, output.ToString());

            DialogResult openFolder = MessageBox.Show("ASM File saved to:\n" + saveFolder + "\nOpen folder?", "ASM Saved", MessageBoxButtons.YesNo);
            if (openFolder == DialogResult.Yes) { Process.Start("explorer.exe", saveFolder); }

            thisroom = origRoom;
            AppendStatus("File saved to:\n" + savePath);
        }
        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            credits A = new credits();
            A.ShowDialog();
        }

        private void Dropdown_LoadRoom(object sender, EventArgs e)
        {
            if(HeaderDropdown.Text.Length < 5) { return; }
            if (tutorialMode) { return; }
            string headerNumbers = HeaderDropdown.Text.Substring(0, 5);
            uint headerAddr = uint.Parse(headerNumbers, NumberStyles.HexNumber);
            LoadRoomToGUI(headerAddr);
        }

        private void PopulateHeaderList()
        {
            //fill HeaderDropdown with contents of given MDB, including room labels.
            HeaderDropdown.Items.Clear();
            string mdbPath = getMDBpath(out bool mdbexists);
            if (!mdbexists) { MessageBox.Show("Could not find\n" + mdbPath, "File not Found", MessageBoxButtons.OK); return; }
            List<string> mdb = File.ReadAllLines(mdbPath).ToList();
            foreach (string room in mdb)
            {
                HeaderDropdown.Items.Add(room);
            }
        }

        private void HeaderDropdown_TextChanged(object sender, EventArgs e)
        {
            AllowHexOnlyCOMBO(sender, e);
        }

        //uses these SMASM global variables to determine what tutorial to show between button clicks.
        public int tutorialCount = 0;
        public int tutorialIndex = 0;
        private List<TutorialText> tutorials = null;
        bool tutorialMode = false;
        private void walkthoughToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tutorials = GetTutorials();
            //would also bring up the tutorial image that blocks the rest of SMASM.
            ShowTutorialBox(tutorialIndex);
        }
        private List<TutorialText> GetTutorials()
        {
            //NOTE: the labels already have word wrap by default!
            List<TutorialText> tutorials = new List<TutorialText>
            {
               new TutorialText
               {
                PosX = HeaderDropdown.Location.X,
                PosY = HeaderDropdown.Location.Y,
                Width = HeaderDropdown.Width,
                Height = HeaderDropdown.Height,
                Text = "Reads MDB List from SMILE's Custom folder for the ROM.\n" +
                        "Level header PC addresses can also be keyed in manually.",
                LabelWidth = 300,
                LabelHeight = 40,
                LeftFacing = false,
                Name = "Header Dropdown"
               },
               new TutorialText
               {
                PosX = RoomIndex.Location.X,
                PosY = RoomIndex.Location.Y - 10,
                Width = 100,
                Height = 195,
                Text = "Room and Area indices can be changed for the purpose of copying rooms.\n" +
                "Others should be changed in main editor.\n\n" +
                "Copying a room:\n" +
                "-Load Room\n" +
                "-Change Indices\n" +
                "-Export to ASM\n" +
                "-Apply to ROM\n" +
                ""
                ,
                LabelWidth = 150,
                LabelHeight = 160,
                LeftFacing = false,
                Name = "RoomVars"
               },
               new TutorialText
               {
                PosX = RoomPicture.Location.X,
                PosY = RoomPicture.Location.Y,
                Width = RoomPicture.Width,
                Height = RoomPicture.Height,
                Text = "Click and drag to scroll. Right-click for scroll editor.\n" +
                "Scroll Editor: RGB scrolls are like SMILE's. Close normally, or shortcut by holding right and left click at the same time."
                ,
                LabelWidth = 300,
                LabelHeight = 50,
                LeftFacing = false,
                Name = "RoomPicture"
               },
                new TutorialText
               {
                PosX = StateBox.Location.X,
                PosY = StateBox.Location.Y,
                Width = StateBox.Width,
                Height = StateBox.Height,
                Text = "Right click to add/remove/rearrange states."
                ,
                LabelWidth = 150,
                LabelHeight = 30,
                LeftFacing = false,
                Name = "Room States"
               },
                new TutorialText
               {
                PosX = RefreshExport.Location.X,
                PosY = RefreshExport.Location.Y,
                Width = RefreshExport.Width,
                Height = 205,
                Text = "Refresh + Export: Use after making changes in SMILE.\n" +
                "\n" +
                "\n" +
                "\n" +
                "Export: Export currently loaded room to ASM file.\n" +
                "Use after making changes in SMASM.\n" +
                "\n" +
                "\n" +
                "Apply: Commit ASM file to ROM.\n" +
                "Use after making changes in SMASM.\n" +
                "\n" +
                "Current Tileset to ASM: Imports the current room tileset from the SMASM Tileset Folders into the ASM File.\n" +
                "Use after making changes in your chosen gfx editor.\n" +
                "\n" +
                "ROM to Tset Folder: Exports the current room tileset from ROM to the SMASM tileset folders for editing.\n" +
                "Use after modifying tile table or other tileset components in SMILE.\n"
                ,
                LabelWidth = 350,
                LabelHeight = 250,
                LeftFacing = false,
                Name = "ASM Buttons"
               },
               new TutorialText
               {
                PosX = EnemyBox.Location.X,
                PosY = EnemyBox.Location.Y,
                Width = EnemyBox.Width,
                Height = 340,
                Text = "Right Click to add and remove room objects. Multiple can be selected for copying/deletion.\n" +
                "\n" +
                "Click and Drag to rearrange lists.\n" +
                "\n" +
                "Shortcut: Double click to duplicate items without opening menu.\n" +
                "\n" +
                "\n" +
                "Info Displayed:\n" +
                "-Enemy ID\n" +
                "-PLM ID\n" +
                "-FX Door Select ($0000 for default FX, else it's a door pointer.)\n" +
                "-Door Destinations (new doors are assigned a placeholder value.)"
                ,
                LabelWidth = 200,
                LabelHeight = 250,
                LeftFacing = false,
                Name = "Room Objects"
               },
               new TutorialText
               {
                PosX = StatusBox.Location.X,
                PosY = StatusBox.Location.Y,
                Width = StatusBox.Width,
                Height = StatusBox.Height,
                Text = "Info console.\n" +
                "Planned support for typing commands."
                ,
                LabelWidth = 200,
                LabelHeight = 250,
                LeftFacing = true,
                Name = "Console"
               },
        };
            return tutorials;
        }
        private void ClearTutorial()
        {
            //goto accounts for the list size changing; keeps looking until no more tutorial tags exist.
            LOOP:
            foreach (Control item in this.Controls)
            {
                if (item.Tag == null) { continue; }
                if (item.Tag.ToString() == "tutorial") { this.Controls.Remove(item); goto LOOP; }
            }
        }
        private void ShowTutorialBox(int index)
        {
            //clear all tutorial-related controls
            //remake all the tutorial controls with the desired tutorial index.
            //Does all the formatting and stuff to make the data in the TutorialText object into a rectangle/controls.

            //might be good to use a borderPadding variable for whitespace around control.
            //and borderThickness for the X and Y  width of the rectangles.
            List<TutorialText> tutorials = GetTutorials();

            tutorialMode = true;
            if(index < 0) { index = tutorials.Count - 1; tutorialIndex = index; }
            if(index > tutorials.Count-1) { index = 0; tutorialIndex = index; }

            ClearTutorial();
            
            int borderThickness = 5;
            int borderPadding = 3;
            TutorialText activetut = tutorials[index];
            Bitmap rectLR = DrawRectangle(borderThickness, activetut.Height, Color.Black);
            Bitmap rectUD = DrawRectangle(activetut.Width, borderThickness, Color.Black);
            //making a picturebox to contain several more pictureboxes will not work because it needs transparency.
            //but, each line will still need its own picturebox!
            PictureBox rectL = new PictureBox
            {
                Image = rectLR,
                BackColor = Color.Transparent,
                Size = new Size(rectLR.Width, rectLR.Height),
                Location = new Point(activetut.PosX - borderPadding - borderThickness, activetut.PosY),
                Visible = true,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Name = "rectL;",
                Tag = "tutorial",
            };
            PictureBox rectR = new PictureBox
            {
                Image = rectLR,
                BackColor = Color.Transparent,
                Size = new Size(rectLR.Width, rectLR.Height),
                Location = new Point(activetut.PosX + activetut.Width + borderPadding, activetut.PosY),
                Visible = true,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Name = "rectR;",
                Tag = "tutorial",
            };
            PictureBox rectU = new PictureBox
            {
                Image = rectUD,
                BackColor = Color.Transparent,
                Size = new Size(rectLR.Width, rectLR.Height),
                Location = new Point(activetut.PosX, activetut.PosY - borderPadding - borderThickness),
                Visible = true,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Name = "rectU;",
                Tag = "tutorial",
            };
            PictureBox rectD = new PictureBox
            {
                Image = rectUD,
                BackColor = Color.Transparent,
                Size = new Size(rectLR.Width, rectLR.Height),
                Location = new Point(activetut.PosX, activetut.PosY + activetut.Height + borderPadding),
                Visible = true,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Name = "rectD;",
                Tag = "tutorial",
            };
            Label explain = new Label
            {
                Text = activetut.Text,
                Location = new Point(rectR.Location.X + borderThickness, rectR.Location.Y),
                BackColor = Color.Yellow,
                AutoSize = false,
                Size = new Size(activetut.LabelWidth, activetut.LabelHeight),
                Tag = "tutorial",
            };
            //an autosized control cannot have its size read accurately...
            if (activetut.LeftFacing)
            {
                explain.Location = new Point(rectL.Location.X - borderThickness - explain.Width, rectL.Location.Y);
            }
            //size of additional space to add for buttons.
            int buttonPadding = 25;
            PictureBox explainBackground = new PictureBox
            {
                Image = DrawRectangle(explain.Size.Width + borderThickness * 2, explain.Size.Height + borderThickness * 2 + buttonPadding, Color.DarkSlateGray),
                Location = new Point(explain.Location.X - borderThickness, explain.Location.Y - borderThickness),
                SizeMode = PictureBoxSizeMode.AutoSize,
                Tag = "tutorial",
            };
            Button closeTutorial = new Button
            {
                Text = "X",
                Size = new Size(20, 20),
                Location = new Point (explainBackground.Width-25, explainBackground.Height-25),
            };
            Button prevTutorial = new Button
            {
                Text = "<",
                Size = new Size(20, 20),
                Location = new Point(borderThickness, explainBackground.Height - 25),
            };
            Button nextTutorial = new Button
            {
                Text = ">",
                Size = new Size(20, 20),
                Location = new Point(prevTutorial.Location.X + prevTutorial.Width + 5, prevTutorial.Location.Y),
            };
            closeTutorial.Click += CloseTutorial_Click;
            prevTutorial.Click += PrevTutorial_Click;
            nextTutorial.Click += NextTutorial_Click;

            explainBackground.Controls.Add(closeTutorial);
            explainBackground.Controls.Add(prevTutorial);
            explainBackground.Controls.Add(nextTutorial);

            this.Controls.Add(rectL);
            this.Controls.Add(rectR);
            this.Controls.Add(rectU);
            this.Controls.Add(rectD);
            this.Controls.Add(explain);
            this.Controls.Add(explainBackground);


            rectL.BringToFront();
            rectR.BringToFront();
            rectU.BringToFront();
            rectD.BringToFront();
            explainBackground.BringToFront();
            explain.BringToFront();
        }

        private void NextTutorial_Click(object sender, EventArgs e)
        {
            tutorialIndex++;
            ShowTutorialBox(tutorialIndex);
        }

        private void PrevTutorial_Click(object sender, EventArgs e)
        {
            tutorialIndex--;
            ShowTutorialBox(tutorialIndex);
        }

        private void CloseTutorial_Click(object sender, EventArgs e)
        {
            tutorialMode = false;
            ClearTutorial();
        }

        private Bitmap DrawRectangle(int width, int height, Color color)
        {
            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (Graphics gfx = Graphics.FromImage(bmp))
            using (SolidBrush brush = new SolidBrush(color))
            {
                gfx.FillRectangle(brush, 0, 0, bmp.Width, bmp.Height);
            }
            return bmp;
        }

        private void OpenMDB_Click(object sender, EventArgs e)
        {
            string mdbPath = getMDBpath(out bool mdbExists);
            if (!mdbExists) { MessageBox.Show("MDB does not exist.\nCreate one by exporting a room and applying to ROM, or supply an existing one at:\n" + mdbPath, "No MDB", MessageBoxButtons.OK); return; }
            Process.Start("notepad.exe", mdbPath);
        }

        private void HeaderDropdown_DropDown(object sender, EventArgs e)
        {
            PopulateHeaderList();
        }

        private void HeaderDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SendKeys.Send("\t");
        }

        private void testbutton_Click(object sender, EventArgs e)
        {

        }
        private void testThreading()
        {
            
        }
    }

    class ThreadedRoomExporter
    { 
        public ThreadedRoomExporter(SMASM caller, roomdata room, int mdbIndex, List<string> smasmSpace, string savepath, int startline, int endline)
        {
            Parent = caller;
            Room = room;
            MDBindex = mdbIndex;
            SmasmSpace = smasmSpace;
            SavePath = savepath;
            StartLine = startline;
            EndLine = endline;
        }

        public void ExportRoom()
        {
            Parent.Export_Room(SmasmSpace, StartLine, EndLine, SavePath, false, Room, out string res);
            Result = res;
            Finished = true;
        }
        public List<string> SmasmSpace { get; set; }
        public string Result { set; get; }
        public string SavePath { set; get; }
        public roomdata Room { set; get; }
        public int MDBindex { set; get; }
        public int StartLine { set; get; }
        public int EndLine { set; get; }
        public SMASM Parent { set; get; }
        public bool Finished { get; set; }
    }

    public struct TutorialText
    {
        //variable properties of tutorial rectangles; will be displayed to screen with a different function.
        //these will be different for each one so it doesn't really need a constructor(?)
        //Unless, can constructors have out args? We could have that add it to the tutorials list.
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Text { get; set; }
        public int LabelWidth { set; get; }
        public int LabelHeight { get; set; }
        public bool LeftFacing { set; get; }
        public string Name { get; set; }
    }
    public struct SmasmRoom
    {
        //GetSMASMsections(smasmSpace, out List<string> smasm8F, out List<string> smasm83d, out List<string> smasm83f, out List<string> smasmA1, out List<string> smasmB4, out List<string> smasmLV, out List<string> smasmTilesets, out List<string> smasmTilesetTable);
        public SmasmRoom(string roomLabel, List<string>smasmSpace, SMASM smasm)
        {
            //all properties return null if the room does not exist 
            //would be nice if we didn't need to pass SMASM itself, but that was the only way to get GetSMASMsections() to work....
            bool roomFound = false;
            //string searchfor = "." + "R" + asmFCN.WByte(roomIndex) + "A" + areaIndex + ".asm";
            string searchfor = roomLabel;
            //break on first occurence of desired room; if one tag is found it is assumed to exist in all the sections.
            foreach (string line in smasmSpace)
            {
                if(line.IndexOf(line) == -1) { continue; }
                else { roomFound = true; break; }
            }

            Exists = roomFound;
            if (!roomFound)
            {
                Label = null;
                PrintPC = null;
                AreaIndex = -1;
                RoomIndex = -1;
                Asm8F = null;
                Asm83d = null;
                Asm83f = null;
                AsmA1 = null;
                AsmB4 = null;
                AsmLV = null;
                return;
            }

            //string roomIndexPattern = @"\S{2}";
            roomLabel = roomLabel.Substring(roomLabel.IndexOf("R")+1);
            //room label pared down to ##A#
            //System.Text.RegularExpressions.Regex roomIndex = new System.Text.RegularExpressions.Regex(roomIndexPattern);
            Label = searchfor;
            AreaIndex = int.Parse(roomLabel.Substring(roomLabel.Length-1),NumberStyles.HexNumber);
            RoomIndex = int.Parse(roomLabel.Substring(0,2), NumberStyles.HexNumber);
            PrintPC = "print pc, \"-" + "R" + asmFCN.WByte((uint)RoomIndex) + "A" + AreaIndex + "\"";
            smasm.GetSMASMsections(smasmSpace, out List<string> smasm8F, out List<string> smasm83d, out List<string> smasm83f, out List<string> smasmA1, out List<string> smasmB4, out List<string> smasmLV, out List<string> smasmTilesets, out List<string> smasmTilesetTable);
            Asm8F = smasm.FindSection(searchfor, smasm8F);
            Asm83d = smasm.FindSection(searchfor, smasm83d);
            Asm83f = smasm.FindSection(searchfor, smasm83f);
            AsmA1 = smasm.FindSection(searchfor, smasmA1);
            AsmB4 = smasm.FindSection(searchfor, smasmB4);
            AsmLV = smasm.FindSection(searchfor, smasmLV);
        }
        public void UpdateLabel()
        {
            //make label match the current Room and Area Indices.
            Label = ".R" + asmFCN.WByte((uint)RoomIndex) + "A" + AreaIndex;
            PrintPC = "print pc, \"-" + "R" + asmFCN.WByte((uint)RoomIndex) + "A" + AreaIndex + "\"";
        }

        public string Label { get; set; }
        public string PrintPC { get; set; }
        public bool Exists { get; set; }
        public int AreaIndex { get; set; }
        public int RoomIndex { get; set; }
        public List<string> Asm8F { get; set; }
        public List<string> Asm83d { get; set; }
        public List<string> Asm83f { get; set; }
        public List<string> AsmA1 { get; set; }
        public List<string> AsmB4 { get; set; }
        public List<string> AsmLV { get; set; }
    }


    public struct MapArea
    {
        //essentially this is just a list of rooms, so that we can have a list of areas.
        public MapArea(uint number)
        {
            AreaIndex = number;
            Rooms = new List<roomdata>();
        }
        public List<roomdata> Rooms { get; set; }
        public uint AreaIndex { get; set; }
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
        public static unsafe uint TilesetDecompress(void* dest, uint pc, uint* end)
        {
            return LunarDecompress(dest, pc, 0x5000, 4, 0, end);  //this exists because the tilesets are 0x5000 max size (editor is not compatible with mode 7 tilesets)
        }
        public static unsafe uint Decompress(void* dest, uint pc, uint* end)
        {
            return LunarDecompress(dest, pc, 0xA000, 4, 0, end);  //not sure if this will work since the last var ROMPOSITION is supposed to be a pointer....
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
