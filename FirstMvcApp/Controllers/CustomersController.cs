using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirstMvcApp.Filters;
using FirstMvcApp.Models;
using FirstMvcApp.Repositories;

namespace FirstMvcApp.Controllers
{
    //[MyCustomFilter]
    public class CustomersController : Controller
    {
        //private ECommerceDbContext db = new ECommerceDbContext();
        private ICustomerRepository repo;

        public CustomersController()
        {
            repo = new CustomerRepository();
        }

        public CustomersController(ICustomerRepository customerRepo)
        {
            repo = customerRepo;
        }

        // GET: Customers
        public ActionResult Index()
        {
            //return View(db.Customers.ToList());
            var customers = repo.Get();
            return View(customers);
        }

        // GET: Customers/Details/5
        // Test Custom Filter for OnResultExecuting and OnResultExecuted.
        //[MyCustomFilter]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = db.Customers.Find(id);
            var customer = repo.Get(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Firstname,Lastname,Email,DOB")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //db.Customers.Add(customer);
                //db.SaveChanges();
                repo.Create(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = db.Customers.Find(id);
            var customer = repo.Get(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Firstname,Lastname,Email,DOB")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(customer).State = EntityState.Modified;
                //db.SaveChanges();
                repo.Edit(customer.Id, customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = db.Customers.Find(id);
            var customer = repo.Get(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Customer customer = db.Customers.Find(id);
            //db.Customers.Remove(customer);
            //db.SaveChanges();
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult ViewOrders(int id)
        {
            return RedirectToAction("Index", "Orders", new { id = id });
        }

        public ActionResult Login(string username, string password)
        {
            var customer = repo.Search(username, password);
            if (customer == null)
            {
                return HttpNotFound("Invalid username + password. Please retry");
            }
            return RedirectToAction("ViewOrders", new { id = customer.Id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
