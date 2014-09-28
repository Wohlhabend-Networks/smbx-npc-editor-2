using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;


namespace smbx_npc_editor.IO
{
    using SpriteHandling;

    public class SMBXNpc
    {
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
        public SMBXNpc()
        {
            en_gfxoffsetx=false;
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

        public void ReadFromTextFile(string fileToRead)
        {
            int line_count = 0;
            StreamReader sr = new StreamReader(fileToRead);
            string line;
            line_count++;line = sr.ReadLine();
            while(line != null)
            {
                string ln = line;
                if(line.Replace(" ", "") == "")
                {
                    line_count++;line = sr.ReadLine();
                    continue;
                } //skips empty strings
                line = ln;
                var Params = line.Split(new char[] { '=' }, 2);
                if(Params[0] == "name")
                {
                    string noQuotes = Params[1].Replace("\"", "");
                    this.name = noQuotes;
                    en_name = true;
                }
                else if(Params[0] == "gfxoffsety")
                {
                    int number; //the number output by the tryparse method
                    bool result = Int32.TryParse(Params[1], out number);
                    if(result)
                    { gfxoffsety = number; en_gfxoffsety = true; }
                    else
                        throw new BadNpcTextFileException(String.Format("Failed to parse parameter {0} with value {1} at line {2}", Params[0], Params[1], line_count));
                }
                else if(Params[0] == "gfxoffsetx")
                {
                    int number;
                    bool result = Int32.TryParse(Params[1], out number);
                    if (result)
                    { gfxoffsetx = number; en_gfxoffsetx = true; }
                    else
                        throw new BadNpcTextFileException(String.Format("Failed to parse parameter {0} with value {1} at line {2}", Params[0], Params[1], line_count));
                }
                //
            }
        }

        
    }

    public class BadNpcTextFileException : Exception
    {
        public BadNpcTextFileException()
        { }
        public BadNpcTextFileException(string message) : base(message)
        {

        }
        public BadNpcTextFileException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }

    public class NpcConfigFile
    {
        List<KeyValuePair<string, string>> npcvalues = new List<KeyValuePair<string, string>>();
        bool _output = true;
        bool _isOpen = false;

        /// <summary>
        /// Main constructor for the NPC Config File class
        /// </summary>
        /// <param name="output">Whether or not to occasionally output some debug stuff.</param>
        public NpcConfigFile(bool output)
        {
            Console.WriteLine("Initiating new NpcConfigFile");
            _output = output;
        }

        public bool isOpening
        {
            get { return _isOpen; }
            set
            {
                _isOpen = value;
            }
        }

        public string[] ExportToStringArray()
        {
            try
            {
                List<string> values = new List<string>();
                foreach (var item in npcvalues)
                {
                    values.Add(String.Format("{0}={1}", item.Key, item.Value));
                }
                return values.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled exception in 'ExportToStringArray' method: {0}", ex.Message);
                return null;
            }
        }

        public void StringArrayToKeyValuePair(string[] toConvert)
        {
            Clear();
            for (int i = 0; i < toConvert.Length; i++ )
            {
                if (toConvert[i].Contains('='))
                {
                    var split = toConvert[i].Split(new char[] { '=' }, 2);
                    AddValue(split[0], split[1]);
                }
                else
                    if (_output)
                        Console.WriteLine("Skipped line: {0}", toConvert[i]);
            }
        }

        public int ItemCount()
        {
            return npcvalues.Count();
        }

        public void Clear()
        {
            if (npcvalues != null)
            {
                npcvalues.Clear();
            }
            //Console.WriteLine("Initiating new NpcConfigFile");
        }

        /// <summary>
        /// Loads the npc file into memory.
        /// </summary>
        /// <param name="FileName"></param>
        public void Load(string FileName)
        {
            StreamReader sr = new StreamReader(FileName);

            Regex regexcomment = new Regex("^([\\s]*#.*)", (RegexOptions.Singleline | RegexOptions.IgnoreCase));
            Regex regexkey = new Regex("^\\s*([^=\\s]*)[^=]*=(.*)", (RegexOptions.Singleline | RegexOptions.IgnoreCase));

            if (_output)
                Console.WriteLine("Reading file {0}", FileName);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line != null)
                {

                    Match m = null;
                    if (regexcomment.Match(line).Success)
                    {
                        m = regexcomment.Match(line);
                        //ignore
                        Console.WriteLine("Ignoring comment");
                    }
                    if (regexkey.Match(line).Success)
                    {
                        m = regexkey.Match(line);
                        var split = line.Split(new char[] { '=' }, 2);
                        npcvalues.Add(new KeyValuePair<string, string>(split[0], split[1]));
                        if (_output)
                            Console.WriteLine("{0} is {1}", split[0], split[1]);
                    }
                    else
                    {
                        Console.WriteLine("Woah there! You dun goofed: {0}", line);
                    }
                }
            }
            sr.Close();
        }

        public List<KeyValuePair<string, string>> List()
        {
            return npcvalues;
        }

        /// <summary>
        /// Add or replace (yes it does both :D) a key and its value
        /// </summary>
        /// <param name="key">The name of the key you want to add</param>
        /// <param name="value">The value of said key</param>

        public void AddValue(string key, string value)
        {
            bool replaced = false;
            if (!_isOpen)
            {
                foreach (var lol in npcvalues)
                {
                    if (String.Equals(lol.Key, key))
                    {
                        npcvalues.Remove(lol);
                        npcvalues.Add(new KeyValuePair<string, string>(key, value));
                        replaced = true;
                        break;
                    }
                }
                if (!replaced)
                    npcvalues.Add(new KeyValuePair<string, string>(key, value));
                if (_output)
                    Console.WriteLine("Adding key {0} with value {1}", key, value);
            }
        }

        /// <summary>
        /// Removes a key
        /// </summary>
        /// <param name="key">The key you want to remove</param>
        public void RemoveValue(string key)
        {
            foreach(var lol in npcvalues)
            {
                if (String.Equals(lol.Key, key))
                    npcvalues.Remove(lol);
                break;
            }
            if (_output)
                Console.WriteLine("Removing key {0}", key);
        }

        public void Save(string filename, bool writeGenerate)
        {
            StreamWriter writer = new StreamWriter(filename);
            if (writeGenerate)
                writer.WriteLine("watermark=Generated by the SMBX NPC Editor by Luigifan2010");
            foreach (var val in npcvalues)
            {
                Console.WriteLine("Writing key {0} with value {1} to file {2}", val.Key, val.Value, Path.GetFileName(filename));
                writer.WriteLine(String.Format("{0}={1}", val.Key, val.Value));
            }
            writer.Flush();
            writer.Close();
        }

        public string GetKeyValue(string key)
        {
            string s = key.Trim();
            string returnval = null;
            foreach (var val in npcvalues)
            {
                if (String.Equals(val.Key.ToString(), s, StringComparison.CurrentCultureIgnoreCase))
                {
                    returnval = val.Value.ToString();
                    goto returning;
                }
                else
                {
                    returnval = null;
                }
            }
        returning:
            return returnval;
        }
        /// <summary>
        /// DONT USE NOT DONE
        /// </summary>
        /// <param name="keyToChange"></param>
        /// <param name="newValue"></param>
        public void SetKeyValue(string keyToChange, string newValue)
        {
            var config = npcvalues.Find(item => item.Key == keyToChange);

            Console.WriteLine("Changing key value of {0} to {1}", config.Key, newValue);
        }
        //

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

    }
}
