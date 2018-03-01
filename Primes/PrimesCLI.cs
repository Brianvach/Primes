using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Primes
{
    class PrimesCLI : PrimesGenerator
    {
        private int[] InputValues;

        public PrimesCLI(string Path)
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
            string[] InputArray;
            try
            {
                InputArray = RawInput.Split('\n');
            }
            catch (NullReferenceException) { return; }
            this.InputValues = Array.ConvertAll(InputArray, s => Int32.Parse(s));
        }
        
        //This method does not assume
        public void Print(int n)
        {
            Console.WriteLine(CalculatePrimes(n));
        }

        //This method does not assume that all primes have already been calculated but assumes that they should be
        public void PrintAll()
        {
            if (this.InputValues == null) return;
            foreach (int num in InputValues)
            {
                Console.WriteLine(CalculatePrimes(num));
            }
        }
    }
}
