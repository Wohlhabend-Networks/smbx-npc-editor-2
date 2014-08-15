using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IniFileHandler;
using ns;
using System.IO;
using System.Threading;

namespace ini_editor
{
    public partial class Form1 : Form
    {
        IniFile ini = new IniFile();
        List<string> sectionsList = new List<string>();
        List<string> keysList = new List<string>();
        string parentNodeValue;
        string nodeKeyValue;
        //
        string curFileName;
        bool changed;
        bool isSection;
        int secNumber;
        int keyNumber;
        //
        IniFile.IniSection currentSection;
        string currentKey;
        string currentKeyValue;
        ExtendedTreeNode SELECTEDNODE;
        //

        public Form1()
        {
            Font = SystemFonts.MessageBoxFont;
            Form1.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
               
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "INI Files (*.ini)|*.ini|All Files (*.*)|*.*";
            switch (changed)
            {
                case(true):
                    DialogResult dr = MessageBox.Show("You have unsaved changes, would you like to save first?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (dr)
                    {
                        case(DialogResult.Yes):
                            save();
                            goto DialogResult;
                        case(DialogResult.No):
                            goto DialogResult;
                        case(DialogResult.Cancel):
                            goto LolSkipEverything;
                    }
                    break;
                case(false):
                    break;
            }
        DialogResult:
            if (of.ShowDialog() == DialogResult.OK)
            {
                curFileName = of.FileName; 
                this.Cursor = Cursors.WaitCursor;
                openIniFile();
            }
        LolSkipEverything:
            Console.WriteLine("Skipped");
        }

        private void iniSectionTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ExtendedTreeNode selected = (ExtendedTreeNode)iniSectionTreeView.SelectedNode;

            switch(selected.GetIntegerType())
            {
                    //0 is a section, 1 is a key, 2 is a value but 2 is just there as a just in case
                case(0):
                    currentSection = ini.GetSection(selected.Text);
                    SELECTEDNODE = selected;
                    editSectionLabel.Text = String.Format("Edit Section {0}", currentSection.Name.ToString());
                    secValueTextBox.Text = currentSection.Name.ToString();
                    break;
                case(1):
                    currentSection = ini.GetSection(selected.Parent.Text);
                    currentKey = selected.Text;
                    currentKeyValue = ini.GetKeyValue(currentSection.Name.ToString(), selected.Text);
                    //
                    editSectionLabel.Text = String.Format("Edit Section {0}", currentSection.Name.ToString());
                    secValueTextBox.Text = currentSection.Name.ToString();
                    //
                    editKeyLabel.Text = String.Format("Edit Section {0}", currentKey);
                    keyValueTextBox.Text = currentKey;
                    //
                    if (currentKeyValue != null)
                    {
                        string value = currentKeyValue;
                        currentKeyValue = value.Replace("\"", "");
                        valueTextBox.Text = currentKeyValue;
                        editValueLabel.Text = String.Format("Edit Value {0}", currentKey);
                    }
                    SELECTEDNODE = selected;
                    break;
                case(2):
                    //invalid????
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (SELECTEDNODE.GetIntegerType())
            {
                case(0):
                    ini.RenameSection(SELECTEDNODE.Text, secValueTextBox.Text);
                    SELECTEDNODE.Text = secValueTextBox.Text;
                    break;
                case(1):
                    MessageBox.Show("Section not selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case(2):
                    MessageBox.Show("Section not selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            changed = true;
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            save();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
                switch (changed)
                {
                    case (true):
                        DialogResult dr = MessageBox.Show("You have unsaved changes, would you like to save first?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        switch (dr)
                        {
                            case (DialogResult.Yes):
                                save();
                                e.Cancel = false;
                                break;
                            case (DialogResult.No):
                                e.Cancel = false;
                                Environment.Exit(0);
                                break;
                            case (DialogResult.Cancel):
                                e.Cancel = true;
                                break;
                        }
                        break;
                    case (false):
                        Environment.Exit(0);
                        break;
                }  
        }

        private void addSectionButton_Click(object sender, EventArgs e)
        {
            ExtendedTreeNode addSection = new ExtendedTreeNode(String.Format("NewSection{0}", secNumber), 0);
            iniSectionTreeView.Nodes.Add(addSection);
            ini.AddSection(addSection.Text);
            secNumber++;
        }

        private void addKeyButton_Click(object sender, EventArgs e)
        {
            try
            {
                ExtendedTreeNode selected = (ExtendedTreeNode)iniSectionTreeView.SelectedNode;

                switch (selected.GetIntegerType())
                {
                    case (0):
                        ExtendedTreeNode addKey = new ExtendedTreeNode(String.Format("NewKey{0}", keyNumber), 1);
                        selected.Nodes.Add(addKey);
                        IniFile.IniSection selectedSection = ini.GetSection(selected.Text);
                        selectedSection.AddKey(String.Format("NewKey{0}", keyNumber));
                        keyNumber++;
                        break;
                    case (1):
                        MessageBox.Show("Please select a section node", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case (2):
                        MessageBox.Show("Please select a section node", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Please select a section node!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void saveKeyButton_Click(object sender, EventArgs e)
        {
            switch (SELECTEDNODE.GetIntegerType())
            {
                case (0):
                    MessageBox.Show("Key not selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case (1):
                    ini.RenameKey(SELECTEDNODE.Parent.Text, SELECTEDNODE.Text, keyValueTextBox.Text);
                    SELECTEDNODE.Text = keyValueTextBox.Text;
                    break;
                case (2):
                    MessageBox.Show("Key not selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            changed = true;
        }

        private void saveValueButton_Click(object sender, EventArgs e)
        {
            switch (SELECTEDNODE.GetIntegerType())
            {
                case (0):
                    MessageBox.Show("[error intensifies]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case (1):
                    ini.SetKeyValue(SELECTEDNODE.Parent.Text, SELECTEDNODE.Text, valueTextBox.Text);
                    break;
                case (2):
                    MessageBox.Show("[error intensifies]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            changed = true;
        }

        #region User Defined Voids
        void clear()
        {
            foreach (TreeNode node in iniSectionTreeView.Nodes)
            {
                node.Remove();
            }
            changed = false;
        }

        void exit()
        {
            Application.Exit();
        }

        void save()
        {
            if (curFileName != null)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    ini.Save(curFileName);
                    MessageBox.Show(String.Format("File {0} saved to {1} successfully!", Path.GetFileName(curFileName), Path.GetFullPath(curFileName)),
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    changed = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Error while saving file {0}\n\n{1}", curFileName, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Cursor = Cursors.Arrow;
            }
        }

        void openIniFile()
        {
            clear();
            try
            {
                iniSectionTreeView.BeginUpdate();
                ini.Load(curFileName);
                foreach (IniFile.IniSection s in ini.Sections)
                {
                    sectionsList.Add(s.Name);
                    foreach (IniFile.IniSection.IniKey k in s.Keys)
                    {
                        keysList.Add(k.Name);
                    }
                }

                foreach (IniFile.IniSection s in ini.Sections)
                {
                    ExtendedTreeNode ex = new ExtendedTreeNode(s.Name, 0);
                    foreach (IniFile.IniSection.IniKey k in s.Keys)
                    {
                        ExtendedTreeNode keyy = new ExtendedTreeNode(k.Name, 1);
                        ex.Nodes.Add(keyy);
                    }
                    iniSectionTreeView.Nodes.Add(ex);
                }
                iniSectionTreeView.TreeViewNodeSorter = new NumericComparer();
                iniSectionTreeView.EndUpdate();
                this.Text = String.Format("C# INI Editor - {0}", Path.GetFileName(curFileName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Text = "C# INI Editor";
                curFileName = null;
            }
            this.Cursor = Cursors.Arrow;
        }
        #endregion

    }
}
