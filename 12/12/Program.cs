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

            int groupCount = 0;
            List<Entry> programs = new List<Entry>();

            foreach (String line in input)
            {
                int programNum = int.Parse(line.Substring(0, line.IndexOf(" ")));
                List<int> children = line.Substring(line.IndexOf(">") + 1).Replace(" ", "").Split(',').Select(int.Parse).ToList();
                programs.Add(new Entry(programNum, children));
            }

            while (programs.Count > 0)
            {
                List<int> group = new List<int>();
                bool flag = true;
                group.Add(programs[0].number);
                programs.RemoveAt(0);
                while (flag)
                {
                    flag = false;
                    for (int i = 0; i < programs.Count; i++)
                    {
                        if (programs[i].children.Intersect(group).ToList().Count != 0)
                        {
                            flag = true;

                            group.Add(programs[i].number);
                            group.AddRange(programs[i].children);
                            group = group.Distinct().ToList();

                            programs.RemoveAt(i);
                            i--;
                        }
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
                groupCount++;
            }

            Console.WriteLine(groupCount);
            Console.ReadLine();
        }
    }
}
