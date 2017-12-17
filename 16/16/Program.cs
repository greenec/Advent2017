using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _16
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] instructions = File.ReadAllText("../../Input.txt").Split(',');
            String programs = "abcdefghijklmnop";
            List<String> states = new List<String>();

            int iterations = 1000000000;

            for (int j = 0; j < iterations; j++)
            {
                for (int i = 0; i < instructions.Length; i++)
                {
                    String instruction = instructions[i];

                    if (instruction[0] == 's')
                    {
                        int idx = programs.Length - int.Parse(instruction.Substring(1));
                        programs = programs.Substring(idx) + programs.Substring(0, idx);
                    }
                    if (instruction[0] == 'x')
                    {
                        int[] arr = instruction.Substring(1).Split('/').Select(int.Parse).ToArray();
                        char a = programs[arr[0]];
                        char b = programs[arr[1]];

                        programs = programs.Replace(a, '?').Replace(b, a).Replace('?', b);
                    }
                    if (instruction[0] == 'p')
                    {
                        char a = instruction[1];
                        char b = instruction[3];

                        programs = programs.Replace(a, '?').Replace(b, a).Replace('?', b);
                    }
                }

                if (states.Contains(programs))
                {
                    programs = states[iterations % j - 1];
                    break;
                }
                else
                {
                    states.Add(programs);
                }
            }

            Console.WriteLine(programs);
            Console.ReadLine();
        }
    }
}
