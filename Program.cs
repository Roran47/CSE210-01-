// See https://aka.ms/new-console-template for more information
using System;

namespace tictactoe
{
    class Program
    {
        static void Main(string[] args)
        {
            string player = Nextplayer("");
            string[] board = CreateBoard();

            while (!Victory(board) && !IsADraw(board))
            {
                DisplayBoard(board);
                MakeMove(player,board);
                player = Nextplayer(player);
            }
            DisplayBoard(board);
            if (IsADraw(board))
            {
                System.Console.WriteLine("Good game. Sorry there is no winner.\nThanks for playing!");
            }
            else if (Victory(board))
            {
                System.Console.WriteLine("Good game. Thanks for playing!");
            }
        }

        static string[] CreateBoard()
        {
            string[] board = new string[9];
            for (int i = 0; i < 9; i++)
            {
                board[i] = (i + 1).ToString();
            }
            return board;
        }

        static void DisplayBoard(string[] board)
        {
            Console.WriteLine();
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }
        static bool Victory(string[] board)
        {
            return ((board[0] == "x" && board[1] == "x" && board[2] == "x") 
                    || (board[3] == "x" && board[4] == "x" && board[5] == "x") 
                    || (board[6] == "x" && board[7] == "x" && board[8] == "x") 
                    || (board[0] == "x" && board[3] == "x" && board[6] == "x") 
                    || (board[1] == "x" && board[4] == "x" && board[7] == "x") 
                    || (board[2] == "x" && board[5] == "x" && board[8] == "x") 
                    || (board[0] == "x" && board[4] == "x" && board[8] == "x")
                    || (board[2] == "x" && board[4] == "x" && board[6] == "x"));
        }
        static bool IsADraw(string[] board)
        {
            bool result = true;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] != "x" && board[i] != "o")
                {
                    result = false;
                    break;
                }   
            }
            return result;
        }
        
        static void MakeMove(string player,string[] board)
        {
            Console.Write($"it is {player}'s turn to pick a number between 1-9: ");
            int player_pick = Convert.ToInt32(Console.ReadLine());
            board[player_pick - 1] = player;
        }
        static string Nextplayer(string current)
        {
            string player = "o";
            if (current == "" || current == "o")
            {
                player = "x";
            }
            return player;
        }
    }
}