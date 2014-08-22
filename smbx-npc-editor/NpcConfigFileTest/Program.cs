using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpcConfigFileTest;
using smbx_npc_editor.IO;
using System.IO;

namespace NpcConfigFileTest
{
    class Program
    {
        static NpcConfigFile npc = new NpcConfigFile(false);
        static void Main(string[] args)
        {
            beginning: 
            Console.WriteLine("Enter the file path to the NPC file you want to load");
            string arg = Console.ReadLine();
            if(File.Exists(arg))
            {
                npc.Load(arg);
                foreach(var val in npc.List())
                {
                    Console.WriteLine("Key {0} with value of {1}", val.Key, val.Value);
                }
                Console.ReadLine();
                acceptInput();
            }
            else
            {
                Console.WriteLine("Doesn't exist, try again");
                goto beginning;
            }
        }

        static void acceptInput()
        {
            Console.WriteLine("Type the command (help to list them)");
            string arg = Console.ReadLine();
            cmdInputInterpreter(arg);
        }

        static void cmdInputInterpreter(string command)
        {
            var split = command.Split(new char[] { ' ' }, 2);
            switch(split[0])
            {
                case("help"):
                    listCommands();
                    acceptInput();
                    break;
                case("save"):
                    npc.Save(@"C:\Users\Mike\Desktop\npc-test.txt", true);
                    Console.WriteLine("Saved!");
                    acceptInput();
                    break;
                case("add-key"):
                    addKey(split[1]);
                    break;
            }
        }

        static void listCommands()
        {
            Console.WriteLine("help: displays this");
            Console.WriteLine("add-key: add a key, then asks for a value");
            Console.WriteLine("save: saves file to desktop");
        }

        static void addKey(string key)
        {
            Console.WriteLine("Enter the value for this");
            string arg = Console.ReadLine();
            npc.AddValue(key, arg);
            acceptInput();
        }
        //
    }
}
