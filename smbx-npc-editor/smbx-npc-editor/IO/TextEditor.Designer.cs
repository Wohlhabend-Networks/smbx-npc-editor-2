namespace smbx_npc_editor.IO
{
    partial class TextEditor
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
            this.richTextEditor = new System.Windows.Forms.RichTextBox();
            this.highlightTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // richTextEditor
            // 
            this.richTextEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextEditor.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextEditor.Location = new System.Drawing.Point(0, 0);
            this.richTextEditor.Name = "richTextEditor";
            this.richTextEditor.Size = new System.Drawing.Size(495, 442);
            this.richTextEditor.TabIndex = 0;
            this.richTextEditor.Text = "";
            this.richTextEditor.TextChanged += new System.EventHandler(this.richTextEditor_TextChanged);
            // 
            // highlightTimer
            // 
            this.highlightTimer.Enabled = true;
            this.highlightTimer.Interval = 1000;
            this.highlightTimer.Tick += new System.EventHandler(this.highlightTimer_Tick);
            // 
            // TextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 442);
            this.Controls.Add(this.richTextEditor);
            this.Name = "TextEditor";
            this.Text = "Text Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TextEditor_FormClosing);
            this.Load += new System.EventHandler(this.TextEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextEditor;
        private System.Windows.Forms.Timer highlightTimer;
    }
}