namespace CodeAdventures
{
    using CodeAdventures.ClassLib.Interfaces;
    using System;
    using System.Collections.Generic;

    public class PrimeFinderOptimized : IPrimeFinder
    {
        private List<int> primes = new List<int>();
        private readonly int upperLimit;

        public PrimeFinderOptimized(int N)
        {
            if (N < 2)
            {
                throw new System.ArgumentException(message: "The upper limit cannot be less than 2!");
            }

            upperLimit = N;

            FindPrimes();
        }

        public List<int> GetAllPrimes()
        {
            return primes;
        }

        private void FindPrimes()
        {
            if (CheckPrimitivePrimes())
            {
                return;
            }

            PopulatePrimesList();
        }

        /// <summary>
        /// Adds primitive primes (2, 3) to the list if necessary, returns true if there is no need to calculate more.
        /// </summary>
        /// <returns></returns>
        private bool CheckPrimitivePrimes()
        {
            primes.Add(2);

            if (upperLimit >= 3)
            {
                primes.Add(3);
            }

            return upperLimit < 5;
        }

        private bool IsPrime(int number)
        {
            //We skip number 2 and 3 from checking, since we don't need it based on the 6 step idea.
            for (int i = 2; i < primes.Count; i++)
            {
                int prime = primes[i];
                //If we can't find a prime divisor below the square root of the number, then we won't find above. (src: https://www.youtube.com/watch?v=lJ3CD9M3nEQ)
                if (prime > Math.Sqrt(upperLimit))
                {
                    break;
                }

                //If the remainder of division with any prime equals to 0, the checked number is not a prime.
                if (number % prime == 0)
                {
                    return false;
                }
            }

            //If we don't get 0 as remainder, the number is prime.
            return true;
        }

        private void PopulatePrimesList()
        {
            //Every prime above 3 takes place next to a multiple of 6 (src: https://youtu.be/ZMkIiFs35HQ).
            for (int i = 6; i <= upperLimit; i += 6)
            {
                int lower = i - 1;
                int higher = i + 1;

                if (lower <= upperLimit)
                {
                    if (IsPrime(lower))
                    {
                        primes.Add(lower);
                    }

                    //We should check for the higher only if the lower is not greater than the upper limit.
                    if (higher <= upperLimit)
                    {
                        if (IsPrime(higher))
                        {
                            primes.Add(higher);
                        }
                    }
                }
            }
        }
    }
}
