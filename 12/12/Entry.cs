using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12
{
    class Entry
    {
        public int number;
        public List<int> children;

        public Entry(int n, List<int> c)
        {
            number = n;
            children = c;
        }
    }
}
