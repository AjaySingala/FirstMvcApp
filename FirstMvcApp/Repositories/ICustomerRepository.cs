using FirstMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvcApp.Repositories
{
    public interface ICustomerRepository
    {
        IList<Customer> Get();
        Customer Get(int? id);
        void Create(Customer customer);
        void Edit(int id, Customer customer);
        void Delete(int id);
        Customer Search(string username, string password);
    }
}
