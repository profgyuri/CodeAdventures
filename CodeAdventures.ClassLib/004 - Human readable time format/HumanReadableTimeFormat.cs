namespace CodeAdventures.ClassLib
{
    using System;
    using System.Linq;

    /// <summary>
    /// Based on this Codewars kata: https://www.codewars.com/kata/52742f58faf5485cae000b9a
    /// </summary>
    public class HumanReadableTimeFormat
    {
        /// <summary>
        /// This overload ignores milliseconds.
        /// </summary>
        public static string FormatInterval(TimeSpan timeSpan)
        {
            return FormatInterval((int)timeSpan.TotalSeconds);
        }

        /// <summary>
        /// Converts the given seconds to a human readable format.
        /// For a more thorough explanation, please visit the provided codewars site.
        /// Example output: 1 hour, 1 minute and 2 seconds
        /// </summary>
        public static string FormatInterval(int seconds)
        {
            if (seconds == 0)
            {
                return "now";
            }

            string[] times = GetActualValues(seconds);

            return ProcessValidValues(times);
        }

        /// <summary>
        /// Gets the correct time intervals from the seconds component.
        /// </summary>
        private static string[] GetActualValues(int seconds)
        {
            string[] times = new string[5];

            int second = seconds % 60;
            int minute = seconds / 60 % 60;
            int hour = seconds / (60 * 60) % 24;
            int day = seconds / (60 * 60 * 24) % 365;
            int year = seconds / (60 * 60 * 24 * 365);

            if (year > 0)
            {
                times[0] = $"{year} year";

                if (year > 1)
                {
                    times[0] += "s";
                }
            }
            if (day > 0)
            {
                times[1] = $"{day} day";

                if (day > 1)
                {
                    times[1] += "s";
                }
            }
            if (hour > 0)
            {
                times[2] = $"{hour} hour";

                if (hour > 1)
                {
                    times[2] += "s";
                }
            }
            if (minute > 0)
            {
                times[3] = $"{minute} minute";

                if (minute > 1)
                {
                    times[3] += "s";
                }
            }
            if (second > 0)
            {
                times[4] = $"{second} second";

                if (second > 1)
                {
                    times[4] += "s";
                }
            }

            return times;
        }

        private static string ProcessValidValues(string[] times)
        {
            string[] nonNullSubSet = times.Where(t => !string.IsNullOrEmpty(t)).ToArray();

            return nonNullSubSet.Length == 1 ? nonNullSubSet[0] : string.Join(", ", nonNullSubSet[..^1]) + " and " + nonNullSubSet[^1];
        }
    }
}
