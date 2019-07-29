using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalMVCApplication.ViewModel;
using MovieRentalMVCApplication.Models;
using System.Data.Common;
using System.Data.Entity;
using System.Net.Http;

namespace MovieRentalMVCApplication.Controllers
{
   // [Authorize]
    public class CustomerController : Controller
    {
        ApplicationDbContext _context;
        

        public CustomerController()
        {

            _context = new ApplicationDbContext();

        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Details(int? id)
        {


            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.ID == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
            
        }

        public ActionResult Index()
        {
            IEnumerable<Customer> customers = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55325/api/");
                var responseTask = client.GetAsync("customers");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Customer>>();
                    readTask.Wait();
                    customers = readTask.Result;
                }
                else
                {
                    customers = Enumerable.Empty<Customer>();
                    ModelState.AddModelError(string.Empty, new Exception());
                }
            }

            return View(customers);
        }
        
        public ActionResult Edit(int? id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("New", viewModel);
        }

        // GET: Customer
        [Authorize(Roles = "admin")]
        public ActionResult New()
        {

            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {

                //MembershipTypes = _context.MembershipTypes.ToList()
                MembershipTypes = membershipTypes
            };


            return View("New", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //_context.Customers.Add(customer);
            //_context.SaveChanges();//link to entity
            //return RedirectToAction("Index", "Customer");
        //   if (!ModelState.IsValid)
        //    { 
        //   var viewModel = new NewCustomerViewModel
        //  {
        //        Customer = customer,
        //       MembershipTypes = _context.MembershipTypes.ToList()
        //   };

        //    return View("New", viewModel);
        //}

            if (customer.ID == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.ID == customer.ID);
                customerInDb.CustName = customer.CustName;
                customerInDb.DOB = customer.DOB;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }


        public ActionResult Delete(int? id)
        {
            Customer customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index","Customer");

        }
    }
}

    
