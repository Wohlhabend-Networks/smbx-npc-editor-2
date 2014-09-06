using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace smbx_npc_editor.IO
{
    public partial class TextEditor : Form
    {
        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        MainUI _parentWindow;
        string curFileName;
        bool hasEdited = false;
        bool hasSaved = false;
        public Regex graphicsWords = new Regex(@"\b(gfxheight|gfxwidth|gfxoffsetx|gfxoffsety|frames|framespeed|framestyle|foreground)\b");
        public Regex physicsWords = new Regex(@"\b(height|width|playerblock|playerblocktop|npcblock|npcblocktop|noblockcollision|cliffturn|nogravity)\b");
        public Regex gameWords = new Regex(@"\b(score|grabside|grabtop|jumphurt|nohurt|noyoshi|speed|nofireball|noiceball)\b");
        public Regex worthlessNameOnly = new Regex(@"\b(name)\b");
        public Regex stringSurrounding = new Regex("\".+\"");
        public Regex ints = new Regex(@"^\d$");

        public TextEditor(string fileName, MainUI parentWindow)
        {
            curFileName = fileName;
            if (File.Exists(curFileName))
                hasSaved = true;
            _parentWindow = parentWindow;
            InitializeComponent();
        }
        public TextEditor(string fileName, bool hasChanges, MainUI parentWindow)
        {
            _parentWindow = parentWindow;
            curFileName = fileName;
            if (File.Exists(curFileName) && !hasChanges)
                hasSaved = true;
            else
                hasSaved = false;
            InitializeComponent();
        }
        public TextEditor(string[] keyArray, string fileName, MainUI parentWindow)
        {
            _parentWindow = parentWindow;
            for (int i = 0; i < keyArray.Length; i++ )
            {
                richTextEditor.AppendText(keyArray[i].ToString() + "\n");
            }
            hasSaved = false;
            InitializeComponent();
        }
        public TextEditor(string[] keyArray, string fileName, bool hasChanges, MainUI parentWindow)
        {
            _parentWindow = parentWindow;
            for (int i = 0; i < keyArray.Length; i++)
            {
                richTextEditor.AppendText(keyArray[i].ToString() + "\n");
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
        public TextEditor(string[] keyArray, MainUI parentWindow)
        {
            _parentWindow = parentWindow;
            InitializeComponent();
            for (int i = 0; i < keyArray.Length; i++)
            {
                richTextEditor.AppendText(keyArray[i].ToString() + "\n");
            }
            hasSaved = false;
            
        }

        private void TextEditor_Load(object sender, EventArgs e)
        {

        }

        private void highlightTimer_Tick(object sender, EventArgs e)
        {
           
        }

        private void richTextEditor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (richTextEditor.SelectedText.Length > 0)
                    richTextEditor.DeselectAll();
                LockWindowUpdate(richTextEditor.Handle);
                int selPos = richTextEditor.SelectionStart;
                richTextEditor.SelectAll();
                richTextEditor.SelectionColor = Color.Black;
                richTextEditor.SelectionStart = selPos;
                foreach (Match graphicsMatch in graphicsWords.Matches(richTextEditor.Text))
                {
                    richTextEditor.Select(graphicsMatch.Index, graphicsMatch.Length);
                    richTextEditor.SelectionColor = Color.DodgerBlue;
                    richTextEditor.SelectionStart = selPos;
                    richTextEditor.SelectionColor = Color.Black;
                }
                foreach (Match physicsMatch in physicsWords.Matches(richTextEditor.Text))
                {
                    richTextEditor.Select(physicsMatch.Index, physicsMatch.Length);
                    richTextEditor.SelectionColor = Color.Blue;
                    richTextEditor.SelectionStart = selPos;
                    richTextEditor.SelectionColor = Color.Black;
                }
                foreach (Match gamesMatch in gameWords.Matches(richTextEditor.Text))
                {
                    richTextEditor.Select(gamesMatch.Index, gamesMatch.Length);
                    richTextEditor.SelectionColor = Color.Purple;
                    richTextEditor.SelectionStart = selPos;
                    richTextEditor.SelectionColor = Color.Black;
                }
                foreach (Match intMatch in ints.Matches(richTextEditor.Text))
                {
                    richTextEditor.Select(intMatch.Index, intMatch.Length);
                    richTextEditor.SelectionColor = Color.Green;
                    richTextEditor.SelectionStart = selPos;
                    richTextEditor.SelectionColor = Color.Black;
                }
                foreach(Match nameMatch in worthlessNameOnly.Matches(richTextEditor.Text))
                {
                    richTextEditor.Select(nameMatch.Index, nameMatch.Length);
                    richTextEditor.SelectionColor = Color.Fuchsia;
                    richTextEditor.SelectionStart = selPos;
                    richTextEditor.SelectionColor = Color.Black;
                }
                foreach(Match quotesMatch in stringSurrounding.Matches(richTextEditor.Text))
                {
                    //Match quotesMatch = stringSurrounding.Match(richTextEditor.Text);
                    richTextEditor.Select(quotesMatch.Index, quotesMatch.Length);
                    richTextEditor.SelectionColor = Color.Green;
                    richTextEditor.SelectionStart = selPos;
                    richTextEditor.SelectionColor = Color.Black;
                }
            }
            finally { LockWindowUpdate(IntPtr.Zero); }
        }

        private void TextEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            var split = richTextEditor.Text.Split(new char[] { '\n' }, richTextEditor.Lines.Length);
            List<string> input = new List<string>();

            for (int i = 0; i < split.Length; i++ )
            {
                input.Add(split[i].ToString());
            }
            _parentWindow.npcfile.StringArrayToKeyValuePair(input.ToArray());
            _parentWindow.loadInValues(_parentWindow.Controls);
            _parentWindow.Show();
        }
    }
}
