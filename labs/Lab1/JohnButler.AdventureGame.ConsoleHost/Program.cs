/*=================
John Butler
ITSE 1430 Fall 2021
Lab 1 : Adventure Game
=================*/

using System;

namespace JohnButler.AdventureGame.ConsoleHost
{
    class Program
    {
        static int roomNumber = 8, positionX = 1, positionY = 0;
        static string direction;

        static void Main(string[] args)
        {
            PrintTitleScreen();
            SetRoom(roomNumber);
            string input;
            do
            {
                input = GetCommand("What will you do?");
                if (input == "Examin")
                    ExaminRoom(roomNumber);
                else if (input == "Move")
                {
                    direction = GetDirection("Which direction do you want to move?");
                    MoveDirection(direction);
                    SetRoom(roomNumber);
                } 
                else if (input == "Quit")
                {
                    if (QuitGame("Are you sure you want to quit (Y/N)?") == true)
                        break;
                } 
                else if (input == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a command.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command, please try again.");
                    Console.ResetColor();
                }

            } while (true);
        }

        static void PrintTitleScreen()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ITSE 1430 Adventure Game");
            Console.WriteLine("John Butler  Fall 2021");
            Console.WriteLine("[Help] to access the help menu.");
            Console.WriteLine("".PadLeft(35, '*'));
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("You were going for a jog in the woods along the country side.");
            Console.WriteLine("Deep in the woods you happen to see an old sign that says \"No Trespassing!\"");
            Console.WriteLine("Like any good citizen, you decided to venture further through the narrow trail.");
            Console.WriteLine("After about a few dozen yards, you see an abandoned mansion, forgotten by time.");
            Console.WriteLine("The exterior is overtaken by a seige of vines and other small plants, most of the");
            Console.WriteLine("windows cracked or outright gone. Curious, you decided to see if the front door");
            Console.WriteLine("was locked or not. It was open and you entered...");
            Console.ResetColor();
        }

        static string GetCommand(string message)
        {
            Console.WriteLine(message);
            string command = Console.ReadLine().Trim();
            while (command == "Help")
            {
                DisplayHelpMenu();
                Console.WriteLine(message);
                command = Console.ReadLine().Trim();
            }
            return command;
        }

        static void ExaminRoom(int roomNumber)
        {
            switch (roomNumber)
            {
                case 1: DisplayRoom1(); break;
                case 2: DisplayRoom2(); break;
                case 3: DisplayRoom3(); break;
                case 4: DisplayRoom4(); break;
                case 5: DisplayRoom5(); break;
                case 6: DisplayRoom6(); break;
                case 7: DisplayRoom7(); break;
                case 8: DisplayRoom8(); break;
                case 9: DisplayRoom9(); break;
                default: Console.WriteLine("Unknown Error"); break;
            }
        }

        static void SetRoom(int roomNumber)
        {
            switch (roomNumber)
            {
                case 1: DisplayRoom1(); break;
                case 2: DisplayRoom2(); break;
                case 3: DisplayRoom3(); break;
                case 4: DisplayRoom4(); break;
                case 5: DisplayRoom5(); break;
                case 6: DisplayRoom6(); break;
                case 7: DisplayRoom7(); break;
                case 8: DisplayRoom8(); break;
                case 9: DisplayRoom9(); break;
                default: Console.WriteLine("Unknown Error"); break;
            }
        }

        static string GetDirection(string message)
        {
            int nextPositionX, nextPositionY;
            Console.WriteLine(message);
            do
            {
                nextPositionX = positionX;
                nextPositionY = positionY;
                direction = Console.ReadLine().Trim();
                while (direction != "North" && direction != "South" && direction != "East" && direction != "West")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That's not a valid direction, please try again.");
                    Console.ResetColor();
                    direction = Console.ReadLine().Trim();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                if (direction == "North" && --nextPositionY < -2)
                    Console.WriteLine("There is no door available in that direction.\nPlease try a different door.");
                else if (direction == "South" && ++nextPositionY > 0)
                    Console.WriteLine("There is no door available in that direction.\nPlease try a different door.");
                else if (direction == "East" && ++nextPositionX > 2)
                    Console.WriteLine("There is no door available in that direction.\nPlease try a different door.");
                else if (direction == "West" && --nextPositionX < 0)
                    Console.WriteLine("There is no door available in that direction.\nPlease try a different door.");
                Console.ResetColor();
            } while (nextPositionY < -2 || nextPositionY > 0 || nextPositionX < 0 || nextPositionX > 2);
            return direction;
        }

        static void MoveDirection(string direction)
        {
            switch (direction)
            {
                case "North": 
                positionY--;
                roomNumber -= 3; 
                break;
                case "South":
                positionY++;
                roomNumber += 3;
                break;
                case "East":
                positionX++;
                roomNumber += 1;
                break;
                case "West":
                positionX--;
                roomNumber -= 1;
                break;
            }
        }

        static void DisplayRoom1()//master bedroom
        {                         
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (2, 0)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Master Bedroom"); //TODO: Finish room description
            Console.ResetColor();
            Console.WriteLine("There is a door to the east and south.");
        }

        static void DisplayRoom2()//dinning hall
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (1, 2)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Dinning Hall"); //TODO: Finish room description
            Console.ResetColor();
            Console.WriteLine("There is a door to the west, south, and east.");
        }

        static void DisplayRoom3()//guestroom
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (2, 2)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Guest Room"); //TODO: Finish room description
            Console.ResetColor();
            Console.WriteLine("There is a door to the west, south.");
        }

        static void DisplayRoom4()//fireplace
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (0, 1)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Fireplace"); //TODO: Finish room description
            Console.ResetColor();
            Console.WriteLine("There is a door to the south, north, and east.");
        }

        static void DisplayRoom5()//kitchen
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (1, 1)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Kitchen"); //TODO: Finish room description
            Console.ResetColor();
            Console.WriteLine("There is a door to the west, north, east, and south.");
        }

        static void DisplayRoom6()//balcanoy
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (2, 1)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Balcanoy"); //TODO: Finish room description
            Console.ResetColor();
            Console.WriteLine("There is a door to the west, north, and south.");
        }

        static void DisplayRoom7()//cellar/basement
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (0, 0)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Cellar"); //TODO: Finish room description
            Console.ResetColor();
            Console.WriteLine("There is a door to the north and east.");
        }

        static void DisplayRoom8()//entrance
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (1, 0)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Entrance"); //TODO: Finish room description
            Console.ResetColor();
            Console.WriteLine("There is a door to the west, north, and east.");
        }

        static void DisplayRoom9()//art gallery
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (2, 0)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Art Gallery"); //TODO: Finish room description
            Console.ResetColor();
            Console.WriteLine("There is a door to the west and north.");
        }

        static void DisplayHelpMenu ()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("** Help Menu **");
            Console.WriteLine("\"Examin\" ::= Examins the room you are currently in.");
            Console.WriteLine("\"Move\"   ::= Move to a different room, you'll choose between North, East, South, or West");
            Console.WriteLine("\"Quit\"   ::= Exits the game.");
            Console.ResetColor();
        }

        static bool QuitGame(string message)
        {
            do
            {
                Console.WriteLine(message);
                ConsoleKeyInfo answer = Console.ReadKey(true);
                switch (answer.Key)
                {
                    case ConsoleKey.Y: Console.WriteLine("Ending game"); return true;
                    case ConsoleKey.N: Console.WriteLine("Continuing game."); return false;
                    default: Console.WriteLine("Invalid answer, try again. (Y/N)"); break;
                }
            } while (true);
        }
    }
}