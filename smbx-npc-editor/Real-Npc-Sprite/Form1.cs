using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Setting;
using ns;
using System.IO;
using System.Drawing.Imaging;

namespace Real_Npc_Sprite
{
    public partial class Form1 : Form
    {
        Bitmap originalImage;
        Bitmap originalMaskImage;
        Bitmap maskImage;
        Bitmap maskedImage;
        //
        IniFile wohlConfig;
        string fullPath;
        string fileOnly;
        int width;
        int height;
        int xOffset;
        int yOffset;
        bool useOffsetVal = false;
        Bitmap bmp;
        int curListIndex;
        List<string> npcList = new List<string>();
        string fileNoExt;
        //
        bool hasMask = false;
        bool dontAskDontTell = false;
        //

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            curDirectoryLabel.Text = Environment.CurrentDirectory + @"\npc";
            
            if (!File.Exists(Environment.CurrentDirectory + @"\lvl_npc.ini"))
            {
                if (!Directory.Exists(Environment.CurrentDirectory + @"\npc"))
                {
                    Application.Exit();
                }
            }

            if (!Directory.Exists(Environment.CurrentDirectory + @"\converted"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\converted");
            }
            wohlConfig = new IniFile(Environment.CurrentDirectory + @"\lvl_npc.ini");
            string filePath = Environment.CurrentDirectory + @"\npc";
            string[] files = System.IO.Directory.GetFiles(filePath);
            NumericComparer ns = new NumericComparer();
            Array.Sort(files, ns);
            foreach (var graphics in files)
            {
                string name = Path.GetFileName(graphics.ToString());
                if(!graphics.EndsWith("m.gif", StringComparison.CurrentCultureIgnoreCase))
                    if(!graphics.EndsWith("Thumbs.db", StringComparison.CurrentCultureIgnoreCase))
                        npcList.Add(graphics);
                
            }
            showNextImage(false);
        }
        
        public void showNextImage(bool add)
        {
            if (add) { curListIndex++; }
            int length = npcList.Count;
            if (curListIndex >= length)
                return;
            if (!File.Exists(npcList[curListIndex].ToString()))
                return;
            else
            {
                //C:\blahblahblah
                fullPath = npcList[curListIndex].ToString();
                //npc-1.gif
                fileOnly = Path.GetFileName(fullPath);
                //npc-1
                fileNoExt = Path.GetFileNameWithoutExtension(fullPath);

                currentNpc.Text = wohlConfig.ReadValue(fileNoExt, "name");
                gfxWidth.Text = wohlConfig.ReadValue(fileNoExt, "gfx-width");
                gfxHeight.Text = wohlConfig.ReadValue(fileNoExt, "gfx-height");
                width = int.Parse(wohlConfig.ReadValue(fileNoExt, "gfx-width"));
                height = int.Parse(wohlConfig.ReadValue(fileNoExt, "gfx-height"));
                xOffset = int.Parse(wohlConfig.ReadValue(fileNoExt, "gfx-offset-x"));
                yOffset = int.Parse(wohlConfig.ReadValue(fileNoExt, "gfx-offset-y"));
                string check = Path.GetDirectoryName(fullPath) + @"\" + fileNoExt + "m.gif";
                if (File.Exists(check))
                {
                    drawMask(check);
                }
                else
                {
                    regularDraw();
                }
                previewBox.Update();
                if (dontAskDontTell)
                {
                    previewBox.Image.Save(string.Format(Environment.CurrentDirectory + @"\converted\{0}.png", fileNoExt), System.Drawing.Imaging.ImageFormat.Png);
                    showNextImage(true);
                    save.Enabled = false;
                    useOffset.Enabled = false;
                    scaleButton.Enabled = false;
                }
            }
        }

