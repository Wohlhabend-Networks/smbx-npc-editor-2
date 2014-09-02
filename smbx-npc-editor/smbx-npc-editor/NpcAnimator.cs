using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace smbx_npc_editor
{
    public partial class NpcAnimator : UserControl
    {
        List<Bitmap> frames = new List<Bitmap>();
        int currentFrame; //index of frame
        int frameCurrent; //used for the nextFrame() function
        int frameSpeed; //value in ms, for timer
        int frameStyle; //from cfg
        int direction; //current direction, -1 or 1
        bool aniDirect; //directed animation, left and right will define animation direction
        bool aniBiDirect; //bidirectional animation
        int curDirect; //current direction of animation
        int frameStep; //how many frames will be forwarded by one animation step
        bool customAnimate;
        int customAniAlg; //0 - foward, 1 - frameJump, 2 by frame sequence
        int custom_frameFL; //first left
        int custom_frameEL; //last left
        int custom_frameFR; //fire red i mean first right
        int custom_frameER; //last right
        bool frameSequence;
        List<int> frames_list = new List<int>();
        int framesQ; //total frames in a sprite (sprite height / gfx height)
        int frameSize; //size of one frame gfxheight
        int frameWidth; //sprite width
        int frameHeight; //sprite height, height of source image
        //Animation
        int frameFirst; //index of firstframe
        int frameLast; //indx of last (-1 = last frame that's stored into array)


        public NpcAnimator()
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
        }
    }
}
