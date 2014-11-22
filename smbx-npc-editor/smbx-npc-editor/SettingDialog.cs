using Setting;
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
using Utility.ModifyRegistry;

namespace smbx_npc_editor
{
    public partial class SettingDialog : Form
    {
        bool runPortable = false;
        bool runPortable_original = false;
        bool npcPreview = false;

        IniFile settingsFile = new IniFile(Environment.CurrentDirectory + @"\Data\settings.ini");
        public SettingDialog()
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
        }

        /// <summary>
        /// Initialize setting dialog, going to a specific tab
        /// </summary>
        /// <param name="tab">0 - Main
        /// 2 - Config
        /// 3 - About</param>
        public SettingDialog(int tab)
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
            tabControl1.SelectedIndex = tab;
        }

        private void SettingDialog_Load(object sender, EventArgs e)
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            String thankyou = smbx_npc_editor.Properties.Resources.thankyou;
            richTextBox1.Rtf = thankyou;
            //
            //Load in settings here
            ModifyRegistry mr = new ModifyRegistry();
            string runPortableStr = mr.Read("runPortable");
            if(runPortableStr == null)
            {//
            }
            else if(runPortableStr == "true")
            {
                runPortable_CheckBox.Checked = true;
                runPortable_original = true;
            }
            else if(runPortableStr == "false")
            {
                runPortable_CheckBox.Checked = false;
                runPortable_original = false;
            }
            string showAnimation = settingsFile.ReadValue("Settings", "showAnimation");
            if(showAnimation == "true")
            {
                npcPreview_CheckBox.Checked = true;
            }
            else if (showAnimation == "false")
            {
                npcPreview_CheckBox.Checked = false;
            }
            //Enable the proper controls
            if (npcPreview)
                npcPreview_CheckBox.Checked = true;
            else if (!npcPreview)
                npcPreview_CheckBox.Checked = false;

            if (runPortable)
                runPortable_CheckBox.Checked = true;
            else if (!runPortable)
                runPortable_CheckBox.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //NPC Pane Enabled
            if(npcPreview_CheckBox.Checked == true)
            {
                previewPanePic.Image = smbx_npc_editor.Properties.Resources.preview_enabled;
                npcPreview = true;
            }
            else if (npcPreview_CheckBox.Checked == false) //NPC Pane disabled
            {
                previewPanePic.Image = smbx_npc_editor.Properties.Resources.preview_disabled;
                npcPreview = false;
            }
        }

        private void runPortable_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(runPortable_CheckBox.Checked == true)
            {
                runPortable = true;
            }
            else if (runPortable_CheckBox.Checked == false)
            {
                runPortable = false;
            }
        }

        //Save and exit
        private void button1_Click(object sender, EventArgs e)
        {
            switch(runPortable)
            {
                case(true):
                    ModifyRegistry mr = new ModifyRegistry();
                    mr.Write("runPortable", true);
                    break;
                case(false):
                    mr = new ModifyRegistry();
                    mr.Write("runPortable", true);
                    break;
            }

            switch(npcPreview)
            {
                case(true):
                    settingsFile.WriteValue("Setttings", "showAnimation", "true");
                    break;
                case(false):
                    settingsFile.WriteValue("Setttings", "showAnimation", "false");
                    break;
            }

            if(runPortable != runPortable_original)
            {
                MessageBox.Show("Changes made to the run portable values will take effect on a restart of the application.", 
                    "Warning", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
            }

            Console.WriteLine("Settings saved!");
            this.Close();
        }

    }
}
