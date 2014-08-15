// (c) Vasian Cepa 2005
// Version 2

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms; // required for NumericComparer : IComparer only

namespace ns
{

	public class NumericComparer<T> : IComparer<T>
	{
		public NumericComparer()
		{}
        private static readonly NumericComparer _innerComparer = new NumericComparer();
		public int Compare(T x, T y)
		{
			if((x is string) && (y is string))
			{
                return _innerComparer.Compare(x.ToString(), y.ToString());
			}
			return -1;
		}
	}//EOC

    public class NumericComparer : IComparer
    {
        public NumericComparer()
        { }
        public int Compare(object x, object y)
        {
            /*
            if ((x is string) && (y is string))
            {
                return StringLogicalComparer.Compare(x.ToString(), y.ToString());
            }
            return -1;*/
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;
            return StringLogicalComparer.Compare(tx.Text, ty.Text);
        }
    }

}