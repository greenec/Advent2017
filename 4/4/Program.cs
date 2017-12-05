using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                String line;
                int numValid = 0;

                System.IO.StreamReader file = new System.IO.StreamReader("../../Input.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (isValidPassphrase2(line))
                    {
                        numValid++;
                    }
                }
                file.Close();

                Console.WriteLine(numValid);
                Console.ReadLine();
            }
        }

        static bool isValidPassphrase(String input)
        {
            String[] arr = input.Split(' ');

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (i != j && arr[i] == arr[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static bool isValidPassphrase2(String input)
        {
            String[] arr = input.Split(' ');

            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = String.Concat(arr[i].OrderBy(c => c));
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (i != j && arr[i] == arr[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
