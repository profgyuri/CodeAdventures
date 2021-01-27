namespace CodeAdventures.Console
{
    using System;
    using CodeAdventures.ClassLib.Interfaces;

    class Program
    {
        static void Main()
        {
            IPrimeFinder primes = new PrimeFinderOptimized(N: 1000000);

            Console.WriteLine(string.Join(", ", primes.GetAllPrimes()));

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
