using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter number to be 'summed:' ");
                // String input = Console.ReadLine();
                String input = File.ReadAllText("../../Input.txt");
                Console.Write(input);

                // BigInteger sum = sum1(input);
                int sum = sum2(input);

                Console.WriteLine("Sum: " + sum);
                Console.ReadLine();
            }

        }

        static BigInteger sum1(String input)
        {
            BigInteger num = BigInteger.Parse(input[input.Length - 1] + input);

            BigInteger sum = 0;
            BigInteger last = num % 10;
            num /= 10;

            while (num != 0)
            {
                if (num % 10 == last)
                {
                    sum += num % 10;
                }
                last = num % 10;
                num /= 10;
            }

            return sum;
        }

        static int sum2(String input)
        {
            int sum = 0;
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] == input[((input.Length / 2) + i) % input.Length])
                {
                    sum += Convert.ToInt32(input[i] + "");
                }
            }
            return sum;
        }
    }
}
