using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] instructions = File.ReadAllText("../../Input.txt").Split(',');
            int x = 0, y = 0, dist = 0, max = 0;

            foreach (String instruction in instructions)
            {
                if (instruction == "n")
                {
                    y += 2;
                }
                else if (instruction == "ne")
                {
                    x++;
                    y++;
                }
                else if (instruction == "se")
                {
                    x++;
                    y--;
                }
                else if (instruction == "s")
                {
                    y -= 2;
                }
                else if (instruction == "sw")
                {
                    x--;
                    y--;
                }
                else if (instruction == "nw")
                {
                    x--;
                    y++;
                }

                dist = Math.Max(Math.Abs(x), (int)Math.Ceiling(Math.Abs(y) / 2.0));
                max = Math.Max(max, dist);
            }
            
            Console.WriteLine(max);
            Console.ReadLine();
        }
    }
}
