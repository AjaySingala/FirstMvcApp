using FirstMvcApp.Controllers;
using FirstMvcApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.Dummy
{
    public class Test
    {
        public void TestCustomerData()
        {
            // Arrange.
            var repo = new CustomerRepositoryTest();
            var controller = new CustomersController(repo);

            // Act.
            var result = controller.Index();

            // Assert.
        }
    }
}