using Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smbx_npc_editor.IO
{
    /// <summary>
    /// A class to convert wohlstand's ini format to SMBX format.
    /// </summary>
    class WohlToSMBX
    {
        /// <summary>
        /// Converts the value from Wohl's format to SMBX's format. Useful for quick conversions if Wohl's differ from SMBX's
        /// </summary>
        /// <param name="config">The config file to use, passed as the IniFile instance</param>
        /// <param name="wohlKey">The key to use (ex: gfx-offset-x)</param>
        /// <param name="npcId">The NPC's ID</param>
        /// <returns></returns>
        public KeyValuePair<string, string> ConvertToSMBX(IniFile config, string wohlKey, string npcId)
        {
            var val = config.ReadValue(npcId, wohlKey);
            switch (wohlKey)
            {
                case ("gfx-offset-x"):
                    return new KeyValuePair<string, string>("gfxoffsetx", val);
                    
                case ("gfx-offset-y"):
                    return new KeyValuePair<string, string>("gfxoffsety", val);
                    
                case ("gfx-height"):
                    return new KeyValuePair<string, string>("gfxheight", val);
                    
                case ("gfx-width"):
                    return new KeyValuePair<string, string>("gfxwidth", val);
                    
                case ("frame-style"):
                    return new KeyValuePair<string, string>("framestyle", val);
                    
                case ("frames"):
                    return new KeyValuePair<string, string>("frames", val);
                    
                case ("frame-speed"): //uses ms
                    throw new NotSupportedException("Framespeed conversions not yet available");
                    
                case ("foreground"):
                    return new KeyValuePair<string, string>("foreground", val);
                    
                case ("speed"):
                    throw new NotSupportedException("Speed conversions not yet available");
                    
                case ("score"):
                    return new KeyValuePair<string, string>("score", val);
                    
                case ("yoshicaneat"):
                    if (val == "0")
                        val = "1";
                    else if (val == "1")
                        val = "0";
                    return new KeyValuePair<string, string>("noyoshi", val);
                    
                case ("grab-side"):
                    return new KeyValuePair<string, string>("grabside", val);
                    
                case ("grab-top"):
                    return new KeyValuePair<string, string>("grabtop", val);
                    
                case ("hurtplayer"):
                    if (val == "0")
                        val = "1";
                    else if (val == "1")
                        val = "0";
                    return new KeyValuePair<string, string>("nohurt", val);
                    
                case ("fixture-width"):
                    return new KeyValuePair<string, string>("width", val);
                    
                case ("fixture-height"):
                    return new KeyValuePair<string, string>("height", val);
                    
                case ("block-npc"):
                    return new KeyValuePair<string, string>("npcblock", val);
                    
                case ("block-npc-top"):
                    return new KeyValuePair<string, string>("npc-block-top", val);
                    
                case ("block-player"):
                    return new KeyValuePair<string, string>("playerblock", val);
                    
                case ("block-player-top"):
                    return new KeyValuePair<string, string>("playerblocktop", val);
                    
                case ("gravity"):
                    if (val == "0")
                        val = "1";
                    else if (val == "1")
                        val = "0";
                    return new KeyValuePair<string, string>("nogravity", val);
                    
                case ("kill-fireball"):
                    if (val == "0")
                        val = "1";
                    else if (val == "1")
                        val = "0";
                    return new KeyValuePair<string, string>("nofireball", val);
                    
                case ("kill-iceball"):
                    if (val == "0")
                        val = "1";
                    else if (val == "1")
                        val = "0";
                    return new KeyValuePair<string, string>("noiceball", val);
                    
                case ("cliffturn"):
                    return new KeyValuePair<string, string>("cliffturn", val);
                    
                case ("kill-onjump"):
                    if (val == "0")
                        val = "1";
                    else if (val == "1")
                        val = "0";
                    return new KeyValuePair<string, string>("jumphurt", val);
                    
                case ("collision-blocks"):
                    if (val == "0")
                        val = "1";
                    else if (val == "1")
                        val = "0";
                    return new KeyValuePair<string, string>("noblockcollision", val);
                    
            }
            return new KeyValuePair<string, string>("NULL", "NULL");
        }

    }
}
