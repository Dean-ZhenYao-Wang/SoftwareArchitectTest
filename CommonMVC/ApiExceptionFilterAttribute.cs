using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using ZYW.IServices;
using ZYW.Services;
using ZYW.Services.Entities;

namespace ZYW.CommonMVC
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public IEventExecutionErrorLogService eventExecutionErrorLogService { get; set; }
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var path = actionExecutedContext.Request.RequestUri.AbsolutePath;

            eventExecutionErrorLogService.ExecutionError(path, path, actionExecutedContext.Exception.StackTrace);

            base.OnException(actionExecutedContext);
        }
    }
}
