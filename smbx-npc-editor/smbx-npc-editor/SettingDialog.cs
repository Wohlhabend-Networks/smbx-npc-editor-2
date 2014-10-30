using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace smbx_npc_editor
{
    public partial class SettingDialog : Form
    {
        public SettingDialog()
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
        }

        private void SettingDialog_Load(object sender, EventArgs e)
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            String thankyou = smbx_npc_editor.Properties.Resources.thankyou;
            richTextBox1.Rtf = thankyou;
        }
    }
}
