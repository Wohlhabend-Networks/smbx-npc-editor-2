using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace smbx_npc_editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            MainUI main = new MainUI();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (System.IO.File.Exists(args[0]))
                main.openPassedFile(args[0]);

            Application.Run(main);

        }
    }
}
