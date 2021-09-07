/*=================
John Butler
ITSE 1430 Fall 2021
Adventure Game
=================*/

using System;

namespace JohnButler.AdventureGame.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            int roomNumber = 5;
            string input;//, direction;
            PrintTitleScreen();
            
            do   //TODO: Impliment core loop for game.
            {
                SetRoom(roomNumber);
                input = GetCommand();
                if (input == "Examin")
                    ExaminRoom(roomNumber);
                //else if (input == "Move")
                //{
                //    direction = GetDirection();
                //    MoveDirection(direction);
                //}
                else if (input == "Quit")
                    break;
                else
                    Console.WriteLine("Invalid command, please try again.");
            } while (input != "Quit");

            Console.WriteLine("Ending game.");
        }

        static void PrintTitleScreen()
        {
            Console.WriteLine("ITSE 1430 Adventure Game");
            Console.WriteLine("------------------------");
            Console.WriteLine("\n\"Help\" to see options\n\n");
            //TODO: Finish discription/story for game.
            Console.WriteLine("The year is 2084 A.D. You, along with a select few were chosen");
            Console.WriteLine("to go on a one way trip to planet Mars to terraform the planet.");
            Console.WriteLine("");
        }

        static string GetCommand()
        {
            Console.WriteLine("What will you do?");
            string command = Console.ReadLine();
            while (command == "help")
            {
                DisplayHelpMenu();
                command = Console.ReadLine();
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
                default:
                Console.WriteLine("Error.");
                break;
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
                default:
                Console.WriteLine("Error.");
                break;
            }
        }

        static string GetDirection()   //TODO: Impliment function
        {
            Console.WriteLine("Which direction do you want to move?");
            string direction = Console.ReadLine();
            return direction;
        }

        static void MoveDirection(string direction)
        {
            //TODO: Write code for function
        }

        static void DisplayRoom1()
        {
            Console.WriteLine("Room 1");
        }

        static void DisplayRoom2()
        {
            Console.WriteLine("Room 2");
        }

        static void DisplayRoom3()
        {
            Console.WriteLine("Room 3");
        }

        static void DisplayRoom4()
        {
            Console.WriteLine("Room 4");
        }

        static void DisplayRoom5()
        {
            Console.WriteLine("Room 5");
        }

        static void DisplayRoom6()
        {
            Console.WriteLine("Room 6");
        }

        static void DisplayRoom7()
        {
            Console.WriteLine("Room 7");
        }

        static void DisplayRoom8()
        {
            Console.WriteLine("Room 8");
        }

        static void DisplayRoom9()
        {
            Console.WriteLine("Room 9");
        }

        static void DisplayHelpMenu ()
        {
            Console.WriteLine("** Help Menu **");
            Console.WriteLine("Examin ::= Examins the room you are currently in.");
            Console.WriteLine("Move ::= Move to a different room, you'll choose between North, East, South, or West");
            Console.WriteLine("Exit ::= Exits the game.");
        }
    }
}