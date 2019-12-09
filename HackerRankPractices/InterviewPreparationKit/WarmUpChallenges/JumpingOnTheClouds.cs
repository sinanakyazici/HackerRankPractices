using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HackerRankPractices.InterviewPreparationKit.WarmUpChallenges
{
    public class JumpingOnTheClouds
    {
        public static void Run()
        {
            var sw = Stopwatch.StartNew();
            var i = jumpingOnClouds(new[] { 0, 0, 0, 1, 0, 0 });
            sw.Stop();
            
            Console.WriteLine($"Result : {i}, Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        static int jumpingOnClouds(int[] c)
        {
            List<int> results = new List<int>();
            Recursive(c, 0, 0, results);
            return results.Min();
        }

        private static void Recursive(int[] c, int index, int step, List<int> results)
        {
            if (c.Length - 1 == index)
            {
                results.Add(step);
                return;
            }

            if (index + 1 < c.Length && c[index + 1] == 0)
            {
                Recursive(c, index + 1, step + 1, results);
            }


            if (index + 2 < c.Length &&  c[index + 2] == 0)
            {
                Recursive(c, index + 2, step + 1, results);
            }
        }
    }
}