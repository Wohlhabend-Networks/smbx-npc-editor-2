using Setting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace smbx_npc_editor.SpriteHandling
{
    public class NpcAnimator
    {
        Bitmap originalImage;
        Bitmap currentFrame;
        int framesCountIndex = 0;
        int totalFrames;
        string npcID;
        IniFile npcConfig;
        Timer AnimationTimer;
        int curFrame = 0;
        int frameHeight;
        int frameWidth;

        public NpcAnimator(Bitmap imageToAnimate, string configToUse, string npcIDNumber)
        {
            originalImage = imageToAnimate;
            npcConfig = new IniFile(configToUse);
            npcID = npcIDNumber;
            compileInformation();
        }

        void AnimationTimer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void compileInformation()
        {
            totalFrames = int.Parse(npcConfig.ReadValue(npcID, "frames"));
            frameHeight = int.Parse(npcConfig.ReadValue(npcID, "gfx-height"));
            frameWidth = int.Parse(npcConfig.ReadValue(npcID, "gfx-width"));
        }


        public Bitmap AnimateNextFrame(PictureBox box, string configToUse)
        {
            curFrame += 1;
            if(curFrame >= totalFrames)
            {
                curFrame = 0;
            }
            Rectangle SR = new Rectangle(0, frameHeight * curFrame, frameWidth, frameHeight);
            Graphics g = Graphics.FromImage(currentFrame);
            g.DrawImage(originalImage, new Rectangle(0, 0, frameWidth, frameHeight), SR, GraphicsUnit.Pixel);
            currentFrame = new Bitmap(frameWidth, frameHeight, PixelFormat.Format32bppArgb);
            return currentFrame;
        }

    }
}
