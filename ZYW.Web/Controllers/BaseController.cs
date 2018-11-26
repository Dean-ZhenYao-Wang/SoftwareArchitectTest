using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.Routing;
using ZYW.CommonMVC;
using ZYW.DTO;

namespace ZYW.Web.Controllers
{
    [EnableCors("*", "*", "*")]
    [ApiExceptionFilter]
    [ApiAuthorize]
    public class BaseController : ApiController
    {
        public UserDTO Identity { get; private set; }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            if (controllerContext.Request.Headers.Authorization != null)
            {
                var token = controllerContext.Request.Headers.Authorization.Parameter;
                this.Identity = IdentityManager.GetByToken(token);
            }
        }
    }
}