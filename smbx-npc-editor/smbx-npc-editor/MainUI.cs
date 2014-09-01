using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using smbx_npc_editor.IO;
using System.IO;
using Setting;
using smbx_npc_editor.SpriteHandling;
using smbxnpceditor;

namespace smbx_npc_editor
{
    public partial class MainUI : Form
    {
        //
        NpcConfigFile npcfile = new NpcConfigFile(true);
        IniFile settingsFile = new IniFile(Environment.CurrentDirectory + @"\Data\settings.ini");
        public IniFile curConfig;
        public string currentConfig;
        bool showAnimationPane;
        //

        public MainUI()
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
            loadSettings();
            compileConfigs();
            //We'll start with the value spinners.
            gfxHeightControl.valueSpinner.ValueChanged += valueSpinner_ValueChanged;
            gfxHeightControl.enabledCheckBox.CheckedChanged += (sender, e) => enabledCheckBox_CheckedChanged(sender, e, gfxHeightControl);
            gfxWidthControl.valueSpinner.ValueChanged += valueSpinner_ValueChanged;
            gfxWidthControl.enabledCheckBox.CheckedChanged += (sender, e) => enabledCheckBox_CheckedChanged(sender, e, gfxWidthControl);
            //Then the ComboBoxes

            //Finally, the checkboxes.
        }

        void enabledCheckBox_CheckedChanged(object sender, object e, SpinnerControlValue sv)
        {
            CheckBox check = (CheckBox)sender;
            if(check.Checked)
            {
                npcfile.AddValue(sv.valueSpinner.Tag.ToString(), sv.valueSpinner.Value.ToString());
            }
            else
            {
                npcfile.RemoveValue(sv.valueSpinner.Tag.ToString());
            }
        }

        void valueSpinner_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown updown = (NumericUpDown)sender;
            npcfile.AddValue(updown.Tag.ToString(), updown.Value.ToString());
        }
        #region crying
        void compileConfigs()
        {
            if (Directory.Exists(Environment.CurrentDirectory + @"\Data"))
            {
                if(currentConfig == "null")
                {
                    noConfig();
                }
                int count = 0;
                List<string> dirs = new List<string>();
                foreach (var dir in Directory.GetDirectories(Environment.CurrentDirectory + @"\Data"))
                {
                    count++;
                    dirs.Add(dir);
                }
                MenuItem[] items = new MenuItem[count];
                bool add = true;
                for (int i = 0; i < items.Length; i++)
                {
                    string dirName = Path.GetFileName(dirs[i]);
                    if (dirName == "tools")
                        add = false;
                    if (!File.Exists(dirs[i] + @"\lvl_npc.ini"))
                        add = false;
                    items[i] = new MenuItem();
                    items[i].Name = "configItem" + i;
                    items[i].Text = dirName;
                    items[i].RadioCheck = true;
                    items[i].Click += new EventHandler(ConfigMenuHandler);
                    if (add)
                        selectConfigMenuItem.MenuItems.Add(items[i]);
                    add = true;
                }
            }
            else
            {
                noConfig();
            }
        }
        void noConfig()
        {
            Console.WriteLine("Data folder was moved or non existent!");
            MenuItem nullConfig = new MenuItem("No configuration available");
            nullConfig.Enabled = false;
            selectConfigMenuItem.MenuItems.Add(nullConfig);
        }
        void loadSettings()
        {
            if (File.Exists(Environment.CurrentDirectory + @"\Data\settings.ini"))
            {
                try
                {
                    currentConfig = settingsFile.ReadValue("Settings", "lastConfig");
                    if (currentConfig == "null")
                    {
                        //do stuff for a null configuration
                    }
                    showAnimationPane = bool.Parse(settingsFile.ReadValue("Settings", "showAnimation"));
                }
                catch
                {
                    //The settings file is probably bad or malformed, so let's try to recreate it.
                    writeInitialIni();
                    loadSettings();
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("We can't seem to find a Data directory alongside the NPC Editor executable. Would you like to run this application as a \"Portable\" app?", "No Data Directory Detected", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch(dr)
                {
                    case(DialogResult.Yes):
                        Utility.ModifyRegistry.ModifyRegistry
                        break;
                    case(DialogResult.No):
                        writeInitialIni();
                        loadSettings();
                        break;
                    case(DialogResult.Cancel):
                        Environment.Exit(0);
                        break;
                }
                writeInitialIni();
                loadSettings();
            }
        }
        void writeInitialIni()
        {
            try
            {
                if (!Directory.Exists(Environment.CurrentDirectory + @"\Data"))
                    Directory.CreateDirectory(Environment.CurrentDirectory + @"\Data");
                StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + @"\Data\settings.ini");
                sw.WriteLine("[Settings]");
                sw.WriteLine("showAnimation=true");
                sw.WriteLine("lastConfig=null");
                sw.WriteLine("lastConfigItem=null");
                sw.Flush();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Looks like we can't get write permission to write the default configurations and settings files!\nTry running this program as administrator before proceeding.\nException output: \nPlease press OK so the program can crash" + ex.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }
        void saveSettings()
        {
            //write settings file
            if (showAnimationPane)
                settingsFile.WriteValue("Settings", "showAnimation", showAnimationPane.ToString());
            else
                settingsFile.WriteValue("Settings", "showAnimation", "false");
            settingsFile.WriteValue("Settings", "lastConfig", currentConfig);
            foreach (MenuItem menu in selectConfigMenuItem.MenuItems)
            {
                if (menu.Checked == true)
                    settingsFile.WriteValue("Settings", "lastConfigItem", menu.Name);
            }
        }
        private void unCheckOthers(MenuItem keep)
        {
            foreach(MenuItem eachMenu in selectConfigMenuItem.MenuItems)
            {
                eachMenu.Checked = false;
            }
            keep.Checked = true;
        }
        #endregion

        private void ConfigMenuHandler(object sender, EventArgs e)
        {
            MenuItem selected = (MenuItem)sender;
            selected.Checked = true;
            MenuItem parent = (MenuItem)selected.Parent;
            unCheckOthers(selected);
            currentConfig = Environment.CurrentDirectory + @"\Data\" + selected.Text;
        }

        private void MainUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            if (showAnimationPane)
                showAnimationMenuItem.Checked = true;
            else
                showAnimationMenuItem.Checked = false;
            try
            {
                foreach (MenuItem menu in selectConfigMenuItem.MenuItems)
                {
                    if (menu.Name == settingsFile.ReadValue("Settings", "lastConfigItem"))
                        menu.Checked = true;
                    else
                        menu.Checked = false;
                }
            }
            catch (Exception ex) { }
            currentConfig = settingsFile.ReadValue("Settings", "lastConfig");
            curConfig = new IniFile(currentConfig + @"\lvl_npc.ini");
        }

        private void showAnimationMenuItem_Click(object sender, EventArgs e)
        {
            if (showAnimationMenuItem.Checked == true)
            {
                showAnimationMenuItem.Checked = false;
                showAnimationPane = false;
                //update UI when the time comes
            }
            else
            {
                showAnimationMenuItem.Checked = true;
                showAnimationPane = true;
                //update UI when the time comes
            }
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            
        }

        private void menuItem9_Click(object sender, EventArgs e)
        {
            if (currentConfig != "null")
            {
                NewConfig nc = new NewConfig(currentConfig);
                nc.ShowDialog();
            }
            else
            {    //reset items, when this is actually implemented of course
            }
        }
        //
    }
}
