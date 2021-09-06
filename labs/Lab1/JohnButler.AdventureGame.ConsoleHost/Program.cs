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
            string input;
            PrintTitleScreen();
            SetRoom(roomNumber);
            do   //TODO: Impliment core loop for game.
            {
                input = GetCommand();
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
        static void SetRoom(int roomNumber)
        {
            //TODO implement switch statement to call correct display room function
        }
        static void DisplayHelpMenu ()
        {
            Console.WriteLine("** Help Menu **");
            Console.WriteLine("Examin ::= Examins the room you are currently in.");
            Console.WriteLine("Move [North] [East] [South] [West] ::= Move you to the room in that direction.");
            Console.WriteLine("Exit ::= Exits the game.");
        }
    }
}