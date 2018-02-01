using System;

namespace L4_Queens
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter an amount for size of board (if not a valid num, will default to 8): ");
            if (!int.TryParse(Console.ReadLine(), out int n))
                n = 8;
            int stepCounter = 0;
            bool display = false;
            for (int i = 1; i <= n; i++) {
                bool[,] board = new bool[i, i];
                NQueens(board, 0);
                display = DoDisplay(board);
                Console.WriteLine((display) ? (i) + ": Solved" : (i) + ": Failed");
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    for (int k = 0; k < board.GetLength(1); k++)
                    {
                        if (display)
                            Console.Write((board[j, k] ? 'Q' : '-') + " ");
                        stepCounter++;
                    }
                    if(display)
                        Console.WriteLine();
                }
                if (display)
                    Console.WriteLine((stepCounter == 1) ? stepCounter + " Step" : stepCounter + " Steps");
            }
        }
        private static bool DoDisplay(bool[,] board )
        {
            for (int j = 0; j < board.GetLength(0); j++)
            {
                for (int k = 0; k < board.GetLength(1); k++)
                {
                    if (board[j, k])
                        return true;
                }
            }
            return false;
        }
        private static bool NQueens(bool[,] board, int x)
        {
            for (int y = 0; y < board.GetLength(1); y++)
            {
                if (IsAllowed(board, x, y))
                {
                    board[x, y] = true;
                    if (x == board.GetLength(0) - 1 || NQueens(board, x + 1))
                    {
                        return true;
                    }
                    board[x, y] = false;
                }
            }
            return false;
        }
        
        private static bool IsAllowed(bool[,] board, int x, int y)
        {
            for (int i = 0; i <= x; i++)
            {
                if (board[i, y] || (i <= y && board[x - i, y - i]) || (y + i < board.GetLength(0) && board[x - i, y + i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
