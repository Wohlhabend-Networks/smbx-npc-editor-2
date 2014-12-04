namespace smbx_npc_editor
{
    partial class SettingDialog
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.runPortable_CheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.previewPanePic = new System.Windows.Forms.PictureBox();
            this.npcPreview_CheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPanePic)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(610, 341);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.runPortable_CheckBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.previewPanePic);
            this.tabPage1.Controls.Add(this.npcPreview_CheckBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(602, 315);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 52);
            this.label4.TabIndex = 4;
            this.label4.Text = "If checked, this application will be run\r\nas portable. Settings will not be store" +
    "d\r\nand configurations will not be available. \r\nThis value is stored in the regis" +
    "try.";
            // 
            // runPortable_CheckBox
            // 
            this.runPortable_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.runPortable_CheckBox.AutoSize = true;
            this.runPortable_CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runPortable_CheckBox.Location = new System.Drawing.Point(99, 152);
            this.runPortable_CheckBox.Name = "runPortable_CheckBox";
            this.runPortable_CheckBox.Size = new System.Drawing.Size(113, 22);
            this.runPortable_CheckBox.TabIndex = 3;
            this.runPortable_CheckBox.Text = "Run Portable";
            this.runPortable_CheckBox.UseVisualStyleBackColor = true;
            this.runPortable_CheckBox.CheckedChanged += new System.EventHandler(this.runPortable_CheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "If checked, the NPC Preview Pane will be \r\nshown alongside the regular controls";
            // 
            // previewPanePic
            // 
            this.previewPanePic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.previewPanePic.Image = global::smbx_npc_editor.Properties.Resources.preview_disabled;
            this.previewPanePic.Location = new System.Drawing.Point(310, 41);
            this.previewPanePic.Name = "previewPanePic";
            this.previewPanePic.Size = new System.Drawing.Size(117, 76);
            this.previewPanePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewPanePic.TabIndex = 1;
            this.previewPanePic.TabStop = false;
            // 
            // npcPreview_CheckBox
            // 
            this.npcPreview_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.npcPreview_CheckBox.AutoSize = true;
            this.npcPreview_CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.npcPreview_CheckBox.Location = new System.Drawing.Point(102, 41);
            this.npcPreview_CheckBox.Name = "npcPreview_CheckBox";
            this.npcPreview_CheckBox.Size = new System.Drawing.Size(202, 22);
            this.npcPreview_CheckBox.TabIndex = 0;
            this.npcPreview_CheckBox.Text = "Enable NPC Preview Pane";
            this.npcPreview_CheckBox.UseVisualStyleBackColor = true;
            this.npcPreview_CheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(602, 315);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configurations";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(602, 315);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Location = new System.Drawing.Point(3, 199);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(596, 113);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "by Luigifan2010";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SMBX NPC Editor";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::smbx_npc_editor.Properties.Resources._128;
            this.pictureBox1.Location = new System.Drawing.Point(242, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 42);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(436, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(512, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save and Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Work in progress, check back soon! :)";
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 383);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingDialog_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPanePic)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox previewPanePic;
        private System.Windows.Forms.CheckBox npcPreview_CheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox runPortable_CheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
    }
}