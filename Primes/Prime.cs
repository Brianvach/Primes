using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Primes
{
    class Prime
    {
        private string output;
        private Dictionary<int, string> PrimeTable = new Dictionary<int, string>(); //Store table of primes to reduce compute time.
        private int[] IntputValues;
        
        public Prime(string Path)
        {
            ExtractIntArray(ExtractTextFromPath(Path));
        }

        private string ExtractTextFromPath(string path)
        {
            string[] ls;
            try
            {
                ls = File.ReadAllLines(path);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Path does not lead to a valid file");
                return null;
            }
            throw new NotImplementedException();
        }

        private void ExtractIntArray(string RawInput)
        {
            string[] InputArray = RawInput.Split('\n');
            this.IntputValues = Array.ConvertAll(InputArray, s => Int32.Parse(s));
        }

        public string CalculatePrimes(int PassedValue)
        {
            string Output;
            int CurrentValue = PassedValue;
            if (PrimeTable.TryGetValue(CurrentValue, out Output))
            {
                return Output;
            }
            Output = CurrentValue + ": "; //create output string to return to the application
            if (CurrentValue == 1)
            {
                return Output + "1, "; // Is 1 a prime number??? Debated, but for the sake of this program, it will be assumed so.
                //return the value since 1 is the most that it will be.
            }
            else
            {
                //keep the 2 specific method, as it is the only even prime number
                DivideByPrime(ref CurrentValue, ref Output, 2);

                //removed the specific method for 3, as it is redundant in the next part of the function

                int x = (int)Math.Floor(Math.Sqrt(CurrentValue)) + 1;
                for (int j = 3; j < x && CurrentValue != 1; j += 2) //Added test to see if number has already searched for all primes
                {
                    DivideByPrime(ref CurrentValue, ref Output, j);
                }

                if (CurrentValue > 1)
                {
                    Output = AddToOutputString(Output, CurrentValue);
                }
            }
            this.PrimeTable.Add(PassedValue, Output);
            return Output;
        }

        private string[] CalculateAllPrimes()
        {
            string[] FullOutput = new string[this.IntputValues.Length];
            for (int i = 0; i < this.IntputValues.Length; i++)
            {
                FullOutput[i] = CalculatePrimes(i);
            }
            return FullOutput;
        }
        
        private void DivideByPrime(ref int n, ref string output, int j)
        {
            while (n % j == 0)
            {
                n /= j;
                output = AddToOutputString(output, j);
            }
        }

        private string AddToOutputString(string output, int j)
        {
            output += j.ToString();
            output += ", ";
            return output;
        }

        //This method does not assume
        public void Print(int n)
        {
            Console.WriteLine(CalculatePrimes(n));
        }

        //This method does not assume that all primes have already been calculated but assumes that they should be
        public void PrintAll()
        {
            foreach (string output in this.CalculateAllPrimes())
            {
                Console.WriteLine(output);
            }
        }
    }
}
