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
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.showAnimationMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.selectConfigMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.npcNameLabel = new System.Windows.Forms.Label();
            this.graphicGb = new System.Windows.Forms.GroupBox();
            this.frameSpeedControl = new smbx_npc_editor.SpinnerControlValue();
            this.framesControl = new smbx_npc_editor.SpinnerControlValue();
            this.yOffsetControl = new smbx_npc_editor.SpinnerControlValue();
            this.xOffsetControl = new smbx_npc_editor.SpinnerControlValue();
            this.widthControl = new smbx_npc_editor.SpinnerControlValue();
            this.gfxHeightSpinner = new smbx_npc_editor.SpinnerControlValue();
            this.npcAnimator1 = new smbx_npc_editor.NpcAnimator();
            this.graphicGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem3,
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
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
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
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.showAnimationMenuItem,
            this.menuItem5,
            this.selectConfigMenuItem});
            this.menuItem3.Text = "&Edit";
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
            this.graphicGb.Controls.Add(this.frameSpeedControl);
            this.graphicGb.Controls.Add(this.framesControl);
            this.graphicGb.Controls.Add(this.yOffsetControl);
            this.graphicGb.Controls.Add(this.xOffsetControl);
            this.graphicGb.Controls.Add(this.widthControl);
            this.graphicGb.Controls.Add(this.gfxHeightSpinner);
            this.graphicGb.Location = new System.Drawing.Point(12, 45);
            this.graphicGb.Name = "graphicGb";
            this.graphicGb.Size = new System.Drawing.Size(277, 326);
            this.graphicGb.TabIndex = 2;
            this.graphicGb.TabStop = false;
            this.graphicGb.Text = "Graphics";
            // 
            // frameSpeedControl
            // 
            this.frameSpeedControl.LabelText = "Framespeed: ";
            this.frameSpeedControl.Location = new System.Drawing.Point(6, 229);
            this.frameSpeedControl.Name = "frameSpeedControl";
            this.frameSpeedControl.Size = new System.Drawing.Size(265, 36);
            this.frameSpeedControl.TabIndex = 5;
            // 
            // framesControl
            // 
            this.framesControl.LabelText = "Frames: ";
            this.framesControl.Location = new System.Drawing.Point(6, 187);
            this.framesControl.Name = "framesControl";
            this.framesControl.Size = new System.Drawing.Size(265, 36);
            this.framesControl.TabIndex = 4;
            // 
            // yOffsetControl
            // 
            this.yOffsetControl.LabelText = "Y Offset: ";
            this.yOffsetControl.Location = new System.Drawing.Point(6, 145);
            this.yOffsetControl.Name = "yOffsetControl";
            this.yOffsetControl.Size = new System.Drawing.Size(265, 36);
            this.yOffsetControl.TabIndex = 3;
            // 
            // xOffsetControl
            // 
            this.xOffsetControl.LabelText = "X Offset: ";
            this.xOffsetControl.Location = new System.Drawing.Point(6, 103);
            this.xOffsetControl.Name = "xOffsetControl";
            this.xOffsetControl.Size = new System.Drawing.Size(265, 36);
            this.xOffsetControl.TabIndex = 2;
            // 
            // widthControl
            // 
            this.widthControl.LabelText = "Width: ";
            this.widthControl.Location = new System.Drawing.Point(6, 61);
            this.widthControl.Name = "widthControl";
            this.widthControl.Size = new System.Drawing.Size(265, 36);
            this.widthControl.TabIndex = 1;
            // 
            // gfxHeightSpinner
            // 
            this.gfxHeightSpinner.LabelText = "Height: ";
            this.gfxHeightSpinner.Location = new System.Drawing.Point(6, 19);
            this.gfxHeightSpinner.Name = "gfxHeightSpinner";
            this.gfxHeightSpinner.Size = new System.Drawing.Size(265, 36);
            this.gfxHeightSpinner.TabIndex = 0;
            // 
            // npcAnimator1
            // 
            this.npcAnimator1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.npcAnimator1.Location = new System.Drawing.Point(519, 45);
            this.npcAnimator1.Name = "npcAnimator1";
            this.npcAnimator1.Size = new System.Drawing.Size(449, 329);
            this.npcAnimator1.TabIndex = 1;
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 383);
            this.Controls.Add(this.graphicGb);
            this.Controls.Add(this.npcAnimator1);
            this.Controls.Add(this.npcNameLabel);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
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
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem showAnimationMenuItem;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem selectConfigMenuItem;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.Label npcNameLabel;
        private NpcAnimator npcAnimator1;
        private System.Windows.Forms.GroupBox graphicGb;
        private SpinnerControlValue gfxHeightSpinner;
        private SpinnerControlValue frameSpeedControl;
        private SpinnerControlValue framesControl;
        private SpinnerControlValue yOffsetControl;
        private SpinnerControlValue xOffsetControl;
        private SpinnerControlValue widthControl;

    }
}

