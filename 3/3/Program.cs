using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new Dictionary<int, Dictionary<int, int>>();

            items = addToGrid(items, 3, 4, 73);

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (items.ContainsKey(i) && items[i].ContainsKey(j))
                    {
                        Console.Write(items[i][j] + " ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
                Console.WriteLine();
            }

            Console.ReadLine();

            /* while (true)
            {
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine(distance(input));
            } */
        }

        static Dictionary<int, Dictionary<int, int>> addToGrid(Dictionary<int, Dictionary<int, int>> dict, int x, int y, int val)
        {
            if (dict.ContainsKey(x))
            {
                if (!dict.ContainsKey(y))
                {
                    dict[x].Add(y, val);
                }
            }
            else
            {
                dict.Add(x, new Dictionary<int, int> { { y, val } });
            }

            return dict;
        }

        static int distance(int n)
        {
            // https://stackoverflow.com/questions/10094745/find-the-position-nth-element-of-a-rectangular-tiled-spiral

            int k = (int)Math.Ceiling((Math.Sqrt(n) - 1) / 2);
            int t = 2 * k + 1;
            int m = (int)Math.Pow(t, 2);

            int x, y;

            t -= 1;

            if (n >= m - t)
            {
                x = k - (m - n);
                y = -k;

                return Math.Abs(x) + Math.Abs(y);
            }

            m -= t;

            if (n >= m - t)
            {
                x = -k;
                y = -k + (m - n);

                return Math.Abs(x) + Math.Abs(y);
            }

            m -= t;

            if (n >= m - t)
            {
                x = -k + (m - n);
                y = k;

                return Math.Abs(x) + Math.Abs(y);
            }

            x = k;
            y = k - (m - n - t);

            return Math.Abs(x) + Math.Abs(y);
        }
    }
}
