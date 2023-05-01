  ______   __       __           ______    ______   __       __ 
 /      \ |  \     /  \         /      \  /      \ |  \     /  \
|  $$$$$$\| $$\   /  $$        |  $$$$$$\|  $$$$$$\| $$\   /  $$
| $$___\$$| $$$\ /  $$$ ______ | $$__| $$| $$___\$$| $$$\ /  $$$
 \$$    \ | $$$$\  $$$$|      \| $$    $$ \$$    \ | $$$$\  $$$$
 _\$$$$$$\| $$\$$ $$ $$ \$$$$$$| $$$$$$$$ _\$$$$$$\| $$\$$ $$ $$
|  \__| $$| $$ \$$$| $$        | $$  | $$|  \__| $$| $$ \$$$| $$
 \$$    $$| $$  \$ | $$        | $$  | $$ \$$    $$| $$  \$ | $$
  \$$$$$$  \$$      \$$         \$$   \$$  \$$$$$$  \$$      \$$
*********************************************************************
README V.1.0.0
****************
INTRO
****************
SM-ASM is an open-source data management tool for use alongside SMILE RF with the ASAR assembler.
The assembler is IMPORTANT, because this works by exporting the room data to labelled ASM code.
Use it as designed, or part it out into your own editor! You decide.

The general work flow with SMASM is to make level edits in SMILE, then any time you save a room there,
you also save it to ASM with SMASM and apply the file to repoint everything.

As of release 1.0.0, it supports repointing of:
    -Level Headers
    -Level Data
    -Room States
    -Scroll Data
    -Enemy Populations
    -Enemies Allowed List (enemy gfx loaded in room)
    -PLM populations
    -Scroll PLM data
    -Room FX
    -Door Lists & Data
    -Tilesets

It has basic deduping of state data to save space and allows addition of new elements with just a few clicks.

In addition to data repointing, it offers the following misc. features:
    -Map generation at 1px : 1 tile    
    -Individual room export to ASM
    -Merge Room Files into single ASM.
    

****************
WHAT'S IN THE BOX?
****************
The release ZIP file contains everything you need to get started:
    SM-ASM.exe
    plmlist.txt
    enemylist.txt
    s0.png
    s1.png
    s2.png
    0.png
    1.png
    2.png

SM-ASM.exe
    This is how you start it! Coded as a Windows Form on the C# .Net framework. Crossplat support is not likely to happen.


plmlist.txt
    Tagged list of all the PLMs in SMILE's default PLM list. These tags can be searched in SMASM for easy plm addition!
    Eg. typing "energy" in the searchbox will give you the normal tank, Chozo, and hidden variants to pick from.
    If you repoint any PLMs, this list needs kept up to date if you want them to draw on the automap.

    All searches look for an exact, non-case-sensitive match in the tag list.
    Here is the exact format:
        ####,T,T,T,T,...,MapProperties:shape:color

    Where #### is the PLM ID in hex, the T's are N number of tags, and the FINAL entry in the list should be a MapProperties tag.
    The MapProperties tag is used for handing the PLM's interaction with the automapping functions. 
    It is a ":" delimited list of strings that do hardcoded things in the mapping routines.
    The color part of it can be changed to any color on Microsoft's .Net color list and the change will be reflected on the maps:
        https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.colors?view=windowsdesktop-8.0


enemylist.txt
    Tagged list of all the enemies in SMILE's default enemy list. Searches work just like the PLM list; exact matches that disregard case.
    This one doesn't have any other purpose but searching, so it doesn't need updated if you don't care to search your repointed/custom enemies.
        ####,T,T,T,T,...
    Where #### is the Enemy ID in hex and the T's are N number of tags.


And the PNGs at the bottom of the ZIP are used to customize the scroll editor graphics if desired. 
SMASM will crash if any of these files are deleted or renamed, so don't do that.

****************
FIRST-TIME SETUP
****************
Starting with a clean ROM:

0. Make sure you have backups of everything first!
1. Put it in a folder by itself & name it whatever your hack is called
2. Go to your installation of SMILE and make a Custom Folder for the hack.
    >Path is ./SMILE RF/Files/Custom/[yourHack]
