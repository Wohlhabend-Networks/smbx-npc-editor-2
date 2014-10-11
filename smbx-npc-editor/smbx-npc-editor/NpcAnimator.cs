using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using smbx_npc_editor.SpriteHandling;
using System.IO;

namespace smbx_npc_editor
{
    public partial class NpcAnimator : UserControl
    {
        AdvNpcAnimator animator = new AdvNpcAnimator();
        obj_npc currentConfig;
        int direction=-1;
        bool isStarted=false;

        //Add some timer here

        //List<Bitmap> frames = new List<Bitmap>();
        //int currentFrame = 0; //index of frame
        //int totalFrames = 0;
        //int frameCurrent; //used for the nextFrame() function
        //int frameSpeed; //value in ms, for timer
        //int frameStyle; //from cfg
        //int direction; //current direction, -1 or 1
        //bool aniDirect; //directed animation, left and right will define animation direction
        //bool aniBiDirect; //bidirectional animation
        //int curDirect; //current direction of animation
        //int frameStep; //how many frames will be forwarded by one animation step
        //bool customAnimate;
        //int customAniAlg; //0 - foward, 1 - frameJump, 2 by frame sequence
        //int custom_frameFL; //first left
        //int custom_frameEL; //last left
        //int custom_frameFR; //fire red i mean first right
        //int custom_frameER; //last right
        //bool frameSequence;
        //List<int> frames_list = new List<int>();
        //int framesQ; //total frames in a sprite (sprite height / gfx height)
        //int frameSize; //size of one frame gfxheight
        //int frameWidth; //sprite width
        //int frameHeight; //sprite height, height of source image
        //Animation
        //int frameFirst; //index of firstframe
        //int frameLast; //indx of last (-1 = last frame that's stored into array)
        //
        MainUI _parentWindow;

        public NpcAnimator()
        {
            //Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
            
        }

        public void setParentWindow(MainUI parentWindow)
        {
            _parentWindow = parentWindow;
        }

        public void setSprite(string fileName)
        {
            compileBitmapList(fileName);
        }

        public void compileBitmapList(string pathToBitmap)
        {
            //if (_parentWindow.npcfile.GetKeyValue("gfxwidth") != null && _parentWindow.npcfile.GetKeyValue("gfxheight") != null)
            //{
            //    frameWidth = int.Parse(_parentWindow.npcfile.GetKeyValue("gfxwidth"));
            //    frameHeight = int.Parse(_parentWindow.npcfile.GetKeyValue("gfxheight"));
            //}

            string pathToMask = Path.Combine(Path.GetDirectoryName(pathToBitmap),
                                Path.GetFileNameWithoutExtension(pathToBitmap) + "m.gif");

            if (File.Exists(pathToBitmap) && File.Exists(pathToMask))
            {
                AlphaBlendedSprite abs = new AlphaBlendedSprite(new Bitmap(pathToBitmap), new Bitmap(pathToMask));
                Bitmap alphaBlended = abs.alphaBlendSprites();
                this.spritePreview.Image = alphaBlended;
                animator.storeImage(alphaBlended);
                
                //for (int i = frameHeight; i < alphaBlended.Height; i = i + frameHeight)
                //{
                    //Rectangle cropRect = new Rectangle(0, i, frameWidth, frameHeight);
                    //Bitmap crop = new Bitmap(cropRect.Width, cropRect.Height);
                    //using(Graphics g = Graphics.FromImage(crop))
                    //{
                     //   g.DrawImage(alphaBlended, new Rectangle(0, 0, crop.Width, crop.Height), cropRect, GraphicsUnit.Pixel);
                     //   frames.Add(crop);
                    //}
                    //totalFrames++;
                //}

            }
            else
                throw new FileNotFoundException("Can't find the mask at: " + pathToMask);
        }

        public void updateAnimator()
        { //Call it when you change one of properties (update SMBXNpc object first)

            bool restart = false;
            if (isStarted)
            {
                stop();
                restart = true;
            }

            /////////// Uncomment and replace 'IniGlobalConfig' and 'CurrentSMBXConfig' when you will make using
            /////////// of the obj_npc and SMBXnpc classes globally;
            //currentConfig = animator.mergeConfigs(IniGlobalConfig, CurrentSMBXConfig);
            ///////////

            if(animator.isReady())
                animator.configureAnimator(currentConfig, direction);

            if (restart)
                start();
        }

        public void start()
        {
            //Set timer's interval at  animator.frameSpeed; (value in milliseconds)
        }

        public void stop()
        {
            //Stop timer
        }

        void AnimationTimer_Tick(object sender, EventArgs e)
        {
            //Draw image which will return by      animator.AnimateNextFrame();
        }

        public string GetMaskPath(string filePath)
        {
            return Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + "m.gif");
        }

        public string GetSpritePath(string filePath)
        {
            return Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + ".gif");
        }

        private void browseButton_Click(object sender, EventArgs e)
        {

        }

        private void faceRightButton_Click(object sender, EventArgs e)
        {
            //if (currentFrame >= totalFrames)
                //currentFrame = 0;
            //this.spritePreview.Image = frames[currentFrame];
            //currentFrame++;
            direction = 1;
            updateAnimator();
        }

        private void faceLeftButton_Click(object sender, EventArgs e)
        {
            //if (currentFrame == -1)
                //currentFrame = 0;
            //this.spritePreview.Image = frames[currentFrame];
            //currentFrame--;
            //if (currentFrame == -1)
            //currentFrame = 0;
            direction = -1;
            updateAnimator();
        }

    }
}
