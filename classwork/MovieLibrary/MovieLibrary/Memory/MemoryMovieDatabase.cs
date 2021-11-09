﻿// ITSE 1430
// Movie Library

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MovieLibrary.Memory
{
    //Implements IMovieDatabase but derives from object
    /// <summary>Provides an in-memory movie database.</summary>
    public class MemoryMovieDatabase : IMovieDatabase
    {
        //Not visible to code that uses the interface
        public void IsOnlyAvailableInMemoryMovieDatabase ()
        { }

        //TODO: Error handling
        public Movie Add ( Movie movie, out string error )
        {
            //Movie must be valid
            if (!ObjectValidator.TryValidate(movie, out error))
                return null;

            //error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return null;

            //Movie title must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
            {
                error = "Movie must be unique";
                return null;
            };

            //Clone
            var newMovie = movie.Clone();

            //Set unique ID
            newMovie.Id = _nextId++;

            _items.Add(newMovie);

            movie.Id = newMovie.Id;
            return movie;
        }

        // Update
        public string Update ( int id, Movie movie )
        {
            //Movie must be valid
            if (!ObjectValidator.TryValidate(movie, out var error))
                return error;

            //Movie must exist
            var existing = FindById(id);
            if (existing == null)
                return "Movie not found";

            //Movie title must be unique
            var dup = FindByTitle(movie.Title);
            if (dup != null && dup.Id != id)
                return "Movie must be unique";

            Copy(existing, movie);
            return null;
        }

        //Delete
        public void Delete ( int id )
        {
            //TODO: Validate id
            var movie = FindById(id);
            if (movie != null)
                _items.Remove(movie);
        }

        //Get
        public Movie Get ( int id )
        {
            //TODO: Validate id
            var movie = FindById(id);

            return movie?.Clone();
        }

        //Get All
        public IEnumerable<Movie> GetAll ()
        {
            //NEVER DO THIS - should not return a ref type directly, it can be modified
            //return _items;

            //int counter = 0;

            //Use iterator syntax
            foreach (var item in _items)
            {
                //++counter;
                System.Diagnostics.Debug.WriteLine($"Returning {item.Title}");
                yield return item.Clone();
            };

            ////Must clone both array and movies to return new copies
            ////Each iteration the next element is copied to the item variable            
            //var items = new Movie[_items.Count];

            //var index = 0;
            //foreach (var item in _items)
            //    items[index++] = item.Clone();

            //return items;
        }

        #region Private Members

        private void Copy ( Movie target, Movie source )
        {
            target.Title = source.Title;
            target.Description = source.Description;
            target.Rating = source.Rating;
            target.RunLength = source.RunLength;
            target.ReleaseYear = source.ReleaseYear;
            target.IsClassic = source.IsClassic;
        }

        private Movie FindByTitle ( string title )
        {
            foreach (var movie in _items)
                if (String.Compare(title, movie.Title, true) == 0)
                    return movie;

            return null;
        }

        private Movie FindById ( int id )
        {
            foreach (var movie in _items)
                if (movie.Id == id)
                    return movie;

            return null;
        }

        //Dynamically resizing array
        private List<Movie> _items = new List<Movie>();
        private int _nextId = 1;
        #endregion
    }
}
