using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NS.MongoTransaction.WebFrontEnd.Helper
{
    public static class Global
    {
        public static string GetCurrentUrl()
        {
            var url = String.Format("{0}/{1}",
                HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString(),
                HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString());

            return url;
        }
    }
}