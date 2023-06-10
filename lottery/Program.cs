using System;
using System.Collections.Generic;
using System.Linq;

namespace lottery
{
    class Program
    {
        static void Main(string[] args)
        {

        
            // should be playing this next
            string[] numbers ={
                "6 13 27 34 36 42",
                "1 11 20 28 31 42",
                "3 6 16 25 39 43",
                "4 7 19 22 31 44"
            };

            string[] HistoryNumbers ={
                "7 24 27 30 39 44",
                "9 10 11 23 32 40",
                "11 19 30 37 39 45",
                "2 9 11 17 18 38",
                "11 20 23 35 42 45", // hasta 2022
                "4 7 8 24 32 39",
                "3 8 28 36 37 41",
                "6 14 22 24 35 44",
                "4 8 10 12 15 39",
                "12 14 22 29 31 45",
                "9 12 14 23 31 43",
                "3 6 12 18 31 35",
                "12 19 26 29 39 45",
                "3 6 7 9 22 42",
                "7 17 21 24 35 41",
                "5 7 11 12 24 40",
                "17 20 23 33 37 45",
                "9 20 25 30 32 40",
                "5 7 10 14 34 41",
                "4 7 9 21 23 25",
                "2 8 11 31 32 45",
                "3 6 10 18 21 39",
                "2 3 6 23 41 42",
                "6 16 34 35 37 42",
                "1 15 20 29 35 38",
                "14 15 24 31 33 39",
                "8 12 17 21 26 42",
                "3 20 24 32 38 40",
                "8 11 19 23 35 37",
                "6 23 30 37 43 44",
                "10 15 17 31 37 42",
                "6 16 18 20 25 36",
                "1 11 22 27 34 37",
                "10 11 19 21 39 45",
                "7 8 13 17 23 25",
                "15 17 19 28 32 33",
                "5 9 13 23 38 41",
                "15 20 25 27 35 39",
                "6 7 11 13 17 45",
                "3 8 10 20 36 42",
                "3 23 31 33 39 45",
                "11 12 14 15 23 37",
                "1 8 19 31 35 40",
                "1 4 6 15 21 27",
                "2 8 13 21 22 33",
                "10 24 32 34 38 43",
                "4 29 35 37 40 41",
                "2 16 18 19 30 40",
                "3 7 16 23 26 34",
            };

            GetInfo(numbers);

            // check if it is already a draw
            foreach (var s in numbers)
            {
                if(HistoryNumbers.Contains(s))
                    Console.WriteLine($"{s} ALREADY A DRAW");
            }

        }

        private static void GetInfo(string[] numbers)
        {
            List<int> sumList = new List<int>();

            foreach (string s in numbers)
            {
                int sum = s.Split(" ").Select(e => Convert.ToInt32(e)).Sum();

                sumList.Add(sum);
                Console.WriteLine($"{s} total sum is {sum}");
            }

            var averageSum = sumList.Average();

            Console.WriteLine($"AVERAGE SUM is {averageSum}");
        }
    }
}
