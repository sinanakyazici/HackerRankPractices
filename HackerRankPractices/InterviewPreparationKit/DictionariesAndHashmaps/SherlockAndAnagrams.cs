using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HackerRankPractices.InterviewPreparationKit.DictionariesAndHashmaps
{
    public class SherlockAndAnagrams
    {
        public static void Run()
        {
            var sw = Stopwatch.StartNew();
            var i = 0;
            for (int j = 0; j < 10; j++)
            {
                i = sherlockAndAnagrams("bahdcafcdadbdgagdddcidaaicggcfdbfeeeghiibbdhabdhffddhffcdccfdddhgiceciffhgdibfdacbidgagdadhdceibbbcc");

            }
            sw.Stop();

            Console.WriteLine($"Result : {i}, Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        static int sherlockAndAnagrams(string s)
        {
            var counter = 0;
            for (int i = 1; i < s.Length; i++)
            {
                var dict = new Dictionary<string, int>();

                for (int j = 0; j <= s.Length - i; j++)
                {
                    var m = s.Substring(j, i).ToCharArray();
                    Array.Sort(m);
                    var n = new string(m);
                    if (!dict.ContainsKey(n))
                        dict.Add(n, 1);
                    else
                        dict[n] += 1;
                }

                foreach (var item in dict)
                {
                    if (item.Value > 1)
                    {
                        // how many different binary combination, example : {a,b,c,d} = ([a,b],[a,c],[a,d],[b,c],[b,d],[c,d]) =  n*(n-1) / 2
                        counter += item.Value * (item.Value - 1) / 2;
                    }
                }
            }

            return counter;
        }
    }
}