using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels; // Add this manually

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }


        [Route("movies/released/{year:regex(\\d{4}):range(1990,2024)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        
        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        //Hardcoded until database created
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie { Id = 1, Name ="Shrek!"},
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }

    }
}