using smbx_npc_editor.SpriteHandling;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace smbx_npc_editor.IO
{
    public class SMBXNpc
    {
        #region Lot's of flags

        public bool ReadFileValid;

        /* Using options flags BEGIN */
        public bool en_gfxoffsetx;
        public int gfxoffsetx;

        public bool en_gfxoffsety;
        public int gfxoffsety;

        public bool en_width;
        public uint width;

        public bool en_height;
        public uint height;

        public bool en_gfxwidth;
        public int gfxwidth;

        public bool en_gfxheight;
        public int gfxheight;

        public bool en_score;
        public int score;

        public bool en_playerblock;
        public bool playerblock;

        public bool en_playerblocktop;
        public bool playerblocktop;

        public bool en_npcblock;
        public bool npcblock;

        public bool en_npcblocktop;
        public bool npcblocktop;

        public bool en_grabside;
        public bool grabside;

        public bool en_grabtop;
        public bool grabtop;

        public bool en_jumphurt;
        public bool jumphurt;

        public bool en_nohurt;
        public bool nohurt;

        public bool en_noblockcollision;
        public bool noblockcollision;

        public bool en_cliffturn;
        public bool cliffturn;

        public bool en_noyoshi;
        public bool noyoshi;

        public bool en_foreground;
        public bool foreground;

        public bool en_speed;
        public float speed;

        public bool en_nofireball;
        public bool nofireball;

        public bool en_nogravity;
        public bool nogravity;

        public bool en_frames;
        public int frames;

        public bool en_framespeed;
        public int framespeed;

        public bool en_framestyle;
        public int framestyle;

        public bool en_noiceball;
        public bool noiceball;

        //Extended
        public bool en_nohammer;
        public bool nohammer;

        public bool en_noshell;
        public bool noshell;

        public bool en_name;
        public string name;
        /* Using options flags END */

        #endregion

        public SMBXNpc()
        {
            en_gfxoffsetx = false;
            en_gfxoffsety = false;
            en_width = false;
            en_height = false;
            en_gfxwidth = false;
            en_gfxheight = false;
            en_score = false;
            en_playerblock = false;
            en_playerblocktop = false;
            en_npcblock = false;
            en_npcblocktop = false;
            en_grabside = false;
            en_grabtop = false;
            en_jumphurt = false;
            en_nohurt = false;
            en_noblockcollision = false;
            en_cliffturn = false;
            en_noyoshi = false;
            en_foreground = false;
            en_speed = false;
            en_nofireball = false;
            en_nogravity = false;
            en_frames = false;
            en_framespeed = false;
            en_framestyle = false;
            en_noiceball = false;
            //Extended
            en_nohammer = false;
            en_noshell = false;
            en_name = false;

            gfxoffsetx = 0;
            gfxoffsety = 0;
            width = 0;
            height = 0;
            gfxwidth = 0;
            gfxheight = 0;
            score = 0;
            playerblock = false;
            playerblocktop = false;
            npcblock = false;
            npcblocktop = false;
            grabside = false;
            grabtop = false;
            jumphurt = false;
            nohurt = false;
            noblockcollision = false;
            cliffturn = false;
            noyoshi = false;
            foreground = false;
            speed = 1;
            nofireball = false;
            nogravity = false;
            frames = 0;
            framespeed = 8;
            framestyle = 0;
            noiceball = false;
            nohammer = false;
            name = "";
        }

        public SMBXNpc getDefaultValues(obj_npc global)
        {
            SMBXNpc local = new SMBXNpc();

            local.gfxoffsetx = global.gfx_offset_x;
            local.gfxoffsety = global.gfx_offset_y;
            local.width = global.width;
            local.height = global.height;
            local.gfxwidth = global.gfx_w;
            local.gfxheight = global.gfx_h;
            local.score = global.score;
            local.playerblock = global.block_player;
            local.playerblocktop = global.block_player_top;
            local.npcblock = global.block_npc;
            local.npcblocktop = global.block_player_top;
            local.grabside = global.grab_side;
            local.grabtop = global.grab_top;
            local.jumphurt = (
                        (global.hurt_player)
                                          &&
                                          (!global.kill_on_jump));
            local.nohurt = (!global.hurt_player);
            local.noblockcollision = (!global.collision_with_blocks);
            local.cliffturn = global.turn_on_cliff_detect;
            local.noyoshi = (!global.can_be_eaten);
            local.foreground = global.foreground;
            local.speed = 1;
            local.nofireball = (!global.kill_by_fireball);
            local.nogravity = (!global.gravity);
            local.frames = global.frames;
            local.framespeed = 8;
            local.framestyle = global.framestyle;
            local.noiceball = (!global.freeze_by_iceball);
            //Extended
            local.nohammer = (!global.kill_hammer);
            local.noshell = (!global.kill_by_npc);
            local.name = global.name;

            return local;
        }

        public void ReadFromTextFile(string fileToRead)
        {
            int line_count = 0;
            StreamReader sr = new StreamReader(fileToRead);
            string line;
            line_count++; line = sr.ReadLine();
            while (line != null)
            {
                string ln = line;
                if (line.Replace(" ", "") == "")
                {
                    line_count++; line = sr.ReadLine();
                    continue;
                } //skips empty strings
                line = ln;
                var Params = line.Split(new char[] { '=' }, 2);
                if (Params[0] == "name")
                {
                    string noQuotes = Params[1].Replace("\"", "");
                    this.name = noQuotes;
                    en_name = true;
                }
                else if (Params[0] == "gfxoffsety")
                {
                    int number; //the number output by the tryparse method
                    bool result = Int32.TryParse(Params[1], out number);
                    if (result)
                    { gfxoffsety = number; en_gfxoffsety = true; }
                    else
                        throw new BadNpcTextFileException(String.Format("Failed to parse parameter {0} with value {1} at line {2}\n\nLine:{3}={4}", Params[0], Params[1], line_count, Params[0], Params[1]));
                }
                else if (Params[0] == "gfxoffsetx")
                {
                    int number;
                    bool result = Int32.TryParse(Params[1], out number);
                    if (result)
                    { gfxoffsetx = number; en_gfxoffsetx = true; }
                    else
                        throw new BadNpcTextFileException(String.Format("Failed to parse parameter {0} with value {1} at line {2}\n\nLine:{3}={4}", Params[0], Params[1], line_count, Params[0], Params[1]));
                }
                else if (Params[0] == "width")
                {
                    int number;
                    bool result = Int32.TryParse(Params[1], out number);
                    if (result)
                    { width = (uint)number; en_width = true; }
                    else
                        throw new BadNpcTextFileException(String.Format("Failed to parse parameter {0} with value {1} at line {2}\n\nLine:{3}={4}", Params[0], Params[1], line_count, Params[0], Params[1]));
                }
                else if (Params[0] == "height")
                {
                    int number;
                    bool result = Int32.TryParse(Params[1], out number);
                    if (result)
                    { height = (uint)number; en_height = true; }
                    else
                        throw new BadNpcTextFileException(String.Format("Failed to parse parameter {0} with value {1} at line {2}\n\nLine:{3}={4}", Params[0], Params[1], line_count, Params[0], Params[1]));
                }
                else if (Params[0] == "gfxwidth")
                {
                    int number;
                    bool result = Int32.TryParse(Params[1], out number);
                    if (result)
                    { gfxwidth = number; en_gfxwidth = true; }
                    else
                        throw new BadNpcTextFileException(String.Format("Failed to parse parameter {0} with value {1} at line {2}\n\nLine:{3}={4}", Params[0], Params[1], line_count, Params[0], Params[1]));
                }
                else if (Params[0] == "gfxheight")
                {
                    int number;
                    bool result = Int32.TryParse(Params[1], out number);
                    if (result)
                    { gfxheight = number; en_gfxheight = true; }
                    else
                        throw new BadNpcTextFileException(String.Format("Failed to parse parameter {0} with value {1} at line {2}\n\nLine:{3}={4}", Params[0], Params[1], line_count, Params[0], Params[1]));
                }
                else if (Params[0] == "score")
                {
                    int number;
                    bool result = Int32.TryParse(Params[1], out number);
                    if (result)
                    { score = number; en_score = true; }
                    else
                        throw new BadNpcTextFileException(String.Format("Failed to parse parameter {0} with value {1} at line {2}\n\nLine:{3}={4}", Params[0], Params[1], line_count, Params[0], Params[1]));
                }
                else if(Params[0] == "playerblock")
                {
                    bool param = ParseInt(Params[1]);
                    playerblock = param; en_playerblock = true;
                }
                else if(Params[0] == "playerblocktop")
                {
                    bool param = ParseInt(Params[1]);
                    playerblocktop = param; en_playerblocktop = true;
                }
                //
            }
        }
        /// <summary>
        /// Parses an integer as a boolean
        /// </summary>
        /// <param name="parse">The int to parse</param>
        /// <returns>False if 0, True if 1, throws an exception with any value over</returns>
        public bool ParseInt(int parse)
        {
            if (parse == 0)
                return false;
            else if (parse == 1)
                return true;
            else if (parse > 1)
                throw new InvalidCastException(String.Format("Unable to parse {0} as boolean", parse));
            return false;
        }
        public bool ParseInt(string parse)
        {
            int _parse; 
            Int32.TryParse(parse, out _parse);

            if (_parse == 0)
                return false;
            else if (_parse == 1)
                return true;
            else if (_parse > 1)
                throw new InvalidCastException(String.Format("Unable to parse {0} as boolean", parse));
            else throw new Exception(String.Format("Unknown error while parsing {0}", _parse));
        }
        //
    }
}
