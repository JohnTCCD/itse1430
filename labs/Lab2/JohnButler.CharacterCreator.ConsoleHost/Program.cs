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
                int choice = GetIntInput("Enter your choice: ");
                switch (choice)
                {
                    case 1: AddCharacter(); break;
                    case 2: ViewCharacter(); break;
                    case 3: EditCharacter(); break;
                    case 4: DeleteCharacter(); break;
                    case 5: quit = QuitGame("Are you sure you want to quit?"); break;
                    default: DisplayError("Value not on the menu."); break;
                }

            } while (!quit);
            
        }

        static Character s_character;

        /// <summary> Displays the menu in console. </summary>
        static void DisplayMainMenu()
        {
            Console.WriteLine("[1] Add Character");
            Console.WriteLine("[2] View Character");
            Console.WriteLine("[3] Edit Character");
            Console.WriteLine("[4] Delete Character");
            Console.WriteLine("[5] Quit");
        }

        /// <summary> Adds a new character, prompts user to enter information on new character. </summary>
        static void AddCharacter()
        {
            Character newCharacter = new Character();
            newCharacter.Name = GetStringInput("Enter the name for the new character: ", true);
            newCharacter.Profession = GetStringInput("Enter the profession for the new character: ", true);
            newCharacter.Race = GetStringInput("Enter the race for the new character: ", true);
            newCharacter.Biography = GetStringInput("Enter the biography for the new character (optional): ", false);

            newCharacter.Strength = GetIntInput("Enter the new character's strength: ");
            newCharacter.Intelligence = GetIntInput("Enter the new character's intelligence: ");
            newCharacter.Agility = GetIntInput("Enter the new character's agility: ");
            newCharacter.Constitution = GetIntInput("Enter the new character's constitution: ");
            newCharacter.Charisma = GetIntInput("Enter the new character's charisma: ");

            s_character = newCharacter;
        }

        /// <summary> Views a character. </summary>
        static void ViewCharacter()
        {

        }

        /// <summary> Edits an existing character. </summary>
        static void EditCharacter()
        {

        }

        /// <summary> Deletes an existing character. </summary>
        static void DeleteCharacter()
        {

        }

        /// <summary> Reads a string from the console. </summary>
        /// <param name="message"> The message to display. </param>
        /// <param name="required"> True if value is required. </param>
        /// <returns> User input. </returns>
        static string GetStringInput(string message, bool required)
        {
            do
            {
                Console.Write(message);
                string input = Console.ReadLine().Trim();

                if (!String.IsNullOrEmpty(input) || !required)
                    return input;
                else
                    DisplayError("Input is required.");

            } while (true);
        }

        /// <summary> Reads an int from the console. </summary>
        /// <param name="message"> Message to display. </param>
        /// <returns> User input. </returns>
        static int GetIntInput(string message)
        {
            do
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (String.IsNullOrEmpty(input))
                {
                    DisplayError("Input is required.");
                    continue;
                }

                if (Int32.TryParse(input, out int value) && value <= Character.maximumValue && value >= Character.minimumValue)
                    return value;
                else
                    DisplayError("Input must be an integer (1 - 100).");  // TODO: Fix input validation for menu range.

            } while (true);
        }

        /// <summary> Handles quit logic. </summary>
        /// <param name="message"> Message to display. </param>
        /// <returns> True if 'y', False if 'n'. </returns>
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

        /// <summary> Displays an error message. </summary>
        /// <param name="errorMessage"> Displays message to console. </param>
        static void DisplayError ( string errorMessage )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }
    }
}
