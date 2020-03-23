using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace khwab.Models.Filters
{
    
        public class LoginFilter : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {

                if (Convert.ToBoolean(HttpContext.Current.Session["status"]) == true)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
        
    }
}