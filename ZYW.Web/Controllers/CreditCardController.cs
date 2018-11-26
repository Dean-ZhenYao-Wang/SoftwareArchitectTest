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
    public class CreditCardController : BaseController
    {
        private static ICreditCardService creditCardService { get; set; }
        [HttpPost]
        public IHttpActionResult ValidationCreditCard(CreditCardDTO creditCardDTO)
        {
            ValidationCreditCardDTO validationCreditCardDTO = creditCardService.ValidationCreditCard(creditCardDTO);
            return Json(new AjaxResult() { Status = "000000", Data = validationCreditCardDTO });
        }
    }
}
