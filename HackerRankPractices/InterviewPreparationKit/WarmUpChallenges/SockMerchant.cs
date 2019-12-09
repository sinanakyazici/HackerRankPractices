using System;
using System.Diagnostics;
using System.Linq;

namespace HackerRankPractices.InterviewPreparationKit.WarmUpChallenges
{
    public class SockMerchant
    {
        public static void Run()
        {
            var sw = Stopwatch.StartNew();
            var i = sockMerchant(9, new []{ 10, 20, 20, 10, 10, 30, 50, 10, 20 });
            sw.Stop();

            Console.WriteLine($"Result : {i}, Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        static int sockMerchant(int n, int[] ar)
        {
            if (n < 2) return 0;
            return ar.GroupBy(x => x).Select(x => new { Item = x, Count = (int)Math.Truncate(x.Count() / 2d) }).Sum(x => x.Count);

        }
    }
}