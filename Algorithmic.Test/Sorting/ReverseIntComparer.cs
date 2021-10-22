using System;
using System.Collections.Generic;

namespace Algorithmic.Sorting
{
    internal class ReverseIntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x == y)
                return 0;
            if (x < y)
                return 1;
            if (x > y)
                return -1;
            else
                throw new Exception();
        }
    }
}
