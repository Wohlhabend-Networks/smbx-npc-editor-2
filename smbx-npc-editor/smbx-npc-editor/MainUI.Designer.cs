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
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.editMenu = new System.Windows.Forms.MenuItem();
            this.showAnimationMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.selectConfigMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.npcNameLabel = new System.Windows.Forms.Label();
            this.graphicGroupBox = new System.Windows.Forms.GroupBox();
            this.foregroundControl = new smbx_npc_editor.CheckBoxValue();
            this.frameStyleControl = new smbx_npc_editor.ComboBoxControlValue();
            this.gfxHeightControl = new smbx_npc_editor.SpinnerControlValue();
            this.gfxWidthControl = new smbx_npc_editor.SpinnerControlValue();
            this.xOffsetControl = new smbx_npc_editor.SpinnerControlValue();
            this.yOffsetControl = new smbx_npc_editor.SpinnerControlValue();
            this.framesControl = new smbx_npc_editor.SpinnerControlValue();
            this.frameSpeedControl = new smbx_npc_editor.SpinnerControlValue();
            this.physicsGroupBox = new System.Windows.Forms.GroupBox();
            this.noGravityControl = new smbx_npc_editor.CheckBoxValue();
            this.heightControl = new smbx_npc_editor.SpinnerControlValue();
            this.turnOnCliffControl = new smbx_npc_editor.CheckBoxValue();
            this.widthControl = new smbx_npc_editor.SpinnerControlValue();
            this.playerCollisionControl = new smbx_npc_editor.CheckBoxValue();
            this.noBlockCollisionControl = new smbx_npc_editor.CheckBoxValue();
            this.playerCollisionTopControl = new smbx_npc_editor.CheckBoxValue();
            this.npcCollisionControl = new smbx_npc_editor.CheckBoxValue();
            this.npcCollisionTopControl = new smbx_npc_editor.CheckBoxValue();
            this.inGameGroupBox = new System.Windows.Forms.GroupBox();
            this.noIceControl = new smbx_npc_editor.CheckBoxValue();
            this.noFireBallControl = new smbx_npc_editor.CheckBoxValue();
            this.speedControl = new smbx_npc_editor.SpinnerControlValue();
            this.cantBeEatenControl = new smbx_npc_editor.CheckBoxValue();
            this.dontHurtControl = new smbx_npc_editor.CheckBoxValue();
            this.jumpHurtControl = new smbx_npc_editor.CheckBoxValue();
            this.grabTopControl = new smbx_npc_editor.CheckBoxValue();
            this.grabSideControl = new smbx_npc_editor.CheckBoxValue();
            this.scoreControl = new smbx_npc_editor.ComboBoxControlValue();
            this.nameControl = new Lerch.Samples.CueTextBox();
            this.npcAnimator = new smbx_npc_editor.NpcAnimator();
            this.graphicGroupBox.SuspendLayout();
            this.physicsGroupBox.SuspendLayout();
            this.inGameGroupBox.SuspendLayout();
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
            this.menuItem9,
            this.menuItem4,
            this.menuItem11,
            this.menuItem12,
            this.menuItem6,
            this.menuItem2});
            this.menuItem1.Text = "&File";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 0;
            this.menuItem9.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.menuItem9.Text = "&New";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItem4.Text = "&Open";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 2;
            this.menuItem11.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuItem11.Text = "&Save";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 3;
            this.menuItem12.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
            this.menuItem12.Text = "Save &As";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 4;
            this.menuItem6.Text = "-";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 5;
            this.menuItem2.Text = "&Exit";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // editMenu
            // 
            this.editMenu.Index = 1;
            this.editMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.showAnimationMenuItem,
            this.menuItem5,
            this.menuItem10,
            this.menuItem3,
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
            // menuItem10
            // 
            this.menuItem10.Index = 2;
            this.menuItem10.Text = "Show &Text Editor";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.Text = "-";
            // 
            // selectConfigMenuItem
            // 
            this.selectConfigMenuItem.Index = 4;
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
            // graphicGroupBox
            // 
            this.graphicGroupBox.Controls.Add(this.foregroundControl);
            this.graphicGroupBox.Controls.Add(this.frameStyleControl);
            this.graphicGroupBox.Controls.Add(this.gfxHeightControl);
            this.graphicGroupBox.Controls.Add(this.gfxWidthControl);
            this.graphicGroupBox.Controls.Add(this.xOffsetControl);
            this.graphicGroupBox.Controls.Add(this.yOffsetControl);
            this.graphicGroupBox.Controls.Add(this.framesControl);
            this.graphicGroupBox.Controls.Add(this.frameSpeedControl);
            this.graphicGroupBox.Location = new System.Drawing.Point(12, 45);
            this.graphicGroupBox.Name = "graphicGroupBox";
            this.graphicGroupBox.Size = new System.Drawing.Size(239, 335);
            this.graphicGroupBox.TabIndex = 2;
            this.graphicGroupBox.TabStop = false;
            this.graphicGroupBox.Text = "Graphics";
            // 
            // foregroundControl
            // 
            this.foregroundControl.BackColor = System.Drawing.Color.Transparent;
            this.foregroundControl.isReset = false;
            this.foregroundControl.LabelText = "Foreground:";
            this.foregroundControl.Location = new System.Drawing.Point(6, 273);
            this.foregroundControl.Name = "foregroundControl";
            this.foregroundControl.Size = new System.Drawing.Size(228, 27);
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
            this.frameStyleControl.isReset = false;
            this.frameStyleControl.LabelText = "Framestyle:";
            this.frameStyleControl.Location = new System.Drawing.Point(5, 240);
            this.frameStyleControl.Name = "frameStyleControl";
            this.frameStyleControl.Size = new System.Drawing.Size(228, 27);
            this.frameStyleControl.TabIndex = 9;
            this.frameStyleControl.Tag = "framestyle";
            this.frameStyleControl.ValueTag = "framestyle";
            // 
            // gfxHeightControl
            // 
            this.gfxHeightControl.BackColor = System.Drawing.Color.Transparent;
            this.gfxHeightControl.CheckBoxEnabled = false;
            this.gfxHeightControl.CurrentValue = 0;
            this.gfxHeightControl.isReset = false;
            this.gfxHeightControl.LabelText = "GFX Height:";
            this.gfxHeightControl.Location = new System.Drawing.Point(6, 42);
            this.gfxHeightControl.MaximumValue = 666666;
            this.gfxHeightControl.MinimumValue = 0;
            this.gfxHeightControl.Name = "gfxHeightControl";
            this.gfxHeightControl.Size = new System.Drawing.Size(228, 27);
            this.gfxHeightControl.SpinnerValue = 0;
            this.gfxHeightControl.TabIndex = 3;
            this.gfxHeightControl.Tag = "gfxheight";
            this.gfxHeightControl.ValueTag = "gfxheight";
            // 
            // gfxWidthControl
            // 
            this.gfxWidthControl.BackColor = System.Drawing.Color.Transparent;
            this.gfxWidthControl.CheckBoxEnabled = false;
            this.gfxWidthControl.CurrentValue = 0;
            this.gfxWidthControl.isReset = false;
            this.gfxWidthControl.LabelText = "GFX Width:";
            this.gfxWidthControl.Location = new System.Drawing.Point(6, 75);
            this.gfxWidthControl.MaximumValue = 666666;
            this.gfxWidthControl.MinimumValue = 0;
            this.gfxWidthControl.Name = "gfxWidthControl";
            this.gfxWidthControl.Size = new System.Drawing.Size(228, 27);
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
            this.xOffsetControl.isReset = false;
            this.xOffsetControl.LabelText = "X Offset:";
            this.xOffsetControl.Location = new System.Drawing.Point(6, 108);
            this.xOffsetControl.MaximumValue = 666666;
            this.xOffsetControl.MinimumValue = 0;
            this.xOffsetControl.Name = "xOffsetControl";
            this.xOffsetControl.Size = new System.Drawing.Size(228, 27);
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
            this.yOffsetControl.isReset = false;
            this.yOffsetControl.LabelText = "Y Offset:";
            this.yOffsetControl.Location = new System.Drawing.Point(6, 141);
            this.yOffsetControl.MaximumValue = 666666;
            this.yOffsetControl.MinimumValue = 0;
            this.yOffsetControl.Name = "yOffsetControl";
            this.yOffsetControl.Size = new System.Drawing.Size(228, 27);
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
            this.framesControl.isReset = false;
            this.framesControl.LabelText = "Frames:";
            this.framesControl.Location = new System.Drawing.Point(6, 174);
            this.framesControl.MaximumValue = 666666;
            this.framesControl.MinimumValue = 0;
            this.framesControl.Name = "framesControl";
            this.framesControl.Size = new System.Drawing.Size(228, 27);
            this.framesControl.SpinnerValue = 0;
            this.framesControl.TabIndex = 7;
            this.framesControl.ValueTag = "frames";
            // 
            // frameSpeedControl
            // 
            this.frameSpeedControl.BackColor = System.Drawing.Color.Transparent;
            this.frameSpeedControl.CheckBoxEnabled = false;
            this.frameSpeedControl.CurrentValue = 8;
            this.frameSpeedControl.isReset = false;
            this.frameSpeedControl.LabelText = "Framespeed:";
            this.frameSpeedControl.Location = new System.Drawing.Point(6, 207);
            this.frameSpeedControl.MaximumValue = 16;
            this.frameSpeedControl.MinimumValue = 0;
            this.frameSpeedControl.Name = "frameSpeedControl";
            this.frameSpeedControl.Size = new System.Drawing.Size(228, 27);
            this.frameSpeedControl.SpinnerValue = 0;
            this.frameSpeedControl.TabIndex = 8;
            this.frameSpeedControl.ValueTag = "framespeed";
            // 
            // physicsGroupBox
            // 
            this.physicsGroupBox.Controls.Add(this.noGravityControl);
            this.physicsGroupBox.Controls.Add(this.heightControl);
            this.physicsGroupBox.Controls.Add(this.turnOnCliffControl);
            this.physicsGroupBox.Controls.Add(this.widthControl);
            this.physicsGroupBox.Controls.Add(this.playerCollisionControl);
            this.physicsGroupBox.Controls.Add(this.noBlockCollisionControl);
            this.physicsGroupBox.Controls.Add(this.playerCollisionTopControl);
            this.physicsGroupBox.Controls.Add(this.npcCollisionControl);
            this.physicsGroupBox.Controls.Add(this.npcCollisionTopControl);
            this.physicsGroupBox.Location = new System.Drawing.Point(257, 45);
            this.physicsGroupBox.Name = "physicsGroupBox";
            this.physicsGroupBox.Size = new System.Drawing.Size(239, 335);
            this.physicsGroupBox.TabIndex = 11;
            this.physicsGroupBox.TabStop = false;
            this.physicsGroupBox.Text = "Physics Related";
            // 
            // noGravityControl
            // 
            this.noGravityControl.BackColor = System.Drawing.Color.Transparent;
            this.noGravityControl.isReset = false;
            this.noGravityControl.LabelText = "No Gravity:";
            this.noGravityControl.Location = new System.Drawing.Point(7, 298);
            this.noGravityControl.Name = "noGravityControl";
            this.noGravityControl.Size = new System.Drawing.Size(228, 27);
            this.noGravityControl.TabIndex = 12;
            this.noGravityControl.ValueChecked = false;
            this.noGravityControl.ValueTag = "nogravity";
            // 
            // heightControl
            // 
            this.heightControl.CheckBoxEnabled = false;
            this.heightControl.CurrentValue = 0;
            this.heightControl.isReset = false;
            this.heightControl.Location = new System.Drawing.Point(8, 34);
            this.heightControl.MaximumValue = 666666;
            this.heightControl.MinimumValue = 0;
            this.heightControl.Name = "heightControl";
            this.heightControl.Size = new System.Drawing.Size(228, 27);
            this.heightControl.SpinnerValue = 1;
            this.heightControl.TabIndex = 0;
            this.heightControl.ValueTag = "height";
            // 
            // turnOnCliffControl
            // 
            this.turnOnCliffControl.isReset = false;
            this.turnOnCliffControl.LabelText = "Turn on Cliff:";
            this.turnOnCliffControl.Location = new System.Drawing.Point(7, 265);
            this.turnOnCliffControl.Name = "turnOnCliffControl";
            this.turnOnCliffControl.Size = new System.Drawing.Size(228, 27);
            this.turnOnCliffControl.TabIndex = 7;
            this.turnOnCliffControl.ValueChecked = false;
            this.turnOnCliffControl.ValueTag = "cliffturn";
            // 
            // widthControl
            // 
            this.widthControl.CheckBoxEnabled = false;
            this.widthControl.CurrentValue = 0;
            this.widthControl.isReset = false;
            this.widthControl.LabelText = "Width:";
            this.widthControl.Location = new System.Drawing.Point(8, 67);
            this.widthControl.MaximumValue = 666666;
            this.widthControl.MinimumValue = 0;
            this.widthControl.Name = "widthControl";
            this.widthControl.Size = new System.Drawing.Size(228, 27);
            this.widthControl.SpinnerValue = 1;
            this.widthControl.TabIndex = 1;
            this.widthControl.ValueTag = "width";
            // 
            // playerCollisionControl
            // 
            this.playerCollisionControl.isReset = false;
            this.playerCollisionControl.LabelText = "Player Collision:";
            this.playerCollisionControl.Location = new System.Drawing.Point(7, 100);
            this.playerCollisionControl.Name = "playerCollisionControl";
            this.playerCollisionControl.Size = new System.Drawing.Size(228, 27);
            this.playerCollisionControl.TabIndex = 2;
            this.playerCollisionControl.ValueChecked = false;
            this.playerCollisionControl.ValueTag = "playerblock";
            // 
            // noBlockCollisionControl
            // 
            this.noBlockCollisionControl.isReset = false;
            this.noBlockCollisionControl.LabelText = "No Block Collision:";
            this.noBlockCollisionControl.Location = new System.Drawing.Point(7, 232);
            this.noBlockCollisionControl.Name = "noBlockCollisionControl";
            this.noBlockCollisionControl.Size = new System.Drawing.Size(228, 27);
            this.noBlockCollisionControl.TabIndex = 6;
            this.noBlockCollisionControl.ValueChecked = false;
            this.noBlockCollisionControl.ValueTag = "noblockcollision";
            // 
            // playerCollisionTopControl
            // 
            this.playerCollisionTopControl.isReset = false;
            this.playerCollisionTopControl.LabelText = "Player Collision Top:";
            this.playerCollisionTopControl.Location = new System.Drawing.Point(7, 133);
            this.playerCollisionTopControl.Name = "playerCollisionTopControl";
            this.playerCollisionTopControl.Size = new System.Drawing.Size(228, 27);
            this.playerCollisionTopControl.TabIndex = 3;
            this.playerCollisionTopControl.ValueChecked = false;
            this.playerCollisionTopControl.ValueTag = "playerblocktop";
            // 
            // npcCollisionControl
            // 
            this.npcCollisionControl.isReset = false;
            this.npcCollisionControl.LabelText = "NPC Collision:";
            this.npcCollisionControl.Location = new System.Drawing.Point(7, 166);
            this.npcCollisionControl.Name = "npcCollisionControl";
            this.npcCollisionControl.Size = new System.Drawing.Size(228, 27);
            this.npcCollisionControl.TabIndex = 4;
            this.npcCollisionControl.ValueChecked = false;
            this.npcCollisionControl.ValueTag = "npcblock";
            // 
            // npcCollisionTopControl
            // 
            this.npcCollisionTopControl.isReset = false;
            this.npcCollisionTopControl.LabelText = "NPC Collision Top:";
            this.npcCollisionTopControl.Location = new System.Drawing.Point(7, 199);
            this.npcCollisionTopControl.Name = "npcCollisionTopControl";
            this.npcCollisionTopControl.Size = new System.Drawing.Size(228, 27);
            this.npcCollisionTopControl.TabIndex = 5;
            this.npcCollisionTopControl.ValueChecked = false;
            this.npcCollisionTopControl.ValueTag = "npcblocktop";
            // 
            // inGameGroupBox
            // 
            this.inGameGroupBox.Controls.Add(this.noIceControl);
            this.inGameGroupBox.Controls.Add(this.noFireBallControl);
            this.inGameGroupBox.Controls.Add(this.speedControl);
            this.inGameGroupBox.Controls.Add(this.cantBeEatenControl);
            this.inGameGroupBox.Controls.Add(this.dontHurtControl);
            this.inGameGroupBox.Controls.Add(this.jumpHurtControl);
            this.inGameGroupBox.Controls.Add(this.grabTopControl);
            this.inGameGroupBox.Controls.Add(this.grabSideControl);
            this.inGameGroupBox.Controls.Add(this.scoreControl);
            this.inGameGroupBox.Location = new System.Drawing.Point(502, 45);
            this.inGameGroupBox.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.inGameGroupBox.Name = "inGameGroupBox";
            this.inGameGroupBox.Size = new System.Drawing.Size(239, 335);
            this.inGameGroupBox.TabIndex = 13;
            this.inGameGroupBox.TabStop = false;
            this.inGameGroupBox.Text = "In Game Values";
            // 
            // noIceControl
            // 
            this.noIceControl.BackColor = System.Drawing.Color.Transparent;
            this.noIceControl.isReset = false;
            this.noIceControl.LabelText = "No Iceball:";
            this.noIceControl.Location = new System.Drawing.Point(7, 298);
            this.noIceControl.Name = "noIceControl";
            this.noIceControl.Size = new System.Drawing.Size(228, 27);
            this.noIceControl.TabIndex = 19;
            this.noIceControl.ValueChecked = false;
            this.noIceControl.ValueTag = "noiceball";
            // 
            // noFireBallControl
            // 
            this.noFireBallControl.isReset = false;
            this.noFireBallControl.LabelText = "No Fireball:";
            this.noFireBallControl.Location = new System.Drawing.Point(7, 265);
            this.noFireBallControl.Name = "noFireBallControl";
            this.noFireBallControl.Size = new System.Drawing.Size(228, 27);
            this.noFireBallControl.TabIndex = 20;
            this.noFireBallControl.ValueChecked = false;
            this.noFireBallControl.ValueTag = "nofireball";
            // 
            // speedControl
            // 
            this.speedControl.CheckBoxEnabled = false;
            this.speedControl.CurrentValue = 1;
            this.speedControl.isReset = false;
            this.speedControl.LabelText = "Speed:";
            this.speedControl.Location = new System.Drawing.Point(6, 232);
            this.speedControl.MaximumValue = 666666;
            this.speedControl.MinimumValue = 0;
            this.speedControl.Name = "speedControl";
            this.speedControl.Size = new System.Drawing.Size(228, 27);
            this.speedControl.SpinnerValue = 0;
            this.speedControl.TabIndex = 19;
            this.speedControl.ValueTag = "speed";
            // 
            // cantBeEatenControl
            // 
            this.cantBeEatenControl.isReset = false;
            this.cantBeEatenControl.LabelText = "Can\'t Be Eaten:";
            this.cantBeEatenControl.Location = new System.Drawing.Point(7, 199);
            this.cantBeEatenControl.Name = "cantBeEatenControl";
            this.cantBeEatenControl.Size = new System.Drawing.Size(228, 27);
            this.cantBeEatenControl.TabIndex = 18;
            this.cantBeEatenControl.ValueChecked = false;
            this.cantBeEatenControl.ValueTag = "noyoshi";
            // 
            // dontHurtControl
            // 
            this.dontHurtControl.isReset = false;
            this.dontHurtControl.LabelText = "Don\'t Hurt:";
            this.dontHurtControl.Location = new System.Drawing.Point(7, 166);
            this.dontHurtControl.Name = "dontHurtControl";
            this.dontHurtControl.Size = new System.Drawing.Size(228, 27);
            this.dontHurtControl.TabIndex = 17;
            this.dontHurtControl.ValueChecked = false;
            this.dontHurtControl.ValueTag = "nohurt";
            // 
            // jumpHurtControl
            // 
            this.jumpHurtControl.isReset = false;
            this.jumpHurtControl.LabelText = "Jump Hurt:";
            this.jumpHurtControl.Location = new System.Drawing.Point(7, 133);
            this.jumpHurtControl.Name = "jumpHurtControl";
            this.jumpHurtControl.Size = new System.Drawing.Size(228, 27);
            this.jumpHurtControl.TabIndex = 16;
            this.jumpHurtControl.ValueChecked = false;
            this.jumpHurtControl.ValueTag = "jumphurt";
            // 
            // grabTopControl
            // 
            this.grabTopControl.isReset = false;
            this.grabTopControl.LabelText = "Grab Top:";
            this.grabTopControl.Location = new System.Drawing.Point(7, 100);
            this.grabTopControl.Name = "grabTopControl";
            this.grabTopControl.Size = new System.Drawing.Size(228, 27);
            this.grabTopControl.TabIndex = 15;
            this.grabTopControl.ValueChecked = false;
            this.grabTopControl.ValueTag = "grabtop";
            // 
            // grabSideControl
            // 
            this.grabSideControl.isReset = false;
            this.grabSideControl.LabelText = "Grab Side:";
            this.grabSideControl.Location = new System.Drawing.Point(7, 67);
            this.grabSideControl.Name = "grabSideControl";
            this.grabSideControl.Size = new System.Drawing.Size(228, 27);
            this.grabSideControl.TabIndex = 14;
            this.grabSideControl.ValueChecked = false;
            this.grabSideControl.ValueTag = "grabside";
            // 
            // scoreControl
            // 
            this.scoreControl.ComboBoxValues.AddRange(new object[] {
            "None",
            "10",
            "100",
            "200",
            "400",
            "800",
            "1000",
            "2000",
            "4000",
            "8000",
            "1-Up",
            "2-Up",
            "3-Up",
            "5-Up"});
            this.scoreControl.isReset = false;
            this.scoreControl.LabelText = "Score:";
            this.scoreControl.Location = new System.Drawing.Point(5, 34);
            this.scoreControl.Name = "scoreControl";
            this.scoreControl.Size = new System.Drawing.Size(228, 27);
            this.scoreControl.TabIndex = 0;
            this.scoreControl.ValueTag = "score";
            // 
            // nameControl
            // 
            this.nameControl.Location = new System.Drawing.Point(85, 10);
            this.nameControl.Name = "nameControl";
            this.nameControl.Size = new System.Drawing.Size(166, 20);
            this.nameControl.TabIndex = 15;
            this.nameControl.Tag = "name";
            this.nameControl.TextChanged += new System.EventHandler(this.nameControl_TextChanged);
            // 
            // npcAnimator
            // 
            this.npcAnimator.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.npcAnimator.Location = new System.Drawing.Point(747, 43);
            this.npcAnimator.Name = "npcAnimator";
            this.npcAnimator.Size = new System.Drawing.Size(432, 337);
            this.npcAnimator.TabIndex = 14;
            // 
            // MainUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1191, 395);
            this.Controls.Add(this.nameControl);
            this.Controls.Add(this.npcAnimator);
            this.Controls.Add(this.inGameGroupBox);
            this.Controls.Add(this.physicsGroupBox);
            this.Controls.Add(this.graphicGroupBox);
            this.Controls.Add(this.npcNameLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(0, 449);
            this.Name = "MainUI";
            this.Text = "SMBX NPC Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainUI_FormClosing);
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.graphicGroupBox.ResumeLayout(false);
            this.physicsGroupBox.ResumeLayout(false);
            this.inGameGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox graphicGroupBox;
        private SpinnerControlValue gfxHeightControl;
        private SpinnerControlValue gfxWidthControl;
        private SpinnerControlValue xOffsetControl;
        private SpinnerControlValue yOffsetControl;
        private SpinnerControlValue framesControl;
        private SpinnerControlValue frameSpeedControl;
        private CheckBoxValue foregroundControl;
        private ComboBoxControlValue frameStyleControl;
        private System.Windows.Forms.GroupBox physicsGroupBox;
        private SpinnerControlValue heightControl;
        private CheckBoxValue noGravityControl;
        private CheckBoxValue turnOnCliffControl;
        private CheckBoxValue noBlockCollisionControl;
        private CheckBoxValue npcCollisionTopControl;
        private CheckBoxValue npcCollisionControl;
        private CheckBoxValue playerCollisionTopControl;
        private CheckBoxValue playerCollisionControl;
        private SpinnerControlValue widthControl;
        private System.Windows.Forms.GroupBox inGameGroupBox;
        private ComboBoxControlValue scoreControl;
        private CheckBoxValue cantBeEatenControl;
        private CheckBoxValue dontHurtControl;
        private CheckBoxValue jumpHurtControl;
        private CheckBoxValue grabTopControl;
        private CheckBoxValue grabSideControl;
        private CheckBoxValue noIceControl;
        private CheckBoxValue noFireBallControl;
        private SpinnerControlValue speedControl;
        private NpcAnimator npcAnimator;
        private Lerch.Samples.CueTextBox nameControl;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem12;

    }
}

