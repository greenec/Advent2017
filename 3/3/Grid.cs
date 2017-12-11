using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Grid
    {
        Dictionary<int, Dictionary<int, int>> grid;

        public Grid()
        {
            grid = new Dictionary<int, Dictionary<int, int>>();
        }

        public void add(int x, int y, int val)
        {
            if (grid.ContainsKey(x))
            {
                if (!grid.ContainsKey(y))
                {
                    grid[x].Add(y, val);
                }
            }
            else
            {
                grid.Add(x, new Dictionary<int, int> { { y, val } });
            }
        }

        public void draw()
        {
            int xMax = 0, yMax = 0;

            foreach (KeyValuePair<int, Dictionary<int, int>> entry in grid)
            {
                if (entry.Key > yMax)
                {
                    yMax = entry.Key;
                }

                foreach (KeyValuePair<int, int> childEntry in entry.Value)
                {
                    if (childEntry.Key > xMax)
                    {
                        xMax = childEntry.Key;
                    }
                }
            }

            for (int j = 0; j <= xMax; j++)
            {
                for (int i = 0; i <= yMax; i++)
                {
                    if (grid.ContainsKey(i) && grid[i].ContainsKey(j))
                    {
                        Console.Write(grid[i][j] + " ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
