using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

namespace AssignmentDay3.Asynchronous
{
    public static class PrimeNumber
    {
        public static void PrintPrimeNumbers()
        {
            Console.WriteLine("Find Prime Number");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var primes = GetPrimeNumbers(2, 10000000);
            stopWatch.Stop();
            Console.WriteLine
            (
                "Sync: Process time: {0}ms, Total of Prime number: {1}",
                stopWatch.ElapsedMilliseconds, primes.Count
            );

            var stopWatch1 = new Stopwatch();
            stopWatch1.Start();
            var primesAsync = GetPrimeNumbersAsync(2, 10000000);
            stopWatch1.Stop();
            Console.WriteLine
            (
                "Async: Process time: {0}ms, Total of Prime number: {1}",
                stopWatch1.ElapsedMilliseconds, primesAsync.Result.Count
            );
        }

        private static List<int> GetPrimeNumbers(int minimum, int maximum)
        {
            List<int> primeNumbers = new List<int>();
            for (int number = minimum; number <= maximum; number++)
            {
                if (IsPrimeNumber(number))
                {
                    primeNumbers.Add(number);
                }
            }

            return primeNumbers;
        }

        private static async Task<List<int>> GetPrimeNumbersAsync(int minimum, int maximum)
        {
            Func<object, List<int>> getPrimeNumber = (object range) =>
            {
                dynamic dynamicRange = range;
                int minimum = dynamicRange.minimum;
                int maximum = dynamicRange.maximum;

                List<int> primeNumbers = new List<int>();
                for (int number = minimum; number <= maximum; number++)
                {
                    if (IsPrimeNumber(number))
                    {
                        primeNumbers.Add(number);
                    }
                }

                return primeNumbers;
            };

            Task<List<int>> task1 = new Task<List<int>>(getPrimeNumber, new { minimum = minimum, maximum = maximum / 4 });
            Task<List<int>> task2 = new Task<List<int>>(getPrimeNumber, new { minimum = maximum / 4 + 1, maximum = maximum / 2 });
            Task<List<int>> task3 = new Task<List<int>>(getPrimeNumber, new { minimum = maximum / 2 + 1, maximum = maximum * 3 / 4 });
            Task<List<int>> task4 = new Task<List<int>>(getPrimeNumber, new { minimum = maximum * 3 / 4 + 1, maximum = maximum });

            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();

            await task1;
            await task2;
            await task3;
            await task4;

            IEnumerable<int> result1 = task1.Result;
            List<int> result2 = task2.Result;
            List<int> result3 = task3.Result;
            List<int> result4 = task4.Result;
            var result = result1.Concat(result2).Concat(result3).Concat(result4);

            return result.ToList();
        }

        static bool IsPrimeNumber(int number)
        {
            if (number % 2 == 0)
            {
                return number == 2;
            }
            else
            {
                var topLimit = (int)Math.Sqrt(number);
                for (int i = 3; i <= topLimit; i += 2)
                {
                    if (number % i == 0) return false;
                }

                return true;
            }
        }
    }
}