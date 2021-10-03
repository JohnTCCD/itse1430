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
            bool exit = false;

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
                    case 5: exit = QuitGame("Are you sure you want to quit?"); break;
                    default: DisplayError("Value not on the menu."); break;
                }

            } while (!exit);
            
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
            newCharacter.Profession = GetProfession();
            newCharacter.Race = GetRace();
            newCharacter.Biography = GetStringInput("Enter the biography for the new character (optional): ", false);

            newCharacter.Strength = GetCharacterAttributeNumber("Enter the new character's strength: ");
            newCharacter.Intelligence = GetCharacterAttributeNumber("Enter the new character's intelligence: ");
            newCharacter.Agility = GetCharacterAttributeNumber("Enter the new character's agility: ");
            newCharacter.Constitution = GetCharacterAttributeNumber("Enter the new character's constitution: ");
            newCharacter.Charisma = GetCharacterAttributeNumber("Enter the new character's charisma: ");

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

        /// <summary> Prompts user to provide input for character profession. </summary>
        /// <returns> User input for character's profession. </returns>
        static string GetProfession()
        {
            do
            {
                string profession = GetStringInput("Enter the profession for the new character: ", true);

                if (IsValidProfession(profession))
                    return profession;
                else
                    DisplayError("Not a valid profession.");

            } while (true);
        }

        /// <summary> Prompts user to provide input for character race. </summary>
        /// <returns> User input for character's race. </returns>
        static string GetRace()
        {
            do
            {
                string race = GetStringInput("Enter the race for the new character: ", true);

                if (IsValidRace(race))
                    return race;
                else
                    DisplayError("Not a valid race.");

            } while (true);
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
                string input = Console.ReadLine().Trim().ToLower();
                if (!String.IsNullOrEmpty(input) || !required)
                    return input;
                else
                    DisplayError("Input is required.");

            } while (true);
        }

        /// <summary> Reads the attribute number from the console. </summary>
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

                if (Int32.TryParse(input, out int value))
                    return value;
                else
                    DisplayError("Input must be an integer.");

            } while (true);
        }

        /// <summary> Gets an integar user input and checks if
        /// it's in range. </summary>
        /// <param name="message"> Message to display. </param>
        /// <returns> Value for a character's attribute. </returns>
        static int GetCharacterAttributeNumber(string message)
        {
            do
            {
                int attributeNumber = GetIntInput(message);

                if (IsAttributeRangeValid(attributeNumber))
                    return attributeNumber;
                else
                    DisplayError("Value not in range. (1 - 100)");

            } while (true);
        }

        /// <summary> Checks if the value is in range. 1 - 100 </summary>
        /// <param name="value"> Character attribute number. </param>
        /// <returns> True if value is in range. </returns>
        static bool IsAttributeRangeValid(int value)
        {
            if (value <= Character.maximumValue && value >= Character.minimumValue)
                return true;
            else
                return false;
        }

        /// <summary> Checks if user input for profession is valid. </summary>
        /// <param name="input"> User input. </param>
        /// <returns> True if input is valid. </returns>
        static bool IsValidProfession(string input)
        {
            if (input == "sorcerer" || input == "knight" || input == "blacksmith" || input == "theif" || input == "diplomat")
                return true;

            else
                return false;
        }

        /// <summary> Checks if user input for race is valid. </summary>
        /// <param name="input"> User input. </param>
        /// <returns> True if input is valid. </returns>
        static bool IsValidRace(string input)
        {
            if (input == "human" || input == "dwarf" || input == "cyborg" || input == "elf" || input == "martian")
                return true;
            else
                return false;
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
