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
    public partial class StateConfig_Reorder : Form
    {
        public roomdata RtnRoom;
        private int prev_index;
        public StateConfig_Reorder(roomdata thisroom)
        {
            InitializeComponent();
            RtnRoom = thisroom;
            InitStateBox(thisroom);
        }

        private void InitStateBox(roomdata thisroom)
        {
            StateBox.Items.Clear();
            for (int i = 0; i < thisroom.StateCount; i++)
            {
                StateBox.Items.Add("State" + i);
            }
            Point A = DefaultStateLabel.Location;
            A.Y = StateBox.Location.Y + (StateBox.Font.Height * StateBox.Items.Count) + 2;
            DefaultStateLabel.Location = A;

        }

        private void lst_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox lst = sender as ListBox;

            // Only use the right mouse button.
            //if (e.Button != MouseButtons.Middle) return;
            int index = lst.IndexFromPoint(e.Location);
            //lst.SelectionMode = SelectionMode.One;
            // Find the item under the mouse.


            //index = IndexFromScreenPoint(lst, new Point(e.X, e.Y));
            
            lst.SelectedIndex = index;
            if (index < 0) return;
            // Drag the item.
            DragItem drag_item = new DragItem(lst, index, lst.Items[index]);
            lst.DoDragDrop(drag_item, DragDropEffects.Move);
        }
        private void lst_DragEnter(object sender, DragEventArgs e)
        {
            ListBox lst = sender as ListBox;
            prev_index = lst.SelectedIndex;
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
        private void lst_DragOver(object sender, DragEventArgs e)
        {
            // Do nothing if the drag is not allowed.
            if (e.Effect != DragDropEffects.Move) return;

            ListBox lst = sender as ListBox;

            // Select the item at this screen location.
            lst.SelectedIndex =
                IndexFromScreenPoint(lst, new Point(e.X, e.Y));
        }
        public static int IndexFromScreenPoint(ListBox lst, Point point)
        {
            // Convert the location to the ListBox's coordinates.
            point = lst.PointToClient(point);

            // Return the index of the item at that position.
            return lst.IndexFromPoint(point);
        }

        private void lst_DragDrop(object sender, DragEventArgs e)
        {
            ListBox lst = sender as ListBox;

            // Get the ListBox item data.
            DragItem drag_item = (DragItem)e.Data.GetData(typeof(DragItem));

            // Get the index of the item at this position.
            //int prev_index = ;
            int new_index =
                IndexFromScreenPoint(lst, new Point(e.X, e.Y));

            // If the item was dropped after all
            // of the items, move it to the end.
            if (new_index == -1) new_index = lst.Items.Count - 1;

            string swapper = lst.Items[new_index].ToString();

            // Remove the item from its original position.
            lst.Items.RemoveAt(prev_index);
            lst.Items.Insert(prev_index, swapper);

            lst.Items.RemoveAt(new_index);
            // Insert the item in its new position.
            lst.Items.Insert(new_index, drag_item.Item);

            //if prev_index < new_index then it was moved DOWN in the list; the swap index moved up one.
            //else, the swap index moved down one.
            //if (prev_index < new_index) { prev_index++; }
            //else { prev_index--; }

            //since each shuffle will affect the PM pointers in all the other states, it makes the most sense
            //to modify the room on closing this window.
            // Select the item.
            lst.SelectedIndex = new_index;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            //RtnRoom = FixStates(RtnRoom);
            this.Close();
        }

        private roomdata FixStates(roomdata thisroom)
        {
            //CURRENTLY fucks up when you make multiple moves because it assumes the starting order
            //compare the state box with the order in the object
            //0         1       A
            //1         0       B
            //2         2       C
            //default
            //---------------
            //replace all the 2's with 2's
            //1's with 0's
            //0's with 1's
            //won't work because we lose the original 0's.
            //--------------
            //Instead, in a copy
            //2's with C's
            //1's with B's
            //0's with A's
            //then,
            //C's with 2's
            //B's with 0's
            //A's with 1's
            //This intermediate step keeps all data sets unique for the duration of the replacement.
            //chr() to generate the letters
            roomdata numbers = thisroom;
            roomdata letters = thisroom;
            roomdata reorder = thisroom;

            const int ASCII_A = 65;

            //for(int i = 0; i < numbers.StateCount; i++)
            //{
            //    state T = numbers.States[i];
            //    T.pmLevelData = StateConfig.LastChar(T.pmLevelData);
            //    T.pmFX =        StateConfig.LastChar(T.pmFX);
            //    T.pmEnemySet =  StateConfig.LastChar(T.pmEnemySet);
            //    T.pmEnemyGFX =  StateConfig.LastChar(T.pmEnemyGFX);
            //    T.pmScrolls =   StateConfig.LastChar(T.pmScrolls);
            //    T.pmPLMset =    StateConfig.LastChar(T.pmPLMset);
            //}
            //Numbers is set up with only the numbers or "t" as the pm tag.
            //So now, since we know that the original order was 0123...D
            //the states can be rearranged with that in mind.
            List<int> origPos = new List<int>();
            List<int> newPos = new List<int>();
            for(int i = 0; i < StateBox.Items.Count; i++)
            {
                if (!int.TryParse(StateConfig.LastChar(StateBox.Items[i].ToString()), out int barse))
                {
                    //Default state goes in here
                    //or actually, it should never go in here because "Default" is not actually in the state list.
                    Console.WriteLine("State Rearrange error1: Default State detected in Listbox.");
                    break;
                }
                origPos.Add(barse);
            }
            for (int i = 0; i < StateBox.Items.Count; i++)
            {
                if (!int.TryParse(StateConfig.LastChar(StateBox.Items[i].ToString()),out int destination))
                {
                    //Default state goes in here
                    //or actually, it should never go in here because "Default" is not actually in the state list.
                    Console.WriteLine("State Rearrange error2: Default State detected in Listbox.");
                    break;
                }
                state T = thisroom.States[i];
                state B = thisroom.States[destination];
                numbers.States.Insert(destination+1, T);
                numbers.States.RemoveAt(i);
                numbers.States.Insert(i, B);
                numbers.States.RemoveAt(destination);
                //origPos.Add(i);
                newPos.Add(destination);
            }
            //ok! the only thing left to do is rename the PM Pointers in Numbers.
            //NOW the letters version comes into play.
            letters = numbers;
            for (int i = 0; i < letters.StateCount; i++)
            {
                state T = letters.States[i];
                T.pmLevelData = StateConfig.LastChar(T.pmLevelData);
                T.pmFX = StateConfig.LastChar(T.pmFX);
                T.pmEnemySet = StateConfig.LastChar(T.pmEnemySet);
                T.pmEnemyGFX = StateConfig.LastChar(T.pmEnemyGFX);
                T.pmScrolls = StateConfig.LastChar(T.pmScrolls);
                T.pmPLMset = StateConfig.LastChar(T.pmPLMset);

                if (int.TryParse(T.pmLevelData, out int barse)) 
                { T.pmLevelData = Char.ConvertFromUtf32(ASCII_A + barse); }
                else { T.pmLevelData = "@"; }

                if (int.TryParse(T.pmFX, out barse)) 
                { T.pmFX = Char.ConvertFromUtf32(ASCII_A + barse); }
                else { T.pmFX = "@"; }

                if (int.TryParse(T.pmEnemySet, out barse)) 
                { T.pmEnemySet = Char.ConvertFromUtf32(ASCII_A + barse); }
                else { T.pmEnemySet = "@"; }

                if (int.TryParse(T.pmEnemyGFX, out barse)) 
                { T.pmEnemyGFX = Char.ConvertFromUtf32(ASCII_A + barse); }
                else { T.pmEnemyGFX = "@"; }

                if (int.TryParse(T.pmScrolls, out barse)) 
                { T.pmScrolls = Char.ConvertFromUtf32(ASCII_A + barse); }
                else { T.pmScrolls = "@"; }

                if (int.TryParse(T.pmPLMset, out barse)) 
                { T.pmPLMset = Char.ConvertFromUtf32(ASCII_A + barse); }
                else { T.pmPLMset = "@"; }

                letters.States[i] = T;
                //PM pointer = "@" point to default state.
                //             ABC... for non default
                //             allows this to work with up to 126-65 states? a whole lot but not up to 255.
            }
            //Letters is now the rearranged version with letters instead of numbers in the PM Pointers.
            //Loop thru each state and change its pms back to the number representation.
            for (int i = 0; i < letters.StateCount; i++)
            {
                state T = letters.States[i];
                //for each state, try every combination of ABCD on the pointers before moving onto the next one.
                for(int j = 0; j < letters.StateCount; j++)
                {
                    if (T.pmLevelData == "@") { T.pmLevelData = "default"; }
                    if (T.pmLevelData == Char.ConvertFromUtf32(ASCII_A + j))
                    { T.pmLevelData = "state" + newPos[j]; }

                    if (T.pmFX == "@") { T.pmFX = "default"; }
                    if( T.pmFX == Char.ConvertFromUtf32(ASCII_A + j))
                    { T.pmFX = "state" + newPos[j]; }

                    if (T.pmEnemySet == "@") { T.pmEnemySet = "default"; }
                    if (T.pmEnemySet == Char.ConvertFromUtf32(ASCII_A + j))
                    { T.pmEnemySet = "state" + newPos[j]; }

                    if (T.pmEnemyGFX == "@") { T.pmEnemyGFX = "default"; }
                    if (T.pmEnemyGFX == Char.ConvertFromUtf32(ASCII_A + j))
                    { T.pmEnemyGFX = "state" + newPos[j]; }

                    if (T.pmScrolls == "@") { T.pmScrolls = "default"; }
                    if (T.pmScrolls == Char.ConvertFromUtf32(ASCII_A + j))
                    { T.pmScrolls = "state" + newPos[j]; }

                    if (T.pmPLMset == "@") { T.pmPLMset = "default"; }
                    if (T.pmPLMset == Char.ConvertFromUtf32(ASCII_A + j))
                    { T.pmPLMset = "state" + newPos[j]; }
                }
                letters.States[i] = T;
                //PM pointer = "@" point to default state.
                //             ABC... for non default
                //             allows this to work with up to 126-65 states? a whole lot but not up to 255.
            }
            reorder = letters;
            return reorder;
        }

        private void StateUp_Click(object sender, EventArgs e)
        {
            RtnRoom = MoveState(-1);
        }

        private void StateDown_Click(object sender, EventArgs e)
        {
            RtnRoom = MoveState(1);
        }

        private roomdata MoveState(int offset)
        {
            if (
                ((StateBox.SelectedIndex == 0 ) && (offset < 0))
                || 
                ((StateBox.SelectedIndex == StateBox.Items.Count - 1) && (offset > 0))
                ||
                (StateBox.SelectedItem == null)
               )
            {
                return RtnRoom;
            }
            //Current problem:
            //All the nondefault PM pointers in every state get repointed to whatever one we just moved.
            roomdata letters = RtnRoom;
            const int ASCII_A = 65;
            List<int> newPos = new List<int>();
            List<int> initPos = new List<int>();

            for (int i = 0; i < StateBox.Items.Count; i++)
            {
                //newPos.Add(i);
                //default state is never in this list so it will never fail.
                if(!int.TryParse(StateConfig.LastChar(StateBox.Items[i].ToString()), out int initialpositions))
                {
                    //it should never get in here but ??? you never know.
                    initialpositions = StateBox.Items.Count - 1;
                    Console.WriteLine("State Rearragnement Error! Detected default state in Statebox.");
                }
                initPos.Add(initialpositions);
            }

            int startindex = StateBox.SelectedIndex;
            int destination = startindex + offset;




            string z = StateBox.Items[startindex].ToString();
            StateBox.Items.RemoveAt(startindex);
            StateBox.Items.Insert(destination, z);


            newPos = initPos;
            newPos.RemoveAt(startindex);
            newPos.Insert(destination, startindex);



            //this loop takes what the pointers already are, and turns them into letters.
            for (int i = 0; i < letters.StateCount; i++)
            {
                state T = letters.States[i];
                T.pmLevelData = StateConfig.LastChar(T.pmLevelData);
                T.pmFX = StateConfig.LastChar(T.pmFX);
                T.pmEnemySet = StateConfig.LastChar(T.pmEnemySet);
                T.pmEnemyGFX = StateConfig.LastChar(T.pmEnemyGFX);
                T.pmScrolls = StateConfig.LastChar(T.pmScrolls);
                T.pmPLMset = StateConfig.LastChar(T.pmPLMset);

                if (int.TryParse(T.pmLevelData, out int barse))
                { T.pmLevelData = Char.ConvertFromUtf32(ASCII_A + newPos[i]); }
                else { T.pmLevelData = "@"; }

                if (int.TryParse(T.pmFX, out barse))
                { T.pmFX = Char.ConvertFromUtf32(ASCII_A + newPos[i]); }
                else { T.pmFX = "@"; }

                if (int.TryParse(T.pmEnemySet, out barse))
                { T.pmEnemySet = Char.ConvertFromUtf32(ASCII_A + newPos[i]); }
                else { T.pmEnemySet = "@"; }

                if (int.TryParse(T.pmEnemyGFX, out barse))
                { T.pmEnemyGFX = Char.ConvertFromUtf32(ASCII_A + newPos[i]); }
                else { T.pmEnemyGFX = "@"; }

                if (int.TryParse(T.pmScrolls, out barse))
                { T.pmScrolls = Char.ConvertFromUtf32(ASCII_A + newPos[i]); }
                else { T.pmScrolls = "@"; }

                if (int.TryParse(T.pmPLMset, out barse))
                { T.pmPLMset = Char.ConvertFromUtf32(ASCII_A + newPos[i]); }
                else { T.pmPLMset = "@"; }

                letters.States[i] = T;
                //PM pointer = "@" point to default state.
                //             ABC... for non default
                //             allows this to work with up to 126-65 states? a whole lot but not up to 255.
            }
            state A = letters.States[startindex];
            letters.States.RemoveAt(startindex);
            letters.States.Insert(destination, A);
            //Letters is now the rearranged version with letters instead of numbers in the PM Pointers.
            //Loop thru each state and change its pms back to the number representation.
            for (int i = 0; i < letters.StateCount; i++)
            {
                state T = letters.States[i];
                //for each state, try every combination of ABCD on the pointers before moving onto the next one.
                for (int j = 0; j < letters.StateCount; j++)
                {
                    if (T.pmLevelData == "@") { T.pmLevelData = "default"; }
                    if (T.pmLevelData == Char.ConvertFromUtf32(ASCII_A + j))
                    { T.pmLevelData = "state" + j; }

                    if (T.pmFX == "@") { T.pmFX = "default"; }
                    if (T.pmFX == Char.ConvertFromUtf32(ASCII_A + j))
                    { T.pmFX = "state" + j; }

                    if (T.pmEnemySet == "@") { T.pmEnemySet = "default"; }
                    if (T.pmEnemySet == Char.ConvertFromUtf32(ASCII_A + j))
                    { T.pmEnemySet = "state" + j; }

                    if (T.pmEnemyGFX == "@") { T.pmEnemyGFX = "default"; }
                    if (T.pmEnemyGFX == Char.ConvertFromUtf32(ASCII_A + j))
                    { T.pmEnemyGFX = "state" + j; }

                    if (T.pmScrolls == "@") { T.pmScrolls = "default"; }
                    if (T.pmScrolls == Char.ConvertFromUtf32(ASCII_A + j))
                    { T.pmScrolls = "state" + j; }

                    if (T.pmPLMset == "@") { T.pmPLMset = "default"; }
                    if (T.pmPLMset == Char.ConvertFromUtf32(ASCII_A + j))
                    { T.pmPLMset = "state" + j; }
                }
                letters.States[i] = T;
                //PM pointer = "@" point to default state.
                //             ABC... for non default
                //             allows this to work with up to 126-65 states? a whole lot but not up to 255.
            }
            StateBox.SelectedIndex = destination;
            return letters;
        }
    }
}
