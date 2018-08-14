using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstMvcApp.Models;

namespace FirstMvcApp.Repositories
{
    public class CustomerRepositoryTest : ICustomerRepository
    {
        private static IList<Customer> _customers = new List<Customer>
        {
            new Customer { Id = 1, Firstname="Ajay", Lastname = "Singala" },
            new Customer { Id = 2, Firstname="John", Lastname = "Smith" },
            new Customer { Id = 3, Firstname="Mary", Lastname = "Jane" },
            new Customer { Id = 4, Firstname="John", Lastname = "Doe" },
        };

        public IList<Customer> Get()
        {
            return _customers;
        }

        public Customer Get(int? id)
        {
            var customer = _customers.Where(c => c.Id == id).SingleOrDefault();
            return customer;
        }

        public void Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id, Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Search(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}