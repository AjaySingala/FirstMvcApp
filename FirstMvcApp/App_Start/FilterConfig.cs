﻿using FirstMvcApp.Filters;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // Global Filter.
            //filters.Add(new MyCustomFilter());
        }
    }
}
