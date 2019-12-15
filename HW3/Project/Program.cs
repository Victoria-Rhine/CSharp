using System;
using System.IO;

namespace Project
{
    class Program
    {   // Print the command line usage for this program
        private static void PrintUsage()
        {
            Console.WriteLine("Usage is:\n" +
                  "\tjava Main C inputfile outputfile\n\n" +
                  "Where:" +
                  "  C is the column number to fit to\n" +
                  "  inputfile is the input text file \n" +
                  "  outputfile is the new output file base name containing the wrapped text.\n" +
                  "e.g. java Main 72 myfile.txt myfile_wrapped.txt");
        }

        private static int WrapSimply(IQueueInterface<string> words, int columnLength, string outputFileName)
        {
            StreamWriter sw = null;
            int col = 1;
            int spacesRemaining = 0; // running count of spaces remaining

            try
            {
                sw = new StreamWriter(outputFileName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Cannot create or open " + outputFileName +
                            " for writing.  Using standard output instead.");
                sw = new StreamWriter(Console.OpenStandardOutput());
            }

            while (!words.IsEmpty())
            {
                string str = words.Peek();
                int len = str.Length;
                // See if we need to wrap to the next line

                if (col == 1)
                {
                    sw.Write(str);
                    col += len;
                    words.Pop();
                }
                else if ((col + len) >= columnLength)
                {
                    // go to the next line
                    sw.WriteLine();
                    spacesRemaining += (columnLength - col) + 1;
                    col = 1;
                }
                else
                {
                    // typical case of printing the next word on the same line
                    sw.Write(" ");
                    sw.Write(str);
                    col += (len + 1);
                    words.Pop();
                }
            }

            sw.WriteLine();
            sw.Flush();
            sw.Close();
            return spacesRemaining;
        } // end WrapSimply
        static void Main(string[] args)
        {
            int c = 72;
            string inputFileName;
            string outputFileName = "output.txt";
            StreamReader readFile = null;

            // Read the command line arguments
            if (args.Length != 3)
            {
                PrintUsage();
                Environment.Exit(1);
            }
            try
            {
                c = int.Parse(args[0]);
                inputFileName = args[1];
                outputFileName = args[2];
                readFile = File.OpenText(inputFileName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find the input file.");
                Environment.Exit(1);
            }
            catch (Exception)
            {
                Console.WriteLine("Something is wrong with the input.");
                PrintUsage();
                Environment.Exit(1);
            }

            // Read words and their lengths into these vectors
            IQueueInterface<string> words = new LinkedQueue<string>();

            // Read input file, tokenize by whitespace
            while (!readFile.EndOfStream)
            {
                string line = readFile.ReadLine();
                string[] splitWords = line.Split(' ');
                foreach (var word in splitWords)
                {
                    words.Push(word);
                }
            }

            readFile.Close();

            // At this point the input text file has now been placed, word by word, into a FIFO queue
            // Each word does not have whitespace included, but does have punctuation, numbers, etc.

            // As an example, so a simple wrap
            int spacesRemaining = WrapSimply(words, c, outputFileName);
            Console.WriteLine("Total spaces remaining (Greedy): " + spacesRemaining);

            /*-------------------------------------------------------------------------
             * Greedy Algorithm (Non-optimal i.e. approximate or heuristic solution)
             * ------------------------------------------------------------------------*/
        }
    }
}