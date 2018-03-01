using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class PrimesGenerator
    {
        private Dictionary<int, string> PrimeTable = new Dictionary<int, string>(); //Store table of primes to reduce compute time.

        public PrimesGenerator() { }        

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
    }
}
