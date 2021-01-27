namespace CodeAdventures.ClassLib
{
    using CodeAdventures.ClassLib.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class PrimeFinder : IPrimeFinder
    {
        private List<int> primes = new List<int>();
        private readonly int upperLimit;

        /// <summary>
        /// Checking for prime numbers as one would do on paper (not optimized for speed or logic).
        /// </summary>
        /// <param name="N">The number you set as the upper limit of the interval (starting from 2) of the search for primes.</param>
        public PrimeFinder(int N)
        {
            if (N < 2)
            {
                throw new System.ArgumentException(message: "The upper limit cannot be less than 2!");
            }

            upperLimit = N;
            FindPrimes();
        }

        /// <summary>
        /// Returns every prime number up to and including your upper limit.
        /// </summary>
        /// <returns></returns>
        public List<int> GetAllPrimes()
        {
            return primes;
        }

        private void FindPrimes()
        {
            for (int i = 2; i <= upperLimit; i++)
            {
                if (primes.All(prime => i % prime != 0))
                {
                    primes.Add(i);
                }
            }
        }
    }
}
