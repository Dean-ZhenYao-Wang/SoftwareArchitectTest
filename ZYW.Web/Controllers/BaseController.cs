using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ZYW.CommonMVC;
using ZYW.DTO;

namespace ZYW.Web.Controllers
{
    [MvcAuthorize]
    public class BaseController : Controller
    {
        public UserDTO Identity { get; private set; }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            var token = requestContext.HttpContext.Request.QueryString["_token"];

            var cookie = requestContext.HttpContext.Request.Cookies["AccessToken"];
            if (cookie != null)
            {
                token = cookie.Value;
            }

            if (!string.IsNullOrEmpty(token))
            {
                Identity = IdentityManager.GetByToken(token);
                ViewBag.Identity = Identity;
            }
        }
    }
}