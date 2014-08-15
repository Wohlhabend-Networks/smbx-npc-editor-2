using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ini_editor
{
    public class ExtendedTreeNode : TreeNode
    {
        /// <summary>
        /// The type it is. Specifically for the ini file.
        /// 0. Section
        /// 1. Key
        /// 2. Value
        /// </summary>
        public TreeNode node;
        public int type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">The name, duh</param>
        /// <param name="_type">Integer type
        /// 0. Section
        /// 1. Key
        /// 2. Value
        /// </param>
        public ExtendedTreeNode(string name, int _type) : base(name)
        {
            type = _type;
        }

        public int GetIntegerType()
        {
            return type;
        }
    }
}

