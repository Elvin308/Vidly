using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models; // Add this manually

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            return View(movie);
        }

        // GET: Movies/Edit/id
        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        // GET: Movies{?{pageIndex}&{sortBy}}
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        }

        // GET: Movies/Hello
        public ActionResult Hello() 
        {
            return Content("Hello World");
        }

        // GET: Movies/redirectAction
        public ActionResult RedirectAction()
        {
            return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        }

        // GET: Movies/NotFound
        public ActionResult NotFound()
        {
            return HttpNotFound();
        }

        // GET: Movies/Empty
        public ActionResult Empty()
        {
            return new EmptyResult();
        }
    }
}