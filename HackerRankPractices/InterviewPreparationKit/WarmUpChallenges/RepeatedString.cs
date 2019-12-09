using System;
using System.Diagnostics;
using System.Linq;

namespace HackerRankPractices.InterviewPreparationKit.WarmUpChallenges
{
    public class RepeatedString
    {
        public static void Run()
        {
            var sw = Stopwatch.StartNew();
            var i = repeatedString("abcac", 10);
            sw.Stop();

            Console.WriteLine($"Result : {i}, Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        static long repeatedString(string s, long n)
        {
            var aCount = s.Count(x => x == 'a');
            if (aCount == 0) return 0;
            if (aCount == s.Length) return n;
            var mod =  (int)(n % s.Length);
            var factor = n / s.Length;
            var plus = s.Substring(0, mod).Count(x => x == 'a');
            return factor * aCount + plus;
        }
    }
}