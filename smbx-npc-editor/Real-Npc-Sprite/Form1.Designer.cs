namespace Real_Npc_Sprite
{
    partial class Form1
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
            this.save = new System.Windows.Forms.Button();
            this.gfxHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gfxWidth = new System.Windows.Forms.TextBox();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currentNpc = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.useOffset = new System.Windows.Forms.CheckBox();
            this.scaleButton = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.changeDirectoryButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.curDirectoryLabel = new System.Windows.Forms.ToolStripLabel();
            this.dontAsk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(13, 139);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(197, 64);
            this.save.TabIndex = 14;
            this.save.Text = "Ok, Save, Next!";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // gfxHeight
            // 
            this.gfxHeight.Location = new System.Drawing.Point(81, 113);
            this.gfxHeight.Name = "gfxHeight";
            this.gfxHeight.Size = new System.Drawing.Size(129, 20);
            this.gfxHeight.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "GFX Height";
            // 
            // gfxWidth
            // 
            this.gfxWidth.Location = new System.Drawing.Point(81, 87);
            this.gfxWidth.Name = "gfxWidth";
            this.gfxWidth.Size = new System.Drawing.Size(129, 20);
            this.gfxWidth.TabIndex = 11;
            // 
            // previewBox
            // 
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewBox.Location = new System.Drawing.Point(3, 16);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(272, 275);
            this.previewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.previewBox.TabIndex = 0;
            this.previewBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "GFX Width";
            // 
            // currentNpc
            // 
            this.currentNpc.AutoSize = true;
            this.currentNpc.Location = new System.Drawing.Point(13, 59);
            this.currentNpc.Name = "currentNpc";
            this.currentNpc.Size = new System.Drawing.Size(21, 13);
            this.currentNpc.TabIndex = 9;
            this.currentNpc.Text = "{0}";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.previewBox);
            this.groupBox1.Location = new System.Drawing.Point(249, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 294);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // useOffset
            // 
            this.useOffset.AutoSize = true;
            this.useOffset.Location = new System.Drawing.Point(19, 238);
            this.useOffset.Name = "useOffset";
            this.useOffset.Size = new System.Drawing.Size(74, 17);
            this.useOffset.TabIndex = 15;
            this.useOffset.Text = "Use offset";
            this.useOffset.UseVisualStyleBackColor = true;
            this.useOffset.CheckedChanged += new System.EventHandler(this.useOffset_CheckedChanged);
            // 
            // scaleButton
            // 
            this.scaleButton.Location = new System.Drawing.Point(13, 209);
            this.scaleButton.Name = "scaleButton";
            this.scaleButton.Size = new System.Drawing.Size(197, 23);
            this.scaleButton.TabIndex = 16;
            this.scaleButton.Text = "Proportionally Size to 32 x 32";
            this.scaleButton.UseVisualStyleBackColor = true;
            this.scaleButton.Click += new System.EventHandler(this.scaleButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeDirectoryButton,
            this.toolStripSeparator1,
            this.curDirectoryLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(539, 25);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // changeDirectoryButton
            // 
            this.changeDirectoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.changeDirectoryButton.Name = "changeDirectoryButton";
            this.changeDirectoryButton.Size = new System.Drawing.Size(103, 22);
            this.changeDirectoryButton.Text = "Change Directory";
            this.changeDirectoryButton.Click += new System.EventHandler(this.changeDirectoryButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // curDirectoryLabel
            // 
            this.curDirectoryLabel.Name = "curDirectoryLabel";
            this.curDirectoryLabel.Size = new System.Drawing.Size(21, 22);
            this.curDirectoryLabel.Text = "{0}";
            // 
            // dontAsk
            // 
            this.dontAsk.AutoSize = true;
            this.dontAsk.Location = new System.Drawing.Point(19, 262);
            this.dontAsk.Name = "dontAsk";
            this.dontAsk.Size = new System.Drawing.Size(114, 17);
            this.dontAsk.TabIndex = 18;
            this.dontAsk.Text = "Don\'t Keep Asking";
            this.dontAsk.UseVisualStyleBackColor = true;
            this.dontAsk.CheckedChanged += new System.EventHandler(this.dontAsk_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 351);
            this.Controls.Add(this.dontAsk);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.scaleButton);
            this.Controls.Add(this.useOffset);
            this.Controls.Add(this.save);
            this.Controls.Add(this.gfxHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gfxWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentNpc);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Sprite Maker";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox gfxHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox gfxWidth;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentNpc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox useOffset;
        private System.Windows.Forms.Button scaleButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton changeDirectoryButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel curDirectoryLabel;
        private System.Windows.Forms.CheckBox dontAsk;
    }
}

