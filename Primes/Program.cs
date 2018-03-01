using System;
using System.Collections;
using System.IO;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimesCLI prime;
            try
            {
                prime = new PrimesCLI(args[0]);
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
