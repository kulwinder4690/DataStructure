using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure
{
    public class BigSqureInRectangle
    {
        struct Score
        {
            public int myScore { get; set; }
            public int bigScoreUntil { get; set; }
        }

        Score[,] scoreTable;

        public static void main()
        {
            BigSqureInRectangle obj = new BigSqureInRectangle();
            int[,] arr = new int[,] { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 1 } };
            int max = obj.GetMaxSqure(arr);
            Console.WriteLine(max);
        }

        public int GetMaxSqure(int[,] arr)
        {
            int m = arr.GetLength(0);
            int n = arr.GetLength(1);

            scoreTable = new Score[m, n];

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    scoreTable[i, j].myScore = -1;


            Score maxSqure = utilGetMaxScore(arr, 0, 0);

            return maxSqure.bigScoreUntil;
        }

        private Score utilGetMaxScore(int[,] arr, int row, int col)
        {
            Score myScore = new Score() { bigScoreUntil = 0, myScore = 0 };;
            if (!isValidCell(arr, row, col))
            {
                return myScore;
            }

            if (scoreTable[row, col].myScore != -1)
                return scoreTable[row, col];

            Score score1 = utilGetMaxScore(arr, row + 1, col);
            Score score2 = utilGetMaxScore(arr, row , col+1);
            Score score3 = utilGetMaxScore(arr, row + 1, col+1);

            int otherScore =  Math.Min(score1.myScore, Math.Min(score2.myScore, score3.myScore));

            if (arr[row, col] == 1)
                myScore.myScore = otherScore + 1;

            int bigUntilHere = Math.Max(score1.bigScoreUntil, Math.Min(score2.bigScoreUntil, score3.bigScoreUntil));

            myScore.bigScoreUntil = Math.Max(myScore.myScore, bigUntilHere);
           

            scoreTable[row, col] = myScore;

            return myScore;

        }

        
        private bool isValidCell(int[,] arr,int row, int col)
        {
            if(row >= arr.GetLength(0))
                return false;

              if(col >= arr.GetLength(1))
                return false;

              return true;
        }

    }
}
