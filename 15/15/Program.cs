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
            Console.WriteLine(part1(40000000));
            Console.WriteLine(part2(5000000));

            Console.ReadLine();
        }

        static int part1(int iterations)
        {
            int count = 0;
            long a = 277, b = 349;

            for (int i = 0; i < iterations; i++)
            {
                a = (a * 16807) % 2147483647;
                b = (b * 48271) % 2147483647;

                if (a % 0x10000 == b % 0x10000)
                {
                    count++;
                }
            }

            return count;
        }

        static int part2(int iterations)
        {
            int count = 0;
            long a = 277, b = 349;

            for(int i = 0; i < iterations; i++)
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

            return count;
        }
    }
}
