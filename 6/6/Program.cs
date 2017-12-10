using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;

            List<int> banks = File.ReadAllText("../../Input.txt").Split('\t').Select(int.Parse).ToList();
            List<List<int>> history = new List<List<int>>();

            while (!contains(history, banks))
            {
                // make sure things are added this way... we don't add references to lists. that's how people get hurt
                history.Add(banks.ToList());
                banks = reallocate(banks);
                count++;
            }

            List<int> target = banks.ToList();
            count = 0;

            while (true)
            {
                count++;
                if (reallocate(banks).SequenceEqual(target))
                {
                    break;
                }
            }

            Console.WriteLine(count);
            Console.ReadLine();
        }

        static List<int> reallocate(List<int> input)
        {
            int maxPos = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] > input[maxPos])
                {
                    maxPos = i;
                }
            }

            int count = input[maxPos];
            input[maxPos] = 0;

            while (count > 0)
            {
                maxPos++;
                input[maxPos % input.Count] += 1;
                count--;
            }

            return input;
        }

        static bool contains(List<List<int>> haystack, List<int> needle)
        {
            for (int i = 0; i < haystack.Count; i++)
            {
                if (needle.SequenceEqual(haystack[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
