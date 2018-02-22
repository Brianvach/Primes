using System;
using System.Collections;
using System.IO;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
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

        //Refactor actual calculation to a seperate method.
        public static string CalculatePrimes(int n)
        {
            string output = n + ": "; //create output string to return to the application
            if (n == 1)
            {
                return output + "1, "; // Is 1 a prime number??? Debated, but for the sake of this program, it will be assumed so.
                //return the value since 1 is the most that it will be.
            }
            else
            {
                //keep the 2 specific method, as it is the only even prime number
                while (n % 2 == 0)
                {
                    n /= 2;
                    output += "2, ";
                }

                //removed the specific method for 3, as it is redundant in the next part of the function

                int x = (int)Math.Floor(Math.Sqrt(n)) + 1;
                for (int j = 3; j < x && n != 1; j += 2) //Added test to see if number has already searched for all primes
                {
                    while (n % j == 0)
                    {
                        n /= j;
                        output += j.ToString();
                        output += ", ";
                    }
                }

                if (n > 1)
                {
                    output += n.ToString();
                    output += ", ";
                }
            }
            return output;
        }
    }
}
