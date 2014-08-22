using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;

namespace smbx_npc_editor.IO
{
    public class NpcConfigFile
    {
        List<KeyValuePair<string, string>> npcvalues = new List<KeyValuePair<string,string>>();

        public void Clear()
        {
            if (npcvalues != null)
            {
                npcvalues.Clear();
            }
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
                        Console.WriteLine("{0} is {1}", split[0], split[1]);
                    }
                    else
                    {
                        Console.WriteLine("Woah there! You dun goofed: {0}", line);
                    }
                }
            }
        }

        public void AddValue(string key, string value)
        {
            bool replaced = false;
            foreach(var lol in npcvalues)
            {
                if(String.Equals(lol.Key, key))
                {
                    npcvalues.Remove(lol);
                    npcvalues.Add(new KeyValuePair<string,string>(key, value));
                    replaced = true;
                }
            }
            if (!replaced)
                npcvalues.Add(new KeyValuePair<string, string>(key, value));
            Console.WriteLine("Adding key {0} with value {1}", key, value);
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
        //
    }
}
