using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }


        [Route("movies/customers/Details/{index}")]
        public ActionResult Details(int index)
        {
            var specificCustomer = GetCustomers().ToList().SingleOrDefault(x => x.Id == index);

            return View(specificCustomer);
        }


        //Hardcoded until database created
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "Elvin Martinez"},
                new Customer {Id = 2, Name = "Blue Man"}
            };
        }
    }
}