        void drawMask(string maskk)
        {
            Bitmap image = (Bitmap)Image.FromFile(fullPath);
            Bitmap mask = (Bitmap)Image.FromFile(maskk);

            if (image.Height == mask.Height && image.Width == mask.Width)
            { }    //continue
            else
                regularDraw();

            hasMask = true;
            originalImage = Create32bppImageAndClearAlpha(Image.FromFile(fullPath) as Bitmap);
            originalMaskImage = Create32bppImageAndClearAlpha((Bitmap)Image.FromFile(maskk));
            PrepareMaskImage();
            Rectangle crop;
            if (useOffsetVal) { crop = new Rectangle(xOffset, yOffset, width, height); }
            else { crop = new Rectangle(0, 0, width, height); }
            Bitmap clone = bmp.Clone(crop, System.Drawing.Imaging.PixelFormat.DontCare);
            if (clone.Height + clone.Width > 64)
            {
                var scaled = ScaleImage((Image)clone, 32, 32);
                previewBox.Image = scaled;
            }
            else
            {
                previewBox.Image = clone;
            }
        }
        void regularDraw()
        {
            hasMask = false;
            bmp = Image.FromFile(fullPath) as Bitmap;
            Rectangle crop;
            if (useOffsetVal) { crop = new Rectangle(xOffset, yOffset, width, height); }
            else { crop = new Rectangle(0, 0, width, height); }
            Bitmap clone = bmp.Clone(crop, System.Drawing.Imaging.PixelFormat.DontCare);
            if (clone.Height + clone.Width > 64)
            {
                var scaled = ScaleImage((Image)clone, 32, 32);
                previewBox.Image = scaled;
            }
            else
            {
                previewBox.Image = clone;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                previewBox.Image.Save(string.Format(Environment.CurrentDirectory + @"\converted\{0}.png", fileNoExt), System.Drawing.Imaging.ImageFormat.Png);
                showNextImage(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Completed operation successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                save.Enabled = true;
                scaleButton.Enabled = true;
                useOffset.Enabled = true;
                dontAsk.Enabled = true;
                dontAsk.Checked = false;
                dontAskDontTell = false;
                curListIndex = 0;
                showNextImage(false);
            }
        }

        public void redrawImage()
        {
            switch (useOffsetVal)
            {
                case(true):
                        bmp = (Bitmap)previewBox.Image;
                        Rectangle crop = new Rectangle(xOffset, yOffset, width, height);
                        Bitmap clone = bmp.Clone(crop, System.Drawing.Imaging.PixelFormat.DontCare);
                        previewBox.Image = clone;
                        previewBox.Update();
                    break;
                case(false):
                        bmp = (Bitmap)previewBox.Image;
                        Rectangle crop1 = new Rectangle(0, 0, width, height);
                        Bitmap clone1 = bmp.Clone(crop1, System.Drawing.Imaging.PixelFormat.DontCare);
                        previewBox.Image = clone1;
                        previewBox.Update();
                    break;
            }

            
        }

        private void useOffset_CheckedChanged(object sender, EventArgs e)
        {
            switch (useOffset.Checked)
            {
                case(true):
                    useOffsetVal = true;
                    redrawImage();
                    break;
                case(false):
                    useOffsetVal = false;
                    redrawImage();
                    break;
            }
        }

        /*public static void Main()
        {
            var image = Image.FromFile(@"c:\logo.png");
            var newImage = ScaleImage(image, 300, 400);
            newImage.Save(@"c:\test.png", ImageFormat.Png);
        }*/

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var xoffset = (int)(newWidth - maxWidth);
            
            var newImage = new Bitmap(32, 32);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        private void scaleButton_Click(object sender, EventArgs e)
        {
            var imgg = previewBox.Image;
            var newImage = ScaleImage(imgg, 32, 32);
            previewBox.Image = newImage;
            previewBox.SizeMode = PictureBoxSizeMode.CenterImage;
            previewBox.Size = new System.Drawing.Size(32, 32);
        }
        //
        #region This is ugly stuff
        private void PrepareMaskedImage()
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.originalImage != null && this.maskImage != null)
            {
                if (this.originalImage.Width != this.maskImage.Width || this.originalImage.Height != this.maskImage.Height)
                {
                    MessageBox.Show("Error: mask and image must have the same size", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.previewBox.Image = null;

                }
                else
                {

                    //allocate the Masked image in ARGB format
                    this.maskedImage = Create32bppImageAndClearAlpha(this.originalImage);

                    BitmapData bmpData1 = maskedImage.LockBits(new Rectangle(0, 0, maskedImage.Width, maskedImage.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, maskedImage.PixelFormat);
                    byte[] maskedImageRGBAData = new byte[bmpData1.Stride * bmpData1.Height];
                    System.Runtime.InteropServices.Marshal.Copy(bmpData1.Scan0, maskedImageRGBAData, 0, maskedImageRGBAData.Length);

                    BitmapData bmpData2 = maskImage.LockBits(new Rectangle(0, 0, maskImage.Width, maskImage.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, maskImage.PixelFormat);
                    byte[] maskImageRGBAData = new byte[bmpData2.Stride * bmpData2.Height];
                    System.Runtime.InteropServices.Marshal.Copy(bmpData2.Scan0, maskImageRGBAData, 0, maskImageRGBAData.Length);

                    //copy the mask to the Alpha layer
                    for (int i = 0; i + 2 < maskedImageRGBAData.Length; i += 4)
                    {
                        maskedImageRGBAData[i + 3] = maskImageRGBAData[i];

                    }
                    System.Runtime.InteropServices.Marshal.Copy(maskedImageRGBAData, 0, bmpData1.Scan0, maskedImageRGBAData.Length);
                    bmp = maskedImage;
                    this.maskedImage.UnlockBits(bmpData1);
                    this.maskImage.UnlockBits(bmpData2);
                    //bmp = maskedImage;
                    //this.previewBox.Image = maskedImage;

                }
                this.Cursor = Cursors.Default;
            }
        }

        private void PrepareMaskImage()
        {
            if (originalMaskImage != null)
            {
                this.Cursor = Cursors.WaitCursor;

                this.maskImage = Create32bppImageAndClearAlpha(originalMaskImage);

                BitmapData bmpData = maskImage.LockBits(new Rectangle(0, 0, maskImage.Width, maskImage.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, maskImage.PixelFormat);

                byte[] maskImageRGBData = new byte[bmpData.Stride * bmpData.Height];

                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, maskImageRGBData, 0, maskImageRGBData.Length);


                byte greyLevel;
                bool opaque = false;
                //int OpacityThreshold = this.trackBar1.Value;
                bool invertedMask = true;//this.checkBoxInvertMask.Checked;
                for (int i = 0; i + 2 < maskImageRGBData.Length; i += 4)
                {
                    //convert to gray scale R:0.30 G=0.59 B 0.11
                    greyLevel = (byte)(0.3 * maskImageRGBData[i + 2] + 0.59 * maskImageRGBData[i + 1] + 0.11 * maskImageRGBData[i]);

                    if (opaque)
                    {
                        greyLevel = (greyLevel < 420/*OpacityThreshold*/) ? byte.MinValue : byte.MaxValue;
                    }
                    if (invertedMask)
                    {
                        greyLevel = (byte)(255 - (int)greyLevel);
                    }

                    maskImageRGBData[i] = greyLevel;
                    maskImageRGBData[i + 1] = greyLevel;
                    maskImageRGBData[i + 2] = greyLevel;

                }
                System.Runtime.InteropServices.Marshal.Copy(maskImageRGBData, 0, bmpData.Scan0, maskImageRGBData.Length);
                this.maskImage.UnlockBits(bmpData);
                //this.spriteMask.Image = maskImage;
                this.Cursor = Cursors.Default;
                // if the loaded image is available, we have everything to compute the masked image
                if (this.originalImage != null)
                {
                    PrepareMaskedImage();
                }
            }
        }

        private Bitmap Create32bppImageAndClearAlpha(Bitmap tmpImage)
        {
            // declare the new image that will be returned by the function
            Bitmap returnedImage = new Bitmap(tmpImage.Width, tmpImage.Height, PixelFormat.Format32bppArgb);

            // create a graphics instance to draw the original image in the new one
            Rectangle rect = new Rectangle(0, 0, tmpImage.Width, tmpImage.Height);
            Graphics g = Graphics.FromImage(returnedImage);

            // create an image attribe to force a clearing of the alpha layer
            ImageAttributes imageAttributes = new ImageAttributes();
            float[][] colorMatrixElements = { 
                        new float[] {1,0,0,0,0},
                        new float[] {0,1,0,0,0},
                        new float[] {0,0,1,0,0},
                        new float[] {0,0,0,0,0},
                        new float[] {0,0,0,1,1}};

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            // draw the original image 
            g.DrawImage(tmpImage, rect, 0, 0, tmpImage.Width, tmpImage.Height, GraphicsUnit.Pixel, imageAttributes);
            g.Dispose();
            return returnedImage;
        }
        #endregion

        private void changeDirectoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.Description = "Select the folder containing your NPC Sprite Images";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string filePath = fd.SelectedPath;
                string[] files = System.IO.Directory.GetFiles(filePath);
                NumericComparer ns = new NumericComparer();
                Array.Sort(files, ns);
                npcList.Clear();
                foreach (var graphics in files)
                {
                    string name = Path.GetFileName(graphics.ToString());
                    if(!graphics.Contains("m.gif"))
                    { 
                        if(!graphics.Contains("Thumbs"))
                            npcList.Add(graphics); 
                    }
                }
                curDirectoryLabel.Text = filePath;
                curListIndex = 0;
                showNextImage(false);
            }
        }

        private void dontAsk_CheckedChanged(object sender, EventArgs e)
        {
            switch (dontAsk.Checked)
            {
                case(true):
                    dontAskDontTell = true;
                    break;
                case(false):
                    dontAskDontTell = false;
                    break;
            }
        }
        //
    }
}
