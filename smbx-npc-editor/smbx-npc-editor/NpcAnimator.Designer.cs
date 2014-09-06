namespace smbx_npc_editor
{
    partial class NpcAnimator
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.npcAnimatorGroup = new System.Windows.Forms.GroupBox();
            this.spritePreview = new System.Windows.Forms.PictureBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.faceRightButton = new System.Windows.Forms.Button();
            this.faceLeftButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.toolTipHandler = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.npcAnimatorGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spritePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.npcAnimatorGroup);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.browseButton);
            this.splitContainer1.Panel2.Controls.Add(this.faceRightButton);
            this.splitContainer1.Panel2.Controls.Add(this.faceLeftButton);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.stopButton);
            this.splitContainer1.Panel2.Controls.Add(this.playButton);
            this.splitContainer1.Size = new System.Drawing.Size(380, 302);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 1;
            // 
            // npcAnimatorGroup
            // 
            this.npcAnimatorGroup.Controls.Add(this.spritePreview);
            this.npcAnimatorGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.npcAnimatorGroup.Location = new System.Drawing.Point(0, 0);
            this.npcAnimatorGroup.Name = "npcAnimatorGroup";
            this.npcAnimatorGroup.Size = new System.Drawing.Size(380, 244);
            this.npcAnimatorGroup.TabIndex = 1;
            this.npcAnimatorGroup.TabStop = false;
            this.npcAnimatorGroup.Text = "NPC Animation";
            // 
            // spritePreview
            // 
            this.spritePreview.BackColor = System.Drawing.Color.Transparent;
            this.spritePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spritePreview.Location = new System.Drawing.Point(3, 16);
            this.spritePreview.Name = "spritePreview";
            this.spritePreview.Size = new System.Drawing.Size(374, 225);
            this.spritePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.spritePreview.TabIndex = 0;
            this.spritePreview.TabStop = false;
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.browseButton.Location = new System.Drawing.Point(259, 14);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(118, 28);
            this.browseButton.TabIndex = 11;
            this.browseButton.Text = "Browse...";
            this.toolTipHandler.SetToolTip(this.browseButton, "Load in a custom sprite file");
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // faceRightButton
            // 
            this.faceRightButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.faceRightButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.faceRightButton.Location = new System.Drawing.Point(209, 14);
            this.faceRightButton.Name = "faceRightButton";
            this.faceRightButton.Size = new System.Drawing.Size(44, 28);
            this.faceRightButton.TabIndex = 10;
            this.faceRightButton.Text = "->";
            this.toolTipHandler.SetToolTip(this.faceRightButton, "Face the NPC right");
            this.faceRightButton.UseVisualStyleBackColor = true;
            this.faceRightButton.Click += new System.EventHandler(this.faceRightButton_Click);
            // 
            // faceLeftButton
            // 
            this.faceLeftButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.faceLeftButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.faceLeftButton.Location = new System.Drawing.Point(159, 14);
            this.faceLeftButton.Name = "faceLeftButton";
            this.faceLeftButton.Size = new System.Drawing.Size(44, 28);
            this.faceLeftButton.TabIndex = 9;
            this.faceLeftButton.Text = "<-";
            this.toolTipHandler.SetToolTip(this.faceLeftButton, "Face the NPC Left");
            this.faceLeftButton.UseVisualStyleBackColor = true;
            this.faceLeftButton.Click += new System.EventHandler(this.faceLeftButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(109, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Clear";
            this.toolTipHandler.SetToolTip(this.button1, "Clear the currently shown sprite");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.stopButton.Location = new System.Drawing.Point(59, 14);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(44, 28);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "Stop";
            this.toolTipHandler.SetToolTip(this.stopButton, "Stop the animation process");
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.playButton.Location = new System.Drawing.Point(9, 14);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(44, 28);
            this.playButton.TabIndex = 6;
            this.playButton.Text = "Start";
            this.toolTipHandler.SetToolTip(this.playButton, "Start the animation process");
            this.playButton.UseVisualStyleBackColor = true;
            // 
            // NpcAnimator
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.Name = "NpcAnimator";
            this.Size = new System.Drawing.Size(380, 302);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.npcAnimatorGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spritePreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox npcAnimatorGroup;
        public System.Windows.Forms.PictureBox spritePreview;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.ToolTip toolTipHandler;
        private System.Windows.Forms.Button faceRightButton;
        private System.Windows.Forms.Button faceLeftButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button playButton;
    }
}
