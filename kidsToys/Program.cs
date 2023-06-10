using System;
using System.Linq;

// https://youtu.be/qWg7SKHsl40
namespace kidsToys
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solution(3, 5, 3));
        }

        public static int solution(int kids, int toys, int start)
        {
            // Implement your solution here

            int kidTurn = start;
            int toysLeft = toys;

            while( toysLeft > 1)
            {                            
                toysLeft--;

                kidTurn++;

                if(kidTurn > kids)
                    kidTurn = 1;
                                
            }

            return kidTurn;
        }
    }
}
