using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {

        private VidlyContext _context;

        public CustomersController()
        {
            _context = new VidlyContext();
        }



        //GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //GET /api/customers/#
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.Where(x => x.Id == id).First();
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return customer;
            }
        }

        //POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return customer;
            }
        }


        //PUT /api/customer/#
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var customerInDb = _context.Customers.Where(x => x.Id == id).First();
                if (customerInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    customerInDb.Name = customer.Name;
                    customerInDb.Birthday = customer.Birthday;
                    customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                    customerInDb.MembershipTypeId = customer.MembershipTypeId;
                    _context.SaveChanges();
                }
            }
        }


        //DELETE /api/customer/#
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var customerInDb = _context.Customers.Where(x => x.Id == id).First();
                if (customerInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    _context.Customers.Remove(customerInDb);
                    _context.SaveChanges();
                }
            }
        }
    }
}
