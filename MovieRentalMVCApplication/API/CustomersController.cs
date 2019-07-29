using MovieRentalMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRentalMVCApplication.API
{
    public class CustomersController : ApiController
    {
       private  ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
         //get/Api/Customers
         [HttpGet]
  
        public IEnumerable<Customer>FindCustomers()
        {
            return _context.Customers.ToList();
        }
        // get//api /customers/id
        public Customer GetCustomerById(int? id)
        {
            return _context.Customers.SingleOrDefault(c => c.ID == id);
        }
        [HttpPost]
        //public Customer CreateCustomer(Customer customer)
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                BadRequest();
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }
        [HttpPut]
        public void UpdateCustomer(Customer customer,int id)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);
            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDb.CustName = customer.CustName;
            customerInDb.DOB = customer.DOB;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            _context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();


        }
    }
}
