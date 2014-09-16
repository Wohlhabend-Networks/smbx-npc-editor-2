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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainUI main = new MainUI();

            if(args.Length > 0)
                if (System.IO.File.Exists(args[0]))
                    main.openPassedFile(args[0]);

            Application.Run(main);

        }
    }
}
