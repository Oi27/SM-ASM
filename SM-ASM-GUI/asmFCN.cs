using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SM_ASM_GUI
{
    
    class asmFCN
    {
        const string d = ", $";
        public static string WByte(uint data)
        {
            return string.Format("{0:X2}", data);
        }
        public static string WWord(uint data)
        {
            return string.Format("{0:X4}", data);
        }
        public static string WLong(uint data)
        {
            return string.Format("{0:X6}", data);
        }


        public static string[] Room2ASM(roomdata thisroom, int levelbuffer)
        //return string array w/each element being the content for each bank.
        //8F, 83, A1, B4, LEVELS
        //Repack all the data in $, delimited lists first that we can use with db.
        //room.Label already has the . built in - level one sublabel.
        {
            //R##A#
            string[] output = new string[6];
            output[0] = ASM8F(thisroom);
            output[1] = ASM83d(thisroom);
            output[2] = ASM83f(thisroom);
            output[3] = ASMA1(thisroom);
            output[4] = ASMB4(thisroom);
            output[5] = ASMLV(thisroom, levelbuffer);
            return output;
        }


        public static string ASM8F(roomdata r)
        {
            string header1 =
                "$" +
                WByte(r.RoomIndex) + d +
                WByte(r.AreaIndex) + d +
                WByte(r.MapX) + d +
                WByte(r.MapY) + d +
                WByte(r.Width) + d +
                WByte(r.Height) + d +
                WByte(r.UpScroller) + d +
                WByte(r.DnScroller) + d +
                WByte(r.SpecialGFX) + 
                ""
                ;
            //create state string here - list of state pointers ending with the std. state one.
            string statetext = "dw $";
            if (r.StateCount == 0) 
            {
                //case default is only state; do nothing.
            }
            else
            {
                for (int i = 0; i < r.StateCount; i++)
                //states are formatted
                //type, arg, pointer
                {
                    statetext += WWord(r.States[i].Type);

                    //All states will have a one-word type. Check what arg style it uses:
                    if(r.States[i].Type == 0xE612 || r.States[i].Type == 0xE629) 
                    {
                        statetext += " : db $" + WByte(r.States[i].StateArg) + " : dw ..state" + i;
                    }
                    else if(r.States[i].Type == 0xE5EB)
                    {
                        statetext += d + WWord(r.States[i].StateArg) + "..state" + i;
                    }
                    else
                    {
                        statetext += ", ..state" + i;
                    }
                    statetext += "\ndw $";
                }
            }
            statetext += "E5E6\n"+"..default\n";

            string statepointers;
            //next up: get all the state data into a string.
            //Default state comes first - each entry is on its own line.
            if (r.States[r.StateCount].pScrolls < 0x8000)
            {
                statepointers =
                "dl LEVELS_" + r.LabelM + "_default" +
                " : db $" + WByte(r.States[r.StateCount].TileSet) + d +
                WByte(r.States[r.StateCount].SongSet) + d +
                WByte(r.States[r.StateCount].PlayInd) +
                " : dw ROOMFX_" + r.LabelM + "_default, " +
                "ENEMYSET_" + r.LabelM + "_default, " +
                "ENEMYGFX_" + r.LabelM + "_default, " +
                "$" + WWord((r.States[r.StateCount].BGxScroll * 0x100) + r.States[r.StateCount].BGyScroll) + d +
                WWord(r.States[r.StateCount].pScrolls) + d +
                WWord(r.States[r.StateCount].pUnused) + d +
                WWord(r.States[r.StateCount].pMainASM) + ", " +
                "..plms_default" + d +
                WWord(r.States[r.StateCount].pBackground) + d +
                WWord(r.States[r.StateCount].pSetupASM) +
                "\n"
                ;
            }
            else
            {
                statepointers =
                "dl LEVELS_" + r.LabelM + "_default" +
                " : db $" + WByte(r.States[r.StateCount].TileSet) + d +
                WByte(r.States[r.StateCount].SongSet) + d +
                WByte(r.States[r.StateCount].PlayInd) +
                " : dw ROOMFX_" + r.LabelM + "_default, " +
                "ENEMYSET_" + r.LabelM + "_default, " +
                "ENEMYGFX_" + r.LabelM + "_default, " +
                "$" + WWord((r.States[r.StateCount].BGxScroll * 0x100) + r.States[r.StateCount].BGyScroll) + ", " +
                "..scrolls_default" + d +
                WWord(r.States[r.StateCount].pUnused) + d +
                WWord(r.States[r.StateCount].pMainASM) + ", " +
                "..plms_default" + d +
                WWord(r.States[r.StateCount].pBackground) + d +
                WWord(r.States[r.StateCount].pSetupASM) +
                "\n"
                ;
            }

            string plmdata = "..plms\n" +
                "...default\n" +
                plms2asm(r.States[r.StateCount]) +
                ""  //end of plms2asm already inserts a \n.
                ;
            string scrolldata = "..scrolls\n" +
                "...default\n" +
                scrolls2asm(r.States[r.StateCount]) +
                ""  //end of plms2asm already inserts a \n.
                ;
            if (r.StateCount != 0)
            {
                for(int i = 0; i < r.StateCount; i++)
                {
                    if (r.States[i].pScrolls < 0x8000)
                    {
                        statepointers +=
                             "..state" + i + "\n" +
                             "dl LEVELS_" + r.LabelM + "_" + r.States[i].pmLevelData +
                             " : db $" + WByte(r.States[i].TileSet) + d +
                             WByte(r.States[i].SongSet) + d +
                             WByte(r.States[i].PlayInd) +
                             " : dw ROOMFX_" + r.LabelM + "_" + r.States[i].pmFX + ", " +
                             "ENEMYSET_" + r.LabelM + "_" + r.States[i].pmEnemySet + ", " +
                             "ENEMYGFX_" + r.LabelM + "_" + r.States[i].pmEnemyGFX + ", " +
                             "$" + WWord((r.States[i].BGxScroll * 0x100) + r.States[i].BGyScroll) + d +
                             WWord(r.States[i].pScrolls) + d +
                             WWord(r.States[i].pUnused) + d +
                             WWord(r.States[i].pMainASM) + ", " +
                             "..plms" + "_" + r.States[i].pmPLMset + d +
                             WWord(r.States[i].pBackground) + d +
                             WWord(r.States[i].pSetupASM) +
                             "\n"
                             ;
                    }
                    else
                    {
                        statepointers +=
                            "..state" + i + "\n" +
                            "dl LEVELS_" + r.LabelM + "_" + r.States[i].pmLevelData +
                            " : db $" + WByte(r.States[i].TileSet) + d +
                            WByte(r.States[i].SongSet) + d +
                            WByte(r.States[i].PlayInd) +
                            " : dw ROOMFX_" + r.LabelM + "_" + r.States[i].pmFX + ", " +
                            "ENEMYSET_" + r.LabelM + "_" + r.States[i].pmEnemySet + ", " +
                            "ENEMYGFX_" + r.LabelM + "_" + r.States[i].pmEnemyGFX + ", " +
                            "$" + WWord((r.States[i].BGxScroll * 0x100) + r.States[i].BGyScroll) + ", " +
                            "..scrolls" + "_" + r.States[i].pmScrolls + d +
                            WWord(r.States[i].pUnused) + d +
                            WWord(r.States[i].pMainASM) + ", " +
                            "..plms" + "_" + r.States[i].pmPLMset + d +
                            WWord(r.States[i].pBackground) + d +
                            WWord(r.States[i].pSetupASM) +
                            "\n"
                            ;
                    }
                    //if state plm data is unique:
                    if("state"+i == r.States[i].pmPLMset)
                    {
                        plmdata +=
                            "..." + "state" + i + "\n" +
                            plms2asm(r.States[i])
                            ;
                    }
                    if ("state" + i == r.States[i].pmScrolls)
                    {
                        scrolldata +=
                            "..." + "state" + i + "\n" +
                            scrolls2asm(r.States[i])
                            ;
                    }
                }
            }

            string doorlabels = "";
            for(int i = 0; i < r.Doors.Count; i++)
            {
                doorlabels += "dw DOORS_" + r.LabelM + "_d" + i + "\n";
            }
            doorlabels += "dw $0000\n";

            string asm =
                        r.Label + "\n" +
                        "{" + "\n" +
                        "print pc, \"-" + r.LabelM + "\"\n" +
                        "db " + header1 + " : dw ..doorout\n" + 
                        statetext +
                        statepointers +
                        "..doorout\n" +
                        doorlabels +
                        plmdata +
                        scrolldata +
                        "}" + "\n";
            return asm;
        }
        public static string plms2asm(state s)
        //For each PLM, add it to its own line.
        //also needs to have scrolls...
        {
            string plmdata = "";
            string scrollstring = plmScrollData2asm(s, out List<PLMdata> scrollPLMs, out List<int> plmIndices);
            //all the PLMs that are not scrolls have -1 in the plmindices list.
            int scrollPLMcount = 0;
            for (int i = 0; i < s.PLMs.Count(); i++)
            {
                if(plmIndices[i] == -1)
                {
                    plmdata += "dw $" +
                    WWord(s.PLMs[i].ID) + " : db $" +
                    WByte(s.PLMs[i].PosX) + d +
                    WByte(s.PLMs[i].PosY) + " : dw $" +
                    WWord(s.PLMs[i].Variable) +
                    "\n"
                    ;
                }
                else
                {
                    plmdata += "dw $" +
                    WWord(s.PLMs[i].ID) + " : db $" +
                    WByte(s.PLMs[i].PosX) + d +
                    WByte(s.PLMs[i].PosY) + " : dw ....scrolldata_scrollPLM" + scrollPLMcount + 
                    "\n"
                    ;
                    scrollPLMcount++;
                }

            }
            plmdata += "dw $0000\n";
            plmdata += scrollstring;
            return plmdata;
        }
        public static string plmScrollData2asm(state s, out List<PLMdata> scrollPLMS, out List<int> plmIndices)
        {
            //generate a list of scroll data to attach to the end of the PLM list.
            //..plms
            //...default
            //....scrolldata
            //.....scrollPLM1
            //.....scrollPLM2
            //.
            //.
            //*Format of scroll updating data is as follows:
            //(screen)(scroll)...(screen)(scroll)(80)
            //Example:
            //03 01 80 < ---change screen 03 to a blue scroll.

            List<PLMdata> scrollsPlmList = new List<PLMdata>();
            List<int> scrollPLMindices = new List<int>();
            for (int i = 0; i < s.PLMs.Count; i++)
            {
                PLMdata plm = s.PLMs[i];
                if(plm.ScrollData == null) 
                { scrollPLMindices.Add(-1); continue; }
                scrollsPlmList.Add(plm);
                scrollPLMindices.Add(i);
            }
            scrollPLMS = scrollsPlmList;
            plmIndices = scrollPLMindices;
            if (scrollPLMS.Count == 0) { return ""; }

            //only gets past this point it there's really data to process
            string scrollPLMdata = "....scrolldata\n";
            for (int i = 0; i < scrollPLMS.Count; i++)
            {
                PLMdata plm = scrollPLMS[i];
                scrollPLMdata += ".....scrollPLM" + i + "\n";
                string scrolldw = "db $";
                for (int j = 0; j < plm.ScrollData.Length; j++)
                {
                    scrolldw += WByte(plm.ScrollData[j]) + d;
                }
                scrolldw = scrolldw.Substring(0, scrolldw.Length-3);
                scrolldw += "\n";
                scrollPLMdata += scrolldw;
            }
            //already ends in a \n

            return scrollPLMdata;
        }
        public static string scrolls2asm(state s)
        {
            if (s.pScrolls < 0x8000) { return ""; }
            string scrolldata = "db $";
            for (int i = 0; i < s.Scrolls.Length; i++)
            {
                scrolldata += WByte(s.Scrolls[i]) + d;
            }
            //chop off the last d that is added extraneously.
            scrolldata = scrolldata.Substring(0, scrolldata.Length - d.Length);
            scrolldata += "\n";
            return scrolldata;
        }

        public static string ASM83d(roomdata r)
        //this one is different in that its data is for the room as a whole and not divided into states.
        //Each door gets its own label.
        {
            string asm = //.R##A# $LevelFree
                        r.Label + "\n" +
                        "{" + "\n" +
                        doors2asm(r) +
                        "}" + "\n";
            return asm;
        }

        public static string doors2asm(roomdata r)
        {
            string doordata = "";
            for (int i = 0; i < r.Doors.Count; i++)
            {
                doordata += "..d" + i + "\n" +
                    "dw $" +
                    WWord(r.Doors[i].Destination) + " : db $" +
                    WByte(r.Doors[i].Bitflag) + d +
                    WByte(r.Doors[i].Direction) + d + 
                    WByte(r.Doors[i].CapX) + d +
                    WByte(r.Doors[i].CapY) + d +
                    WByte(r.Doors[i].ScrnX) + d +
                    WByte(r.Doors[i].ScrnY) + " : dw $" +
                    WWord(r.Doors[i].SpawnDist) + d + 
                    WWord(r.Doors[i].DoorASM) + 
                    "\n"
                    ;
            }
            return doordata;
        }


        public static string ASM83f(roomdata r)
        {
            string fx =
                "..default\n" +
                fx2asm(r.States[r.StateCount]) +
                ""
                ;
            if (r.StateCount != 0)
            {
                for (int i = 0; i < r.StateCount; i++)
                {
                    //if state data is unique:
                    if ("state" + i == r.States[i].pmFX)
                    {
                        fx +=
                            ".." + "state" + i + "\n" +
                            fx2asm(r.States[i])
                            ;
                    }

                }
            }
            string asm = //.R##A# $LevelFree
                        r.Label + "\n" +
                        "{" + "\n" +
                        fx +
                        "}" + "\n";
            return asm;
        }

        public static string fx2asm(state s)
        {
            //each room with no FX gets its own $FFFF... would be nice to implement a way they can share.
            //an idea similar to the way doors are moved around:
            //modify the file before applying to have all these FFFF door selects replaced with a label pointing to a standard No-FX entry, hardcoded at the beginning of SMASM_83F
            
            //this loop is very strange but it works. Prints the FX with the default entry last.
            string fxdata = "";
            for (int i = s.FX.Count-1; i > -1; i--)
            {
                if(s.FX[i].DoorSelect == 0xFFFF)
                {
                    fxdata += "dw $FFFF\n";
                    break;
                }
                fxdata += "dw $" +
                    WWord(s.FX[i].DoorSelect) + d +
                    WWord(s.FX[i].LiqStart) + d +
                    WWord(s.FX[i].LiqEnd) + d +
                    WWord(s.FX[i].LiqSpeed) + " : db $" +
                    WByte(s.FX[i].LiqDelay) + d +
                    WByte(s.FX[i].Type) + d +
                    WByte(s.FX[i].BitA) + d +
                    WByte(s.FX[i].BitB) + d +
                    WByte(s.FX[i].BitC) + d +
                    WByte(s.FX[i].PalFXflags) + d +
                    WByte(s.FX[i].TileAnimFlags) + d +
                    WByte(s.FX[i].PalBlend) +
                    "\n"
                    ;
            }
            return fxdata;
        }
        public static string ASMA1(roomdata r)
        {
            string enemydata =
                "..default\n" +
                enemies2asm(r.States[r.StateCount]) +
                ""
                ;
            if (r.StateCount != 0)
            {
                for (int i = 0; i < r.StateCount; i++)
                {
                    //if state data is unique:
                    if ("state" + i == r.States[i].pmEnemySet)
                    {
                        enemydata +=
                            ".." + "state" + i + "\n" +
                            enemies2asm(r.States[i])
                            ;
                    }

                }
            }
            string asm = //.R##A# $LevelFree
                        r.Label + "\n" +
                        "{" + "\n" +
                        enemydata +
                        "}" + "\n";
            return asm;
        }
        public static string enemies2asm(state s)
        //For each enemy, add it to its own line.
        {
            string enemydata = "";
            for (int i = 0; i < s.Enemies.Count; i++)
            {
                enemydata += "dw $" +
                    WWord(s.Enemies[i].ID) + d +
                    WWord(s.Enemies[i].PosX) + d +
                    WWord(s.Enemies[i].PosY) + d +
                    WWord(s.Enemies[i].TileMap) + d +
                    WWord(s.Enemies[i].Special) + d +
                    WWord(s.Enemies[i].SpecGFX) + d +
                    WWord(s.Enemies[i].Speed1) + d +
                    WWord(s.Enemies[i].Speed2) +
                    "\n"
                    ;
            }
            enemydata += "dw $FFFF : db $" + WByte(s.EnemyCount) + "\n";
            return enemydata;
        }

        public static string ASMB4(roomdata r)
        {
            string enemygfx =
                "..default\n" +
                enemygfx2asm(r.States[r.StateCount]) +
                ""
                ;
            if (r.StateCount != 0)
            {
                for (int i = 0; i < r.StateCount; i++)
                {
                    //if state data is unique:
                    if ("state" + i == r.States[i].pmEnemySet)
                    {
                        enemygfx +=
                            ".." + "state" + i + "\n" +
                            enemygfx2asm(r.States[i])
                            ;
                    }

                }
            }
            string asm = //.R##A# $LevelFree
                        r.Label + "\n" +
                        "{" + "\n" +
                        enemygfx +
                        "}" + "\n";
            return asm;
        }
        public static string enemygfx2asm(state s)
        {
            string enemygfx = "";
            for (int i = 0; i < s.EnemiesAllowed.Count; i++)
            {
                enemygfx += "dw $" +
                    WWord(s.EnemiesAllowed[i].ID) + d +
                    WWord(s.EnemiesAllowed[i].Palette) +
                    "\n"
                    ;
            }
            enemygfx += "dw $FFFF\n";
            return enemygfx;
        }

        public static string ASMLV(roomdata r, int levelbuffer)
        {
            string leveldata =
                "..default\n" +
                levels2asm(r.States[r.StateCount], levelbuffer) +
                ""
                ;

            if (r.StateCount != 0)
            {
                for (int i = 0; i < r.StateCount; i++)
                {
                    //if state data is unique:
                    if ("state" + i == r.States[i].pmLevelData)
                    {
                        leveldata +=
                            ".." + "state" + i + "\n" +
                            levels2asm(r.States[i], levelbuffer)
                            ;
                    }

                }
            }

            string asm = //.R##A# $LevelFree
                        r.Label + "\n" +
                        "{" + "\n" +
                        leveldata +
                        "}" + "\n";
            return asm;
        }

        public static string levels2asm(state s, int levelbuffer)
        //creates labels for each state, dbs all the compressed bytes in.
        {
            string leveldata = "db $";
            for (int i = 0; i < s.LevelDataSizeC; i++)
            {
                leveldata += WByte(s.LevelDataC[i]) + d;
            }
            leveldata = leveldata.Substring(0, leveldata.Length - d.Length);
            leveldata += "\n" +
            "fillbyte $FF" + "\n" +
            "fill " + levelbuffer + "\n" +
            "";
            return leveldata;
        }
    }
}
