using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using ZYW.CommonMVC;
using ZYW.DTO;

namespace ZYW.Web.Controllers
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var attr = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>();
            var isAnonymous = attr.Any(a => a is AllowAnonymousAttribute);

            if (!isAnonymous)
            {
                UserDTO identity = null;

                if (actionContext.Request.Headers.Authorization != null)
                {
                    var token = actionContext.Request.Headers.Authorization.Parameter;
                    identity = IdentityManager.GetByToken(token);
                }

                if (identity == null)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}