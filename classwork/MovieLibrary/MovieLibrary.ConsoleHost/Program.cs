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

        static Movie movie; // = new Movie();

        private static void DeleteMovie ()
        {
            if (movie == null)
                return;

            //var newMovie = movie.Copy();

            //Confirm
            if (!ReadBoolean("Are you sure (Y/N)? "))
                return;

            //delete movie
            movie = null;
        }

        static void AddMovie()
        {
             var newMovie = new Movie();

            do
            {
                // newMovie.set_Title(...)
                newMovie.Title = ReadString("Enter the movie title: ", false);                     // Required
                newMovie.Description = ReadString("Enter the optional description: ", false);     // Optional

                newMovie.RunLength = ReadInt32("Enter run length (in minutes): ", 0);                // >= 0
                newMovie.ReleaseYear = ReadInt32("Enter the release year (min 1900): ", Movie.MinimumReleaseYear);// 1900+

                //double reviewRating;     // Optional, 0.0 to 5.0
                newMovie.Rating = ReadString("Enter the MPAA rating: ", false);           // Optional, MPAA (not enforced)
                newMovie.IsClassic = ReadBoolean("Is this a classic (Y/N)? ");          // Optional

                //Validate
                var error = newMovie.Validate();
                if (!String.IsNullOrEmpty(error))
                {
                    movie = newMovie;
                    return;
                };
                DisplayError(error);
            } while (true);
        }

        static void ViewMovie ()
        {
            //What if they haven't added one yet?
            //if (String.IsNullOrEmpty(movie.title))
            if (movie == null)
            {
                Console.WriteLine("No movie available");
                return;
            };

            //movie.get_Title()
            Console.WriteLine($"{movie.Title} ({movie.ReleaseYear})");
            Console.WriteLine($"Runtime: {movie.RunLength} mins");
            Console.WriteLine($"MPAA Rating {movie.Rating}");
            Console.WriteLine($"Classic? {movie.IsClassic}");
            Console.WriteLine(movie.Description);

            if (movie.AgeInYears >= 25)
                Console.WriteLine($"{movie.AgeInYears}th Anniversary");
            //movie.AgeInYears = 10;
        }

        /// <summary> Reads an Int32 from the console.</summary>
        /// <param name="message">The message to display.</param>
        /// <param name="minimimValue">The minimum value allowed.</param>
        /// <returns> The integrval value that was entered. </returns>
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
            Console.WriteLine("".PadLeft(15, '-'));

            Console.WriteLine("A) dd");
            Console.WriteLine("V) iew");
            Console.WriteLine("D) elete");
            Console.WriteLine("Q) uit");

            while (true)
            {
                //Get input
                string input = Console.ReadLine().Trim();
                switch (input.ToUpper())
                {
                    case "C": return 'B';
                    case "Q": return 'Q';
                    case "A": return 'A';
                    case "V": return 'V';
                    case "D": return 'D';
                };

                DisplayError("Invalid input");
            };
        }
    }
}
