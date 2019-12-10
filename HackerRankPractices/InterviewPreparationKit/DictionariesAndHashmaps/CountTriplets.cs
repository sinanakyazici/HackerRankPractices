using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HackerRankPractices.InterviewPreparationKit.DictionariesAndHashmaps
{
    public class CountTriplets
    {
        public static void Run()
        {
            var sw = Stopwatch.StartNew();
            var random = new Random();
            var r = (int)Math.Pow(10, 9);
            var arr = new int[(int)Math.Pow(10, 5)];
            for (int j = 0; j < arr.Length; j++)
            {
                arr[j] = (int)Math.Pow(10, 9);
            }
            var i = countTriplets(arr.Select(x => (long)x).ToList(), r);
            var ii = countTriplets(new List<long> { 1, 3, 9, 9, 27, 81 }, 3);
            sw.Stop();

            Console.WriteLine($"Result : {i}, Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }


        static long countTriplets(List<long> arr, long r)
        {
            long counter = 0;
            var map1 = new Dictionary<long, long>();
            var map2 = new Dictionary<long, long>();
            foreach (var val in arr)
            {
                if (map2.ContainsKey(val))
                {
                    counter += map2[val];
                }

                if (map1.ContainsKey(val))
                {
                    if (map2.ContainsKey(val * r))
                    {
                        map2[val * r] += map1[val];
                    }
                    else
                    {
                        map2[val * r] = map1[val];
                    }
                }

                if (map1.ContainsKey(val * r))
                {
                    map1[val * r]++;
                }
                else
                {
                    map1[val * r] = 1;
                }
            }

            return counter;
        }
    }
}