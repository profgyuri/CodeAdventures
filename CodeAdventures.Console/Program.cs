namespace CodeAdventures.Console
{
    using System;
    using CodeAdventures.ClassLib.Interfaces;

    class Program
    {
        static void Main()
        {
            IPrimeFinder primes = new PrimeFinderOptimized(N: 10000000);

            Console.WriteLine(primes.GetAllPrimes().Count);

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
