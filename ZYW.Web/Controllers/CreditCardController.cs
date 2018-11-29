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
    /// XINYONGKA
    /// </summary>
    public class CreditCardController : BaseController
    {
        public ICreditCardService creditCardService { get; set; }
        public IBaiduAIFanceService baiduAIFanceService { get; set; }
        /// <summary>
        /// VALIDATION
        /// </summary>
        /// <param name="creditCardDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult ValidationCreditCard(CreditCardDTO creditCardDTO)
        {
            ValidationCreditCardDTO validationCreditCardDTO = creditCardService.ValidationCreditCard(creditCardDTO);
            return Json(new AjaxResult() { Status = "000000", Data = validationCreditCardDTO });
        }
        /// <summary>
        /// Detect
        /// </summary>
        /// <param name="image">图片的base64编码</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Detect([FromBody]string image)
        {
            string imageUrl = baiduAIFanceService.Detect(image, "BASE64","age,beauty,faceshape,gender,glasses,race,face_type,landmark").Result;
            return Json(imageUrl);
        }
    }
}
