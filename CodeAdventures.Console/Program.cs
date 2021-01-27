namespace CodeAdventures.Console
{
    using System;
    using ClassLib;

    class Program
    {
        static void Main()
        {
            AllPrimesUpToN primes = new AllPrimesUpToN(N: 1);

            Console.WriteLine(string.Join(", ", primes.GetBiggestPrime()));

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
