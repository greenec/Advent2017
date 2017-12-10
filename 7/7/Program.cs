using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = File.ReadAllText("../../Input.txt");
            List<Disc> arr = new List<Disc>();

            String line;

            System.IO.StreamReader file = new System.IO.StreamReader("../../Input.txt");
            while ((line = file.ReadLine()) != null)
            {
                int weightStart = line.IndexOf("(") + 1;
                int weightLength = line.IndexOf(")") - weightStart;
                int childrenStart = line.IndexOf("-> ");

                String name = line.Substring(0, line.IndexOf(' '));
                int weight = int.Parse(line.Substring(weightStart, weightLength));
                String[] children;

                if (childrenStart == -1)
                {
                    children = new String[0];
                }
                else
                {
                    children = line.Substring(childrenStart + 3).Split(new String[] { ", " }, StringSplitOptions.None);
                }

                arr.Add(new Disc(name, weight, children));
            }
            file.Close();

            int bottomPos = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (!isChild(arr, arr[i]))
                {
                    bottomPos = i;
                }
            }

            Console.WriteLine("Bottom disc: " + arr[bottomPos].Name);

            String discName = arr[bottomPos].Name;

            while (discName != "stop")
            {
                Disc start = getDisc(arr, discName);

                for (int i = 0; i < start.Children.Length; i++)
                {
                    Disc d = getDisc(arr, start.Children[i]);
                    Console.WriteLine("Name: " + d.Name + ", weight: " + d.Weight + ", tower weight: " + sumTowers(arr, d));
                }

                discName = Console.ReadLine();
            }

            Console.ReadLine();
        }

        static bool isChild(List<Disc> arr, Disc d)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < arr[i].Children.Length; j++)
                {
                    if (arr[i].Children[j] == d.Name)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static int sumTowers(List<Disc> arr, Disc d)
        {
            int sum = 0;
            for (int j = 0; j < d.Children.Length; j++)
            {
                sum += sumTowers(arr, getDisc(arr, d.Children[j]));
            }

            return d.Weight + sum;
        }

        static Disc getDisc(List<Disc> arr, String name)
        {
            for(int i = 0; i < arr.Count; i++)
            {
                if(arr[i].Name == name)
                {
                    return arr[i];
                }
            }
            return arr[0];
        }
    }
}
