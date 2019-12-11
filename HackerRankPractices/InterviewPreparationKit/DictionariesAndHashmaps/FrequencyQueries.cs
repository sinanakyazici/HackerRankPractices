using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HackerRankPractices.InterviewPreparationKit.DictionariesAndHashmaps
{
    public class FrequencyQueries
    {
        public static void Run()
        {
            var sw = Stopwatch.StartNew();
            var list = GenerateList();
            var i = freqQuery(new List<List<int>>
            {
                new List<int> { 1, 3 },
                new List<int> { 2, 3 },
                new List<int> { 3, 2 },
                new List<int> { 1, 4 },
                new List<int> { 1, 5 },
                new List<int> { 1, 5 },
                new List<int> { 1, 4 },
                new List<int> { 3, 2 },
                new List<int> { 2, 4 },
                new List<int> { 3, 2 },
            });
            var ii = freqQuery(list);
            sw.Stop();

            Console.WriteLine($"Result : {i}, Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        private static List<List<int>> GenerateList()
        {
            var list = new List<List<int>>();
            var r = new Random();
            for (int i = 0; i < Math.Pow(10, 6); i++)
            {
                list.Add(new List<int> { r.Next(1, 3), r.Next(1, (int)Math.Pow(10, 9)) });
            }

            return list;
        }

        static List<int> freqQuery(List<List<int>> queries)
        {
            var arr = queries.Select(x => new { Action = x[0], Data = x[1] }).ToList();
            var frequencyNumber = new Dictionary<int, int>();
            var countFrequencyNumber = new Dictionary<int, int>();
            var result = new List<int>();
            for (int i = 0; i < arr.Count; i++)
            {
                var action = arr[i].Action;
                var value = arr[i].Data;
                if (action == 1)
                {
                    if (frequencyNumber.ContainsKey(value))
                    {
                        countFrequencyNumber[frequencyNumber[value]]--;
                        if (countFrequencyNumber[frequencyNumber[value]] == 0) countFrequencyNumber.Remove(frequencyNumber[value]);
                        frequencyNumber[value]++;
                        if (countFrequencyNumber.ContainsKey(frequencyNumber[value])) countFrequencyNumber[frequencyNumber[value]]++;
                        else countFrequencyNumber[frequencyNumber[value]] = 1;
                    }
                    else
                    {
                        frequencyNumber[value] = 1;
                        if (countFrequencyNumber.ContainsKey(1)) countFrequencyNumber[1]++;
                        else countFrequencyNumber[1] = 1;
                    }
                }
                else if (action == 2)
                {
                    if (frequencyNumber.ContainsKey(value))
                    {
                        if (frequencyNumber[value] > 0)
                        {
                            countFrequencyNumber[frequencyNumber[value]]--;
                            if (countFrequencyNumber[frequencyNumber[value]] == 0) countFrequencyNumber.Remove(frequencyNumber[value]);
                            frequencyNumber[value]--;
                            if (frequencyNumber[value] > 0)
                            {
                                if (countFrequencyNumber.ContainsKey(frequencyNumber[value])) countFrequencyNumber[frequencyNumber[value]]++;
                                else countFrequencyNumber[frequencyNumber[value]] = 1;
                            }
                            else
                            {
                                frequencyNumber.Remove(value);
                            }
                        }
                        else
                        {
                            frequencyNumber.Remove(value);
                        }
                    }
                }
                else
                {
                    if (countFrequencyNumber.ContainsKey(value)) result.Add(1);
                    else result.Add(0);
                }
            }

            return result;
        }
    }
}