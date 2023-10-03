using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SM_ASM_GUI
{
    public partial class StateConfig : Form
    {
        //saves the pm pointers when focus leaves the groupbox containing the pm boxes.
        //state type is saved immediately on selecting it in the dropdown.
        //state argument is saved when the entry box is left.



        roomdata thisroom;
        roomdata origroom;
        public roomdata ModdedRoom { get; set; }

        public StateConfig(roomdata troom, int statenumber)
        {
            //sets up the state selection combobox, which handles the rest of the population.
            //Assigns thisroom to a local variable so that it can be edited outside this setup function.
            InitializeComponent();
            InitializeStateConfigurator(troom, statenumber);
            origroom = troom;
        }

        private void InitializeStateConfigurator(roomdata troom, int statenumber)
        {
            //these variables are not laid out well >_<;
            //ModdedRoom is simply used as a return property. It is written to here to handle if the user X's out of the state editor. The only other time is when save is clicked.
            //thisroom is used for everything else this editor writes to, before being assigned to ModdedRoom when Save is clicked.
            thisroom = troom;
            ModdedRoom = thisroom;

            StateSelect.Items.Clear();
            if(thisroom.States[thisroom.StateCount].Type != (uint)StateType.Default)
            {
                MessageBox.Show("Default state has been detected using a non-default state type. This will be corrected to E5E6.", "Invalid Default State", MessageBoxButtons.OK);
                state A = thisroom.States[thisroom.StateCount];
                A.Type = (uint)StateType.Default;
                thisroom.States[thisroom.StateCount] = A;
            }
            if (thisroom.StateCount != 0)
            {
                for (int i = 0; i < thisroom.StateCount; i++)
                {
                    StateSelect.Items.Add("State " + i);
                }
            }
            StateSelect.Items.Add("Default");
            StateSelect.SelectedIndex = statenumber;

            //Make the ShareBoxes match the entries in statebox.
            //this is just for initialization & gets updated to correct values later on.
            foreach (ComboBox sharebox in GroupSharing.Controls)
            {
                sharebox.Items.Clear();
                foreach (var state in StateSelect.Items)
                {
                    sharebox.Items.Add(state);
                }
            }

            //i starts at 1 to disallow picking "Default" for non-default states.
            var StateNames = (StateType[])Enum.GetValues(typeof(StateType));
            BoxStateType.Items.Clear();
            for (int i = 1; i < StateNames.Length; i++)
            {
                BoxStateType.Items.Add(StateNames[i]);
            }
            PopulateStateConfig(thisroom, statenumber);
        }


        private void PopulateStateConfig(roomdata thisroom, int statenumber)
        {
            //use the PM values in each state to select an item from its list.
            //Also read the things that will need manual assignment.
            //the PMs in each state are strings of the state name that the pointer belongs to.
            state currentstate = thisroom.States[statenumber];
            StateType type = (StateType)currentstate.Type;

            bool isDefaultState;

            if (statenumber == thisroom.StateCount) 
            { 
                isDefaultState = true;
                BoxStateType.Enabled = false;
                BoxStateType.Text = "Default";
            }
            else
            {
                isDefaultState = false;
                BoxStateType.Enabled = true;
                BoxStateType.SelectedItem = type.ToString();
                BoxStateType.Text = type.ToString();
            }
            StateArgChanges(type, currentstate.StateArg);
            //if the PM string ends in a number, then it's a state number
            //else, it's default.
            //also if we're looking at the default state, disable the box.
            ComboMatchChar(LevelShare,    currentstate.pmLevelData,isDefaultState);
            ComboMatchChar(FXshare,       currentstate.pmFX,       isDefaultState);
            ComboMatchChar(ScrollsShare,  currentstate.pmScrolls,  isDefaultState);
            ComboMatchChar(PLMshare,     currentstate.pmPLMset,   isDefaultState);
            ComboMatchChar(EnemySetShare, currentstate.pmEnemySet, isDefaultState);
            ComboMatchChar(GFXshare, currentstate.pmEnemyGFX, isDefaultState);

            BoxBackground.Text = asmFCN.WWord(currentstate.pBackground);
            BoxMainASM.Text = asmFCN.WWord(currentstate.pMainASM);
            BoxSetupASM.Text = asmFCN.WWord(currentstate.pSetupASM);
            BoxUnused.Text = asmFCN.WWord(currentstate.pUnused);

            BoxTileset.Text = asmFCN.WByte(currentstate.TileSet);
            BoxSongSet.Text = asmFCN.WByte(currentstate.SongSet);
            BoxPlayIndex.Text = asmFCN.WByte(currentstate.PlayInd);
            BoxBGX.Text = asmFCN.WByte(currentstate.BGxScroll);
            BoxBGY.Text = asmFCN.WByte(currentstate.BGyScroll);


        }
        private void StateArgChanges(StateType type, uint arg)
        {
            //enable or disable, change max length of state arg box.
            int maxlen;
            bool argExists;
            switch (type)
            {
                case StateType.Default:
                    argExists = false;
                    maxlen = 0;
                    break;
                case StateType.Door:
                    argExists = true;
                    maxlen = 4;
                    break;
                case StateType.BossMain:
                    argExists = false;
                    maxlen = 0;
                    break;
                case StateType.Event:
                    argExists = true;
                    maxlen = 2;
                    break;
                case StateType.BossChoose:
                    argExists = true;
                    maxlen = 2;
                    break;
                case StateType.GotMorph:
                    argExists = false;
                    maxlen = 0;
                    break;
                case StateType.GotMorphMissiles:
                    argExists = false;
                    maxlen = 0;
                    break;
                case StateType.GotPowerbomb:
                    argExists = false;
                    maxlen = 0;
                    break;
                case StateType.GotSpeed:
                    argExists = false;
                    maxlen = 0;
                    break;
                default:
                    argExists = false;
                    maxlen = 0;
                    break;
            }
            BoxStateArg.MaxLength = maxlen;
            BoxStateArg.Enabled = argExists;
            BoxStateArg.Clear();
            //fill in the argument. If it's not a byte or word size, it will default to not filling in.
            switch (maxlen)
            {
                case 2:
                    BoxStateArg.Text = asmFCN.WByte(arg);
                    break;  
                case 4:
                    BoxStateArg.Text = asmFCN.WWord(arg);
                    break;
                default:
                    break;
            }

        }
        private void ComboMatchChar(ComboBox A, string matchLast, bool isDefaultState)
        {
            try
            {
                if (isDefaultState)
                {
                    A.Enabled = false;
                    A.SelectedItem = "Default";
                    return;
                }
                A.Enabled = true;
                //if no match found, default to last entry.
                if (A.Items.Count == 0) { return; }
                bool matchfound = false;
                string lastchar = matchLast.Substring(matchLast.Length - 1);
                foreach (string item in A.Items)
                {
                    if (item.Substring(item.Length - 1) == lastchar)
                    {
                        A.SelectedItem = item;
                        matchfound = true;
                        break;
                    }
                }
                if (!matchfound)
                { A.SelectedIndex = A.Items.Count - 1; }
                return;
            }
            catch
            {
                A.SelectedIndex = A.Items.Count - 1;
            }

        }

        private void StateConfig_Load(object sender, EventArgs e)
        {

        }

        private void StateSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateStateConfig(thisroom, StateSelect.SelectedIndex);
        }

        private void SharePointer(object sender, EventArgs e)
        {
            //did it like this to avoid having 6 unique functions.
            //the PMs of the state are stored in the combobox tags until the save function is called.
            ComboBox A = (ComboBox)sender;
            string oldTag = "";
            if (A.Tag != null) { oldTag = A.Tag.ToString(); }
            A.Tag = "state" + A.SelectedIndex;
            if (A.Tag == null) { return; }
            if (!GroupSharing.ContainsFocus) { return; }
            //if the state being pointed to also points to this state for its PM, disallow the change and show a message.
            //vvv default state will never point back at this in a meaningful way vvv
            if (!int.TryParse(A.SelectedItem.ToString().Substring(A.SelectedItem.ToString().Length-1), out int barse)) { return; }
            state destination = thisroom.States[barse];
            int destIndex = barse;
            int currIndex = StateSelect.SelectedIndex;

            //if the destination points HERE and the destination is not this state pointing to itself:
            if (
                (
                (LastChar(destination.pmLevelData) == StateSelect.SelectedIndex.ToString())
                ||
                (LastChar(destination.pmFX) == StateSelect.SelectedIndex.ToString())
                ||
                (LastChar(destination.pmScrolls) == StateSelect.SelectedIndex.ToString())
                ||
                (LastChar(destination.pmPLMset) == StateSelect.SelectedIndex.ToString())
                ||
                (LastChar(destination.pmEnemySet) == StateSelect.SelectedIndex.ToString())
                ||
                (LastChar(destination.pmEnemyGFX) == StateSelect.SelectedIndex.ToString())
                )
                &&
                (barse != StateSelect.SelectedIndex)
                )
            {
                MessageBox.Show
                    (
                    "The specified state already points to this one. These can't overlap!",
                    "Pointer Error",
                    MessageBoxButtons.OK
                    );
                A.Tag = oldTag;

                if (int.TryParse(oldTag.Substring(oldTag.Length-1), out barse))
                {
                    A.SelectedIndex = barse;
                }
                else
                {
                    A.SelectedIndex = thisroom.StateCount;
                }
                return;
            }
            //if it points to another state, the destination must have a unique pointer.
            //the last char of the pm pointer in the destination must be == the destination index.
            //ignore if the destination is default state.
            //Also, we only want to test the box that we're using.

            //it had a bug where changing state dropdown will trigger this using the stuff from the other state...
            //made it run only when the groupbox is the active control!

            bool thi = false;
                 if ((FirstChar(A.Name) == "L") && (LastChar(destination.pmLevelData) != destIndex.ToString())) { thi = true; }
            else if ((FirstChar(A.Name) == "F") && (LastChar(destination.pmFX) != destIndex.ToString())       ) { thi = true; }
            else if ((FirstChar(A.Name) == "S") && (LastChar(destination.pmScrolls) != destIndex.ToString())  ) { thi = true; }
            else if ((FirstChar(A.Name) == "P") && (LastChar(destination.pmPLMset) != destIndex.ToString())   ) { thi = true; }
            else if ((FirstChar(A.Name) == "E") && (LastChar(destination.pmEnemySet) != destIndex.ToString()) ) { thi = true; }
            else if ((FirstChar(A.Name) == "G") && (LastChar(destination.pmEnemyGFX) != destIndex.ToString()) ) { thi = true; }

            if
                (
                (destIndex != StateSelect.Items.Count-1)
                &&
                (destIndex != currIndex)
                &&
                thi
                )
            {
                MessageBox.Show
                    (
                    "The specified state does not have a unique pointer. ",
                    "Pointer Error",
                    MessageBoxButtons.OK
                    );
                A.Tag = oldTag;

                if (int.TryParse(oldTag.Substring(oldTag.Length - 1), out barse))
                {
                    A.SelectedIndex = barse;
                }
                else
                {
                    A.SelectedIndex = thisroom.StateCount;
                }
                return;
            }

            if (destIndex < currIndex)
            {
                MessageBox.Show
                    (
                    "The specified unique pointer should point to this one instead if you want the data to be the same.",
                    "Pointer Error",
                    MessageBoxButtons.OK
                    );
                A.Tag = oldTag;

                if (int.TryParse(oldTag.Substring(oldTag.Length - 1), out barse))
                {
                    A.SelectedIndex = barse;
                }
                else
                {
                    A.SelectedIndex = thisroom.StateCount;
                }
                return;
            }

        }
        public static string LastChar(string str)
        {
            return str.Substring(str.Length - 1);
        }
        public static string FirstChar(string str)
        {
            return str.Substring(0, 1);
        }
        private void SavePMs2room()
        {
            //Commit combo box tags to state PMs.
            state A = thisroom.States[StateSelect.SelectedIndex];

            A.pmLevelData = LevelShare.Tag.ToString();
            A.pmFX = FXshare.Tag.ToString();
            A.pmScrolls = ScrollsShare.Tag.ToString();
            A.pmPLMset = PLMshare.Tag.ToString();
            A.pmEnemySet = EnemySetShare.Tag.ToString();
            A.pmEnemyGFX = GFXshare.Tag.ToString();

            thisroom.States[StateSelect.SelectedIndex] = A;
        }

        private void GroupSharing_Leave(object sender, EventArgs e)
        {
            SavePMs2room();
        }

        private void BoxStateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            state A = thisroom.States[StateSelect.SelectedIndex];
            StateType B = (StateType)Enum.Parse(typeof(StateType), BoxStateType.SelectedItem.ToString());
            A.Type = (uint)B;
            thisroom.States[StateSelect.SelectedIndex] = A;
            StateArgChanges(B, A.StateArg);
            //even if it's unneeded, the state arg can stay in the object because it simply won't get printed.
        }

        private void BoxStateArg_Validated(object sender, EventArgs e)
        {
            state A = thisroom.States[StateSelect.SelectedIndex];
            A.StateArg = uint.Parse(BoxStateArg.Text,System.Globalization.NumberStyles.HexNumber);
            thisroom.States[StateSelect.SelectedIndex] = A;
        }

        private void Hexnumber_Validating(object sender, CancelEventArgs e)
        {
            TextBox A = (TextBox)sender;
            if(uint.TryParse(A.Text,System.Globalization.NumberStyles.HexNumber,null,out uint barse))
            {
                return;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void GroupManuals_Leave(object sender, EventArgs e)
        {
            //the numbers will always be validated before it gets here
            state A = thisroom.States[StateSelect.SelectedIndex];
            A.pBackground = uint.Parse(BoxBackground.Text, System.Globalization.NumberStyles.HexNumber);
            A.pMainASM = uint.Parse(BoxMainASM.Text, System.Globalization.NumberStyles.HexNumber);
            A.pSetupASM = uint.Parse(BoxSetupASM.Text, System.Globalization.NumberStyles.HexNumber);
            A.pUnused = uint.Parse(BoxUnused.Text, System.Globalization.NumberStyles.HexNumber);
            A.TileSet = uint.Parse(BoxTileset.Text, System.Globalization.NumberStyles.HexNumber);
            A.SongSet = uint.Parse(BoxSongSet.Text, System.Globalization.NumberStyles.HexNumber);
            A.PlayInd = uint.Parse(BoxPlayIndex.Text, System.Globalization.NumberStyles.HexNumber);
            A.BGxScroll = uint.Parse(BoxBGX.Text, System.Globalization.NumberStyles.HexNumber);
            A.BGyScroll = uint.Parse(BoxBGY.Text, System.Globalization.NumberStyles.HexNumber);
            thisroom.States[StateSelect.SelectedIndex] = A;
        }

        private void ButtonAddState_Click(object sender, EventArgs e)
        {
            AddStateDialog A = new AddStateDialog();
            A.ShowDialog();
            if (!A.CreateNewState) { return; }
            //New states will copy the data from Default & change its PM pointers.
            //They will be placed at the top of the list.
            //Uniques bool array is:
            //[L, F, S, P, E, G]
            state newstate = thisroom.States[thisroom.StateCount];
            //so, because state is a stuct and all the lists inside it are classes, each list needs to be explicitly copied to new list instances in the new state struct.
            //newstate.PLMs = new List<PLMdata>(newstate.PLMs);
            //newstate.Enemies = new List<EnemyData>(newstate.Enemies);
            //newstate.EnemiesAllowed = new List<EnemyGFX>(newstate.EnemiesAllowed);
            //newstate.FX = new List<FXdata>(newstate.FX);
            //List<uint> copy = newstate.Scrolls.ToList();
            //newstate.Scrolls = copy.ToArray();
            if (A.Uniques[0]) { newstate.pmLevelData = "state" + thisroom.StateCount; }
            if (A.Uniques[1]) { newstate.pmFX = "state" + thisroom.StateCount; }
            if (A.Uniques[2]) { newstate.pmScrolls = "state" + thisroom.StateCount; }
            if (A.Uniques[3]) { newstate.pmPLMset = "state" + thisroom.StateCount; }
            if (A.Uniques[4]) { newstate.pmEnemySet = "state" + thisroom.StateCount; }
            if (A.Uniques[5]) { newstate.pmEnemyGFX = "state" + thisroom.StateCount; }

            newstate.Type = (uint)StateType.Event;
            thisroom.States.Insert(thisroom.States.Count-1, newstate);
            thisroom.StateCount++;

            InitializeStateConfigurator(thisroom,thisroom.StateCount);
            //the PM pointers themselves will be managed like this? The Uniques array should change the uint pointers.
            //this should be recalculated for ALL states because this new state 0 will replace the existing state 0.
            //thisroom.DupChek();
            //would not be necessary if we inserted this just below Default State, so that it's a new number...
            //We'll do that!
            //The new state will be inserted at the current Statecount-1.

        }

        private void ButtonKillState_Click(object sender, EventArgs e)
        {
            //this will replace the other state destructor.
            if(thisroom.StateCount == 0)
            {
                MessageBox.Show("Cannot delete the only state.", "State Error", MessageBoxButtons.OK);
                return;
            }

            if (thisroom.States[StateSelect.SelectedIndex].Type == (uint)StateType.Default)
            {
                DialogResult delState = MessageBox.Show("Deleting default state. State " + (thisroom.StateCount - 1) + " will be casted as new default state.", "Delete Default State", MessageBoxButtons.YesNo);
                if (delState == DialogResult.No) { return; }
            }

            //we also need to remove any references to the deleted state from the PM pointers.
            string delstate = "state" + StateSelect.SelectedIndex;
            state T;
            for (int i = 0; i < thisroom.StateCount - 1; i++)
            {
                T = thisroom.States[i];
                if (T.pmLevelData == delstate) { T.pmLevelData = "default"; }
                if (T.pmFX == delstate) { T.pmFX = "default"; }
                if (T.pmEnemySet == delstate) { T.pmEnemySet = "default"; }
                if (T.pmEnemyGFX == delstate) { T.pmEnemyGFX = "default"; }
                if (T.pmScrolls == delstate) { T.pmScrolls = "default"; }
                if (T.pmPLMset == delstate) { T.pmPLMset = "default"; }
            }

            thisroom.States.RemoveAt((int)StateSelect.SelectedIndex);
            thisroom.StateCount--;

            //finally, cast the final state in the list to be default.
            T = thisroom.States[thisroom.StateCount];
            T.Type = (uint)StateType.Default;
            T.pmLevelData = "default";
            T.pmFX = "default";
            T.pmEnemySet = "default";
            T.pmEnemyGFX = "default";
            T.pmScrolls = "default";
            T.pmPLMset = "default";
            thisroom.States[thisroom.StateCount] = T;

            InitializeStateConfigurator(thisroom, thisroom.StateCount);
        }

        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            StateConfig_Help A = new StateConfig_Help();
            A.ShowDialog();
        }

        private void StateConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                MessageBox.Show("Changes will be discarded.", "User Exit", MessageBoxButtons.OK);
                ModdedRoom = origroom;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StateConfig_Reorder A = new StateConfig_Reorder(thisroom);
            A.ShowDialog();
            thisroom = A.RtnRoom;
            InitializeStateConfigurator(thisroom, thisroom.StateCount);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ModdedRoom = thisroom;
            this.Hide();
        }
    }
}
