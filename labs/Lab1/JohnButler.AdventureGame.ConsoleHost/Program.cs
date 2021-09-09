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
        static int roomNumber;
        static string direction;

        static void Main(string[] args)
        {
            roomNumber = 5;
            string input;
            PrintTitleScreen();
            
            do
            {
                SetRoom(roomNumber);
                input = GetCommand();
                if (input == "Examin")
                    ExaminRoom(roomNumber);
                else if (input == "Move")
                {
                    direction = GetDirection();
                    MoveDirection(direction);
                } else if (input == "Quit")
                    input = QuitGame("Are you sure you want to quit (Yes/No)?");
                else
                    Console.WriteLine("Invalid command, please try again.");
            } while (input != "Quit");
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
            while (command == "Help")
            {
                DisplayHelpMenu();
                Console.WriteLine("What will you do?");
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

        static string GetDirection()
        {
            Console.WriteLine("Which direction do you want to move?");
            string direction = Console.ReadLine();
            return direction;
        }

        static void MoveDirection(string direction)
        {
            //TODO: Add input validation
            int roomRow, roomColumn;
            if (roomNumber == 1 || roomNumber == 2 || roomNumber == 3)
                roomRow = 1;
            else if (roomNumber == 4 || roomNumber == 5 || roomNumber == 6)
                roomRow = 2;
            else
                roomRow = 3;
            if (roomNumber == 1 || roomNumber == 4 || roomNumber == 7)
                roomColumn = 1;
            else if (roomNumber == 2 || roomNumber == 5 || roomNumber == 8)
                roomColumn = 2;
            else
                roomColumn = 3;
            if ((direction == "North") && (roomRow != 1))
                roomNumber -= 3;
            if ((direction == "South") && (roomRow != 3))
                roomNumber += 3;
            if ((direction == "East") && (roomColumn != 3))
                roomNumber += 1;
            if ((direction == "West") && (roomColumn != 1))
                roomNumber -= 1;
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
            Console.WriteLine("Move   ::= Move to a different room, you'll choose between North, East, South, or West");
            Console.WriteLine("Quit   ::= Exits the game.");
        }

        static string QuitGame(string message)
        {
            do
            {
                Console.WriteLine(message);
                var answer = Console.ReadLine();
                if (answer == "Yes")
                {
                    Console.WriteLine("Ending game.");
                    return "Quit";
                } else if (answer == "No")
                {
                    Console.WriteLine("Continuing game.");
                    return "Not Quit";
                } else
                    Console.WriteLine("Invalid answer, try again.");
            } while (true);
        }
    }
}