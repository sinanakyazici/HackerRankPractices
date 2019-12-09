using System;
using System.Diagnostics;
using System.Linq;

namespace HackerRankPractices.InterviewPreparationKit.Arrays
{
    public class NewYearChaos
    {
        public static void Run()
        {
            var arr = Enumerable.Range(2, 100000).ToList();
            arr.Add(1);
            var sw = Stopwatch.StartNew();
            var i = minimumBribes(arr.ToArray());
            sw.Stop();

            Console.WriteLine($"Result : {i}, Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        static string minimumBribes(int[] q)
        {
            var counter = 0;
            for (var i = q.Length - 1; 0 <= i; i--)
            {
                var item = q[i];
                if (item - (i + 1) > 2)
                {
                    return "Too chaotic";
                }

                for (var j = Math.Max(0, item - 2); j < i; j++)
                {
                    if (q[j] > item) counter++;
                }
            }

            return counter.ToString();
        }
    }
}