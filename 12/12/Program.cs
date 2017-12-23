using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _12
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] input = File.ReadAllLines("../../Input.txt");

            bool flag = true;
            int count = 1;
            List<Entry> programs = new List<Entry>();
            List<int> touchesZero = new List<int>() { 0 };

            foreach (String line in input)
            {
                int programNum = int.Parse(line.Substring(0, line.IndexOf(" ")));
                List<int> children = line.Substring(line.IndexOf(">") + 1).Replace(" ", "").Split(',').Select(int.Parse).ToList();
                programs.Add(new Entry(programNum, children));
            }

            while (flag)
            {
                flag = false;
                for (int i = 0; i < programs.Count; i++)
                {
                    if (programs[i].number == 0)
                    {
                        touchesZero.AddRange(programs[i].children);
                        count += programs[i].children.Count;
                        programs.RemoveAt(i);
                        Console.WriteLine("Adding: " + String.Join(", ", programs[i].children));
                        i--;
                        continue;
                    }

                    if (programs[i].children.Intersect(touchesZero).ToList().Count != 0)
                    {
                        flag = true;
                        programs.RemoveAt(i);
                        Console.WriteLine("Adding: " + String.Join(", ", programs[i].children));
                        count++;
                        i--;
                    }
                }
                if (!flag)
                {
                    break;
                }
            }

            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
