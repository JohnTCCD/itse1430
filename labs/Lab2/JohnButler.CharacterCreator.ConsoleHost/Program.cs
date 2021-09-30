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
            bool quit = false;

            do
            {
                DisplayMainMenu();
                int choice = GetMenuChoice();
                switch (choice)
                {
                    case 1: AddCharacter(); break;
                    case 2: Console.WriteLine("You chose View Character."); break;
                    case 3: Console.WriteLine("You chose Edit Character."); break;
                    case 4: Console.WriteLine("You chose Delete Character."); break;
                    case 5: quit = QuitGame("Are you sure you want to quit?"); break;
                    default: DisplayError("Unknown Error."); break;
                }

            } while (!quit);
            
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

        static void AddCharacter()
        {
            Character chr = new Character();
            chr.Name = GetStringInput("Enter the name for the new character: ", true);
        }

        static void ViewCharacter()
        {

        }

        static void EditCharacter()
        {

        }

        static void DeleteCharacter()
        {

        }

        static string GetStringInput(string message, bool required)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine().Trim();
            do
            {
                if (!String.IsNullOrEmpty(input) || !required)
                    return input;
                else
                    DisplayError("Input is required.");

            } while (true);
        }

        static bool QuitGame ( string message )
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(message);
                ConsoleKeyInfo answer = Console.ReadKey(true);
                switch (answer.Key)
                {
                    case ConsoleKey.Y:
                    {
                        Console.WriteLine("Ending game");
                        Console.ResetColor();
                        return true;
                    }
                    case ConsoleKey.N:
                    {
                        Console.WriteLine("Continuing game.");
                        Console.ResetColor();
                        return false;
                    }
                    default: DisplayError("Invalid answer, please try again."); break;
                }

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
