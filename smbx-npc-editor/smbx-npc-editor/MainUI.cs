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
        IniFile settingsFile = new IniFile(Environment.CurrentDirectory + @"\Data\settings.ini");
        public IniFile curConfig;
        public string currentConfig;
        bool showAnimationPane = true;
        bool runPortable = false;
        bool hasChanges = false;
        bool hasDoneASaveAs = false;
        string curFile = null;
        //
        int animatorWidth;
        //
        public NpcConfigFile npcfile = new NpcConfigFile(true);
        string curNpcId = "blank";
        //
        public MainUI()
        {
            FontFamily ff = new FontFamily(SystemFonts.MessageBoxFont.Name);
            Font usingg = new Font(SystemFonts.MessageBoxFont, SystemFonts.MessageBoxFont.Style);
            //Font = new Font(ff, 8, usingg.Style);
            this.Controls.Add(npcAnimator);
            InitializeComponent();
            loadSettings();
            compileConfigs();
            npcAnimator.setParentWindow(this);
            GetUserControls(this.Controls);
        }

        private void GetUserControls(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is UserControl)
                {
                    if (c is SpinnerControlValue)
                    {
                        SpinnerControlValue svc = (SpinnerControlValue)c;
                        svc.valueSpinner.ValueChanged += (sender, e) => valueSpinner_ValueChanged(sender, e, svc);
                        svc.enabledCheckBox.CheckedChanged += (sender, e) => enabledCheckBox_CheckedChanged(sender, e, svc);
                    }
                    else if (c is ComboBoxControlValue)
                    {
                        ComboBoxControlValue cbcv = (ComboBoxControlValue)c;
                        cbcv.ComboValue.SelectedIndexChanged += comboValue_SelectedIndexChanged;
                        cbcv.enabledCheckBox.CheckedChanged += (sender, e) => combo_enabledCheckBox_CheckedChanged(sender, e, cbcv);
                    }
                    else if (c is CheckBoxValue)
                    {
                        CheckBoxValue cbv = (CheckBoxValue)c;
                        cbv.checkValue.CheckedChanged += (sender, e) => checkValue_CheckedChanged(sender, e, cbv);
                        cbv.enabledCheckBox.CheckedChanged += (sender, e) => cb_enabledCheckBox_CheckedChanged(sender, e, cbv);
                    }
                }
                if (c.Controls.Count > 0)
                    GetUserControls(c.Controls);
            }
        }
        #region Control Events
        private void nameControl_TextChanged(object sender, EventArgs e)
        {
            if (nameControl.Text == String.Empty)
                npcfile.RemoveValue("name");
            else
                npcfile.AddValue("name", String.Format("\"{0}\"", nameControl.Text));
        }

        void enabledCheckBox_CheckedChanged(object sender, object e, SpinnerControlValue sv)
        {
            CheckBox check = (CheckBox)sender;
            if(check.Checked)
            {
                npcfile.AddValue(sv.valueSpinner.Tag.ToString(), sv.valueSpinner.Value.ToString());
                hasChanges = true;
            }
            else
            {
                npcfile.RemoveValue(sv.valueSpinner.Tag.ToString());
                hasChanges = true;
            }
        }

        void valueSpinner_ValueChanged(object sender, EventArgs e, SpinnerControlValue svc)
        {
            if (!svc.isReset && svc.enabledCheckBox.Checked)
            {
                NumericUpDown updown = (NumericUpDown)sender;
                npcfile.AddValue(updown.Tag.ToString(), updown.Value.ToString());
                hasChanges = true;
            }
        }
        //
        void cb_enabledCheckBox_CheckedChanged(object sender, object e, CheckBoxValue cb)
        {
            CheckBox check = (CheckBox)sender;
            if(check.Checked)
            {
                switch(cb.checkValue.Checked)
                {
                    case(true):
                        npcfile.AddValue(cb.checkValue.Tag.ToString(), "1");
                        hasChanges = true;
                        break;
                    case(false):
                        npcfile.AddValue(cb.checkValue.Tag.ToString(), "0");
                        hasChanges = true;
                        break;
                }
            }
            else
            {
                npcfile.RemoveValue(cb.checkValue.Tag.ToString());
                hasChanges = true;
            }
        }
        void checkValue_CheckedChanged(object sender, EventArgs e, CheckBoxValue cb)
        {
            CheckBox check = (CheckBox)sender;
            if (!cb.isReset && cb.enabledCheckBox.Checked)
            {
                switch (check.Checked)
                {
                    case (true):
                        npcfile.AddValue(check.Tag.ToString(), "1");
                        hasChanges = true;
                        break;
                    case (false):
                        npcfile.AddValue(check.Tag.ToString(), "0");
                        hasChanges = true;
                        break;
                }
            }
        }
        //
        void combo_enabledCheckBox_CheckedChanged(object sender, EventArgs e, ComboBoxControlValue cbcv)
        {
            CheckBox check = (CheckBox)sender;
            switch(check.Checked)
            {
                case(true):
                    if (cbcv.GetSelectedIndex().ToString() != "-1")
                    {
                        npcfile.AddValue(cbcv.ComboValue.Tag.ToString(), cbcv.GetSelectedIndex().ToString());
                        hasChanges = true;
                    }
                    break;
                case(false):
                    npcfile.RemoveValue(cbcv.ComboValue.Tag.ToString());
                    hasChanges = true;
                    break;
            }
        }
        void comboValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            if(combo.SelectedIndex.ToString() != "-1")
            {npcfile.AddValue(combo.Tag.ToString(), combo.SelectedIndex.ToString());
            hasChanges = true;}
        }
        #endregion
        #region crying
        void ResetItems(Control.ControlCollection controls, bool resetFile)
        {
            foreach(Control c in controls)
            {
                if(c is UserControl)
                {
                    if(c is SpinnerControlValue)
                    {
                        SpinnerControlValue svc = (SpinnerControlValue)c;
                        svc.isReset = true;
                        svc.Reset();
                        if (svc.ValueTag == "framespeed")
                            svc.CurrentValue = 8;
                    }
                    if(c is ComboBoxControlValue)
                    {
                        ComboBoxControlValue cbcv = (ComboBoxControlValue)c;
                        cbcv.Reset();
                    }
                    if(c is CheckBoxValue)
                    {
                        CheckBoxValue cbv = (CheckBoxValue)c;
                        cbv.isReset = true;
                        cbv.Reset();
                    }
                }
                if (c.Controls.Count > 0)
                    ResetItems(c.Controls, resetFile);
            }
            nameControl.Text = "";
            if (resetFile)
            {
                ///TODO: Reset the animator and NPC Name stuff. Along with the title and any other loose variables.
                npcfile.Clear();
                //
                undoResetFlag(this.Controls);
                //
                hasChanges = false;
                curFile = null;
            }
        }

        void undoResetFlag(Control.ControlCollection controls)
        {
            foreach(Control c in controls)
            {
                if(c is UserControl)
                {
                    if(c is SpinnerControlValue)
                    {
                        SpinnerControlValue svc = (SpinnerControlValue)c;
                        svc.isReset = false;
                    }
                    else if(c is CheckBoxValue)
                    {
                        CheckBoxValue cbv = (CheckBoxValue)c;
                        cbv.isReset = false;
                    }
                }
                if (c.Controls.Count > 0)
                    undoResetFlag(c.Controls);
            }
        }

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
            if(File.Exists(Environment.CurrentDirectory + @"\Data\settings.ini"))
            {
                try
                {
                    currentConfig = settingsFile.ReadValue("Settings", "lastConfig");
                    if(currentConfig == "null")
                    {
                        //do null stuff
                    }
                    showAnimationPane = bool.Parse(settingsFile.ReadValue("Settings", "showAnimation"));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Utility.ModifyRegistry.ModifyRegistry mr = new Utility.ModifyRegistry.ModifyRegistry();
                try
                {
                    string runPortableStr = mr.Read("runPortable");
                    Console.WriteLine("RegKey 'runPortable' is equal to {0}", runPortableStr.ToString());
                    if (runPortableStr == null)
                        throw new InvalidDataException();
                    else if (runPortableStr == "true")
                    {
                        runPortable = true;
                        runPortableEvents();
                    }
                    else if (runPortableStr == "false")
                    { runPortable = false; writeInitialIni(); loadSettings(); }
                    else
                        throw new InvalidDataException();
                }
                catch
                {
                    DialogResult dr = MessageBox.Show("We can't seem to find a Data directory alongside the NPC Editor executable. Would you like to run this application as a \"Portable\" app?", "No Data Directory Detected", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    switch (dr)
                    {
                        case (DialogResult.Yes):
                            mr.Write("runPortable", "true");
                            break;
                        case (DialogResult.No):
                            mr.Write("runPortable", "false");
                            writeInitialIni();
                            loadSettings();
                            break;
                        case (DialogResult.Cancel):
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
        void runPortableEvents()
        {
            MenuItem runPortableMenu = new MenuItem("Run portable (stored in registry)", runPortableMenu_Clicked);
            if (runPortable)
            {
                runPortableMenu.Checked = true;
                MenuItem sep = new MenuItem("-");
                editMenu.MenuItems.Add(sep);
                editMenu.MenuItems.Add(runPortableMenu);
            }
        }

        private void runPortableMenu_Clicked(object sender, EventArgs e)
        {
            Utility.ModifyRegistry.ModifyRegistry mr = new Utility.ModifyRegistry.ModifyRegistry();
            MenuItem portMenu = (MenuItem)sender;
            if(portMenu.Checked == true)
            {
                portMenu.Checked = false;
                mr.Write("runPortable", "false");
                Console.WriteLine("Writing key 'runPortable' to registry with value 'false'");
            }
            else
            {
                portMenu.Checked = true;
                mr.Write("runPortable", true);
                Console.WriteLine("Writing key 'runPortable' to registry with value 'true'");
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
                settingsFile.WriteValue("Settings", "showAnimation", "true");
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
            if(hasChanges)
            {
                DialogResult dr = MessageBox.Show("You have unsaved changes, would you like to save these before closing?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                switch(dr)
                {
                    case(DialogResult.Yes):
                        if (curFile != null)
                            if (File.Exists(curFile))
                                saveOnly();
                            else
                                saveAs();
                        else
                            saveAs();
                        saveSettings();
                        break;
                    case(DialogResult.No):
                        saveSettings();
                        Environment.Exit(0);
                        break;
                    case(DialogResult.Cancel):
                        e.Cancel = true;
                        break;
                }
            }
            else
            {
                saveSettings();
                Environment.Exit(0);
            }
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            animatorWidth = npcAnimator.Width;
            if (showAnimationPane)
            {
                showAnimationMenuItem.Checked = true;
            }
            else
            { 
                showAnimationMenuItem.Checked = false;
                npcAnimator.Visible = false;
                this.UpdateBounds();
            }
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
            catch (Exception ex) { Console.WriteLine("Not a problem but, {0}", ex.Message); }
            currentConfig = settingsFile.ReadValue("Settings", "lastConfig");
            curConfig = new IniFile(currentConfig + @"\lvl_npc.ini");
        }

        private void showAnimationMenuItem_Click(object sender, EventArgs e)
        {
            updateAnimatorVisibility(false);
        }

        void updateAnimatorVisibility(bool initial)
        {
            if (showAnimationMenuItem.Checked == true)
            {
                showAnimationMenuItem.Checked = false;
                showAnimationPane = false;
                //update UI when the time comes
                int curHeight = this.Height;
                
                npcAnimator.Visible = false;
                this.UpdateBounds();
            }
            else
            {
                showAnimationMenuItem.Checked = true;
                showAnimationPane = true;
                int curHeight = this.Height;
                npcAnimator.Visible = true;
                this.UpdateBounds();
                //update UI when the time comes
            }
        }

        private void menuItem9_Click(object sender, EventArgs e)
        {
            if (currentConfig != "null")
            {
                NewConfig nc = new NewConfig(currentConfig);
                DialogResult dr = nc.ShowDialog();
                switch(dr)
                {
                    case(DialogResult.OK):
                        ResetItems(this.Controls, true);
                        curNpcId = nc.npcId;
                        Console.WriteLine("Selected NPC ID was {0}", curNpcId);
                        break;
                    case(DialogResult.Cancel):
                        break;
                }
            }
            else
            {    //reset items, when this is actually implemented of course
                ResetItems(this.Controls, true);
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void loadDefaultsFromIni(Control.ControlCollection controls, List<string> dontTouchThis)
        {
            foreach(Control c in controls)
            {
                if(c is UserControl)
                {
                    if(c is SpinnerControlValue)
                    {
                        SpinnerControlValue svc = (SpinnerControlValue)c;
                        foreach(var item in dontTouchThis)
                        {
                            if(svc.ValueTag != item)
                            {
                                //fill in default value
                            }
                        }
                    }
                    //
                }
                //
            }
            //
        }

        public void loadInValues(Control.ControlCollection controls)
        {
            npcfile.isOpening = true;
            foreach (Control c in controls)
            {
                if (c is UserControl)
                {
                    if (c is SpinnerControlValue)
                    {
                        SpinnerControlValue svc = (SpinnerControlValue)c;
                        if (npcfile.GetKeyValue(svc.ValueTag) != null)
                        {
                            svc.CurrentValue = int.Parse(npcfile.GetKeyValue(svc.ValueTag));
                            svc.enabledCheckBox.Checked = true;
                        }
                        else
                        {
                            svc.CurrentValue = svc.MinimumValue;
                            svc.enabledCheckBox.Checked = false;
                        }
                    }
                    else if (c is ComboBoxControlValue)
                    {
                        ComboBoxControlValue cbcv = (ComboBoxControlValue)c;
                        if (npcfile.GetKeyValue(cbcv.ValueTag) != null)
                        {
                            cbcv.SetSelectedIndex(int.Parse(npcfile.GetKeyValue(cbcv.ValueTag)));
                            cbcv.enabledCheckBox.Checked = true;
                        }
                        else
                        {
                            cbcv.SetSelectedIndex(-1);
                            cbcv.enabledCheckBox.Checked = false;
                        }
                    }
                    else if (c is CheckBoxValue)
                    {
                        CheckBoxValue cbv = (CheckBoxValue)c;
                        if(npcfile.GetKeyValue(cbv.ValueTag) != null)
                        {
                            switch(int.Parse(npcfile.GetKeyValue(cbv.ValueTag)))
                            {
                                case(1):
                                    cbv.ValueChecked = true;
                                    cbv.enabledCheckBox.Checked = true;
                                    break;
                                case(0):
                                    cbv.ValueChecked = false;
                                    cbv.enabledCheckBox.Checked = true;
                                    break;
                            }
                        }
                        else
                        {
                            cbv.ValueChecked = false;
                            cbv.enabledCheckBox.Checked = false;
                        }
                    }
                }
                if (c.Controls.Count > 0)
                    loadInValues(c.Controls);
            }
            if (npcfile.GetKeyValue("name") != null)
            {
                string value = npcfile.GetKeyValue("name");
                if (value.Contains('\"'))
                {
                    nameControl.Text = value.Replace("\"", "");
                }
            }
            npcfile.isOpening = false;
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            smbx_npc_editor.IO.TextEditor textEdit = null;
            if(curFile == null)
            {
                textEdit = new TextEditor(npcfile.ExportToStringArray(), this);
            }
            else if(curFile != null && hasChanges)
            {
                textEdit = new TextEditor(npcfile.ExportToStringArray(), curFile, hasChanges, this);
            }
            else if(curFile != null && !hasChanges)
            {
                textEdit = new TextEditor(curFile, this);
            }
            if (textEdit != null)
            { textEdit.Show(); this.Hide(); }
            else
                Console.WriteLine("Lolwut, not showing");
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "SMBX NPC Text Files (npc-*.txt)|npc-*.txt|Plain Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            of.Title = "Select an NPC Text File";
            DialogResult dr = of.ShowDialog();
            switch(dr)
            {
                case(DialogResult.OK):
                    ResetItems(this.Controls, true);
                    npcfile.Clear();
                    npcfile.Load(of.FileName);
                    curFile = of.FileName;
                    loadInValues(this.Controls);
                    hasDoneASaveAs = true;
                    if(File.Exists(npcAnimator.GetSpritePath(of.FileName)))
                    {
                        npcAnimator.setSprite(npcAnimator.GetSpritePath(of.FileName));
                    }
                    break;
                case(DialogResult.Cancel):
                    break;
            }
        }

        private void menuItem11_Click(object sender, EventArgs e)
        {
            if (curFile != null)
                if (File.Exists(curFile))
                    saveOnly();
                else
                    saveAs();
            else
                saveAs();
        }

        void saveAs()
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "SMBX NPC Text Files (npc-*.txt)|npc-*.txt|Plain Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (curNpcId != "blank")
                sf.FileName = String.Format("{0}.txt", curNpcId);
            else
                sf.FileName = "npc-.txt";
            DialogResult dr = sf.ShowDialog();
            
            switch (dr)
            {
                case (DialogResult.OK):
                    curFile = sf.FileName;
                    hasDoneASaveAs = true;
                    saveOnly();
                    break;
                case (DialogResult.Cancel):
                    break;
            }
        }
        void saveOnly()
        {
            try
            {
                npcfile.Save(curFile, true);
                String message = String.Format("File saved to {0} successfully!", curFile);
                MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                String errorMessage = string.Format("An error ocurred while trying to save to {0}:\n{1}", curFile, ex.Message);
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string GetNpcId(string fullPath)
        {
            try
            {
                return Path.GetFileNameWithoutExtension(fullPath);
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("An error occurred while trying to get the NPC's ID:\n{0}\nThe 'fullPath' passed is: {1}", ex.Message, fullPath),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            saveAs();
        }
        //
    }
}
