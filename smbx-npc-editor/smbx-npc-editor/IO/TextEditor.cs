using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace smbx_npc_editor.IO
{
    public partial class TextEditor : Form
    {
        string curFileName;
        bool hasEdited = false;
        bool hasSaved = false;

        public TextEditor(string fileName)
        {
            curFileName = fileName;
            if (File.Exists(curFileName))
                hasSaved = true;
            InitializeComponent();
        }
        public TextEditor(string fileName, bool hasChanges)
        {
            curFileName = fileName;
            if (File.Exists(curFileName) && !hasChanges)
                hasSaved = true;
            else
                hasSaved = false;
            InitializeComponent();
        }
        public TextEditor(string[] keyArray, string fileName)
        {
            for (int i = 0; i < keyArray.Length; i++ )
            {
                richTextEditor.AppendText(keyArray[i].ToString());
            }
            hasSaved = false;
            InitializeComponent();
        }
        public TextEditor(string[] keyArray, string fileName, bool hasChanges)
        {
            for (int i = 0; i < keyArray.Length; i++)
            {
                richTextEditor.AppendText(keyArray[i].ToString());
            }
            if(fileName != null && !hasChanges)
            {
                curFileName = fileName;
                hasSaved = true;
            }
            else if(fileName != null && hasChanges)
            {
                curFileName = fileName;
                hasSaved = false;
            }
            else
            {
                hasSaved = false;
            }
            hasSaved = false;
            InitializeComponent();
        }
        public TextEditor(string[] keyArray)
        {
            InitializeComponent();
            for (int i = 0; i < keyArray.Length; i++)
            {
                richTextEditor.AppendText(keyArray[i].ToString() + "\n");
            }
            hasSaved = false;
            
        }
    }
}
