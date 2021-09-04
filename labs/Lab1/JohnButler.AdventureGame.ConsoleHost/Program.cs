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
            int roomNumber = 8;
            string input;
            PrintTitleScreen();
            FindRoom(roomNumber);

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
            //TODO: Display discription/story for game.
        }
        static string GetCommand()
        {
            //TODO: Display help menu.
            Console.WriteLine("What will you do?");
            string command = Console.ReadLine();
            return command;
        }
        static void FindRoom(int roomNumber)
        {
            switch(roomNumber)
            {   //TODO: Add rest of the room numbers.
                case 8:
                DisplayRoom8();
                break;

                default:
                Console.WriteLine("Invalid input.");
                break;
            }
        }
        static void DisplayRoom8()
        {
            //TODO: Display room info.
            Console.WriteLine("Room 8");
        }
    }
}