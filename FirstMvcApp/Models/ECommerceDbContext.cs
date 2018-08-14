using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstMvcApp.Models
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext()
            :base("name=ECommerceDbContext")
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}