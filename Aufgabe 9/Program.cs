using System;

namespace Aufgabe_9
{
     class TicTacToe
    {
        public static char[] board = {'1','2','3','4','5','6','7','8','9'};
        public static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            StartGame();
        }

        public static void StartGame()
        {
            string endGame = "";


            for (;;)
            {
                PrintBoard();

                
                Console.WriteLine($"Spieler {currentPlayer}: Bitte Zeichen setzen.");
                Console.Write("Zeichen:  ");
                string PlayerInput = Console.ReadLine();

                
                processData(PlayerInput);
                
               
                if (IsBoardFull() && GetWinner() == '0')
                {
                    endGame = "Unentschieden!";
                    break;
                }

                
                if (GetWinner() != '0')
                {
                    endGame = $"Spieler {GetWinner()} hat gewonnen!";
                    break;
                }

                
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }

            PrintBoard();
            Console.WriteLine("Spiel zu Ende.");
            Console.WriteLine(endGame);
        }

        public static void processData(string PlayerInput)
        {
            if (PlayerInput.Length > 1)
            {
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                Console.WriteLine("Ungültige Eingabe.");
                return;
            }

            try
            {
                if (int.Parse(board[int.Parse(PlayerInput) - 1]+"").GetType() == typeof(int))
                    board[int.Parse(PlayerInput) - 1] = currentPlayer;
                else
                {
                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                    Console.WriteLine("Stelle bereits belegt.");
                }

            }
            catch (Exception)
            {
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                Console.WriteLine("Ungültige Eingabe.");
            }
        }

        public static char GetWinner()
        {
            int[,] CheckBoard = new int[,] {{1,2,3},{4,5,6},{7,8,9},{1,4,7},{2,5,8},{3,6,9},{1,5,9},{3,5,7}};
            char Winner = '0';

            for (var i = 0; i < CheckBoard.GetLength(0); i++)
            {
                if (board[CheckBoard[i,0] - 1] == board[CheckBoard[i,1] - 1] && board[CheckBoard[i,1] - 1] == board[CheckBoard[i,2] - 1])
                {
                    Winner = board[CheckBoard[i,0] - 1];
                }
            }

            return Winner;
        }

        public static bool IsBoardFull()
        {
            foreach (var boardEntry in board)
            {
                try
                {
                    if (int.Parse(boardEntry+"").GetType() == typeof(int))
                    {
                        return false;
                    }
                }
                catch (Exception) {}
            }
            return true;
        }

        public static void PrintBoard()
        {
            Console.WriteLine($"| {board[0]} | {board[1]} | {board[2]} |");
            Console.WriteLine($"| {board[3]} | {board[4]} | {board[5]} |");
            Console.WriteLine($"| {board[6]} | {board[7]} | {board[8]} |");
        }
    }
}