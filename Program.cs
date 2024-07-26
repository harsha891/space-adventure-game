using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    internal class Program
    {
        static string[,] board = new string[,] {
            /*
             * board order is upside down in code structure
             * X and Y will inverse
             * C means cheese power
             */
           // 0     1    2    3     4     5     6     7
            {"U",  "U", "U", "U",  "U",  "U",  "U",  "U"},  // Row 0
            {"R",  "R", "U", "D",  "UC", "U",  "L",  "L"},  // Row 1
            {"R",  "R", "U", "R",  "L",  "R",  "L",  "L"},  // Row 2
            {"RC", "R", "U", "R",  "U",  "U",  "L",  "L"},  // Row 3
            {"R",  "R", "U", "R",  "U",  "U",  "LC", "L"},  // Row 4
            {"R",  "R", "R", "RC", "U",  "U",  "L",  "L"},  // Row 5
            {"R",  "R", "U", "D",  "U",  "R",  "L",  "L"},  // Row 6
            {"D",  "R", "R", "R",  "R",  "R",  "D",  "W"}   // Row 7
        };

        struct Player
        {
            public string Name;
            public int X;
            public int Y;
        }

        static Player[] playerDetails = new Player[4];
        public static int noOfPlayers;
        static Random rnd = new Random();

        //Methos to select no of players and their names
        static void ResetGame()
        {
            string playersn;
            // Handling player count input
            do
            {
                Console.Write("Enter no of player (2 to 4) : ");
                playersn = Console.ReadLine();
                if (playersn.Equals("2") || playersn.Equals("3") || playersn.Equals("4"))
                    break;
                Console.Write(" Invalid Input, ");
            } while (true);
            Console.WriteLine();

            // Storing players details to playerDetails[i]
            noOfPlayers = int.Parse(playersn);
            for (int i = 0; i < noOfPlayers; i++)
            {
                Console.Write("Enter <PLAYER " + (i + 1) + "> name : ");
                playerDetails[i].Name = Console.ReadLine();
                playerDetails[i].X = 0;
                playerDetails[i].Y = 0;
            }
            Console.WriteLine();
        }

        static int DiceThrow()
        {
            return rnd.Next(1, 7);
        }

        // Method for moving player ahead if another player already exists.
        static void movePlayerOnBoard(Player playerOnSquare, int playerNo, int diceNo)
        {

            string playerPostion = board[playerDetails[playerNo].X, playerDetails[playerNo].Y];

            string direction = "UP";
            if (playerPostion.StartsWith("D")) direction = "DOWN";
            else if (playerPostion.StartsWith("R")) direction = "RIGHT";
            else if (playerPostion.StartsWith("L")) direction = "LEFT";

            Console.WriteLine("\t" + playerDetails[playerNo].Name + " bounces of " + playerOnSquare.Name + " & moves " + direction);
            if (playerPostion.StartsWith("U"))
            {
                if (playerDetails[playerNo].X + diceNo > 7)
                    Console.WriteLine("\tPlayer Cant make this play, next player continues....");
                else
                    playerDetails[playerNo].X += diceNo;
            }
            else if (playerPostion.StartsWith("D"))
            {
                if (playerDetails[playerNo].X - diceNo < 0)
                    Console.WriteLine("\tPlayer Cant make this play, next player continues....");
                else
                    playerDetails[playerNo].X -= diceNo;
            }
            else if (playerPostion.StartsWith("R"))
            {
                if (playerDetails[playerNo].Y + diceNo > 7)
                    Console.WriteLine("\tPlayer Cant make this play, next player continues....");
                else
                    playerDetails[playerNo].Y += diceNo;
            }
            else if (playerPostion.StartsWith("L"))
            {
                if (playerDetails[playerNo].Y - diceNo < 0)
                    Console.WriteLine("\tPlayer Cant make this play, next player continues....");
                else
                    playerDetails[playerNo].Y -= diceNo;
            }
        }

        static bool RocketInSquare(int currentPlayer, int X, int Y)
        {
            for (int i = 0; i < noOfPlayers; i++)
            {
                if (i == currentPlayer)
                    continue;

                if (playerDetails[i].X == X && playerDetails[i].Y == Y)
                {
                    movePlayerOnBoard(playerDetails[i], currentPlayer, 1);
                    return true;
                }
            }
            return false;
        }

        static void shootDeathRay(int playerNo)
        {
            Console.WriteLine("\tChoose a Player to shoot down");
            for (int i = 0; i < noOfPlayers; i++)
            {
                if (i == playerNo)
                    continue;

                Console.WriteLine("\t" + i + " Player " + playerDetails[i].Name + " at (" + playerDetails[i].Y + ", " + playerDetails[i].X + ")");
            }

            Console.Write("\tPlayer " + playerDetails[playerNo].Name + ", select a player to shoot : ");
            int selectedPlayer = int.Parse(Console.ReadLine());
            Console.WriteLine("\t Player " + playerDetails[selectedPlayer].Name + " needs to select an empty place from below options to occupy");
            for (int i = 0; i < 8; i++)
            {
                bool playerExist = true;
                for (int p = 0; p < noOfPlayers; p++)
                {
                    if (playerDetails[p].X == 0 && playerDetails[p].Y == i)
                    {
                        playerExist = false;
                    }
                }
                if (playerExist)
                    Console.WriteLine("\t\t" + i + ". (" + i + ", 0)");
            }

            Console.Write("\t Player " + playerDetails[selectedPlayer].Name + ", Select your choice : ");
            playerDetails[selectedPlayer].X = 0;
            playerDetails[selectedPlayer].Y = int.Parse(Console.ReadLine());
        }

        private static void PlayerTurn(int playerNo)
        {
            int diceNo = DiceThrow();
            string playerPostion = board[playerDetails[playerNo].X, playerDetails[playerNo].Y];

            string direction = "UP";
            if (playerPostion.StartsWith("D")) direction = "DOWN";
            else if (playerPostion.StartsWith("R")) direction = "RIGHT";
            else if (playerPostion.StartsWith("L")) direction = "LEFT";

            Console.WriteLine("\nPlayer " + playerDetails[playerNo].Name + " is at square (" + playerDetails[playerNo].Y + ", " + playerDetails[playerNo].X + ") rolled " + diceNo + " will move " + direction);

            if (playerPostion.StartsWith("U"))
            {
                if (playerDetails[playerNo].X + diceNo <= 7)
                    playerDetails[playerNo].X += diceNo;
            }
            else if (playerPostion.StartsWith("D"))
            {
                if (playerDetails[playerNo].X - diceNo >= 0)
                    playerDetails[playerNo].X -= diceNo;
            }
            else if (playerPostion.StartsWith("R"))
            {
                if (playerDetails[playerNo].Y + diceNo <= 7)
                    playerDetails[playerNo].Y += diceNo;
            }
            else if (playerPostion.StartsWith("L"))
            {
                if (playerDetails[playerNo].Y - diceNo >= 0)
                    playerDetails[playerNo].Y -= diceNo;
            }

            // Checking for other rockets on the square
            bool spotFix = true;
            do
            {
                spotFix = RocketInSquare(playerNo, playerDetails[playerNo].X, playerDetails[playerNo].Y);
            } while (spotFix);

            ShowStatus();
            Console.WriteLine("");

            string newPostion = board[playerDetails[playerNo].X, playerDetails[playerNo].Y];
            CheesePowerSquare(newPostion, playerNo);
        }

        static void CheesePowerSquare(string newPostion,int playerNo)
        {
            if (newPostion.Contains("C"))
            {
                Console.WriteLine("\tPlayer " + playerDetails[playerNo].Name + " Landed on cheese power square.\n\tSelect one option from below.");
                Console.WriteLine("\t\t1. refuel engine(Extra Chance to Roll a Dice)");
                Console.WriteLine("\t\t2. Cheese Deathray(Shoot another player to send him to bottom of the board)\n");

                Console.Write("\tPlayer " + playerDetails[playerNo].Name + " Enter your option : ");
                String choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine();
                        PlayerTurn(playerNo);
                        break;
                    case "2":
                        Console.WriteLine();
                        shootDeathRay(playerNo);
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
        }

        static void ShowStatus()
        {
            Console.WriteLine("\tHyperspace Cheese Battle Status Report ");
            Console.WriteLine("\t====================================== ");
            Console.WriteLine("\tThere are " + noOfPlayers + " Players");
            for (int i = 0; i < noOfPlayers; i++)
            {
                if(playerDetails[i].Y == 7 &&  playerDetails[i].X == 7)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t" + playerDetails[i].Name + "  is at square (" + playerDetails[i].Y + ", " + playerDetails[i].X + ").");
                Console.ResetColor();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\tSpace Cheese Battle\n");

            int turns = 0;
            Player winner = new Player();
            ResetGame();
            Console.WriteLine("\tGAME LOG : ");
            while (true)
            {
                PlayerTurn(turns % noOfPlayers);

                // If a player wins flag = false to exit loop
                if (board[playerDetails[turns % noOfPlayers].X, playerDetails[turns % noOfPlayers].Y].Equals("W"))
                {
                    winner = playerDetails[turns % noOfPlayers];
                    break;
                }
                turns++;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press enter for next turn");
                Console.ResetColor();
                Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\t\tGAME OVER\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\tPLAYER < " + winner.Name + " > HAS WON THE GAME.\n");
            Console.ResetColor();
        }

    }
}
