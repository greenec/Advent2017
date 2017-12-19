using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_17
{
    class Program
    {
        static void Main(string[] args)
        {
            int pos = 0, steps = 355;
            List<int> list = new List<int> { 0 };

            for (int i = 1; i < 2018; i++)
            {
                pos = (pos + steps) % list.Count + 1;
                list.Insert(pos, i);
            }

            int output = 0;

            for (int i = 1; i < 50000000; i++)
            {
                pos = (pos + steps) % i + 1;
                if (pos == 1)
                {
                    output = i;
                }
            }

            //Console.WriteLine(list[pos + 1]);
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
