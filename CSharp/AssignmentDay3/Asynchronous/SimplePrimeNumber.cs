using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

namespace AssignmentDay3.Asynchronous
{
    public static class SimplePrimeNumber
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
            var primesAsync = SplitDataAndGetPrimeNumbers(2, 10000000, 4);
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

        private static async Task<List<int>> SplitDataAndGetPrimeNumbers(int minimum, int maximum, int numberTasks)
        {
            Task<List<int>>[] tasks = new Task<List<int>>[numberTasks];
            int start = minimum, end = start - 1;
            for (var taskIndex = 1; taskIndex <= numberTasks; taskIndex++)
            {
                start = end + 1;
                end = maximum * taskIndex / numberTasks;
                tasks[taskIndex - 1] = GetPrimeNumbersAsync(start, end);
            }
            var results = await Task.WhenAll(tasks);

            return results.SelectMany(x => x).ToList();
        }

        private static async Task<List<int>> GetPrimeNumbersAsync(int minimum, int maximum)
        {
            var result = await Task.Factory.StartNew(() =>
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
            });

            return result;
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