using System;
using System.Collections.Generic;


// check in a square matrix if a player won the x o game this turn
// 3 in a row, column or diagonal

namespace crossCircleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var M = new Dictionary<int, string[]>();
            M.Add(0, new string[] { "o", "o", "o"});
            M.Add(1, new string[] { "o", "", "x" });
            M.Add(2, new string[] { "", "x", "x" });

            Console.WriteLine($"winner is: {checkWinnerRow(0,2,M)} {checkWinnerColumn(0,2,M)}");
        }


         private static string checkWinnerDiagonal(int row, int column, Dictionary<int, string[]> M){

            
            return null;
         }
        private static string checkWinnerRow(int row, int column, Dictionary<int, string[]> M){

            string winner = string.Empty; // no winner, 
            int xPlayerCont = 0;
            string character = M[row][column];

// checks for row winner
            if(character == "x")
            {
                xPlayerCont = 1 + checkLeft(row, column, character, M) + checkRight(row, column, character, M);
                winner = (xPlayerCont == 3) ? "x" : winner;
            }

            
            if(character == "o")
            {
                xPlayerCont = 1 + checkLeft(row, column, character, M) + checkRight(row, column, character, M);
                winner = (xPlayerCont == 3) ? "o" : winner;
            }

            return winner;
        }

        private static string checkWinnerColumn(int row, int column, Dictionary<int, string[]> M){

            string winner = string.Empty; // no winner, 
            int playerCont = 0;
            string character = M[row][column];

// checks for row winner
            if(character == "x")
            {
                playerCont = 1 + checkDown(row, column, character, M) + checkUp(row, column, character, M);
                winner = (playerCont == 3) ? "x" : winner;
            }

            
            if(character == "o")
            {
                playerCont = 1 + checkDown(row, column, character, M) + checkUp(row, column, character, M);
                winner = (playerCont == 3) ? "o" : winner;
            }

            return winner;
        }


        private static int checkLeft(int row, int column, string character, Dictionary<int, string[]> M){
            int playerCont = 0;

            while(--column >= 0 && M[row][column] == character){
                playerCont++;
            }

            return playerCont;
        }

        private static int checkRight(int row, int column, string character, Dictionary<int, string[]> M){
            int playerCont = 0;

            while(++column < M.Count && M[row][column] == character){
                playerCont++;
            }

            return playerCont;
        }

        private static int checkUp(int row, int column, string character, Dictionary<int, string[]> M){
            int playerCont = 0;

            while(--row >= 0 && M[row][column] == character){
                playerCont++;
            }

            return playerCont;
        }
        private static int checkDown(int row, int column, string character, Dictionary<int, string[]> M){
            int playerCont = 0;

            while(++row < M.Count && M[row][column] == character){
                playerCont++;
            }

            return playerCont;
        }


    }
}
