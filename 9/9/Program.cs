using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            String stream = File.ReadAllText("../../Input.txt");
            bool inGarbage = false;
            int parentScore = 0, score = 0, garbageCount = 0;

            for (int i = 0; i < stream.Length; i++)
            {
                if (stream[i] == '!')
                {
                    i++;
                    continue;
                }

                if (inGarbage)
                {
                    if(stream[i] == '>')
                    {
                        inGarbage = false;
                        continue;
                    }
                    garbageCount++;
                    continue;
                }

                if (stream[i] == '<')
                {
                    inGarbage = true;
                    continue;
                }

                if (stream[i] == '{')
                {
                    parentScore++;
                    score += parentScore;
                    continue;
                }

                if(stream[i] == '}')
                {
                    parentScore--;
                    continue;
                }
            }
            
            Console.WriteLine("Score: " + score);
            Console.WriteLine("Garbage count: " + garbageCount);
            Console.ReadLine();
        }
    }
}
