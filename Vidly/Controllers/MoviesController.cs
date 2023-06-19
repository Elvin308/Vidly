using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek!"
            };

            return View(movie);
            //return Content("Hello World!"); //Returns plain text
            //return HttpNotFound(); //Returns not found page
            //return new EmptyResult(); //Returns an empty page
            //return RedirectToAction("Index", "HomeController", new {page = 1, sort = "name"}); //Redirects to provided
        }

        // GET: Movies/Edit/#
        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        // GET: Movies/pageIndex=#/sortBy=""
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if(!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}",pageIndex,sortBy));
        }

        // GET: Movies/####/##
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}