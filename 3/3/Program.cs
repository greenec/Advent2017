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
            var grid = new Grid();

            grid.add(3, 4, 73);
            grid.draw();

            Console.ReadLine();
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
