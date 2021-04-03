namespace CodeAdventures.Console
{
    using System;
    using CodeAdventures.ClassLib;
    using CodeAdventures.ClassLib.Interfaces;

    class Program
    {
        static void Main()
        {
            IPrimeFinder primes = new PrimeFinderOptimized(N: 20000000);

            Console.WriteLine(string.Format("{0:n0}", primes.GetAllPrimes().Count));

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
