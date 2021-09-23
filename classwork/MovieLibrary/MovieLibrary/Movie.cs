using System;

namespace MovieLibrary
{
    //Naming rules for class
    // 1. Pascal cased
    // 2. Never prefix with T, C or anything else
    // 3. Noun - because they represent an object/entity in your system

    /// <summary> Represents a movie. </summary>
    public class Movie
    {
        // Fields
        // 1. Always camel cased, TODO: for now
        // 2. Should NEVER be public
        // 3. Always zero initialized or can default
        // 4. Cannot initialize to another field's value
        public string title;
        public string description;
        public int runLength;
        public int releaseYear = 1900;
        public double reviewRating;
        public string rating;
        public bool isClassic;

        public const int MinimumReleaseYear = 1990;

        // Methods - provide functionality (function inside a class)
        // Can reference fields in method

        /// <summary> Copies movie </summary>
        /// <returns> A copy of the movie </returns>
        public Movie Copy ()
        {
            var movie = new Movie();
            movie.title = title;
            movie.description = description;
            movie.runLength = runLength;
            movie.releaseYear = releaseYear;
            movie.reviewRating = reviewRating;
            movie.rating = rating;
            movie.isClassic = isClassic;

            return movie;
        }

        public string Validate ( /*Movie this*/ )
        {
            //Title is required
            if (String.IsNullOrEmpty(title)) //this.title
                return "Title is required";

            //Run length >= 0
            //if (this.runLength < 0)
            if (runLength < 0)
                return "Run Length must be at least zero";

            //Release year >= 1900
            if (releaseYear < MinimumReleaseYear)
                return "Release Year must be at least " + MinimumReleaseYear;

            return null;
        }

        private void SetDiscriptionToTitle ()
        {
            description = title;
        }
    }
}
