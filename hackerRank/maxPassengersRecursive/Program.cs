using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace maxPassengers
{
    class Program
    {
        private static Dictionary<int, int[]> M = new Dictionary<int, int[]>();
        private static Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
        private static int bestSum = 0;

        static void Main(string[] args)
        {

            // fill square matrix
            // M.Add(0, new int[] { 1, 0, 0 });
            // M.Add(1, new int[] { 0, 0, 0 });
            // M.Add(2, new int[] { 0, 0, 1 });

            M.Add(0, new int[] { 0, 0, -1, 0 });
            M.Add(1, new int[] { 1, 0, -1, 0 });
            M.Add(2, new int[] { 1, 1, 1, 1 });
            M.Add(3, new int[] { 1, 1, 1 , 0 });

            // M.Add(0, new int[] { 0, 1});
            // M.Add(1, new int[] { -1, 0});


            // push initial pair
            foo(new Tuple<int, int>(0, 0));

            Console.WriteLine(bestSum);
        }


        private static void foo(Tuple<int, int> pair)
        {
            int size = M.Count;
            int rowIndex = pair.Item1;
            int columnIndex = pair.Item2;

            stack.Push(pair);
            // one foo instance may have cleared the stack, so we need a snapshot
            Stack<Tuple<int, int>> stackBackup = new Stack<Tuple<int, int>>(stack);

            if (canPushDown(rowIndex, columnIndex)){         
                if(stack.Count < 1)
                    stack = stackBackup; // recover this instance stack
                foo(new Tuple<int, int>(rowIndex + 1, columnIndex));
            }

            if (canPushRight(rowIndex, columnIndex)){    
                if(stack.Count < 1)
                    stack = stackBackup;  
                foo(new Tuple<int, int>(rowIndex, columnIndex + 1));
            }

            // destination reached
            if (rowIndex == size - 1 && columnIndex == size - 1)
            {
                int deepSum = stack.Select(e => M[e.Item1][e.Item2]).Sum();
                // get current's best sum
                bestSum = Math.Max(bestSum, deepSum);
                stack.Clear(); // thi is why stack may get lost
            }
        }

        private static bool canPushRight(int rowIndex, int columnIndex)
        {
            int size = M.Count;
            int nextRow = rowIndex + 1;
            int nextColumn = columnIndex + 1;

            return (nextColumn < size && M[rowIndex][nextColumn] != -1);
        }

        private static bool canPushDown(int rowIndex, int columnIndex)
        {
            int size = M.Count;
            int nextRow = rowIndex + 1;
            int nextColumn = columnIndex + 1;

            return (nextRow < size && M[nextRow][columnIndex] != -1);
        }
    }
}
