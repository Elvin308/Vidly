using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private VidlyContext _context;

        public CustomersController()
        {
            _context = new VidlyContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(x => x.MembershipType).ToList();
            return View(customers);
        }


        [Route("movies/customers/Details/{index}")]
        public ActionResult Details(int index)
        {
            var specificCustomer = _context.Customers.Where(x => x.Id == index).FirstOrDefault();

            return View(specificCustomer);
        }
    }
}