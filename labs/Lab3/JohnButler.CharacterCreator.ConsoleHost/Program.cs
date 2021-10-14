/*========================
John Butler
ITSE 1430 Fall 2021
Lab 2 : Character Creator
========================*/

using System;

namespace JohnButler.AdventureGame.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ITSE 1430 Character Creator");
            Console.WriteLine("John Butler  Fall 2021");
            Console.WriteLine();
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
            if (s_character != null)
                DisplayError("There is already a character made.");
            else
            {
                Character newCharacter = new Character();
                newCharacter.Name = GetStringInput("Enter the name for the new character: ", true);
                newCharacter.Profession = GetProfession();
                newCharacter.Race = GetRace();
                newCharacter.Biography = GetStringInput("Enter the biography for the new character (optional): ", false);
                newCharacter.Strength = GetCharacterAttributeNumber("Enter the character's strength: ");
                newCharacter.Intelligence = GetCharacterAttributeNumber("Enter the character's intelligence: ");
                newCharacter.Agility = GetCharacterAttributeNumber("Enter the character's agility: ");
                newCharacter.Constitution = GetCharacterAttributeNumber("Enter the character's constitution: ");
                newCharacter.Charisma = GetCharacterAttributeNumber("Enter the character's charisma: ");
                s_character = newCharacter;
            }
        }

        /// <summary> Views an existing character. </summary>
        static void ViewCharacter()
        {
            if (s_character != null)
            {
                Console.WriteLine();
                Console.WriteLine("** Character Information **");
                Console.WriteLine($"Name: {s_character.Name}");
                Console.WriteLine($"Profession: {s_character.Profession}");
                Console.WriteLine($"Race: {s_character.Race}");
                Console.WriteLine($"Biography: {s_character.Biography}");
                Console.WriteLine($"Strength: {s_character.Strength}");
                Console.WriteLine($"Intelligence: {s_character.Intelligence}");
                Console.WriteLine($"Agility: {s_character.Agility}");
                Console.WriteLine($"Constitution: {s_character.Constitution}");
                Console.WriteLine($"Charisma: {s_character.Charisma}");
                Console.WriteLine();
            }
            else
                DisplayError("There is no character created.");
        }

        /// <summary> Edits an existing character. </summary>
        static void EditCharacter()
        {
            if (s_character == null)
            {
                Console.WriteLine("No character created yet, creating new character.");
                AddCharacter();
            }

            const int NumberOfCharacteristics = 9;
            for (int i = 1; i <= NumberOfCharacteristics; i++)
                DisplayCharacteristic(i);

            ViewCharacter();
        }

        /// <summary> Deletes an existing character. </summary>
        static void DeleteCharacter()
        {
            if (s_character != null)
            {
                Console.WriteLine();

                if (ConfirmChange("Are you sure you want to delete the character? (Y/N)"))
                {
                    s_character = null;
                    Console.WriteLine("Character deleted.");
                } 
                else
                    Console.WriteLine("Character not deleted.");

                Console.WriteLine();
            }
            else
                DisplayError("There is no character to delete.");
        }

        /// <summary> Displays an individual characteristic of the character. </summary>
        /// <param name="characteristicNumber"> Which characteristic to display. </param>
        static void DisplayCharacteristic (int characteristicNumber)
        {
            Console.WriteLine();

            switch (characteristicNumber)
            {
                case 1: Console.WriteLine($"Name: {s_character.Name}"); break;
                case 2: Console.WriteLine($"Profession: {s_character.Profession}"); break;
                case 3: Console.WriteLine($"Race: {s_character.Race}"); break;
                case 4: Console.WriteLine($"Biography: {s_character.Biography}"); break;
                case 5: Console.WriteLine($"Strength: {s_character.Strength}"); break;
                case 6: Console.WriteLine($"Intelligence: {s_character.Intelligence}"); break;
                case 7: Console.WriteLine($"Agility: {s_character.Agility}"); break;
                case 8: Console.WriteLine($"Constitution: {s_character.Constitution}"); break;
                case 9: Console.WriteLine($"Charisma: {s_character.Charisma}"); break;
                default: DisplayError("Unknown Error."); break;
            }

            if (ConfirmChange("Do you want to change this value? (Y/N)"))
                ChangeCharacteristic(characteristicNumber);
        }

        /// <summary> Prompts user to change the value of characteristic. </summary>
        /// <param name="characteristicNumber"> Which characteristic to change. </param>
        static void ChangeCharacteristic(int characteristicNumber)
        {
            switch (characteristicNumber)
            {
                case 1: s_character.Name = GetStringInput("Enter the new name for the character: ", true); break;
                case 2: s_character.Profession = GetProfession(); break;
                case 3: s_character.Race = GetRace(); break;
                case 4: s_character.Biography = GetStringInput("Enter the new biography for the character (optional): ", false); break;
                case 5: s_character.Strength = GetCharacterAttributeNumber("Enter the new strength for the character: "); break;
                case 6: s_character.Intelligence = GetCharacterAttributeNumber("Enter the new intelligence for the character: "); break;
                case 7: s_character.Agility = GetCharacterAttributeNumber("Enter the new agility for the character: "); break;
                case 8: s_character.Constitution = GetCharacterAttributeNumber("Enter the new constitution for the character: "); break;
                case 9: s_character.Charisma = GetCharacterAttributeNumber("Enter the new charisma for the character: "); break;
                default: DisplayError("Unknown Error."); break;
            }
        }

        /// <summary> Prompts user to provide input for character profession. </summary>
        /// <returns> User input for character's profession. </returns>
        static string GetProfession()
        {
            do
            {
                Console.WriteLine("[Sorcerer]  [Knight]  [Diplomat]  [Blacksmith]  [Theif]");
                string profession = GetStringInput("Enter one of the five professions above for the character: ", true);

                if (ValidateProfession(profession))
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
                Console.WriteLine("[Human]  [Elf]  [Cyborg]  [Dwarf]  [Martian]");
                string race = GetStringInput("Enter one of the five races above for the character: ", true);

                if (ValidateRace(race))
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
                string input = Console.ReadLine().Trim();

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

                if (ValidateRange(attributeNumber))
                    return attributeNumber;
                else
                    DisplayError("Value not in range. (1 - 100)");

            } while (true);
        }

        /// <summary> Checks if the value is in range. 1 - 100 </summary>
        /// <param name="value"> Character attribute number. </param>
        /// <returns> True if value is in range. </returns>
        static bool ValidateRange(int value)
        {
            if (value <= Character.MaximumValue && value >= Character.MinimumValue)
                return true;
            else
                return false;
        }

        /// <summary> Checks if user input for profession is valid. </summary>
        /// <param name="input"> User input. </param>
        /// <returns> True if input is valid. </returns>
        static bool ValidateProfession(string input)
        {
            switch (input.ToLower())
            {
                case "sorcerer":
                case "knight":
                case "blacksmith":
                case "theif":
                case "diplomat": return true;
                default: return false;
            }
        }

        /// <summary> Checks if user input for race is valid. </summary>
        /// <param name="input"> User input. </param>
        /// <returns> True if input is valid. </returns>
        static bool ValidateRace(string input)
        {
            switch (input.ToLower())
            {
                case "human":
                case "dwarf":
                case "cyborg":
                case "elf":
                case "martian": return true;
                default: return false;
            }
        }

        /// <summary> Displays a confirmation. </summary>
        /// <param name="message"> Message to display. </param>
        /// <returns> True if Y, false if N. </returns>
        static bool ConfirmChange(string message)
        {
            do
            {
                Console.WriteLine(message);
                ConsoleKeyInfo answer = Console.ReadKey(true);

                switch (answer.Key)
                {
                    case ConsoleKey.Y: return true;
                    case ConsoleKey.N: return false;
                    default: DisplayError("Invalid input."); break;
                }

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

        /// <summary> Displays an error message with red text. </summary>
        /// <param name="errorMessage"> Displays message to console. </param>
        static void DisplayError ( string errorMessage )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }
    }
}
