using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            String line;
            int sum = 0;

            System.IO.StreamReader file = new System.IO.StreamReader("../../Input.txt");
            while ((line = file.ReadLine()) != null)
            {
                String[] arr = line.Split('\t');

                sum += calcDivs(arr);
            }
            file.Close();

            Console.WriteLine("Checksum: " + sum);
            System.Console.ReadLine();
        }

        static int calcDiff(String[] input)
        {
            int[] arr = Array.ConvertAll(input, int.Parse);
            int max = arr[0], min = arr[0];
            foreach(int num in arr)
            {
                max = (num > max) ? num : max;
                min = (num < min) ? num : min;
            }
            return max - min;
        }

        static int calcDivs(String[] input)
        {
            int[] arr = Array.ConvertAll(input, int.Parse);

            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr.Length; j++)
                {
                    if(i != j && arr[i] % arr[j] == 0)
                    {
                        return arr[i] / arr[j];
                    }
                }
            }

            return 0;
        }
    }
}
