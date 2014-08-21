using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using smbx_npc_editor.IO;

namespace smbx_npc_editor
{
    public partial class MainUI : Form
    {
        NpcConfigFile npcfile = new NpcConfigFile();

        public MainUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "NPC Text Files (npc-*.txt)|npc-*.txt|All Files (*.*)|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                npcfile.Clear();
                npcfile.Load(of.FileName);
                Console.WriteLine("Requesting gfxwidth..");
                string tryinglol = npcfile.GetKeyValue("gfxwidth");
                if (tryinglol != null)
                    Console.WriteLine("gfxwidth is {0}!!!!!!!!", tryinglol);
            }
        }
    }
}
