/*========================
John Butler
ITSE 1430 Fall 2021
Lab 2 : Character Creator
========================*/

using System;

namespace JohnButler.CharacterCreator.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ITSE 1430 Character Creator");
            Console.WriteLine("John Butler  Fall 2021");

            do
            {
                DisplayMainMenu();
                int choice = GetMenuChoice();
            } while (true);

        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("[1] Add Character");
            Console.WriteLine("[2] View Character");
            Console.WriteLine("[3] Edit Character");
            Console.WriteLine("[4] Delete Character");
            Console.WriteLine("[5] Quit");
        }

        static int GetMenuChoice ()
        {
            do
            {
                Console.WriteLine("What do you want to do?");
                string input = Console.ReadLine();

                if (String.IsNullOrEmpty(input))
                {
                    DisplayError("Input is required.");
                    continue;
                }

                if (Int32.TryParse(input, out int value))
                {
                    if (value >= 1 && value <= 5)
                        return value;
                    else
                        DisplayError("Value of input is not in range. (1 - 5)");
                } 
                else
                    DisplayError("Input must be an integer.");

            } while (true);
        }

        static void DisplayError ( string errorMessage )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }
    }
}
