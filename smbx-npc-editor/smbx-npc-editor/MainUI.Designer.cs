namespace smbx_npc_editor
{
    partial class MainUI
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.editMenu = new System.Windows.Forms.MenuItem();
            this.showAnimationMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.selectConfigMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.npcNameLabel = new System.Windows.Forms.Label();
            this.graphicGb = new System.Windows.Forms.GroupBox();
            this.foregroundControl = new smbx_npc_editor.CheckBoxValue();
            this.frameStyleControl = new smbx_npc_editor.ComboBoxControlValue();
            this.gfxHeightControl = new smbx_npc_editor.SpinnerControlValue();
            this.gfxWidthControl = new smbx_npc_editor.SpinnerControlValue();
            this.xOffsetControl = new smbx_npc_editor.SpinnerControlValue();
            this.yOffsetControl = new smbx_npc_editor.SpinnerControlValue();
            this.framesControl = new smbx_npc_editor.SpinnerControlValue();
            this.frameSpeedControl = new smbx_npc_editor.SpinnerControlValue();
            this.graphicGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.editMenu,
            this.menuItem7});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4,
            this.menuItem9,
            this.menuItem6,
            this.menuItem2});
            this.menuItem1.Text = "&File";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItem4.Text = "&Open";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.menuItem9.Text = "&New";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "-";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.Text = "&Exit";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // editMenu
            // 
            this.editMenu.Index = 1;
            this.editMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.showAnimationMenuItem,
            this.menuItem5,
            this.selectConfigMenuItem});
            this.editMenu.Text = "&Edit";
            // 
            // showAnimationMenuItem
            // 
            this.showAnimationMenuItem.Checked = true;
            this.showAnimationMenuItem.Index = 0;
            this.showAnimationMenuItem.Text = "Show Animation Pane";
            this.showAnimationMenuItem.Click += new System.EventHandler(this.showAnimationMenuItem_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "-";
            // 
            // selectConfigMenuItem
            // 
            this.selectConfigMenuItem.Index = 2;
            this.selectConfigMenuItem.Text = "Select Configuration";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8});
            this.menuItem7.Text = "&Help";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 0;
            this.menuItem8.Text = "&About";
            // 
            // npcNameLabel
            // 
            this.npcNameLabel.AutoSize = true;
            this.npcNameLabel.Location = new System.Drawing.Point(13, 13);
            this.npcNameLabel.Name = "npcNameLabel";
            this.npcNameLabel.Size = new System.Drawing.Size(66, 13);
            this.npcNameLabel.TabIndex = 0;
            this.npcNameLabel.Text = "NPC Name: ";
            // 
            // graphicGb
            // 
            this.graphicGb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.graphicGb.Controls.Add(this.foregroundControl);
            this.graphicGb.Controls.Add(this.frameStyleControl);
            this.graphicGb.Controls.Add(this.gfxHeightControl);
            this.graphicGb.Controls.Add(this.gfxWidthControl);
            this.graphicGb.Controls.Add(this.xOffsetControl);
            this.graphicGb.Controls.Add(this.yOffsetControl);
            this.graphicGb.Controls.Add(this.framesControl);
            this.graphicGb.Controls.Add(this.frameSpeedControl);
            this.graphicGb.Location = new System.Drawing.Point(12, 45);
            this.graphicGb.Name = "graphicGb";
            this.graphicGb.Size = new System.Drawing.Size(239, 352);
            this.graphicGb.TabIndex = 2;
            this.graphicGb.TabStop = false;
            this.graphicGb.Text = "Graphics";
            // 
            // foregroundControl
            // 
            this.foregroundControl.BackColor = System.Drawing.Color.Transparent;
            this.foregroundControl.LabelText = "Foreground:";
            this.foregroundControl.Location = new System.Drawing.Point(6, 310);
            this.foregroundControl.Name = "foregroundControl";
            this.foregroundControl.Size = new System.Drawing.Size(228, 37);
            this.foregroundControl.TabIndex = 10;
            this.foregroundControl.Tag = "foreground";
            this.foregroundControl.ValueChecked = false;
            this.foregroundControl.ValueTag = "foreground";
            // 
            // frameStyleControl
            // 
            this.frameStyleControl.BackColor = System.Drawing.Color.Transparent;
            this.frameStyleControl.ComboBoxValues.AddRange(new object[] {
            "Single Sprite",
            "Left/Right Sprites",
            "Left/Right/Upside Down Sprites"});
            this.frameStyleControl.LabelText = "Framestyle:";
            this.frameStyleControl.Location = new System.Drawing.Point(5, 267);
            this.frameStyleControl.Name = "frameStyleControl";
            this.frameStyleControl.Size = new System.Drawing.Size(228, 37);
            this.frameStyleControl.TabIndex = 9;
            this.frameStyleControl.Tag = "framestyle";
            this.frameStyleControl.ValueTag = "framestyle";
            // 
            // gfxHeightControl
            // 
            this.gfxHeightControl.BackColor = System.Drawing.Color.Transparent;
            this.gfxHeightControl.CheckBoxEnabled = false;
            this.gfxHeightControl.CurrentValue = 1;
            this.gfxHeightControl.LabelText = "GFX Height:";
            this.gfxHeightControl.Location = new System.Drawing.Point(6, 19);
            this.gfxHeightControl.MaximumValue = 666666;
            this.gfxHeightControl.MinimumValue = 1;
            this.gfxHeightControl.Name = "gfxHeightControl";
            this.gfxHeightControl.Size = new System.Drawing.Size(228, 37);
            this.gfxHeightControl.SpinnerValue = 0;
            this.gfxHeightControl.TabIndex = 3;
            this.gfxHeightControl.Tag = "gfxheight";
            this.gfxHeightControl.ValueTag = "gfxheight";
            // 
            // gfxWidthControl
            // 
            this.gfxWidthControl.BackColor = System.Drawing.Color.Transparent;
            this.gfxWidthControl.CheckBoxEnabled = false;
            this.gfxWidthControl.CurrentValue = 1;
            this.gfxWidthControl.LabelText = "GFX Width:";
            this.gfxWidthControl.Location = new System.Drawing.Point(6, 60);
            this.gfxWidthControl.MaximumValue = 666666;
            this.gfxWidthControl.MinimumValue = 1;
            this.gfxWidthControl.Name = "gfxWidthControl";
            this.gfxWidthControl.Size = new System.Drawing.Size(228, 37);
            this.gfxWidthControl.SpinnerValue = 0;
            this.gfxWidthControl.TabIndex = 4;
            this.gfxWidthControl.Tag = "gfxwidth";
            this.gfxWidthControl.ValueTag = "gfxwidth";
            // 
            // xOffsetControl
            // 
            this.xOffsetControl.BackColor = System.Drawing.Color.Transparent;
            this.xOffsetControl.CheckBoxEnabled = false;
            this.xOffsetControl.CurrentValue = 0;
            this.xOffsetControl.LabelText = "X Offset:";
            this.xOffsetControl.Location = new System.Drawing.Point(6, 101);
            this.xOffsetControl.MaximumValue = 666666;
            this.xOffsetControl.MinimumValue = 0;
            this.xOffsetControl.Name = "xOffsetControl";
            this.xOffsetControl.Size = new System.Drawing.Size(228, 37);
            this.xOffsetControl.SpinnerValue = 0;
            this.xOffsetControl.TabIndex = 5;
            this.xOffsetControl.Tag = "gfxoffsetx";
            this.xOffsetControl.ValueTag = "gfxoffsetx";
            // 
            // yOffsetControl
            // 
            this.yOffsetControl.BackColor = System.Drawing.Color.Transparent;
            this.yOffsetControl.CheckBoxEnabled = false;
            this.yOffsetControl.CurrentValue = 0;
            this.yOffsetControl.LabelText = "Y Offset:";
            this.yOffsetControl.Location = new System.Drawing.Point(6, 142);
            this.yOffsetControl.MaximumValue = 666666;
            this.yOffsetControl.MinimumValue = 0;
            this.yOffsetControl.Name = "yOffsetControl";
            this.yOffsetControl.Size = new System.Drawing.Size(228, 37);
            this.yOffsetControl.SpinnerValue = 0;
            this.yOffsetControl.TabIndex = 6;
            this.yOffsetControl.Tag = "gfxoffsety";
            this.yOffsetControl.ValueTag = "gfxoffsety";
            // 
            // framesControl
            // 
            this.framesControl.BackColor = System.Drawing.Color.Transparent;
            this.framesControl.CheckBoxEnabled = false;
            this.framesControl.CurrentValue = 0;
            this.framesControl.LabelText = "Frames:";
            this.framesControl.Location = new System.Drawing.Point(6, 183);
            this.framesControl.MaximumValue = 666666;
            this.framesControl.MinimumValue = 0;
            this.framesControl.Name = "framesControl";
            this.framesControl.Size = new System.Drawing.Size(228, 37);
            this.framesControl.SpinnerValue = 0;
            this.framesControl.TabIndex = 7;
            this.framesControl.ValueTag = "frames";
            // 
            // frameSpeedControl
            // 
            this.frameSpeedControl.BackColor = System.Drawing.Color.Transparent;
            this.frameSpeedControl.CheckBoxEnabled = false;
            this.frameSpeedControl.CurrentValue = 8;
            this.frameSpeedControl.LabelText = "Framespeed:";
            this.frameSpeedControl.Location = new System.Drawing.Point(6, 224);
            this.frameSpeedControl.MaximumValue = 16;
            this.frameSpeedControl.MinimumValue = 0;
            this.frameSpeedControl.Name = "frameSpeedControl";
            this.frameSpeedControl.Size = new System.Drawing.Size(228, 37);
            this.frameSpeedControl.SpinnerValue = 0;
            this.frameSpeedControl.TabIndex = 8;
            this.frameSpeedControl.ValueTag = "framespeed";
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 409);
            this.Controls.Add(this.graphicGb);
            this.Controls.Add(this.npcNameLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(996, 469);
            this.Name = "MainUI";
            this.Text = "SMBX NPC Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainUI_FormClosing);
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.graphicGb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem editMenu;
        private System.Windows.Forms.MenuItem showAnimationMenuItem;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem selectConfigMenuItem;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.Label npcNameLabel;
        private System.Windows.Forms.GroupBox graphicGb;
        private SpinnerControlValue gfxHeightControl;
        private SpinnerControlValue gfxWidthControl;
        private SpinnerControlValue xOffsetControl;
        private SpinnerControlValue yOffsetControl;
        private SpinnerControlValue framesControl;
        private SpinnerControlValue frameSpeedControl;
        private CheckBoxValue foregroundControl;
        private ComboBoxControlValue frameStyleControl;

    }
}

