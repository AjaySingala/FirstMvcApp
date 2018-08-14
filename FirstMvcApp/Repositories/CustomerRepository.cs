using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FirstMvcApp.Models;

namespace FirstMvcApp.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ECommerceDbContext db = new ECommerceDbContext();

        public IList<Customer> Get()
        {
            var customers = db.Customers.ToList<Customer>();
            return customers;
        }

        public Customer Get(int? id)
        {
            var customer = db.Customers.Find(id);
            return customer;
        }

        public void Create(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
        }

        public void Edit(int id, Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Customer Search(string username, string password)
        {
            var customer = db.Customers
                .Where(c => c.Username == username && c.Password == password)
                .SingleOrDefault<Customer>();

            return customer;
        }
    }
}