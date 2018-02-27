using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Primes
{
    [TestFixture]
    class PrimeTest
    {
        Prime TestingPrime = new Prime();
        //Tests for 1 thru 3 are to make sure that the core portions do not break
        [Test]
        public void ValidateOne()
        {
            string expected = "1: 1, ";
            string output = TestingPrime.CalculatePrimes(1);
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void ValidateTwo()
        {
            string expected = "2: 2, ";
            string output = TestingPrime.CalculatePrimes(2);
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void ValidateThree()
        {
            string expected = "3: 3, ";
            string output = TestingPrime.CalculatePrimes(3);
            Assert.AreEqual(expected, output);
        }

        //test the first prime that is not hard coded
        [Test]
        public void ValidateFive()
        {
            string expected = "5: 5, ";
            string output = TestingPrime.CalculatePrimes(5);
            Assert.AreEqual(expected, output);
        }

        //testing a very large prim
        [Test]
        public void ValidateLargePrime()
        {
            string expected = "15485863: 15485863, ";
            string output = TestingPrime.CalculatePrimes(15485863);
            Assert.AreEqual(expected, output);
        }

        //testing small non-prime
        [Test]
        public void ValidateSmallComposite()
        {
            string expected = "4: 2, 2, ";
            string output = TestingPrime.CalculatePrimes(4);
            Assert.AreEqual(expected, output);
        }

        //Validate large 2 based number
        [Test]
        public void ValidateLargeTwoBase()
        {
            string expected = "1073741824: ";
            for (int i = 0; i < 30; i++)
            {
                expected += "2, ";
            }
            string output = TestingPrime.CalculatePrimes(1073741824);
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void ValidateIntMax()
        {
            //This number is prime, and should only return itself
            //This number should test how quickly the algorithm is for iterating through possible primes
            string expected = int.MaxValue.ToString();
            expected += ": 2147483647, ";
            string output = TestingPrime.CalculatePrimes(2147483647);
            Assert.AreEqual(expected, output);
        }

        //ensure that the method is able to iterate and add multiple prime numbers.
        [Test]
        public void ValidatUniquePrimeNumber()
        {
           
            string expected = "223092870: 2, 3, 5, 7, 11, 13, 17, 19, 23, ";
            string output = TestingPrime.CalculatePrimes(223092870);
            Assert.AreEqual(expected, output);
        }

        //Make sure that it is able to handle a number that is perfectly squared.
        [Test]
        public void ValidateDoubleHigherPrime()
        {
            string expected = "49: 7, 7, ";
            string output = TestingPrime.CalculatePrimes(49);
            Assert.AreEqual(expected, output);
        }
        
        //same as above, but with a number that is to the 4th power.
        [Test]
        public void TestNumberToFourth()
        {
            string expected = "625: 5, 5, 5, 5, ";
            string output = TestingPrime.CalculatePrimes(625);
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestNegativeNumber()
        {
            //while 2 * 2 != -4, -4 contains two 2s. This requires that -1 is displayed, or that it gives the incorrect result
            //I will continue to use the same logic as was provided.
            string expected = "-4: 2, 2, ";
            string output = TestingPrime.CalculatePrimes(-4);
            Assert.AreEqual(expected, output);
        }


        //no need to test passing a non-integer value, as the program will not compile
    }
}
