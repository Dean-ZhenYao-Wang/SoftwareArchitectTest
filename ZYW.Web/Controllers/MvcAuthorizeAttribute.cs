using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZYW.CommonMVC;
using ZYW.DTO;

namespace ZYW.Web.Controllers
{
    public class MvcAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var attr = filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), false);
            var isAnonymous = attr.Any(a => a is AllowAnonymousAttribute);
            if (!isAnonymous)
            {
                var token = filterContext.HttpContext.Request.QueryString["_token"];
                var cookie = filterContext.HttpContext.Request.Cookies["AccessToken"];
                if (cookie != null)
                {
                    token = cookie.Value;
                }

                UserDTO identity = null;

                if (!string.IsNullOrEmpty(token))
                {
                    identity = IdentityManager.GetByToken(token);
                }

                if (identity == null)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Login");
                    filterContext.HttpContext.Response.End();
                }
            }
        }
    }
}