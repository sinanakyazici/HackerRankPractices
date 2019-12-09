using System;
using System.Diagnostics;

namespace HackerRankPractices.InterviewPreparationKit.WarmUpChallenges
{
    public class CountingValleys
    {
        public static void Run()
        {
            var sw = Stopwatch.StartNew();
            var i = countingValleys(8, "UDDDUDUU");
            sw.Stop();

            Console.WriteLine($"Result : {i}, Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        static int countingValleys(int n, string s)
        {
            var v = 0;
            var counter = 0;
            for (var i = 0; i < n; i++)
            {
                if (s[i] == 'D')
                {
                    counter--;
                }

                if (s[i] == 'U')
                {
                    counter++;
                }


                if (counter == 0 && s[i] == 'U')
                {
                    v++;
                }
            }
            return v;
        }
    }
}