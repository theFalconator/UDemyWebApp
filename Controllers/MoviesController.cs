using System;
using System.Collections.Generic;
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
            var movie = new Movie(1, "Shrek");
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

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            
            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }
        
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}