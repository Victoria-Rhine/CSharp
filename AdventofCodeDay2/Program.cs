using System;
using System.Collections.Generic;

namespace AdventofCodeDay2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\torir\source\repos\AdventofCodeDay2\input.txt");
            string[] intcode = text.Split(',');

            List<int> programNum = new List<int>();
            foreach (var num in intcode) {
                programNum.Add(Convert.ToInt32(num));
            }

            int opcode;
            int value;
            int first;
            int second;
            int location;

           programNum[1] = 57; 
           programNum[2] = 41;
            //19690720

            for (int i = 0; i <= programNum.Count; i += 4)
            {
                opcode = programNum[i];

                if (opcode == 1)
                {
                    first = programNum[i + 1];
                    second = programNum[i + 2];
                    location = programNum[i + 3];
                    value = programNum[first] + programNum[second];
                    programNum[location] = value;
                }
                else if (opcode == 2)
                {
                    first = programNum[i + 1];
                    second = programNum[i + 2];
                    location = programNum[i + 3];
                    value = programNum[first] * programNum[second];
                    programNum[location] = value;
                }
                else if (opcode == 99)
                            break;
                else
                    Console.WriteLine("Oops, unknown code");
            }
            Console.WriteLine("Value at position 0 is: " + programNum[0]);
        }
    }
}
