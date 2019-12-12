using System;
using System.Diagnostics;

namespace HackerRankPractices.InterviewPreparationKit.Sorting
{
    public class SortingComparator
    {
        private class Player
        {
            public string name { get; }
            public int score { get; }

            public Player(string name, int score)
            {
                this.name = name;
                this.score = score;
            }
        }

        public static void Run()
        {
            var sw = Stopwatch.StartNew();
            var arr = new[] {
                new Player("david", 100),
                new Player("heraldo", 50),
                new Player("aakansha", 75),
                new Player("aleksa", 150),
                new Player("amy", 100),
            };

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (comparator(arr[j], arr[j + 1]) == -1)
                    {
                        var temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            sw.Stop();

            Console.WriteLine($"Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        static int comparator(Player a, Player b)
        {
            // -1 if a < b, 0 if a == b, 1 if a > b
            if (a.score > b.score) return 1;
            if (a.score < b.score) return -1;
            if (string.CompareOrdinal(a.name, b.name) < 0) return 1; // ascending
            if (string.CompareOrdinal(a.name, b.name) > 0) return -1; // ascending
            return 0;
        }
    }
}