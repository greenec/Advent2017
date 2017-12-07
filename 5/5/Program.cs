using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            String line;

            System.IO.StreamReader file = new System.IO.StreamReader("../../Input.txt");
            while ((line = file.ReadLine()) != null)
            {
                list.Add(int.Parse(line));
            }
            file.Close();

            int pos = 0, steps = 0;

            while(pos >= 0 && pos < list.Count)
            {
                if(list[pos] >= 3)
                {
                    list[pos] -= 1;
                    pos += list[pos] + 1;
                }
                else
                {
                    list[pos] += 1;
                    pos += list[pos] - 1;
                }

                steps++;
            }

            Console.WriteLine(steps);
            Console.ReadLine();
        }
    }
}
