using FirstMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcApp.Filters
{
    public class MyCustomFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            var message = $"[OnActionExecuting] - {controllerName}.{actionName}";
            Debug.WriteLine(message);
        
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            var message = $"[OnActionExecuted] - {controllerName}.{actionName}";
            Debug.WriteLine(message);

            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            var message = $"[OnResultExecuting] - {controllerName}.{actionName}";
            Debug.WriteLine(message);

            //// Change the data BEFORE View is rendered.
            //var result = filterContext.Result as ViewResult;
            //var customer = result.Model as Customer;
            //customer.Firstname += " [Edited in OnResultExecuting ActionFilter]";

            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            var message = $"[OnResultExecuted] - {controllerName}.{actionName}";
            Debug.WriteLine(message);

            //// Change the data AFTER View is rendered.
            //var result = filterContext.Result as ViewResult;
            //var customer = result.Model as Customer;
            //customer.Firstname += " [Edited in OnResultExecuted ActionFilter]";

            base.OnResultExecuted(filterContext);
        }
    }
}