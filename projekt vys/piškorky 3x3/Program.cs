using System;

namespace Piskvorky
{
    class Program
    {
        static char[,] board = new char[3, 3];
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            InitializeBoard();
            PlayGame();
        }

        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        static void PlayGame()
        {
            int moves = 0;
            while (true)
            {
                PrintBoard();
                Console.WriteLine($"Hráč {currentPlayer}, zadejte řádek (0-2) a sloupec (0-2):");
                string input = Console.ReadLine();
                var inputs = input.Split(',');

                if (inputs.Length != 2 || !int.TryParse(inputs[0], out int row) || !int.TryParse(inputs[1], out int col) ||
                    row < 0 || row > 2 || col < 0 || col > 2 || board[row, col] != ' ')
                {
                    Console.WriteLine("Neplatný vstup, zkuste to znovu.");
                    continue;
                }

                board[row, col] = currentPlayer;
                moves++;

                if (CheckWin())
                {
                    PrintBoard();
                    Console.WriteLine($"Hráč {currentPlayer} vyhrál!");
                    break;
                }
                if (moves == 9)
                {
                    PrintBoard();
                    Console.WriteLine("Hra skončila remízou!");
                    break;
                }

                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
        }

        static void PrintBoard()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($" {board[i, 0]} | {board[i, 1]} | {board[i, 2]} ");
                if (i < 2)
                {
                    Console.WriteLine("---|---|---");
                }
            }
        }

        static bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                // Kontrola řádků a sloupců
                if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                    (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
                {
                    return true;
                }
            }

            // Kontrola diagonál
            if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
            {
                return true;
            }

            return false;
        }
    }
}