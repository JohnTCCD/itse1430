// ITSE 1430
// Movie Library
using System;

namespace MovieLibrary.ConsoleHost
{
    //Main program
    class Program
    {
        //Entry point function
        static void Main(string[] args)
        {
            bool done = false;

            do
            {
                char choice = GetInput();
                switch (choice)
                {
                    case 'Q': done = HandleQuit(); break;
                    case 'A': AddMovie(); break;
                    case 'V': ViewMovie(); break;
                    case 'D': DeleteMovie(); break;
                    default: DisplayError("Unknown Option"); break;
                };
            } while (!done);
        }

        static Movie movie = new Movie();

        private static void DeleteMovie ()
        {
            //Confirm
            if (!ReadBoolean("Are you sure (Y/N)? "))
                return;

            //delete movie
            movie.title = null;
        }

        static void AddMovie()
        {
            //Movie details - ignoring warnings for now...

             movie.title = ReadString("Enter the movie title: ", true);                     // Required
             movie.description = ReadString("Enter the optional description: ", false);     // Optional

             movie.runLength = ReadInt32("Enter run length (in minutes): ", 0);                // >= 0
             movie.releaseYear = ReadInt32("Enter the release year (min 1900): ", 1900);       // 1900+

            //double reviewRating;     // Optional, 0.0 to 5.0
             movie.rating = ReadString("Enter the MPAA rating: ", false);           // Optional, MPAA (not enforced)
             movie.isClassic = ReadBoolean("Is this a classic (Y/N)? ");          // Optional
        }

        static void ViewMovie ()
        {
            //What if they haven't added one yet?
            if (String.IsNullOrEmpty(movie.title))
            {
                Console.WriteLine("No movie available");
                return;
            }



            Console.WriteLine($"{movie.title} ({movie.releaseYear})");
            Console.WriteLine($"Runtime: {movie.runLength} mins");
            Console.WriteLine($"MPAA Rating {movie.rating}");
            Console.WriteLine($"Classic? {movie.isClassic}");
            Console.WriteLine(movie.description);
        }

        static int ReadInt32 ( string message, int minimimValue )
        {
            Console.Write(message);

            //Validate input
            do
            {
                //string input = Console.ReadLine();
                var input = Console.ReadLine();


                //TODO: Input validation
                //int result = Int32.Parse(input); // Crashes program, not good for input
                //int result;

                //if string parsed AND result is at least minimum value
                //if (Int32.TryParse(input, out result))
                //    if (result >= minimimValue)
                if (Int32.TryParse(input, out var result) && result >= minimimValue)
                    return result;

                DisplayError("The value must be an integral value >= " + minimimValue);
            } while (true);

            //return -1;  not needed
        }

        static string ReadString ( string message, bool required )
        {
            Console.Write(message);

            do
            {
                string input = Console.ReadLine().Trim();

                // Is required
                if (!String.IsNullOrEmpty(input) || !required)
                    return input;

                DisplayError("Value is required");
            } while (true); 
        }

        static void DisplayError( string messsage )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(messsage);
            Console.ResetColor();
        }

        private static bool HandleQuit ()
        {
           // return ReadBoolean("Are you sure you want to quit (Y/N)? ");

            //Display a confirmation
            if (ReadBoolean("Are you sure you want to quit (Y/N)? "))
                return true;

            //Return results
            return true;
        }

        private static bool ReadBoolean ( string message )
        {
            Console.Write(message);

            do
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Y)
                    return true;
                else if (input.Key == ConsoleKey.N)
                    return false;
            } while (true);
            
            //Not needed anymore
            //return false;
        }

        static char GetInput()
        {
            Console.WriteLine("Movie Library");
            //Console.WriteLine("---------------");
            Console.WriteLine("".PadLeft(15, '-'));

            Console.WriteLine("A) dd");
            Console.WriteLine("V) iew");
            Console.WriteLine("D) elete");
            Console.WriteLine("Q) uit");

            while (true)
            {
                //Get input
                string input = Console.ReadLine().Trim();
                //if (input == "Q")
                //    return 'Q';
                //else if (input == "A")
                //    return 'A';
                //else if (input == "V")
                //    return 'V';
                //else if (input == "D")
                //    return 'D';

                // Case insensitive
                switch (input.ToUpper())
                {
                    //No fall thru, unless case statement empty
                    //Must end with return or break;
                    //case "B": input = "10"; break;
                    //case "c":
                    case "C": return 'B';

                    //case "q":
                    case "Q": return 'Q';

                    //case "a":
                    case "A": return 'A';

                    //case "v":
                    case "V": return 'V';

                    //case "d":
                    case "D": return 'D';
                    //default:;
                };

                DisplayError("Invalid input");
            };
            //return default(char); //default
        }
    }
}
