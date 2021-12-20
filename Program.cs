using System;
using System.Collections.Generic;

namespace Cs21
{
    class Program
    {
        /// <summary>
        /// Special override to set the class to run as "Today".
        /// To hard-code the run to a specific day X, set Today = typeof(DayX);
        /// To simply run the highest-numbered day, set Today = null;
        /// </summary>
        static Type Today => null;

        static void Main(string[] args)
        {
            // Pick the day to run
            Type today = Today;
            if (today != null)
            {
                Console.WriteLine($"Explicitly set Today = {today.Name}");
                Run(today);
            }
            else
            {
                Type[] days = BaseDay.DiscoverDerivedClasses();
                Console.WriteLine($"Found {days.Length} days");
                int latest = days.Length - 1;
                today = days[latest];
                Console.WriteLine($"The most recent is {today.Name}");
                while (!Run(today) && --latest >= 0)
                {
                    today = days[latest];
                    Console.WriteLine($"\nFalling back to {today.Name}\n");
                }
            }
        }

        /// <summary>
        /// Run part 1 and 2 from the chosen day
        /// </summary>
        /// <param name="today">The Day class</param>
        static bool Run(Type today)
        {
            Type[] noArgs = new Type[0];
            BaseDay day = today.GetConstructor(noArgs).Invoke(noArgs) as BaseDay;
            Console.WriteLine($"");

            // Run part 1, if it has been implemented
            if (!day.ImplementsPart1)
                Console.WriteLine($"{day} does NOT implement part 1");
            else
            {
                Console.WriteLine($"Running {day}.Part1...");
                object part1 = day.Part1();
                PrintAnswer(part1);
            }

            // Run part 2, if it has been implemented
            if (!day.ImplementsPart2)
                Console.WriteLine($"{day} does NOT implement part 2");
            else
            {
                Console.WriteLine($"Running {day}.Part2...");
                object part2 = day.Part2();
                PrintAnswer(part2);
                Console.WriteLine("Answer: " + part2);
            }

            return day.ImplementsPart1 || day.ImplementsPart2;
        }

        static void PrintAnswer(object o)
        {
            if (o == null)
                Console.WriteLine("null");
            else if (o is string s)
            {
                Console.WriteLine(s);
            }
            else if (o is char[] ca)
            {
                Console.WriteLine(new string(ca));
                return;
            }
            else
            {
                List<Type> interfaces = new List<Type>(o.GetType().GetInterfaces());
                if (interfaces.Contains(typeof(System.Collections.IEnumerable)))
                {
                    var en = o as System.Collections.IEnumerable;
                    foreach (var item in en)
                    {
                        PrintAnswer(item);
                    }
                }
                else
                    Console.WriteLine(o.ToString());
            }
        }
    }
}