3. Put a copy of the vanilla MDB in [yourHack]/Data/mdb.txt
4. Open SMASM and pick file paths as prompted.
    >ROM
    >ASM - Leaving the ASM path blank will create a new .asm in the same folder as the ROM. Recommended for first time.
    >SMILE FILES FOLDER - used to start doing stuff with the custom folder made in step 2.
    >ASAR - Recommended to have the assembler in the same folder as SMASM.exe
    (There is also a tile table box here but we don't need to worry about that on a vanilla ROM; populates default value.)
    (If you've repointed the list of tilesets in $8F, you'll need to update this pointer to its address)

5. If you're interested in tileset repointing, click Tilesets > ROM to Tileset Folders
    This process may take a minute or two as it rips all the tilesets to .gfx, .pal, and .ttb files.
    YYCHR is my recommendation for graphics editor to use with it.

5.5 (if tileset repointing) click Tilesets > Tileset Folders to ASM
    This process may also take a minute or two for every tileset in the game.

6. You're ready to edit rooms!


****************
USING SMASM
****************
You'll know a room is loaded properly when you see a little map of it in the lower left corner.
ALSO: see the in-editor tutorial in About > Walkthough to explain the UI.

Copying Rooms:
    SMASM can't make rooms on its own; it can only export existing ones. Every room in the MDB must have a unique room and area index in this system.
    >Load Room from MDB Dropdown
    >Change the room and area index to an unused combination if copying a room that's already in the ASM file.
    >Export to ASM

Once you've copied all the vanilla rooms you'd like to start out with:
    >Apply ASM
    >Reload the hack in SMILE to update the MDB over there.

This will repoint everything and *clear the MDB list* down to the rooms that are in the ASM file.
From here, you can continue copying and modifying rooms to create your hack.

Modifying Rooms:
    Use SMILE for editing level data, level header and tile table, among all the stuff that SMASM doesn't do.
    Use SMASM for adding enemies, PLMs, FX, doors, room states, scroll data

    Always remember to save in SMILE before you save in SMASM

    After making changes in SMILE:
    (should be done before you leave the room in SMILE)
    >Refresh room from ROM
    >Export to ASM

    Adding an enemy to a room:
    >Load Room from MDB Dropdown if not already loaded
    >Right-Click Enemies List, Add Enemy
    >Export to ASM
    >Apply to ROM

    Adding a Scroll PLM:
    >Load Room from MDB Dropdown if not already loaded
    >Right-Click PLM List, Add Scroll PLM
    >Right-Click PLM List, select Scroll PLM Editor
    >Window works like SMILE's.
    >Export to ASM
    >Apply to ROM

    Other room contents (doors, FX, etc.) work the same way.
    
    
    To keep door links made in SMILE:
    >Link the doors
    >Export both rooms to ASM
    >Apply to ROM
    
          

Room States:
    Load room and right-click the state selector.
    >Remove state can be done instantly
    >Add State opens a window where states can be rearranged and change what other states it shares pointers with.
    >More details in the help page of the States dialog window (? Button)
    

Modifying Tilesets:
    This section assumes you did the tiletable setup at the beginning to generate the Tilesets Folder
    Tilesets Folder contains .gfx, .pal, and .ttb for every tileset in the game.
NOTE: SMASM is not compatible with Mode 7 tilesets. It will break any given to it because it cuts them down to a $5000 bytes maximum size, and all the Mode 7 ones are larger than that.
    Adding or removing folders and then using "Tilesets > Tileset Folders to ASM" will add or remove those tilesets from the game.
    The Tile Table is the only thing that should ever be changed in SMILE, becuase palette or gfx changes could cause overwrites and corrupt data within the same tileset.

    Adding a Tileset:
    >If your total tileset count is higher than vanilla's, repoint the $8F tilesets table by opening the SMASM "Config > File Paths" and changing the number for the tileset table.
    >Make a new folder following the naming convention of the existing ones: tileset index in decimal, a "-", and the tileset index in hex.
    >Place your gfx, pal, ttb files in the folder
    >Click "Tilesets > Tileset Folders to ASM".
    >Apply to ROM

    Removing a Tileset:
    >Delete the tileset folder
    >Rename all the other ones so there are no gaps in the indices
    >Click "Tilesets > Tileset Folders to ASM".
    >Apply to ROM
    (Note that this would mess up the tileset indices associated with any existing rooms, so not recommended.)

    Modifying GFX or Palette:
    >Open the contents of the desired tileset folder with your favorite SNES graphics editor
    >Save and Click "Tilesets > Tileset Folders to ASM".
    >Apply to ROM
    For faster operation, you can also load a room that uses the tileset and click "Current Tileset Folder to ASM"


    Modifying Tile Table:
    >This still has to be done in SMILE.
    >Make any changes there, save ROM.
    >In SMASM, load a room that uses that tileset and click "ROM to Tset Folder".
    >Click "Current Tileset Folder to ASM"
    >Apply to ROM
    (This has to be done a single tileset at a time because expanding the tile table will overwrite the beginning of the next tileset in ROM, which is fixed and repointed next time the ASM is applied.)



****************
Patch Notes
****************
v.1.0.0
+initial release
