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
        static int roomNumber = 5, positionX = 1, positionY = -1;
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
                    Console.WriteLine("Please enter a command.");
                else
                    Console.WriteLine("Invalid command, please try again.");
            } while (true);
        }

        static void PrintTitleScreen()
        {
            Console.WriteLine("ITSE 1430 Adventure Game");
            Console.WriteLine("[Help] to access the help menu.");
            Console.WriteLine("".PadLeft(35, '*'));
            Console.WriteLine("The year is 2084 A.D. You are the lone survivor on a mission to colonize planet");
            Console.WriteLine("Mars. You live in a state-of-the-art colony home that protects you from the");
            Console.WriteLine("severe enviornment of the planet's surface. As a result of a catastophic nuclear");
            Console.WriteLine("war that destroyed most of life on Earth, all communication with Earth has ceased.");
            Console.WriteLine("Having run of food, water, and company, you turn towards the dream sequencer, a");
            Console.WriteLine("high-tech machine that allows a user to sleep and dream of events experienced in");
            Console.WriteLine("the user's previous life, to pass your remaining time on this life.");
            Console.WriteLine("Upon getting settled in the dream sequencer, you quickly fall asleep and find yourself");
            Console.WriteLine("within a dream where you are standing in a room that acts as an interface for which");
            Console.WriteLine("life you will relive...");
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
                    Console.WriteLine("That's not a valid direction, please try again.");
                    direction = Console.ReadLine().Trim();
                }
                if (direction == "North" && --nextPositionY < -2)
                    Console.WriteLine("There is no door available in that direction.\nPlease try a different door.");
                else if (direction == "South" && ++nextPositionY > 0)
                    Console.WriteLine("There is no door available in that direction.\nPlease try a different door.");
                else if (direction == "East" && ++nextPositionX > 2)
                    Console.WriteLine("There is no door available in that direction.\nPlease try a different door.");
                else if (direction == "West" && --nextPositionX < 0)
                    Console.WriteLine("There is no door available in that direction.\nPlease try a different door.");
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

        static void DisplayRoom1()//TODO: Provide a description for all room functions
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
            Console.WriteLine("\"Examin\" ::= Examins the room you are currently in.");
            Console.WriteLine("\"Move\"   ::= Move to a different room, you'll choose between North, East, South, or West");
            Console.WriteLine("\"Quit\"   ::= Exits the game.");
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