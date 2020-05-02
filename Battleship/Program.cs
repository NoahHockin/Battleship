using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Play");
                Console.WriteLine("\tb) How to Play");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayPlayScreen();
                        break;

                    case "b":
                        DisplayHowToPlayScreen();
                        break;

                    case "q":
                        DisplayClosingScreen();
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        static void DisplayHowToPlayScreen()
        {
            //
            // game instructions
            //
            DisplayScreenHeader("How to Play");
            Console.WriteLine();
            Console.WriteLine("\tAt the start of the game the computer will generate a randomly placed");
            Console.WriteLine("\tset of three coordinates in a horizontal line representing the location");
            Console.WriteLine("\tof the enemy ship. The goal is to sink the ship by hitting it three");
            Console.WriteLine("\ttimes, once at each coordinate. To fire at a coordinate enter the letter");
            Console.WriteLine("\tfollowed by the number that represents the coordinate. If you hit the");
            Console.WriteLine("\tship a white 'X' will be displayed at that position. If you miss a");
            Console.WriteLine("\twhite '0' will be displayed at that position. get three 'X's in a row\n\tto win.");
            DisplayContinuePrompt();

        }

        static void DisplayPlayScreen()
        {
            string a1 = "~";
            string b1 = "~";
            string c1 = "~";
            string d1 = "~";
            string e1 = "~";
            string a2 = "~";
            string b2 = "~";
            string c2 = "~";
            string d2 = "~";
            string e2 = "~";
            string a3 = "~";
            string b3 = "~";
            string c3 = "~";
            string d3 = "~";
            string e3 = "~";
            string a4 = "~";
            string b4 = "~";
            string c4 = "~";
            string d4 = "~";
            string e4 = "~";
            string a5 = "~";
            string b5 = "~";
            string c5 = "~";
            string d5 = "~";
            string e5 = "~";
            bool validResponse = true;
            bool shipSunk = false;
            string[] letterCoordinates = {"B", "C", "D"};
            string userResponse = "";
            string userLetter = "";
            string computerLetter = "";
            int userNumber = 0;
            int computerNumber = 0;
            string shipLetter1 = "";
            string shipLetter2 = "";
            string shipLetter3 = "";
            string hitOrMiss = "";
            bool coord1HitOnce = false;
            bool coord2HitOnce = false;
            bool coord3HitOnce = false;
            int hits = 0;

            //
            // game setup
            //
            DisplayScreenHeader("Game Setup");
            Console.WriteLine();
            Console.WriteLine("\tThe computer will now decide where to put its battleship.");
            Console.WriteLine();
            DisplayContinuePrompt();
            Console.WriteLine();
            
            //
            // generate random set of three coordinates
            //
            Random rnd = new Random();

            int index = rnd.Next(letterCoordinates.Length);
            computerLetter = letterCoordinates[index];
            
            computerNumber = rnd.Next(1, 6);

            if (computerLetter == "B")
            {
                shipLetter1 = "A";
                shipLetter2 = "B";
                shipLetter3 = "C";
            }
            else if (computerLetter == "C")
            {
                shipLetter1 = "B";
                shipLetter2 = "C";
                shipLetter3 = "D";
            }
            else if (computerLetter == "D")
            {
                shipLetter1 = "C";
                shipLetter2 = "D";
                shipLetter3 = "E";
            }

            Console.WriteLine("\tThe coordinates have been decided");
            Console.WriteLine();
            DisplayContinuePrompt();

            //
            // begin the game
            //
            do
            {
                //
                // display game board
                //
                DisplayScreenHeader("Find the battleship");
                Console.WriteLine("\t  A  B  C  D  E  |");
                Console.WriteLine($"\t1 {a1}  {b1}  {c1}  {d1}  {e1}  |");
                Console.WriteLine($"\t2 {a2}  {b2}  {c2}  {d2}  {e2}  |");
                Console.WriteLine($"\t3 {a3}  {b3}  {c3}  {d3}  {e3}  |");
                Console.WriteLine($"\t4 {a4}  {b4}  {c4}  {d4}  {e4}  |");
                Console.WriteLine($"\t5 {a5}  {b5}  {c5}  {d5}  {e5}  |");
                Console.WriteLine();

                //
                // get letter coordinate from user and validate it
                //
                do
                {
                    validResponse = true;
                    Console.Write("\tEnter a letter coordinate: ");
                    userResponse = Console.ReadLine().ToUpper();

                    if (userResponse == "A")
                    {
                        userLetter = userResponse;
                    }
                    else if (userResponse == "B")
                    {
                        userLetter = userResponse;
                    }
                    else if (userResponse == "C")
                    {
                        userLetter = userResponse;
                    }
                    else if (userResponse == "D")
                    {
                        userLetter = userResponse;
                    }
                    else if (userResponse == "E")
                    {
                        userLetter = userResponse;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter either A, B, C, D or E.");
                        Console.WriteLine();
                        DisplayContinuePrompt();
                        validResponse = false;
                    }
                } while (!validResponse);

                //
                // get number coordinate from user and validate it
                //
                do
                {
                    Console.Write($"\tEnter a number coordinate: ");
                    userResponse = Console.ReadLine();

                    int.TryParse(userResponse, out userNumber);

                    validResponse = int.TryParse(userResponse, out userNumber);

                    if (!validResponse)
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("Pease enter a number 1 - 5.");
                        Console.WriteLine();
                        DisplayContinuePrompt();
                    }
                    else
                    {
                        validResponse = true;
                    }

                    if (userNumber > 5)
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("Pease enter a number 1 - 5.");
                        Console.WriteLine();
                        DisplayContinuePrompt();
                    }

                } while (!validResponse);

                //
                // check if the user hit the target
                //
                if (userNumber == computerNumber)
                {
                    if (userLetter == shipLetter1)
                    {
                        hitOrMiss = "X";
                        if (!coord1HitOnce)
                        {
                            hits++;
                            coord1HitOnce = true;
                        }
                    }
                    else if (userLetter == shipLetter2)
                    {
                        hitOrMiss = "X";
                        if (!coord2HitOnce)
                        {
                            hits++;
                            coord2HitOnce = true;
                        }
                    }
                    else if (userLetter == shipLetter3)
                    {
                        hitOrMiss = "X";
                        if (!coord3HitOnce)
                        {
                            hits++;
                            coord3HitOnce = true;
                        }
                    }
                }
                else
                {
                    hitOrMiss = "0";
                }

                //
                // update the game board
                //
                if (userLetter == "A")
                {
                    if (userNumber == 1)
                    {
                        a1 = hitOrMiss;
                    }
                    else if (userNumber == 2)
                    {
                        a2 = hitOrMiss;
                    }
                    else if (userNumber == 3)
                    {
                        a3 = hitOrMiss;
                    }
                    else if (userNumber == 4)
                    {
                        a4 = hitOrMiss;
                    }
                    else
                    {
                        a5 = hitOrMiss;
                    }
                }
                else if (userLetter == "B")
                {
                    if (userNumber == 1)
                    {
                        b1 = hitOrMiss;
                    }
                    else if (userNumber == 2)
                    {
                        b2 = hitOrMiss;
                    }
                    else if (userNumber == 3)
                    {
                        b3 = hitOrMiss;
                    }
                    else if (userNumber == 4)
                    {
                        b4 = hitOrMiss;
                    }
                    else
                    {
                        b5 = hitOrMiss;
                    }
                }
                else if (userLetter == "C")
                {
                    if (userNumber == 1)
                    {
                        c1 = hitOrMiss;
                    }
                    else if (userNumber == 2)
                    {
                        c2 = hitOrMiss;
                    }
                    else if (userNumber == 3)
                    {
                        c3 = hitOrMiss;
                    }
                    else if (userNumber == 4)
                    {
                        c4 = hitOrMiss;
                    }
                    else
                    {
                        c5 = hitOrMiss;
                    }
                }
                else if (userLetter == "D")
                {
                    if (userNumber == 1)
                    {
                        d1 = hitOrMiss;
                    }
                    else if (userNumber == 2)
                    {
                        d2 = hitOrMiss;
                    }
                    else if (userNumber == 3)
                    {
                        d3 = hitOrMiss;
                    }
                    else if (userNumber == 4)
                    {
                        d4 = hitOrMiss;
                    }
                    else
                    {
                        d5 = hitOrMiss;
                    }
                }
                else
                {
                    if (userNumber == 1)
                    {
                        e1 = hitOrMiss;
                    }
                    else if (userNumber == 2)
                    {
                        e2 = hitOrMiss;
                    }
                    else if (userNumber == 3)
                    {
                        e3 = hitOrMiss;
                    }
                    else if (userNumber == 4)
                    {
                        e4 = hitOrMiss;
                    }
                    else
                    {
                        e5 = hitOrMiss;
                    }
                }

                //
                // reset hit/miss indicator
                //
                hitOrMiss = "0";
                //
                // check if the ship is sunk
                //
                if (hits == 3)
                {
                    //
                    // final update to the game board
                    //
                    shipSunk = true;
                    DisplayScreenHeader("Find the battleship");
                    Console.WriteLine("\t  A  B  C  D  E  |");
                    Console.WriteLine($"\t1 {a1}  {b1}  {c1}  {d1}  {e1}  |");
                    Console.WriteLine($"\t2 {a2}  {b2}  {c2}  {d2}  {e2}  |");
                    Console.WriteLine($"\t3 {a3}  {b3}  {c3}  {d3}  {e3}  |");
                    Console.WriteLine($"\t4 {a4}  {b4}  {c4}  {d4}  {e4}  |");
                    Console.WriteLine($"\t5 {a5}  {b5}  {c5}  {d5}  {e5}  |");
                    Console.WriteLine();

                    //
                    // notify the user that the ship is sunk
                    //
                    Console.WriteLine("The ship has been hit 3 times.");
                    Console.WriteLine();
                    DisplayContinuePrompt();
                }
            } while (!shipSunk);

            DisplayScreenHeader("Mission Accomplished!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\tYou successfully sunk the battleship!");
            Console.WriteLine();
            Console.WriteLine("\tYou will now be returned to the main menu.");
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tBattleship");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for Playing!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

    }
}
