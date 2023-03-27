
namespace SM_ASM_GUI
{
    partial class StateConfig_Reorder
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
            this.label1 = new System.Windows.Forms.Label();
            this.StateBox = new System.Windows.Forms.ListBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.DefaultStateLabel = new System.Windows.Forms.Label();
            this.StateUp = new System.Windows.Forms.Button();
            this.StateDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Use arrow buttons to move.\r\nStates will be renamed to reflect the new order \r\nwhe" +
    "n this is closed.";
            // 
            // StateBox
            // 
            this.StateBox.FormattingEnabled = true;
            this.StateBox.Location = new System.Drawing.Point(12, 55);
            this.StateBox.Name = "StateBox";
            this.StateBox.Size = new System.Drawing.Size(120, 173);
            this.StateBox.TabIndex = 1;
            this.StateBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.lst_DragDrop);
            this.StateBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.lst_DragEnter);
            this.StateBox.DragOver += new System.Windows.Forms.DragEventHandler(this.lst_DragOver);
            this.StateBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lst_MouseDown);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(153, 188);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 40);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // DefaultStateLabel
            // 
            this.DefaultStateLabel.AutoSize = true;
            this.DefaultStateLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DefaultStateLabel.Enabled = false;
            this.DefaultStateLabel.Location = new System.Drawing.Point(13, 179);
            this.DefaultStateLabel.Name = "DefaultStateLabel";
            this.DefaultStateLabel.Size = new System.Drawing.Size(41, 13);
            this.DefaultStateLabel.TabIndex = 3;
            this.DefaultStateLabel.Text = "Default";
            // 
            // StateUp
            // 
            this.StateUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.StateUp.Location = new System.Drawing.Point(153, 55);
            this.StateUp.Name = "StateUp";
            this.StateUp.Size = new System.Drawing.Size(75, 41);
            this.StateUp.TabIndex = 4;
            this.StateUp.Text = "▲";
            this.StateUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.StateUp.UseVisualStyleBackColor = true;
            this.StateUp.Click += new System.EventHandler(this.StateUp_Click);
            // 
            // StateDown
            // 
            this.StateDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.StateDown.Location = new System.Drawing.Point(153, 102);
            this.StateDown.Name = "StateDown";
            this.StateDown.Size = new System.Drawing.Size(75, 41);
            this.StateDown.TabIndex = 5;
            this.StateDown.Text = "▼";
            this.StateDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.StateDown.UseVisualStyleBackColor = true;
            this.StateDown.Click += new System.EventHandler(this.StateDown_Click);
            // 
            // StateConfig_Reorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 249);
            this.Controls.Add(this.StateDown);
            this.Controls.Add(this.StateUp);
            this.Controls.Add(this.DefaultStateLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.StateBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StateConfig_Reorder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reorder States";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox StateBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label DefaultStateLabel;
        private System.Windows.Forms.Button StateUp;
        private System.Windows.Forms.Button StateDown;
    }
}