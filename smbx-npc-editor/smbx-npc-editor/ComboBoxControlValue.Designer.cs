namespace smbx_npc_editor
{
    partial class ComboBoxControlValue
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
            this.label = new System.Windows.Forms.Label();
            this.enabledCheckBox = new System.Windows.Forms.CheckBox();
            this.ComboValue = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(1, 1);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(79, 27);
            this.label.TabIndex = 21;
            this.label.Text = "Height:";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // enabledCheckBox
            // 
            this.enabledCheckBox.AutoSize = true;
            this.enabledCheckBox.Location = new System.Drawing.Point(206, 11);
            this.enabledCheckBox.Name = "enabledCheckBox";
            this.enabledCheckBox.Size = new System.Drawing.Size(15, 14);
            this.enabledCheckBox.TabIndex = 19;
            this.enabledCheckBox.UseVisualStyleBackColor = true;
            this.enabledCheckBox.CheckedChanged += new System.EventHandler(this.enabledCheckBox_CheckedChanged);
            // 
            // ComboValue
            // 
            this.ComboValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboValue.Enabled = false;
            this.ComboValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ComboValue.FormattingEnabled = true;
            this.ComboValue.Location = new System.Drawing.Point(86, 6);
            this.ComboValue.Name = "ComboValue";
            this.ComboValue.Size = new System.Drawing.Size(109, 21);
            this.ComboValue.TabIndex = 22;
            // 
            // ComboBoxControlValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ComboValue);
            this.Controls.Add(this.label);
            this.Controls.Add(this.enabledCheckBox);
            this.Name = "ComboBoxControlValue";
            this.Size = new System.Drawing.Size(228, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label;
        public System.Windows.Forms.CheckBox enabledCheckBox;
        private System.Windows.Forms.ComboBox ComboValue;
    }
}
