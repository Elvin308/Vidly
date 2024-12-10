using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.DTOs;
using AutoMapper;

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
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);
        }

        //GET /api/customers/#
        public CustomerDTO GetCustomer(int id)
        {
            var customer = _context.Customers.Where(x => x.Id == id).First();
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Mapper.Map<Customer,CustomerDTO>(customer);
            }
        }

        //POST /api/customers
        [HttpPost]
        public CustomerDTO CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
                _context.Customers.Add(customer);
                _context.SaveChanges();

                customerDTO.Id = customer.Id;
                return customerDTO;
            }
        }


        //PUT /api/customer/#
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDTO)
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
                    Mapper.Map<CustomerDTO,Customer>(customerDTO, customerInDb);
                    //The mapper does this for us
                    //customerInDb.Name = customerDTO.Name;
                    //customerInDb.Birthday = customerDTO.Birthday;
                    //customerInDb.IsSubscribedToNewsletter = customerDTO.IsSubscribedToNewsletter;
                    //customerInDb.MembershipTypeId = customerDTO.MembershipTypeId;
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
