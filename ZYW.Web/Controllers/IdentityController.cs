using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZYW.CommonMVC;
using ZYW.DTO;
using ZYW.IServices;

namespace ZYW.Web.Controllers
{
    /// <summary>
    /// User Login Controller
    /// </summary>
    public class IdentityController : ApiController
    {
        public IUserService userService { get; set; }
        /// <summary>
        /// User Login 
        /// </summary>
        /// <param name="model">Login model</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Login(LoginUserDTO model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var identity = userService.Login(model.LoginName, model.PassWord);

            if (identity == null)
            {
                return Json(new AjaxResult { Status = "999999", ErrorMsg = "登录账号或登录密码不正确" });
            }
            return Json(new AjaxResult { Status = "999999", Data = identity });
        }
    }
}
