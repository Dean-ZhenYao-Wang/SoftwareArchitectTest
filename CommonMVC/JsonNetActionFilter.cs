using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ZYW.CommonMVC
{
    public class JsonNetActionFilter:IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Change filterContext. Result from JsonResult to JsonNetResult
            //The filterContext. Result is worth the ActionResult object returned by the action execution
            if(filterContext.Result is JsonResult&&!(filterContext.Result is JsonNetResult))
            {
                JsonResult jsonResult = (JsonResult)filterContext.Result;
                JsonNetResult jsonNetResult = new JsonNetResult();
                jsonNetResult.ContentEncoding = jsonResult.ContentEncoding;
                jsonNetResult.ContentType = jsonResult.ContentType;
                jsonNetResult.Data = jsonResult.Data;
                jsonNetResult.JsonRequestBehavior = jsonResult.JsonRequestBehavior;
                jsonNetResult.MaxJsonLength = jsonResult.MaxJsonLength;
                jsonNetResult.RecursionLimit = jsonResult.RecursionLimit;
                filterContext.Result = jsonResult;
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}
