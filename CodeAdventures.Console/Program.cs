namespace CodeAdventures.Console
{
    using System;
    using ClassLib;
    using CodeAdventures.ClassLib.Interfaces;

    class Program
    {
        static void Main()
        {
            IPrimeFinder primes = new PrimeFinder(N: 122);

            Console.WriteLine(string.Join(", ", primes.GetAllPrimes()));

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
