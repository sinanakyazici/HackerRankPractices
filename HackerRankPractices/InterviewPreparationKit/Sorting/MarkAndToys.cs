using System;
using System.Diagnostics;
using System.Linq;

namespace HackerRankPractices.InterviewPreparationKit.Sorting
{
    public class MarkAndToys
    {
        public static void Run()
        {
            var sw = Stopwatch.StartNew();
            var i = maximumToys(new[] { 1, 12, 5, 111, 200, 1000, 10 }, 50);
            var ii = maximumToys(Enumerable.Repeat(1, (int)Math.Pow(10, 5)).ToArray(), (int)Math.Pow(10, 9));
            sw.Stop();

            Console.WriteLine($"Result : {i}, Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        static int maximumToys(int[] prices, int k)
        {
            Array.Sort(prices);
            var sum = 0;
            var counter = 0;
            for (var i = 0; i < prices.Length; i++)
            {
                if (k < prices[i]) break;
                sum += prices[i];
                if (sum <= k) counter++;
                else break;
            }

            return counter;
        }

    }
}