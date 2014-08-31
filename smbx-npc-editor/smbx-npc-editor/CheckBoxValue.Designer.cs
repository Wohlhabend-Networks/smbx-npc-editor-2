namespace smbx_npc_editor
{
    partial class CheckBoxValue
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
            this.label = new System.Windows.Forms.Label();
            this.enabledCheckBox = new System.Windows.Forms.CheckBox();
            this.checkValue = new System.Windows.Forms.CheckBox();
            this.toolTipHandler = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label.Location = new System.Drawing.Point(1, 1);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(79, 27);
            this.label.TabIndex = 24;
            this.label.Text = "Height:";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // enabledCheckBox
            // 
            this.enabledCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enabledCheckBox.AutoSize = true;
            this.enabledCheckBox.Location = new System.Drawing.Point(202, 9);
            this.enabledCheckBox.Name = "enabledCheckBox";
            this.enabledCheckBox.Size = new System.Drawing.Size(15, 14);
            this.enabledCheckBox.TabIndex = 23;
            this.enabledCheckBox.UseVisualStyleBackColor = true;
            this.enabledCheckBox.CheckedChanged += new System.EventHandler(this.enabledCheckBox_CheckedChanged);
            // 
            // checkValue
            // 
            this.checkValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkValue.AutoSize = true;
            this.checkValue.Enabled = false;
            this.checkValue.Location = new System.Drawing.Point(86, 9);
            this.checkValue.Name = "checkValue";
            this.checkValue.Size = new System.Drawing.Size(15, 14);
            this.checkValue.TabIndex = 25;
            this.toolTipHandler.SetToolTip(this.checkValue, "Disabled (0)");
            this.checkValue.UseVisualStyleBackColor = true;
            this.checkValue.CheckedChanged += new System.EventHandler(this.checkValue_CheckedChanged);
            // 
            // CheckBoxValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkValue);
            this.Controls.Add(this.label);
            this.Controls.Add(this.enabledCheckBox);
            this.Name = "CheckBoxValue";
            this.Size = new System.Drawing.Size(228, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label;
        public System.Windows.Forms.CheckBox enabledCheckBox;
        private System.Windows.Forms.CheckBox checkValue;
        private System.Windows.Forms.ToolTip toolTipHandler;
    }
}
