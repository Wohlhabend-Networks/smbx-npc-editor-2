using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;

namespace smbx_npc_editor.IO
{

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
        public uint gfxwidth;

        public bool en_gfxheight;
        public uint gfxheight;

        public bool en_score;
        public uint score;

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
        bool nohurt;

        public bool en_noblockcollision;
        bool noblockcollision;

        public bool en_cliffturn;
        bool cliffturn;

        public bool en_noyoshi;
        bool noyoshi;

        public bool en_foreground;
        bool foreground;

        public bool en_speed;
        float speed;

        public bool en_nofireball;
        bool nofireball;

        public bool en_nogravity;
        bool nogravity;

        public bool en_frames;
        uint frames;

        public bool en_framespeed;
        uint framespeed;

        public bool en_framestyle;
        uint framestyle;

        public bool en_noiceball;
        bool noiceball;
        
        //Extended
        public bool en_nohammer;
        bool nohammer;

        public bool en_noshell;
        bool noshell;

        public bool en_name;
        string name;
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
    }
}
