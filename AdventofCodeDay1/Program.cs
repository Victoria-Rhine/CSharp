using System;

namespace AdventofCodeDay1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\torir\source\repos\AdventofCodeDay1\input.txt");

            CalculateFuel(lines);

            static void CalculateFuel(string[] lines)
            {
                double num;
                double total = 0;

                foreach (string line in lines)
                {
                    num = (Math.Floor(((Convert.ToDouble(line))) / 3) - 2);
                    total += num;
                }

                Console.WriteLine("The total is: " + total);
            }

            CalculateTotalFuel(lines);

            static void CalculateTotalFuel(string[] lines)
            {
                double num;
                double total = 0;

                foreach (string line in lines)
                {
                    num = (Math.Floor(((Convert.ToDouble(line))) / 3) - 2);
                    total += num;

                    if (Math.Floor(num / 3) - 2 > 0)
                    {
                        do
                        {
                           num = Math.Floor(num / 3) - 2;
                           total += num;
                        } while (Math.Floor(num / 3) - 2 > 0);
                    }       
                }
                Console.WriteLine("The final total is: " + total);
            }
        }
    }
}
