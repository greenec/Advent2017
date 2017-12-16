using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _15
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger a = 277, b = 349, count = 0;

            for (int i = 0; i < 5000000; i++)
            {
                a = (a * 16807) % 2147483647;
                while (a % 4 != 0)
                {
                    a = (a * 16807) % 2147483647;
                }

                b = (b * 48271) % 2147483647;
                while (b % 8 != 0)
                {
                    b = (b * 48271) % 2147483647;
                }

                if (a % 0x10000 == b % 0x10000)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
