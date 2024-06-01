using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PhoneBookApp.BusinessObjectLayer.Common
{
    public class ValidationAuthorize : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["UserId"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Home/Index");
            }
            return ;
        }
    }
}
