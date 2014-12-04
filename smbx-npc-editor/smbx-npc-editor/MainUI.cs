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
using System.Deployment.Application;
using System.Threading;

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
        public SMBXNpc smbxNpcFile = new SMBXNpc();
        string curNpcId = "blank";
        //
        public MainUI()
        {
            /*FontFamily ff = new FontFamily(SystemFonts.MessageBoxFont.Name);
            Font usingg = new Font(SystemFonts.MessageBoxFont, SystemFonts.MessageBoxFont.Style);
            //Font = new Font(ff, 8, usingg.Style);*/
            this.Controls.Add(npcAnimator);
            showChangelog();
            InitializeComponent();
            loadSettings();
            compileConfigs();
            npcAnimator.setParentWindow(this);

            Version myVersion = new Version(Application.ProductVersion);

            if (ApplicationDeployment.IsNetworkDeployed)
                myVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;
            if (myVersion != null)
                this.Text = String.Format(this.Text.ToString(), myVersion.ToString());
            else
                this.Text = String.Format(this.Text.ToString(), Application.ProductVersion);
        }

        public void showChangelog()
        {
            if (!ApplicationDeployment.IsNetworkDeployed)
                return;

            if (!ApplicationDeployment.CurrentDeployment.IsFirstRun)
                return;
            Form changelog = new Form();
            Button closeButton = new Button();
            WebBrowser browser = new WebBrowser();
            changelog.Text = "Changelog";
            changelog.ShowIcon = false;
            changelog.Size = new System.Drawing.Size(450, 500);
            changelog.TopMost = true;
            //
            closeButton.Text = "Close";
            closeButton.Height = 100;
            closeButton.Dock = DockStyle.Bottom;
            //
            //browser.Site = "http://mrmiketheripper.x10.mx/smbx-npc-editor/changelog.html";
            browser.Url = new Uri("http://mrmiketheripper.x10.mx/smbx-npc-editor/changelog.html");
            browser.Dock = DockStyle.Top;
            browser.Height = changelog.Height - closeButton.Height;
            //
            changelog.Controls.Add(closeButton);
            changelog.Controls.Add(browser);
            closeButton.Click += closeButton_Click;
            changelog.StartPosition = FormStartPosition.CenterScreen;
            changelog.ShowDialog();
        }

        void closeButton_Click(object sender, EventArgs e)
        {
            Button sent = (Button)sender;
            Form parent = (Form)sent.Parent;
            parent.Close();
        }
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
                        File.Delete(Environment.CurrentDirectory + @"\temp.npctxt");
                        break;
                    case(DialogResult.No):
                        saveSettings();
                        File.Delete(Environment.CurrentDirectory + @"\temp.npctxt");
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
                File.Delete(Environment.CurrentDirectory + @"\temp.npctxt");
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

        /// <summary>
        /// Loads in the values from a temp file, after the TextEditor has been closed
        /// </summary>
        public void loadInValuesFromTemp()
        {
            smbxNpcFile = new SMBXNpc();
            if (File.Exists(Environment.CurrentDirectory + @"\temp.npctxt"))
            {
                smbxNpcFile.ReadFromTextFile(Environment.CurrentDirectory + @"\temp.npctxt");
                hasChanges = true;
            }
        }
        

        private void menuItem10_Click(object sender, EventArgs e)
        {
            smbx_npc_editor.IO.TextEditor textEdit = null;
            smbxNpcFile.WriteToTextFile(Environment.CurrentDirectory + @"\temp.npctxt");
            textEdit = new TextEditor(Environment.CurrentDirectory + @"\temp.npctxt", this);
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
                    curFile = of.FileName;
                    smbxNpcFile = new SMBXNpc();
                    try
                    { 
                        smbxNpcFile.ReadFromTextFile(curFile);
                        loadValuesFromSmbxNpc();
                    }
                    catch (BadNpcTextFileException ex)
                    {
                        MessageBox.Show(String.Format("An error occurred while trying to process the NPC Text File\n{0}", ex.Message), 
                            "Error Processing Text File", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error); 
                    }
                    //
                    hasDoneASaveAs = true;
                    if(File.Exists(npcAnimator.GetSpritePath(of.FileName)))
                    {
                        npcAnimator.setSprite(npcAnimator.GetSpritePath(of.FileName));
                    }
                    ///TODO: Load the values into the UI
                    break;
                case(DialogResult.Cancel):
                    break;
            }
        }

        public void openPassedFile(string fileName)
        {
            throw new NotImplementedException();
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
                smbxNpcFile.WriteToTextFile(curFile);
                String message = String.Format("File saved to {0} successfully!", curFile);
                MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hasChanges = false;
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

        /// <summary>
        /// Only call this function once we're absolutely sure that the SMBXNpc was read correctly!
        /// </summary>
        public void loadValuesFromSmbxNpc()
        {
            if(smbxNpcFile.en_gfxoffsetx)
            {
                xOffsetControl.enabledCheckBox.Checked = true;
                xOffsetControl.CurrentValue = smbxNpcFile.gfxoffsetx;
            }
            if (smbxNpcFile.en_gfxoffsety)
            {
                yOffsetControl.enabledCheckBox.Checked = true;
                yOffsetControl.CurrentValue = smbxNpcFile.gfxoffsety;
            }
            if (smbxNpcFile.en_width)
            {
                widthControl.enabledCheckBox.Checked = true;
                widthControl.CurrentValue = (int)smbxNpcFile.width;
            }
            if (smbxNpcFile.en_height)
            {
                heightControl.enabledCheckBox.Checked = true;
                heightControl.CurrentValue = (int)smbxNpcFile.height;
            }
            if (smbxNpcFile.en_gfxwidth)
            {
                gfxWidthControl.enabledCheckBox.Checked = true;
                gfxWidthControl.CurrentValue = smbxNpcFile.gfxwidth;
            }
            if (smbxNpcFile.en_gfxheight)
            {
                gfxHeightControl.enabledCheckBox.Checked = true;
                gfxHeightControl.CurrentValue = smbxNpcFile.gfxheight;
            }
            if (smbxNpcFile.en_score)
            {
                scoreControl.enabledCheckBox.Checked = true;
                scoreControl.SetSelectedIndex(smbxNpcFile.score);
            }
            if (smbxNpcFile.en_playerblock)
            {
                playerCollisionControl.enabledCheckBox.Checked = true;
                playerCollisionControl.checkValue.Checked = smbxNpcFile.playerblock;
            }
            if (smbxNpcFile.en_playerblocktop)
            {
                playerCollisionTopControl.enabledCheckBox.Checked = true;
                playerCollisionTopControl.checkValue.Checked = smbxNpcFile.playerblocktop;
            }
            if (smbxNpcFile.en_npcblock)
            {
                npcCollisionControl.enabledCheckBox.Checked = true;
                npcCollisionControl.checkValue.Checked = smbxNpcFile.npcblock;
            }
            if (smbxNpcFile.en_npcblocktop)
            {
                npcCollisionTopControl.enabledCheckBox.Checked = true;
                npcCollisionTopControl.checkValue.Checked = smbxNpcFile.npcblocktop;
            }
            if (smbxNpcFile.en_grabside)
            {
                grabSideControl.enabledCheckBox.Checked = true;
                grabSideControl.checkValue.Checked = smbxNpcFile.grabside;
            }
            if (smbxNpcFile.en_grabtop)
            {
                grabTopControl.enabledCheckBox.Checked = true;
                grabTopControl.checkValue.Checked = smbxNpcFile.grabtop;
            }
            if (smbxNpcFile.en_jumphurt)
            {
                jumpHurtControl.enabledCheckBox.Checked = true;
                jumpHurtControl.checkValue.Checked = smbxNpcFile.jumphurt;
            }
            if (smbxNpcFile.en_nohurt)
            {
                dontHurtControl.enabledCheckBox.Checked = true;
                dontHurtControl.checkValue.Checked = smbxNpcFile.nohurt;
            }
            if (smbxNpcFile.en_noblockcollision)
            {
                noBlockCollisionControl.enabledCheckBox.Checked = true;
                noBlockCollisionControl.checkValue.Checked = smbxNpcFile.noblockcollision;
            }
            if (smbxNpcFile.en_cliffturn)
            {
                turnOnCliffControl.enabledCheckBox.Checked = true;
                turnOnCliffControl.checkValue.Checked = smbxNpcFile.cliffturn;
            }
            if (smbxNpcFile.en_noyoshi)
            {
                cantBeEatenControl.enabledCheckBox.Checked = true;
                cantBeEatenControl.checkValue.Checked = smbxNpcFile.noyoshi;
            }
            if (smbxNpcFile.en_foreground)
            {
                foregroundControl.enabledCheckBox.Checked = true;
                foregroundControl.checkValue.Checked = smbxNpcFile.foreground;
            }
            if(smbxNpcFile.en_speed)
            {
                speedControl.enabledCheckBox.Checked = true;
                speedControl.CurrentValue = smbxNpcFile.speed;
            }
            if (smbxNpcFile.en_nofireball)
            {
                noFireBallControl.enabledCheckBox.Checked = true;
                noFireBallControl.checkValue.Checked = smbxNpcFile.nofireball;
            }
            if (smbxNpcFile.en_nogravity)
            {
                noGravityControl.enabledCheckBox.Checked = true;
                noGravityControl.checkValue.Checked = smbxNpcFile.nogravity;
            }
            if(smbxNpcFile.en_frames)
            {
                framesControl.enabledCheckBox.Checked = true;
                framesControl.CurrentValue = smbxNpcFile.frames;
            }
            if(smbxNpcFile.en_framespeed)
            {
                frameSpeedControl.enabledCheckBox.Checked = true;
                frameSpeedControl.CurrentValue = smbxNpcFile.framespeed;
            }
            if (smbxNpcFile.en_framespeed)
            {
                frameSpeedControl.enabledCheckBox.Checked = true;
                frameSpeedControl.CurrentValue = smbxNpcFile.framespeed;
            }
            if (smbxNpcFile.en_framestyle)
            {
                frameStyleControl.enabledCheckBox.Checked = true;
                frameStyleControl.SetSelectedIndex(smbxNpcFile.framestyle);
            }///come back to this
            if (smbxNpcFile.en_noiceball)
            {
                noIceControl.enabledCheckBox.Checked = true;
                noIceControl.checkValue.Checked = smbxNpcFile.noiceball;
            }
            if (smbxNpcFile.en_name)
            {
                //frameSpeedControl.enabledCheckBox.Checked = true;
                //frameSpeedControl.CurrentValue = smbxNpcFile.framespeed;
                nameControl.Text = smbxNpcFile.name;
            }
        }

        public void returnControlFromKey(string key)
        {
            switch(key)
            {
                case("gfxoffsetx"):
                    
                    break;
                case("gfxoffsety"):
                    break;
                case("height"):
                    break;
                case("width"):
                    break;
                case("gfxheight"):
                    break;
                case("gfxwidth"):
                    break;
                case("frames"):
                    break;
                case("framespeed"):
                    break;
                case("framestyle"):
                    break;
                case("foreground"):
                    break;
                case("playerblock"):
                    break;
                case("playerblocktop"):
                    break;
                case("npcblock"):
                    break;
                case("npcblocktop"):
                    break;
                case("noblockcollision"):
                    break;
                case("cliffturn"):
                    break;
                case("nogravity"):
                    break;
                case("score"):
                    break;
                case("grabside"):
                    break;
                case("grabtop"):
                    break;
                case("jumphurt"):
                    break;
                case("nohurt"):
                    break;
                case("noyoshi"):
                    break;
                case("speed"):
                    break;
                case("nofireball"):
                    break;
                case("noiceball"):
                    break;
                case("name"):
                    break;
            }
        }

        private void menuItem13_Click(object sender, EventArgs e)
        {
            SettingDialog sd = new SettingDialog();
            sd.ShowDialog();
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            SettingDialog sd = new SettingDialog(2);
            sd.ShowDialog();
        }
    }
}
