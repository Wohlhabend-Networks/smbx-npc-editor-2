using Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using smbx_npc_editor.SpriteHandling;

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
            KeyValuePair<string, string> returnVal = new KeyValuePair<string, string>();
            var val = config.ReadValue(npcId, wohlKey);
            switch (wohlKey)
            {
                case ("gfx-offset-x"):
                    return new KeyValuePair<string, string>("gfxoffsetx", val);
                    break;
                case ("gfx-offset-y"):
                    return new KeyValuePair<string, string>("gfxoffsety", val);
                    break;
                case ("gfx-height"):
                    return new KeyValuePair<string, string>("gfxheight", val);
                    break;
                case ("gfx-width"):
                    return new KeyValuePair<string, string>("gfxwidth", val);
                    break;
                case ("frame-style"):
                    return new KeyValuePair<string, string>("framestyle", val);
                    break;
                case ("frames"):
                    return new KeyValuePair<string, string>("frames", val);
                    break;
                case ("frame-speed"): //uses ms
                    throw new NotSupportedException("Framespeed conversions not yet available");
                    break;
                case ("foreground"):
                    return new KeyValuePair<string, string>("foreground", val);
                    break;
                case ("speed"):
                    throw new NotSupportedException("Speed conversions not yet available");
                    break;
                case ("score"):
                    return new KeyValuePair<string, string>("score", val);
                    break;
                case ("yoshicaneat"):
                    if (val == "0")
                        val = "1";
                    else if (val == "1")
                        val = "0";
                    return new KeyValuePair<string, string>("noyoshi", val);
                    break;
                case ("grab-side"):
                    return new KeyValuePair<string, string>("grabside", val);
                    break;
                case ("grab-top"):
                    return new KeyValuePair<string, string>("grabtop", val);
                    break;
                case ("hurtplayer"):
                    if (val == "0")
                        val = "1";
                    else if (val == "1")
                        val = "0";
                    return new KeyValuePair<string, string>("nohurt", val);
                    break;
                case ("fixture-width"):
                    return new KeyValuePair<string, string>("width", val);
                    break;
                case ("fixture-height"):
                    return new KeyValuePair<string, string>("height", val);
                    break;
                case ("block-npc"):
                    return new KeyValuePair<string, string>("npcblock", val);
                    break;
                case ("block-npc-top"):
                    return new KeyValuePair<string, string>("npc-block-top", val);
                    break;
                case ("block-player"):
                    return new KeyValuePair<string, string>("playerblock", val);
                    break;
                case ("block-player-top"):
                    return new KeyValuePair<string, string>("playerblocktop", val);
                    break;
                case ("gravity"):
                    if (val == "0")
                        val = "1";
                    else if (val == "1")
                        val = "0";
                    return new KeyValuePair<string, string>("nogravity", val);
                    break;
                case ("kill-fireball"):
                    if (val == "0")
                        val = "1";
                    else if (val == "1")
                        val = "0";
                    return new KeyValuePair<string, string>("nofireball", val);
                    break;
                case ("kill-iceball"):
                    if (val == "0")
                        val = "1";
                    else if (val == "1")
                        val = "0";
                    return new KeyValuePair<string, string>("noiceball", val);
                    break;
                case ("cliffturn"):
                    return new KeyValuePair<string, string>("cliffturn", val);
                    break;
                case ("kill-onjump"):
                    if (val == "0")
                        val = "1";
                    else if (val == "1")
                        val = "0";
                    return new KeyValuePair<string, string>("jumphurt", val);
                    break;
                case ("collision-blocks"):
                    if (val == "0")
                        val = "1";
                    else if (val == "1")
                        val = "0";
                    return new KeyValuePair<string, string>("noblockcollision", val);
                    break;
            }
            return new KeyValuePair<string, string>("NULL", "NULL");
        }

    }
}
