namespace ini_editor
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.iniSectionTreeView = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveKeyButton = new System.Windows.Forms.Button();
            this.keyValueTextBox = new System.Windows.Forms.TextBox();
            this.editKeyLabel = new System.Windows.Forms.Label();
            this.saveValueButton = new System.Windows.Forms.Button();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.editValueLabel = new System.Windows.Forms.Label();
            this.saveSectionButton = new System.Windows.Forms.Button();
            this.secValueTextBox = new System.Windows.Forms.TextBox();
            this.editSectionLabel = new System.Windows.Forms.Label();
            this.addKeyButton = new System.Windows.Forms.Button();
            this.addSectionButton = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.iniSectionTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.addKeyButton);
            this.splitContainer1.Panel2.Controls.Add(this.addSectionButton);
            this.splitContainer1.Size = new System.Drawing.Size(813, 486);
            this.splitContainer1.SplitterDistance = 132;
            this.splitContainer1.TabIndex = 0;
            // 
            // iniSectionTreeView
            // 
            this.iniSectionTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iniSectionTreeView.Location = new System.Drawing.Point(0, 0);
            this.iniSectionTreeView.Name = "iniSectionTreeView";
            this.iniSectionTreeView.Size = new System.Drawing.Size(132, 486);
            this.iniSectionTreeView.TabIndex = 0;
            this.iniSectionTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.iniSectionTreeView_NodeMouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.saveKeyButton);
            this.groupBox1.Controls.Add(this.keyValueTextBox);
            this.groupBox1.Controls.Add(this.editKeyLabel);
            this.groupBox1.Controls.Add(this.saveValueButton);
            this.groupBox1.Controls.Add(this.valueTextBox);
            this.groupBox1.Controls.Add(this.editValueLabel);
            this.groupBox1.Controls.Add(this.saveSectionButton);
            this.groupBox1.Controls.Add(this.secValueTextBox);
            this.groupBox1.Controls.Add(this.editSectionLabel);
            this.groupBox1.Location = new System.Drawing.Point(13, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 432);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit Value";
            // 
            // saveKeyButton
            // 
            this.saveKeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveKeyButton.Location = new System.Drawing.Point(569, 102);
            this.saveKeyButton.Name = "saveKeyButton";
            this.saveKeyButton.Size = new System.Drawing.Size(74, 23);
            this.saveKeyButton.TabIndex = 8;
            this.saveKeyButton.Text = "Save";
            this.saveKeyButton.UseVisualStyleBackColor = true;
            this.saveKeyButton.Click += new System.EventHandler(this.saveKeyButton_Click);
            // 
            // keyValueTextBox
            // 
            this.keyValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyValueTextBox.Location = new System.Drawing.Point(12, 104);
            this.keyValueTextBox.Name = "keyValueTextBox";
            this.keyValueTextBox.Size = new System.Drawing.Size(551, 20);
            this.keyValueTextBox.TabIndex = 6;
            // 
            // editKeyLabel
            // 
            this.editKeyLabel.AutoSize = true;
            this.editKeyLabel.Location = new System.Drawing.Point(11, 88);
            this.editKeyLabel.Name = "editKeyLabel";
            this.editKeyLabel.Size = new System.Drawing.Size(46, 13);
            this.editKeyLabel.TabIndex = 7;
            this.editKeyLabel.Text = "Edit Key";
            // 
            // saveValueButton
            // 
            this.saveValueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveValueButton.Location = new System.Drawing.Point(569, 141);
            this.saveValueButton.Name = "saveValueButton";
            this.saveValueButton.Size = new System.Drawing.Size(74, 23);
            this.saveValueButton.TabIndex = 5;
            this.saveValueButton.Text = "Save";
            this.saveValueButton.UseVisualStyleBackColor = true;
            this.saveValueButton.Click += new System.EventHandler(this.saveValueButton_Click);
            // 
            // valueTextBox
            // 
            this.valueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueTextBox.Location = new System.Drawing.Point(12, 143);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(551, 20);
            this.valueTextBox.TabIndex = 3;
            // 
            // editValueLabel
            // 
            this.editValueLabel.AutoSize = true;
            this.editValueLabel.Location = new System.Drawing.Point(11, 127);
            this.editValueLabel.Name = "editValueLabel";
            this.editValueLabel.Size = new System.Drawing.Size(55, 13);
            this.editValueLabel.TabIndex = 4;
            this.editValueLabel.Text = "Edit Value";
            // 
            // saveSectionButton
            // 
            this.saveSectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSectionButton.Location = new System.Drawing.Point(569, 63);
            this.saveSectionButton.Name = "saveSectionButton";
            this.saveSectionButton.Size = new System.Drawing.Size(74, 23);
            this.saveSectionButton.TabIndex = 2;
            this.saveSectionButton.Text = "Save";
            this.saveSectionButton.UseVisualStyleBackColor = true;
            this.saveSectionButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // secValueTextBox
            // 
            this.secValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secValueTextBox.Location = new System.Drawing.Point(12, 65);
            this.secValueTextBox.Name = "secValueTextBox";
            this.secValueTextBox.Size = new System.Drawing.Size(551, 20);
            this.secValueTextBox.TabIndex = 0;
            // 
            // editSectionLabel
            // 
            this.editSectionLabel.AutoSize = true;
            this.editSectionLabel.Location = new System.Drawing.Point(11, 49);
            this.editSectionLabel.Name = "editSectionLabel";
            this.editSectionLabel.Size = new System.Drawing.Size(64, 13);
            this.editSectionLabel.TabIndex = 1;
            this.editSectionLabel.Text = "Edit Section";
            // 
            // addKeyButton
            // 
            this.addKeyButton.Location = new System.Drawing.Point(94, 13);
            this.addKeyButton.Name = "addKeyButton";
            this.addKeyButton.Size = new System.Drawing.Size(75, 23);
            this.addKeyButton.TabIndex = 4;
            this.addKeyButton.Text = "Add Key";
            this.addKeyButton.UseVisualStyleBackColor = true;
            this.addKeyButton.Click += new System.EventHandler(this.addKeyButton_Click);
            // 
            // addSectionButton
            // 
            this.addSectionButton.Location = new System.Drawing.Point(13, 13);
            this.addSectionButton.Name = "addSectionButton";
            this.addSectionButton.Size = new System.Drawing.Size(75, 23);
            this.addSectionButton.TabIndex = 3;
            this.addSectionButton.Text = "Add Section";
            this.addSectionButton.UseVisualStyleBackColor = true;
            this.addSectionButton.Click += new System.EventHandler(this.addSectionButton_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem4,
            this.menuItem3});
            this.menuItem1.Text = "&File";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItem2.Text = "&Open";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuItem4.Text = "&Save";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "&Exit";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 486);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "C# INI Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView iniSectionTreeView;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.Label editSectionLabel;
        private System.Windows.Forms.TextBox secValueTextBox;
        private System.Windows.Forms.Button saveSectionButton;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.Button addKeyButton;
        private System.Windows.Forms.Button addSectionButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button saveKeyButton;
        private System.Windows.Forms.TextBox keyValueTextBox;
        private System.Windows.Forms.Label editKeyLabel;
        private System.Windows.Forms.Button saveValueButton;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.Label editValueLabel;
    }
}

