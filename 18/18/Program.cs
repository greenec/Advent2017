using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _18
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] instructions = File.ReadAllLines("../../Input.txt");
            Dictionary<String, long> registers = new Dictionary<String, long>();
            long lastPlayedFreq = 0;

            // initialize registers if not an integer
            for (int i = 0; i < instructions.Length; i++)
            {
                String[] components = instructions[i].Split(' ');
                if (!long.TryParse(components[1], out var n))
                {
                    registers[components[1]] = 0;
                }
            }

            for (long i = 0; i < instructions.Length; i++)
            {
                String[] components = (instructions[i] + " 0").Split(' ');
                long x = (registers.ContainsKey(components[1])) ? registers[components[1]] : long.Parse(components[1]);
                long y = (registers.ContainsKey(components[2])) ? registers[components[2]] : long.Parse(components[2]);

                if (components[0] == "snd")
                {
                    lastPlayedFreq = x;
                }
                else if (components[0] == "set")
                {
                    registers[components[1]] = y;
                }
                else if (components[0] == "add")
                {
                    registers[components[1]] += y;
                }
                else if (components[0] == "mul")
                {
                    registers[components[1]] *= y;
                }
                else if (components[0] == "mod")
                {
                    registers[components[1]] %= y;
                }
                else if (components[0] == "rcv")
                {
                    if (x != 0)
                    {
                        break;
                    }
                }
                else if (components[0] == "jgz")
                {
                    if (x > 0)
                    {
                        i += y - 1;
                    }
                }
            }

            Console.WriteLine(lastPlayedFreq);
            Console.ReadLine();
        }
    }
}
