using FirstMvcApp.Controllers;
using FirstMvcApp.Models;
using FirstMvcApp.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FirstMvcApp.VSTest
{
    public class CustomersControllerTest
    {
        IList<Customer> _customers = new List<Customer>
        {
            new Customer { Id = 101, Firstname = "Ajay", Lastname = "Singala" },
            new Customer { Id = 102, Firstname = "John", Lastname = "Smith" },
            new Customer { Id = 103, Firstname = "Mary", Lastname = "Jane" }
        };

        [Fact]
        public void When_IndexCalled_AllCustomersReturned()
        {
            var dbMock = new Mock<ICustomerRepository>();
            dbMock.Setup(m => m.Get()).Returns(_customers);

            // Subject under test.
            var sut = new CustomersController(dbMock.Object);

            var result = sut.Index();
            var customersResult = ((System.Web.Mvc.ViewResult)result).Model as IList<Customer>;

            Assert.Equal(_customers.Count, customersResult.Count);
        }

        [Fact]
        public void When_CreateCalled_NewCustomerCreated()
        {
            var dbMock = new Mock<ICustomerRepository>();
            var customer = new Customer { Id = 104, Firstname = "Neo", Lastname = "Trinity" };

            // Subject under test.
            var sut = new CustomersController(dbMock.Object);

            sut.Create(customer);

            dbMock.Verify(_ => _.Create(It.Is<Customer>(c => c == customer)));
            //dbMock.VerifyAll();
        }
    }
}
