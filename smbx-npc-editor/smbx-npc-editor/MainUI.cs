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
        NpcConfigFile npcfile = new NpcConfigFile();
        IniFile settingsFile = new IniFile(Environment.CurrentDirectory + @"\Data\settings.ini");
        public IniFile curConfig;
        public string currentConfig;
        bool showAnimationPane;
        //

        public MainUI()
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
            compileConfigs();
            loadSettings();
        }
        #region crying
        void compileConfigs()
        {
            int count = 0;
            List<string> dirs = new List<string>();
            foreach(var dir in Directory.GetDirectories(Environment.CurrentDirectory + @"\Data"))
            {
                count++;
                dirs.Add(dir);
            }
            MenuItem[] items = new MenuItem[count];
            bool add = true;
            for(int i = 0; i < items.Length; i++)
            {
                string dirName = Path.GetFileName(dirs[i]);
                if (dirName == "tools")
                    add = false;
                items[i] = new MenuItem();
                items[i].Name = "configItem" + i;
                items[i].Text = dirName;
                items[i].RadioCheck = true;
                items[i].Click += new EventHandler(ConfigMenuHandler);
                if(add)
                    selectConfigMenuItem.MenuItems.Add(items[i]);
                add = true;
            }
        }
        void loadSettings()
        {
            currentConfig = settingsFile.ReadValue("Settings", "lastConfig");
            showAnimationPane = bool.Parse(settingsFile.ReadValue("Settings", "showAnimation"));
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
            NewConfig nc = new NewConfig(currentConfig);
            nc.ShowDialog();
        }
        //
    }
}
