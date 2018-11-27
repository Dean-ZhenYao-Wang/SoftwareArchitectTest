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
        private ICreditCardService creditCardService { get; set; }
        /// <summary>
        /// VALIDATION
        /// </summary>
        /// <param name="creditCardDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult ValidationCreditCard(CreditCardDTO creditCardDTO)
        {
            ValidationCreditCardDTO validationCreditCardDTO = creditCardService.ValidationCreditCard(creditCardDTO);
            return Json(new AjaxResult() { Status = "000000", Data = validationCreditCardDTO });
        }
    }
}
