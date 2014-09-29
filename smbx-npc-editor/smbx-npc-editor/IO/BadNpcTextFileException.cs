using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smbx_npc_editor.IO
{
    public class BadNpcTextFileException : Exception
    {
        public BadNpcTextFileException()
        { }
        public BadNpcTextFileException(string message)
            : base(message)
        {

        }
        public BadNpcTextFileException(string message, string actualLine)
            : base(message)
        { }
        public BadNpcTextFileException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
