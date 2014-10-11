using Setting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace smbx_npc_editor.SpriteHandling
{
    using IO;
    public class obj_npc
    {
        IniFile npcConfig;
        //    [npc-1]
        public ulong id;
        //    name="Goomba"
        public string name;
        //    group="Enemy" 		;The sort category
        public string group;
        //    category="Enemy"		;The sort category
        public string category;
        //    image="npc-1.gif"		;NPC Image file
        public string image_n;
        public string mask_n;
        public Bitmap image;
        public Bitmap mask;
        //    algorithm="0"			;NPC's alhorytm. Alhoritm have states and events (onDie, onTail, onCollisionWithFlyBlock...)
        public int algorithm;
            //    ;If algorithm = 0, will using basic parametric alhorythm.
        //    ;Else, get alhorythm from list
        //    default-effect=2		;Spawn effect ID on jump-die
        public ulong effect_1;
        //    shell-effect=4			;effect on kick by shell or other NPC
        public ulong effect_2;

        //    ; graphics
        public int gfx_offset_x;
        //    gfx-offst-x=0
        public int gfx_offset_y;
        //    gfx-offst-y=2
        public int gfx_h;
        //    gfx-height-y=32
        public int gfx_w;
        //    gfx-width-y=32

        public bool custom_physics_to_gfx; //The GFX size defining by physics size in the custom configs

        public int grid;
        //    grid=32
        //    grid-offset-x=0
        public int grid_offset_x;
        //    grid-offset-y=0
        public int grid_offset_y;

        public int grid_attach_style; //0 - middle, 1 - left side

        //    frame-style=0	; (0-2) This option in some alhoritmes can be ignored
        public int framestyle;
        //    frames=2
        public int frames;
        //    frame-speed=128
        public int framespeed;
        //    foreground=0
        public bool foreground;
        //    background=0
        public bool background;
        //    animation-bidirectional=0
        public bool ani_bidir;
        //    animation-direction=0
        public bool ani_direct;

        public bool ani_directed_direct; //Animation direction will be gotten from NPC's direction
        //    ; for editor
        //    custom-animation=0
        public bool custom_animate;
        //    ; this option useful for non-standart algorithmic sprites (for example, bosses)

        //    ;custom-animation-alg=0		; Custom animation algorithm
            // 0 simple frame range, 1 - frame Jump; 2 - custom animation sequances
        public int custom_ani_alg;
        //    ;custom-animation-fl=0		; First frame for LEFT
        public int custom_ani_fl;
        //    ;custom-animation-el=0		; end frame for LEFT / Jump step
        public int custom_ani_el;
        //    ;custom-animation-fr=0		; first frame for RIGHT
        public int custom_ani_fr;
        //    ;custom-animation-er=0		; end frame for RIGHT / Jump step
        public int custom_ani_er;

        public List<int> frames_left;     //Frame srquence for left
        public List<int> frames_right;    //Frame srquence for right

        //    container=0			; NPC can containing inside other NPC (need enable special option type 2)
        public bool container;

        public int display_frame;

        public bool no_npc_collions;
        //    ; this option disabling collisions in editor with other NPCs, but with NPC's of same ID collisions will be checked

        //    ; Special option
        //    have-special=0			; Special NPC's option, what can used by NPC's algorithm
        public bool special_option;
        //    ;special-name="Cheep-cheep"	; 60

        public string special_name;
        //    ;special-type=0			; 61 0 combobox, 1 - spin, 2 - npc-id
        public int special_type;
        //    ;special-combobox-size=3		; 62 quantity of options
        //public List<string> special_combobox_opts;
        //    ;special-option-0="Swim"		; 63 set title for 0 option combobox
        //    ;special-option-1="Jump"		; 64 set title for 1 option combobox
        //    ;special-option-2="Projective"	; 65 set title for 2 option combobox
        public int special_spin_min;
        //    ;special-spin-min=0		; 66 milimal value of spin
        public int special_spin_max;
        //    ;special-spin-max=25		; 67 maximal value of spin
        public int special_spin_value_offset;

        //    have-special-2=0			; Special NPC's option, what can used by NPC's algorithm
        public bool special_option_2; //Second special option
        //    special-2-npc-spin-required
        //public List<long> special_2_npc_spin_required;
        //    special-2-npc-box-required
        //public List<long> special_2_npc_box_required;

        //    ;special-2-name="Cheep-cheep"	; 60
            //string special_2_name;
        //    ;special-2-type=0			; 61 0 combobox, 1 - spin
            //int special_2_type;
        //    ;special-combobox-size=3		; 62 quantity of options
            //List<string > special_2_combobox_opts;
        //    ;special-option-0="Swim"		; 63 set title for 0 option combobox
        //    ;special-option-1="Jump"		; 64 set title for 1 option combobox
        //    ;special-option-2="Projective"	; 65 set title for 2 option combobox
            //int special_2_spin_min;
        //    ;special-2-spin-min=0		; 66 milimal value of spin
            //int special_2_spin_max;
        //    ;special-2-spin-max=25		; 67 maximal value of spin
            //int special_2_spin_value_offset;
            //special-2-spin-value-offset

        //    ;game process
        //    score=2				; Add scores to player (value 0-13)
        //    ; 0, 10, 100, 200, 400, 800, 1000, 2000, 4000, 8000, 1up, 2up, 5up, 3up
        public int score;
        //    speed=64			; Default movement speed in px/s
        public int speed;
        //    moving=1			; NPC simply moving right/left

        public bool movement;
        //    scenery=0			; NPC as block
        public bool scenery;
        //    immortal=0			; NPC Can't be destroy
        public bool immortal;
        //    yoshicaneat=1			; NPC can be eaten by yoshi
        public bool can_be_eaten;
        //    takeble=0			; NPC destroyble on contact with player
        public bool takable;
        //    grab-side=0			; NPC can be grabbed on side
        public bool grab_side;
        //    grab-top=0			; NPC can be grabbed on top
        public bool grab_top;
        //    grab-any=0			; NPC can be grabbed on any collisions
        public bool grab_any;
        //    default-health=1		; NPC's health value
        public int health;
        //    hurtplayer=1			; Hurt player on contact
        public bool hurt_player;
        //    hurtnpc=0			; Hurt other npc on contact
        public bool hurt_npc;

        //    ;Editor featured
            //string direct_alt_title;
            //string direct_alt_left;
            //string direct_alt_right;
            //bool direct_disable_random;

        //    allow-bubble=1			; Allow packable into the bubble
            //bool allow_bubble;
        //    allow-egg=1			; Allow packable into the egg
            //bool allow_egg;
        //    allow-lakitu=1			; Allow packable into the SMW Lakitu
            //bool allow_lakitu;
        //    allow-burred=1			; Allow packable under the herb
            //bool allow_buried;


        //    ; Physics
        //    ; Size of NPC's body (Collision box)
        //    fixture-height=32
        public uint height;
        //    fixture-width=32
        public uint width;
        //    block-npc=1		; NPC is a solid object for NPC's
        public bool block_npc;
        //    block-npc-top=0		; on NPC's top can be stay other NPC's
        public bool block_npc_top;
        //    block-player=0		; NPC is a solid object for player
        public bool block_player;
        //    block-player-top=0	; on NPC's top can be stay player
        public bool block_player_top;
        //    collision-blocks=1	; Enable collisions with blocks
        public bool collision_with_blocks;
        //    gravity=1		; Enable gravitation for this NPC
        public bool gravity;
        //    adhesion=0		; allows to NPC walking on wall and on celling
        public bool adhesion;

        //    ;Events
        //    deactivate=1		; Deactivate on state offscreen > 4 sec ago
        public bool deactivation;
        //    kill-slside=1		; Kill on Slope slide
        public bool kill_slide_slope;
        //    kill-onjump=1		; Kill on jump on NPC's head
        public bool kill_on_jump;
        //    kill-bynpc=1		; Kill by contact with other NPC with hurt-npc
        //    ; for example: moving SHELL have "HURT_NPC", and shell kiling ALL NPCs on contact
        public bool kill_by_npc;
        //    kill-fireball=1		; kill on collision with NPC, marked as "fireball"
        public bool kill_by_fireball;
        //    kill-iceball=1		; freeze on collision with NPC, marked as "iceball"
        public bool freeze_by_iceball;
        //    kill-hammer=1		; kill on collision with NPC, marked as "hammer" or "boomerang"
        public bool kill_hammer;
        //    kill-tail=1		; kill on tail attack
        public bool kill_tail;
        //    kill-spin=1		; kill on spin jump
        public bool kill_by_spinjump;
        //    kill-statue=1		; kill on tanooki statue fall
        public bool kill_by_statue;
        //    kill-with-mounted=1	; kill on jump with mounted items
        public bool kill_by_mounted_item;
        //    kill-on-eat=1		; Kill on eat, or transform into other
        public bool kill_on_eat;
        //    cliffturn=0		; NPC turns on cliff
        public bool turn_on_cliff_detect;
        //    lava-protection=0	; NPC will not be burn in lava
        public bool lava_protect;

            bool is_star; //If this marker was set, this NPC will be markered as "star"
            //Quantity placed NPC's with marker "star" will be save in LVL-file

            //Editor defaults
            //bool default_friendly;
            //bool default_friendly_value;

            //bool default_nomovable;
            //bool default_nomovable_value;

            //bool default_boss;
            //bool default_boss_value;

            //bool default_special;
            //long default_special_value;


            public bool isValid;

            public obj_npc()
            {
                isValid = false;
                frames_left = new List<int>();
                frames_right = new List<int>();
            }

            public void init(string configToUse, string npcID)
            {
                isValid = false;
                if (!File.Exists(configToUse)) return;

                npcConfig = new IniFile(configToUse);
                //    [npc-1]
                id = ulong.Parse(npcID);
                //    name="Goomba"
                name = npcConfig.ReadValue(npcID, "name");
                if (name.Length == 0) return;
                //    group="Enemy" 		;The sort category
                group = npcConfig.ReadValue(npcID, "group");
                //    category="Enemy"		;The sort category
                category = npcConfig.ReadValue(npcID, "category");
                //    image="npc-1.gif"		;NPC Image file
                image_n = npcConfig.ReadValue(npcID, "image");
                mask_n = npcConfig.ReadValue(npcID, "image");
                //You should append "m" letter into basename of filename
                //
                //
                //Bitmap image;
                //Bitmap mask;
                //    algorithm="0"			;NPC's alhorytm. Alhoritm have states and events (onDie, onTail, onCollisionWithFlyBlock...)
                algorithm = int.Parse(npcConfig.ReadValue(npcID, "algorithm"));
                //    ;If algorithm = 0, will using basic parametric alhorythm.
                //    ;Else, get alhorythm from list
                //    default-effect=2		;Spawn effect ID on jump-die
                effect_1 = ulong.Parse(npcConfig.ReadValue(npcID, "default-effect"));
                //    shell-effect=4			;effect on kick by shell or other NPC
                effect_2 = ulong.Parse(npcConfig.ReadValue(npcID, "shell-effect"));

                //    ; graphics
                gfx_offset_x = int.Parse(npcConfig.ReadValue(npcID, "gfx-offst-x"));
                //    gfx-offst-x=0
                gfx_offset_y = int.Parse(npcConfig.ReadValue(npcID, "gfx-offst-y"));
                //    gfx-offst-y=2
                gfx_h = int.Parse(npcConfig.ReadValue(npcID, "gfx-height"));
                //    gfx-height-y=32
                gfx_w = int.Parse(npcConfig.ReadValue(npcID, "gfx-width"));
                //    gfx-width-y=32

                custom_physics_to_gfx = bool.Parse(npcConfig.ReadValue(npcID, "physics-to-gfx")); //The GFX size defining by physics size in the custom configs

                grid = int.Parse(npcConfig.ReadValue(npcID, "grid"));
                //    grid=32
                //    grid-offset-x=0
                grid_offset_x = int.Parse(npcConfig.ReadValue(npcID, "grid-offset-x"));
                //    grid-offset-y=0
                grid_offset_y = int.Parse(npcConfig.ReadValue(npcID, "grid-offset-y"));

                //grid-attachement-style
                grid_attach_style = int.Parse(npcConfig.ReadValue(npcID, "grid-attachement-style")); //0 - middle, 1 - left side

                //    frame-style=0	; (0-2) This option in some alhoritmes can be ignored
                framestyle = int.Parse(npcConfig.ReadValue(npcID, "frame-style"));
                //    frames=2
                frames = int.Parse(npcConfig.ReadValue(npcID, "frames"));
                //    frame-speed=128
                framespeed = int.Parse(npcConfig.ReadValue(npcID, "frame-speed"));
                //    foreground=0
                foreground = bool.Parse(npcConfig.ReadValue(npcID, "foreground"));
                //    background=0
                background = bool.Parse(npcConfig.ReadValue(npcID, "background"));
                //    animation-bidirectional=0
                ani_bidir = bool.Parse(npcConfig.ReadValue(npcID, "animation-bidirectional"));
                //    animation-direction=0
                ani_direct = bool.Parse(npcConfig.ReadValue(npcID, "animation-direction"));

                ani_directed_direct = bool.Parse(npcConfig.ReadValue(npcID, "animation-directed-direction")); //Animation direction will be gotten from NPC's direction
                //    ; for editor
                //    custom-animation=0
                custom_animate = bool.Parse(npcConfig.ReadValue(npcID, "custom-animation"));
                //    ; this option useful for non-standart algorithmic sprites (for example, bosses)

                //    ;custom-animation-alg=0		; Custom animation algorithm
                // 0 simple frame range, 1 - frame Jump; 2 - custom animation sequances
                custom_ani_alg = int.Parse(npcConfig.ReadValue(npcID, "custom-animation-alg"));
                //    ;custom-animation-fl=0		; First frame for LEFT
                custom_ani_fl = int.Parse(npcConfig.ReadValue(npcID, "custom-animation-fl"));
                //    ;custom-animation-el=0		; end frame for LEFT / Jump step
                custom_ani_el = int.Parse(npcConfig.ReadValue(npcID, "custom-animation-el"));
                //    ;custom-animation-fr=0		; first frame for RIGHT
                custom_ani_fr = int.Parse(npcConfig.ReadValue(npcID, "custom-animation-fr"));
                //    ;custom-animation-er=0		; end frame for RIGHT / Jump step
                custom_ani_er = int.Parse(npcConfig.ReadValue(npcID, "custom-animation-er"));

                List<string> tmp;

                frames_left.Clear();
                string framesListLeft = npcConfig.ReadValue(npcID, "ani-frames-left");
                if (framesListLeft.Length > 0)
                {
                    framesListLeft = framesListLeft.Replace(" ", "");
                    tmp = new List<string>(framesListLeft.Split(','));
                    for (int i = 0; i < tmp.Count(); i++)
                        frames_left.Add(int.Parse(tmp[i]));     //Frame srquence for left
                }

                frames_right.Clear();
                string framesListRight = npcConfig.ReadValue(npcID, "ani-frames-right");
                if (framesListRight.Length > 0)
                {
                    framesListLeft = framesListLeft.Replace(" ", "");
                    tmp = new List<string>(framesListLeft.Split(','));
                    for (int i = 0; i < tmp.Count(); i++)
                        frames_right.Add(int.Parse(tmp[i]));     //Frame srquence for right
                }

                //    container=0			; NPC can containing inside other NPC (need enable special option type 2)
                container = bool.Parse(npcConfig.ReadValue(npcID, "container"));

                display_frame = int.Parse(npcConfig.ReadValue(npcID, "display-frame"));

                no_npc_collions = bool.Parse(npcConfig.ReadValue(npcID, "no-npc-collisions"));
                //    ; this option disabling collisions in editor with other NPCs, but with NPC's of same ID collisions will be checked

                //    ; Special option
                //    have-special=0			; Special NPC's option, what can used by NPC's algorithm
                special_option = bool.Parse(npcConfig.ReadValue(npcID, "have-special"));
                //    ;special-name="Cheep-cheep"	; 60

                special_name = npcConfig.ReadValue(npcID, "special-name");
                //    ;special-type=0			; 61 0 combobox, 1 - spin, 2 - npc-id
                special_type = int.Parse(npcConfig.ReadValue(npcID, "special-type"));
                //    ;special-combobox-size=3		; 62 quantity of options
                //List<string> special_combobox_opts;
                //    ;special-option-0="Swim"		; 63 set title for 0 option combobox
                //    ;special-option-1="Jump"		; 64 set title for 1 option combobox
                //    ;special-option-2="Projective"	; 65 set title for 2 option combobox
                //int special_spin_min;
                //    ;special-spin-min=0		; 66 milimal value of spin
                //int special_spin_max;
                //    ;special-spin-max=25		; 67 maximal value of spin
                //int special_spin_value_offset;

                //    have-special-2=0			; Special NPC's option, what can used by NPC's algorithm
                //bool special_option_2; //Second special option
                //    special-2-npc-spin-required
                //List<long> special_2_npc_spin_required;
                //    special-2-npc-box-required
                //List<long> special_2_npc_box_required;

                //    ;special-2-name="Cheep-cheep"	; 60
                //string special_2_name;
                //    ;special-2-type=0			; 61 0 combobox, 1 - spin
                //int special_2_type;
                //    ;special-combobox-size=3		; 62 quantity of options
                //List<string> special_2_combobox_opts;
                //    ;special-option-0="Swim"		; 63 set title for 0 option combobox
                //    ;special-option-1="Jump"		; 64 set title for 1 option combobox
                //    ;special-option-2="Projective"	; 65 set title for 2 option combobox
                //int special_2_spin_min;
                //    ;special-2-spin-min=0		; 66 milimal value of spin
                //int special_2_spin_max;
                //    ;special-2-spin-max=25		; 67 maximal value of spin
                //int special_2_spin_value_offset;
                //special-2-spin-value-offset

                //    ;game process
                //    score=2				; Add scores to player (value 0-13)
                //    ; 0, 10, 100, 200, 400, 800, 1000, 2000, 4000, 8000, 1up, 2up, 5up, 3up
                score = int.Parse(npcConfig.ReadValue(npcID, "score"));
                //    speed=64			; Default movement speed in px/s
                speed = int.Parse(npcConfig.ReadValue(npcID, "speed"));
                //    moving=1			; NPC simply moving right/left

                movement = bool.Parse(npcConfig.ReadValue(npcID, "moving"));
                //    scenery=0			; NPC as block
                scenery = bool.Parse(npcConfig.ReadValue(npcID, "scenery"));
                //    immortal=0			; NPC Can't be destroy
                immortal = bool.Parse(npcConfig.ReadValue(npcID, "immortal"));
                //    yoshicaneat=1			; NPC can be eaten by yoshi
                can_be_eaten = bool.Parse(npcConfig.ReadValue(npcID, "yoshicaneat"));
                //    takeble=0			; NPC destroyble on contact with player
                takable = bool.Parse(npcConfig.ReadValue(npcID, "takeble"));
                //    grab-side=0			; NPC can be grabbed on side
                grab_side = bool.Parse(npcConfig.ReadValue(npcID, "grab-side"));
                //    grab-top=0			; NPC can be grabbed on top
                grab_top = bool.Parse(npcConfig.ReadValue(npcID, "grab-top"));
                //    grab-any=0			; NPC can be grabbed on any collisions
                grab_any = bool.Parse(npcConfig.ReadValue(npcID, "grab-any"));
                //    default-health=1		; NPC's health value
                health = int.Parse(npcConfig.ReadValue(npcID, "default-health"));
                //    hurtplayer=1			; Hurt player on contact
                hurt_player = bool.Parse(npcConfig.ReadValue(npcID, "hurtplayer"));
                //    hurtnpc=0			; Hurt other npc on contact
                hurt_npc = bool.Parse(npcConfig.ReadValue(npcID, "hurtnpc"));

                //    ;Editor featured
                //string direct_alt_title;
                //string direct_alt_left;
                //string direct_alt_right;
                //bool direct_disable_random;

                //    allow-bubble=1			; Allow packable into the bubble
                //bool allow_bubble;
                //    allow-egg=1			; Allow packable into the egg
                //bool allow_egg;
                //    allow-lakitu=1			; Allow packable into the SMW Lakitu
                //bool allow_lakitu;
                //    allow-burred=1			; Allow packable under the herb
                //bool allow_buried;


                //    ; Physics
                //    ; Size of NPC's body (Collision box)
                //    fixture-height=32
                string tmpS = npcConfig.ReadValue(npcID, "fixture-height");
                if (tmpS.Length == 0) tmpS = npcConfig.ReadValue(npcID, "physical-height");
                height = uint.Parse(tmpS);
                //    fixture-width=32
                tmpS = npcConfig.ReadValue(npcID, "fixture-height");
                if (tmpS.Length == 0) tmpS = npcConfig.ReadValue(npcID, "fixture-width");
                width = uint.Parse(tmpS);
                //    block-npc=1		; NPC is a solid object for NPC's
                block_npc = bool.Parse(npcConfig.ReadValue(npcID, "block-npc"));
                //    block-npc-top=0		; on NPC's top can be stay other NPC's
                block_npc_top = bool.Parse(npcConfig.ReadValue(npcID, "block-npc-top"));
                //    block-player=0		; NPC is a solid object for player
                block_player = bool.Parse(npcConfig.ReadValue(npcID, "block-player"));
                //    block-player-top=0	; on NPC's top can be stay player
                block_player_top = bool.Parse(npcConfig.ReadValue(npcID, "block-player-top"));
                //    collision-blocks=1	; Enable collisions with blocks
                collision_with_blocks = bool.Parse(npcConfig.ReadValue(npcID, "collision-blocks"));
                //    gravity=1		; Enable gravitation for this NPC
                gravity = bool.Parse(npcConfig.ReadValue(npcID, "gravity"));
                //    adhesion=0		; allows to NPC walking on wall and on celling
                adhesion = bool.Parse(npcConfig.ReadValue(npcID, "adhesion"));

                //    ;Events
                //    deactivate=1		; Deactivate on state offscreen > 4 sec ago
                deactivation = bool.Parse(npcConfig.ReadValue(npcID, "deactivate"));
                //    kill-slside=1		; Kill on Slope slide
                kill_slide_slope = bool.Parse(npcConfig.ReadValue(npcID, "kill-slside"));
                //    kill-onjump=1		; Kill on jump on NPC's head
                kill_on_jump = bool.Parse(npcConfig.ReadValue(npcID, "kill-onjump"));
                //    kill-bynpc=1		; Kill by contact with other NPC with hurt-npc
                //    ; for example: moving SHELL have "HURT_NPC", and shell kiling ALL NPCs on contact
                kill_by_npc = bool.Parse(npcConfig.ReadValue(npcID, "kill-bynpc"));
                //    kill-fireball=1		; kill on collision with NPC, marked as "fireball"
                kill_by_fireball = bool.Parse(npcConfig.ReadValue(npcID, "kill-fireball"));
                //    kill-iceball=1		; freeze on collision with NPC, marked as "iceball"
                freeze_by_iceball = bool.Parse(npcConfig.ReadValue(npcID, "kill-iceball"));
                //    kill-hammer=1		; kill on collision with NPC, marked as "hammer" or "boomerang"
                kill_hammer = bool.Parse(npcConfig.ReadValue(npcID, "kill-hammer"));
                //    kill-tail=1		; kill on tail attack
                kill_tail = bool.Parse(npcConfig.ReadValue(npcID, "kill-tail"));
                //    kill-spin=1		; kill on spin jump
                kill_by_spinjump = bool.Parse(npcConfig.ReadValue(npcID, "kill-spin"));
                //    kill-statue=1		; kill on tanooki statue fall
                kill_by_statue = bool.Parse(npcConfig.ReadValue(npcID, "kill-statue"));
                //    kill-with-mounted=1	; kill on jump with mounted items
                kill_by_mounted_item = bool.Parse(npcConfig.ReadValue(npcID, "kill-with-mounted"));
                //    kill-on-eat=1		; Kill on eat, or transform into other
                kill_on_eat = bool.Parse(npcConfig.ReadValue(npcID, "kill-on-eat"));
                //    cliffturn=0		; NPC turns on cliff
                turn_on_cliff_detect = bool.Parse(npcConfig.ReadValue(npcID, "cliffturn"));
                //    lava-protection=0	; NPC will not be burn in lava
                lava_protect = bool.Parse(npcConfig.ReadValue(npcID, "lava-protection"));

                is_star = bool.Parse(npcConfig.ReadValue(npcID, "is-star"));
                //If this marker was set, this NPC will be markered as "star"
                //Quantity placed NPC's with marker "star" will be save in LVL-file

                //Editor defaults
                //bool default_friendly;
                //bool default_friendly_value;

                //bool default_nomovable;
                //bool default_nomovable_value;

                //bool default_boss;
                //bool default_boss_value;

                //bool default_special;
                //long default_special_value;
                isValid = true;
            }
    }


    public class AdvNpcAnimator
    {
        ///////////////////////////////Wohlstand's////////////////////////
        Bitmap mainImage;
        obj_npc setup; //Merged config file

        bool isInitialized = false;

        List<Bitmap > frames;//- bitmaps dynamic array. Will have inside them frames.
        bool animated;
        public int frameSpeed;// - value in milliseconds, this is a timer value
        int frameStyle;// - same from config
        int direction;// - current direction (-1 or 1)
        bool aniDirect;// - Directed animation. I.e. left and right directions will define animation direction (reverse or direct)
        bool aniBiDirect;// - Bidirectional animation. I.e. animation direction will turn on last frame and will turn after return into first frame.
        int curDirect;// - direction of animation, I.e. direct or reverse animation.
        int frameStep;// - How many frames will be forwarded by one animation step. (defaultly 1, but if enabled algorithm "frameJump", this value can be redefined)
        bool customAnimate;
        int customAniAlg; //custom animation algorythm 0 - forward, 1 - frameJump, 2 - animation by frame sequance
        
        int custom_frameFL;//first left
        int custom_frameEL;//end left / jump step
        int custom_frameFR;//first right
        int custom_frameER;//enf right / jump step
        bool frameSequance;
        List<int> frames_list;

        int framesQ;// - total frames in sprite (calculating by dividing of sprite height to gfx height value)
        int frameSize; // size of one frame - gfx height
        int frameWidth; // sprite width
        int frameHeight; //sprite height - height of source image

        //Animation alhorithm
        int CurrentFrame;
        int frameCurrent;

        int frameFirst;
        int frameLast;

        //////////////////Luigifan's//////////////////
        Bitmap originalImage;
        //Bitmap currentFrame;

        //int framesCountIndex = 0;
        //int totalFrames;
        string npcID;
        //IniFile npcConfig;
        Timer AnimationTimer;
        //int curFrame = 0;
        //int frameHeight;
        //int frameWidth;
        MainUI _parentWindow; //This is needed so we can iterate through and pull the values from the controls
                              //It needs to be an already existing instance instead of a new instance.

        public AdvNpcAnimator(/*Bitmap imageToAnimate, MainUI parentWindow*/)
        {
            //_parentWindow = parentWindow;
            npcID = "0";
            animated = false;
            aniDirect = false;
            aniBiDirect = false;
            direction = -1;
            frameStep = 1;
            curDirect = -1;
            frameStep = 1;
            frameSize = 1;

            CurrentFrame = 0; //Real frame
            frameCurrent = 0; //Timer frame

            frameFirst = 0; //from first frame
            frameLast = -1; //to unlimited frameset

            compileInformation();
        }

        public bool isReady()
        {
            return isInitialized;
        }


        public void storeImage(Bitmap imageToAnimate)
        {
            originalImage = imageToAnimate;
            isInitialized = false;
        }

        /// <summary>
        /// Defining configuration of NPC animator
        /// </summary>
        /// <param name="config">Merged configuration set</param>
        /// <param name="direction">Current direction of NPC</param>
        public void configureAnimator(obj_npc config, int direct)
        {
            mainImage = originalImage;
            setup = config;
            ////Wohlstand's//////////////////////
            npcID = setup.id.ToString();

            animated = true;
            framesQ = setup.frames;
            frameSpeed = setup.framespeed;
            frameStyle = setup.framestyle;
            direction = direct;
            frameStep = 1;

            frameSequance = false;

            frameSequance = false;

            aniBiDirect = setup.ani_bidir;
            customAniAlg = setup.custom_ani_alg;

            customAnimate = setup.custom_animate;

            custom_frameFL = setup.custom_ani_fl;//first left
            custom_frameEL = setup.custom_ani_el;//end left
            custom_frameFR = setup.custom_ani_fr;//first right
            custom_frameER = setup.custom_ani_er;//enf right

            frameSize = setup.gfx_h; // height of one frame
            frameWidth = setup.gfx_w; //width of target image

            frameHeight = mainImage.Height; // Height of target image

            //Protectors
            if (frameSize <= 0) frameSize = 1;
            if (frameSize > mainImage.Height) frameSize = mainImage.Height;

            if (frameWidth <= 0) frameWidth = 1;
            if (frameWidth > mainImage.Width) frameWidth = mainImage.Width;

            int dir = direction;
            if (direction == 0) //if direction=random
            {
                Random rnd = new Random();
                dir = ((0 == rnd.Next(0,1)) ? -1 : 1); //set randomly 1 or -1
            }

            if (setup.ani_directed_direct)
                aniDirect = (dir == -1) ^ (setup.ani_direct);
            else
                aniDirect = setup.ani_direct;

            if (customAnimate) // User defined spriteSet (example: boss)
            {
                switch (dir)
                {
                    case -1: //left
                        frameFirst = custom_frameFL;
                        switch (customAniAlg)
                        {
                            case 2:
                                frameSequance = true;
                                frames_list = setup.frames_left;
                                frameFirst = 0;
                                frameLast = frames_list.Count - 1;
                                break;
                            case 1:
                                frameStep = custom_frameEL;
                                frameLast = -1; break;
                            case 0:
                            default:
                                frameLast = custom_frameEL; break;
                        }
                        break;
                    case 1: //Right
                        frameFirst = custom_frameFR;
                        switch (customAniAlg)
                        {
                            case 2:
                                frameSequance = true;
                                frames_list = setup.frames_right;
                                frameFirst = 0;
                                frameLast = frames_list.Count - 1; break;
                            case 1:
                                frameStep = custom_frameER;
                                frameLast = -1; break;
                            case 0:
                            default:
                                frameLast = custom_frameER; break;
                        }
                        break;
                    default: break;
                }
            }
            else
            {
                switch (frameStyle)
                {
                    case 2: //Left-Right-upper sprite
                        framesQ = setup.frames * 4;
                        switch (dir)
                        {
                            case -1: //left
                                frameFirst = 0;
                                frameLast = (int)(framesQ - (framesQ / 4) * 3) - 1;
                                break;
                            case 1: //Right
                                frameFirst = (int)(framesQ - (framesQ / 4) * 3);
                                frameLast = (int)(framesQ / 2) - 1;
                                break;
                            default: break;
                        }
                        break;

                    case 1: //Left-Right sprite
                        framesQ = setup.frames * 2;
                        switch (dir)
                        {
                            case -1: //left
                                frameFirst = 0;
                                frameLast = (int)(framesQ / 2) - 1;
                                break;
                            case 1: //Right
                                frameFirst = (int)(framesQ / 2);
                                frameLast = framesQ - 1;
                                break;
                            default: break;
                        }

                        break;

                    case 0: //Single sprite
                    default:
                        frameFirst = 0;
                        frameLast = framesQ - 1;
                        break;
                }
            }

            curDirect = dir;
            createAnimationFrames();
            isInitialized = true;
        }

        /// <summary>
        /// Generating frames array from source image
        /// </summary>
        void createAnimationFrames()
        {
            frames.Clear();
            Bitmap tmp = originalImage;
            for (int i = 0; (frameSize * i < frameHeight); i++)
            {
                Rectangle SR = new Rectangle(0, frameSize * i, frameWidth, frameSize);
                Graphics g = Graphics.FromImage(tmp);
                g.DrawImage(originalImage, new Rectangle(0, 0, frameWidth, frameHeight), SR, GraphicsUnit.Pixel);
                tmp = new Bitmap(frameWidth, frameHeight, PixelFormat.Format32bppArgb);
                frames.Add(tmp);
            }
        }


        /// <summary>
        /// This function will merge global config with local SMBX NPC.txt config and will return merged config set
        /// </summary>
        /// <param name="global">Global config, read from INI file</param>
        /// <param name="local">SMBX Locak NPC config, read from NPC.txt or edited by UI</param>
        /// <param name="captured">Size of whole image sprite</param>
        /// <returns></returns>
        public obj_npc mergeConfigs(obj_npc global, SMBXNpc local, Size captured )
        {
            obj_npc merged = global;
            merged.name = (local.en_name)?local.name:global.name;

            merged.gfx_offset_x = (local.en_gfxoffsetx)?local.gfxoffsetx:global.gfx_offset_x;
            merged.gfx_offset_y = (local.en_gfxoffsety)?local.gfxoffsety:global.gfx_offset_y;

            merged.width = (local.en_width)?local.width:global.width;
            merged.height = (local.en_height)?local.height:global.height;

            merged.foreground = (local.en_foreground)?local.foreground:global.foreground;

            merged.framespeed = (local.en_framespeed)?
                (int)Math.Round( (double)(global.framespeed) / ((double)8 / (double)(local.framespeed)) )
                                : global.framespeed;
            merged.framestyle = (local.en_framestyle)?local.framestyle:global.framestyle;

            //Copy physical size to GFX size
            if( (local.en_width) && (merged.custom_physics_to_gfx) )
                merged.gfx_w = (int)merged.width;
            else
            {
                if ((!local.en_gfxwidth) && (captured.Width != 0) && (global.gfx_w != captured.Width))
                    merged.width = (uint)captured.Width;

                merged.gfx_w = ((captured.Width != 0) ? captured.Width : global.gfx_w);
            }

            //Copy physical size to GFX size
            if( (local.en_height) && (merged.custom_physics_to_gfx) )
                merged.gfx_h = (int)merged.height;
            else
                merged.gfx_h = global.gfx_h;


            if ((!local.en_gfxwidth) && (captured.Width != 0) && (global.gfx_w != captured.Width))
                merged.gfx_w = captured.Width;
            else
                merged.gfx_w = (local.en_gfxwidth) ? (local.gfxwidth>0 ? local.gfxwidth : 1 ) : merged.gfx_w;

            merged.gfx_h = (local.en_gfxheight) ? (local.gfxheight>0 ? local.gfxheight : 1 ) : merged.gfx_h;


            if(((int)merged.width>=(int)merged.grid))
                merged.grid_offset_x = -1 * (int)Math.Round( (double)((int)merged.width % merged.grid)/2 );
            else
                merged.grid_offset_x = (int)Math.Round((double)(merged.grid - (int)merged.width) / 2);

            if(merged.grid_attach_style==1) merged.grid_offset_x += 16;

            merged.grid_offset_y = (int)(-merged.height % merged.grid);


            if((merged.framestyle==0)&&((local.en_gfxheight)||(local.en_height))&&(!local.en_frames))
            {
                merged.frames = (int)Math.Round((double)(captured.Height) / (double)(merged.gfx_h));
                //merged.custom_animate = false;
            }
            else
                merged.frames = (local.en_frames)?local.frames:global.frames;

            if((local.en_frames)||(local.en_framestyle))
            {
                merged.ani_bidir = false; //Disable bidirectional animation
                if((local.en_frames)) merged.custom_animate = false; //Disable custom animation
            }

            // Convert out of range frames by framestyle into animation with controlable diraction
            if((merged.framestyle>0)&&(merged.gfx_h*merged.frames >= (uint)captured.Height))
            {
                merged.framestyle = 0;
                merged.ani_direct = false;
                merged.ani_directed_direct = true;
            }

            merged.score = (local.en_score)?local.score:global.score;
            merged.block_player = (local.en_playerblock)?local.playerblock:global.block_player;
            merged.block_player_top = (local.en_playerblocktop)?local.playerblocktop:global.block_player_top;
            merged.block_npc = (local.en_npcblock)?local.npcblock:global.block_npc;
            merged.block_npc_top = (local.en_npcblocktop)?local.npcblocktop:global.block_npc_top;
            merged.grab_side = (local.en_grabside)?local.grabside:global.grab_side;
            merged.grab_top = (local.en_grabtop)?local.grabtop:global.grab_top;
            merged.kill_on_jump = (local.en_jumphurt)? (!local.jumphurt) : global.kill_on_jump ;
            merged.hurt_player = (local.en_nohurt)?!local.nohurt:global.hurt_player;
            merged.collision_with_blocks = (local.en_noblockcollision)?(!local.noblockcollision):global.collision_with_blocks;
            merged.turn_on_cliff_detect = (local.en_cliffturn)?local.cliffturn:global.turn_on_cliff_detect;
            merged.can_be_eaten = (local.en_noyoshi)?(!local.noyoshi):global.can_be_eaten;
            merged.speed = (local.en_speed) ? (int)Math.Round(global.speed * local.speed) : global.speed;
            merged.kill_by_fireball = (local.en_nofireball)?(!local.nofireball):global.kill_by_fireball;
            merged.gravity = (local.en_nogravity)?(!local.nogravity):global.gravity;
            merged.freeze_by_iceball = (local.en_noiceball)?(!local.noiceball):global.freeze_by_iceball;
            merged.kill_hammer = (local.en_nohammer)?(!local.nohammer):global.kill_hammer;
            merged.kill_by_npc = (local.en_noshell)?(!local.noshell):global.kill_by_npc;

            return merged;
        }

        void compileInformation()
        {
            //This is where we'd want to get the values from the editor itself, and if they don't exist pull them from the WohlToSMBX class, load them in as defaults in the editor.
        }

        public Bitmap AnimateNextFrame() ///*PictureBox box, string configToUse
        {
            if (frames.Count == 0) return mainImage; //Protector

            //curFrame += 1;
            //if(curFrame >= totalFrames)
            //{
                //curFrame = 0;
            //}
            //Rectangle SR = new Rectangle(0, frameHeight * curFrame, frameWidth, frameHeight);
            //Graphics g = Graphics.FromImage(currentFrame);
            //g.DrawImage(originalImage, new Rectangle(0, 0, frameWidth, frameHeight), SR, GraphicsUnit.Pixel);
            //currentFrame = new Bitmap(frameWidth, frameHeight, PixelFormat.Format32bppArgb);

            if (!aniDirect)
            {
                frameCurrent += frameStep;

                if (((frameCurrent >= frames.Count - (frameStep - 1)) && (frameLast <= -1)) ||
                     ((frameCurrent > frameLast) && (frameLast >= 0)))
                {
                    if (!aniBiDirect)
                    {
                        frameCurrent = frameFirst;
                    }
                    else
                    {
                        frameCurrent -= frameStep * 2;
                        aniDirect = !aniDirect;
                    }
                }
            }
            else
            {
                frameCurrent -= frameStep;

                if (frameCurrent < frameFirst)
                {
                    if (!aniBiDirect)
                    {
                        frameCurrent = ((frameLast == -1) ? frames.Count - 1 : frameLast);
                    }
                    else
                    {
                        frameCurrent += frameStep * 2;
                        aniDirect = !aniDirect;
                    }
                }
            }
            setFrame(frameSequance ? frames_list[frameCurrent] : frameCurrent);
            return frames[CurrentFrame];
        }

        public void setFrame(int y)
        {
            if (frames.Count == 0) return;
            //frameCurrent = frameSize * y;
            CurrentFrame = y;
            //Out of range protection
            if (CurrentFrame >= frames.Count) CurrentFrame = (frameFirst < frames.Count) ? frameFirst : 0;
            if (CurrentFrame < frameFirst) CurrentFrame = (frameLast < 0) ? frames.Count - 1 : frameLast;
        }


    }
}
