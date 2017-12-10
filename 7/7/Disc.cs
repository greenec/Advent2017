using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    class Disc
    {
        public String Name;
        public int Weight;
        public String[] Children;

        public Disc(String n, int w, String[] c)
        {
            Name = n;
            Weight = w;
            Children = c;
        }
    }
}
