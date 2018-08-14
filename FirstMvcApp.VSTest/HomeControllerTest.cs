using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FirstMvcApp.Controllers;
using System.Web.Mvc;

namespace FirstMvcApp.VSTest
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index_Returns_View()
        {
            var controller = new HomeController();
            var result = controller.Index();
            Assert.IsType<ViewResult>(result);
        }
    }
}
