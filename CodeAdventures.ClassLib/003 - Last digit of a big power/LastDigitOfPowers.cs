namespace CodeAdventures.ClassLib
{
    using System;
    using System.Linq;

    /// <summary>
    /// Based on this Codewars kata: https://www.codewars.com/kata/5518a860a73e708c0a000027
    /// </summary>
    public class LastDigitOfPowers
    {
        /// <summary>
        /// Calculates the last digit of a number on a high power without using <see cref="System.Numerics.BigInteger"/>.
        /// For a more thorough explanation, please visit the provided codewars site.
        /// Format: x1 ^ (x2 ^ (x3 ^ (... ^ xn))).
        /// </summary>
        /// <returns></returns>
        public static int LastDigit(int[] array)
        {
            //Edge cases.
            if ((array.Length == 0) || (array.Length == 2 && array.All(x => x == 0)))
            {
                return 1;
            }
            if (array.Length == 1)
            {
                return array[0] % 10;
            }

            int power = array[^1];

            for (int i = array.Length - 1; i >= 1; i--)
            {
                if (i - 1 == 0)
                {
                    break;
                }

                power = array[i - 1] < 10 && power < 10 ? (int)Math.Pow(array[i - 1], power) : GetNewPower(array[i - 1], power);
            }

            return power > 0 ? LastDigitOfPower(array[0], power) : 1;
        }

        /// <summary>
        /// Returns the last digit of a**b. Does not handle corner cases.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int LastDigitOfPower(int a, int b)
        {
            return (a % 10) switch
            {
                0 => 0,
                1 => 1,
                2 => (b % 4) switch
                {
                    0 => 6,
                    1 => 2,
                    2 => 4,
                    3 => 8,
                    _ => -1,
                },
                3 => (b % 4) switch
                {
                    0 => 1,
                    1 => 3,
                    2 => 9,
                    3 => 7,
                    _ => -1,
                },
                4 => b % 2 == 1 ? 4 : 6,
                5 => 5,
                6 => 6,
                7 => (b % 4) switch
                {
                    0 => 1,
                    1 => 7,
                    2 => 9,
                    3 => 3,
                    _ => -1,
                },
                8 => (b % 4) switch
                {
                    0 => 6,
                    1 => 8,
                    2 => 4,
                    3 => 2,
                    _ => -1,
                },
                9 => b % 2 == 1 ? 9 : 1,
                _ => -1,
            };
        }

        private static int SimplifyValidNumber(int a)
        {
            //The last digit will remain the same, if we calculte with
            //power mod 4 + 4. With this we get even the highest powers
            //down to the level, where at least a computer can calculate
            //with it (e.g.: 7618 % 4 == 6 % 4).
            return a % 4 + 4;
        }

        private static int GetNewPower(int a, int b)
        {
            if (a > 10)
            {
                a = SimplifyValidNumber(a);
            }
            if (b > 10)
            {
                b = SimplifyValidNumber(b);
            }

            return (int)Math.Pow(a, b);
        }
    }
}
