﻿using System.Web;
using System.Web.Mvc;

namespace NS.MongoTransaction.WebFrontEnd
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}