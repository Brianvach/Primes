using System;
using System.Collections;
using System.IO;

namespace Primes
{
    class Program
    {
        static void OldMain(string[] args)
        {
            string[] ls;
            //put the initial command into a try catch to ensure the program is able to close gracefully
            try
            {
                ls = File.ReadAllLines(args[0]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Please pass the path as an argument");
                return; //Use return to exit the program, no need to continue running the application as it is run from the command line.
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Path does not lead to a valid file");
                return;
            }

            for (int i = 0; i < ls.Length; i++)
            {
                string l = ls[i];
                int n = int.Parse(l);
                string output = CalculatePrimes(n); //Refactor into seperate method, easier for testing
                Console.WriteLine(output);
            }
        }

        static void Main(string[] args)
        {
            Prime prime;
            try
            {
                prime = new Prime(args[0]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Please pass a path to the text file.");
                return;
            }
            prime.PrintAll();
        }

        //Refactor actual calculation to a seperate method.
        
    }
}
