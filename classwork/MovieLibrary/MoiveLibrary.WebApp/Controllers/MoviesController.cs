using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using MovieLibrary;

namespace MoiveLibrary.WebApp.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesController (IMovieDatabase database)
        {
            _database = database;
        }
        public IActionResult List ()
        {
            var movies = _database.GetAll().OrderBy(x => x.Title);


            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit ( int id, Movie movie )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _database.Update(movie.Id, movie);

                    //PRG - post, redirect (to list), get
                    return RedirectToAction(nameof(List));
                }
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(movie);
        }

        [HttpGet]
        public IActionResult Create ()
        {
            var movie = new Movie();

            return View(movie);
        }

        [HttpPost]
        public IActionResult Create (int id, Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _database.Add(movie);

                    //PRG - post, redirect (to list), get
                    return RedirectToAction(nameof(List));
                }
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(movie);
        }

        [HttpGet]
        public IActionResult Delete ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete ( int id, Movie movie )
        {
            try
            {
                _database.Delete(id);

                //PRG - post, redirect (to list), get
                return RedirectToAction(nameof(List));
                
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(movie);
        }

        private readonly IMovieDatabase _database;
    }
}
