using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UDemyWebApplication.Models;
using UDemyWebApplication.ViewModels;

namespace UDemyWebApplication.Controllers
{
    public class MoviesController : Controller
    {
        // GET
        public ActionResult Random()
        {
            var movie = new Movie {Id=1, Name="Shrek"};
            var customers = new List<Customer>
            {
                new Customer() {Name = "Customer 1"},
                new Customer() {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            // Do not use ViewData or ViewBag to pass data.
//            ViewData["Movie"] = result;
//            ViewBag.Movie = result;
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }
        
        
        
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek"},
                new Movie {Id = 2, Name = "Wall-e"}
            };
        }

        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == id);
            return View(movie);
            
        }
    }
}