using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ns;
using Setting;
using System.IO;

namespace smbxnpceditor
{
    public partial class NewConfig : Form
    {
        public NewConfig(string currentConfig)
        {
            curConfig = currentConfig;
            InitializeComponent();
            Font = SystemFonts.MessageBoxFont;
        }
        public string npcId = "npc-1";
        IniFile wohlConfig;
        string curConfig = null;
        

        private void existingConfigRb_CheckedChanged(object sender, EventArgs e)
        {
            int newHeight;
            int width;
            switch (existingConfigRb.Checked)
            {
                case(true):
                    listViewGroupBox.Visible = true;
                    newHeight = this.Size.Height + 447;
                    width = this.Size.Width;
                    this.Size = new System.Drawing.Size(width, newHeight);
                    existingConfigRb.Text = string.Format("From Existing Configuration - Selected {0}", npcId);
                    searchTb.Enabled = true;
                    break;
                case(false):
                    listViewGroupBox.Visible = false;
                    newHeight = this.Size.Height - 447;
                    width = this.Size.Width;
                    this.Size = new System.Drawing.Size(width, newHeight);
                    existingConfigRb.Text = "From Existing Configuration";
                    searchTb.Enabled = false;
                    npcId = "blank";
                    this.Update();
                    this.UpdateBounds();
                    break;
            }
        }

        private void reloadList()
        {
            try
            {
                foreach (ListViewItem lv in listView1.Items)
                {
                    lv.Remove();
                }
            }
            catch{}

            string[] files = System.IO.Directory.GetFiles(curConfig + @"\sprites", "npc-*.png");
            NumericComparer ns = new NumericComparer();
            Array.Sort(files, ns);
            ImageList sprites = new ImageList();
            sprites.ImageSize = new System.Drawing.Size(32, 32);
            foreach (var graphics in files)
            {
                if (graphics.Contains(".png"))
                {
                    Bitmap bmp = new Bitmap(Image.FromFile(graphics) as Bitmap);
                    sprites.Images.Add(bmp);
                    bmp = null;
                }
            }
            
            int index = 0;
            ListViewItem lvi;
            listView1.SmallImageList = sprites;
            listView1.BeginUpdate();
            foreach (var graphics in files)
            {
                if(index != 292)
                {
                    string npc = Path.GetFileNameWithoutExtension(graphics);

                    lvi = new ListViewItem();
                    lvi.Text = wohlConfig.ReadValue(npc, "name");
                    lvi.SubItems.Add(npc);
                    lvi.ImageIndex = index;
                    //lvi.ImageIndex = index;
                    listView1.Items.Add(lvi);
                    index++;
                }
                    
            }
            listView1.EndUpdate();
            this.listView1.Focus();
            this.listView1.Items[0].Selected = true;
        }

        private void NewConfig_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            wohlConfig = new IniFile(curConfig + @"\lvl_npc.ini");
            System.Threading.Thread load = new System.Threading.Thread(reloadList);
            load.Start();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 1)
            {
                npcId = listView1.SelectedItems[0].SubItems[1].Text;
                existingConfigRb.Text = String.Format("From Existing Configuration - Selected {0}", npcId);
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchTb.Text != "") 
            {
                for(int i = listView1.Items.Count - 1; i >= 0; i--) {
                    var item = listView1.Items[i];
                    if (item.Text.ToLower().Contains(searchTb.Text.ToLower())) {
                        //item.BackColor = SystemColors.Highlight;
                        //item.ForeColor = SystemColors.HighlightText;
                    }
                    else {
                        listView1.Items.Remove(item);
                    }
                }
                if (listView1.SelectedItems.Count == 1) {
                    //listView1.Focus();
                }
            }
            else   
            {
                reloadList();
            }
        }
    }
}
