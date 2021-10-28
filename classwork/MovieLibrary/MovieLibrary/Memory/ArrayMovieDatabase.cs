// ITSE 1430
// Movie Library

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    internal class ArrayMovieDatabase
    {

        public ArrayMovieDatabase ()
        {
            //TODO: Seed
            //Object initializer - creating and initializing new object
            // new T() {
            //   property1 = valie 1
            //   property2 = value 2
            //};
            _items[0] = new Movie() {
                Title = "Jaws",
                Rating = "PG",
                RunLength = 210,
                ReleaseYear = 1975,
                Description = "Shark film",
                Id = 1,
            };

            _items[1] = new Movie() {
                Title = "Dune",
                Rating = "PG",
                ReleaseYear = 1979,
                RunLength = 133,
                Id = 2,
            };

            
            //movie = new Movie() {
            //    Title = "Sand",
            //    Rating = "R",
            //    ReleaseYear = 1988,
            //    RunLength = 209,
            //    Id = 3,
            //};
            //_items[2] = movie;

            _items[2] = new Movie() {
                Title = "Sand",
                Rating = "R",
                ReleaseYear = 1988,
                RunLength = 209,
                Id = 3,
            };
        }

        //TODO: Add
        public void Add (Movie movie)
        {

        }

        //TODO: Update
        public void Update (Movie movie)
        {

        }

        //TODO: Delete
        public void Delete (Movie movie)
        {

        }

        //TODO: Get
        public Movie Get ()
        {
            return null;
        }

        //TODO: Get All
        public Movie[] GetAll ()
        {
            //NEVER DO THIS - should not return a ref type directly
            //return _items;
            //Array.Copy() - Will copy array but not ref movies

            //Need to filter out null movies
            var count = 0;
            foreach (var item in _items)
            {
                if (item != null)
                    ++count;
            }

            //Must clone both array and avoies to return new copies
            //new Movie[0];
            var items = new Movie[count];

            //Don't need the for loop
            //for (int index = 0; index < _items.Length; ++index)
            //{items[index] = Copy(_items[index]);}

            //Each iteration the next element is copied to the item variable
            // 3 limitations
            //   No index (use a simple index variable)
            //   Item is read only
            //   Array cannot change for the life of the loop (keep a separate list)
            var index = 0;
            foreach (var item in _items)
            {
                if (item != null)
                    items[index++] = item.Clone();
            }
            return items;
        }

        //Arrays are always open in C#
        //Array size is specified at the point of creation
        private Movie[] _items = new Movie[100];
    }
}
