using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using ZYW.IServices;

namespace ZYW.Web.Controllers
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private static IEventExecutionErrorLogService eventExecutionErrorLogService { get; set; }
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var path = actionExecutedContext.Request.RequestUri.AbsolutePath;

            eventExecutionErrorLogService.ExecutionError(path, path, actionExecutedContext.Exception.StackTrace);

            base.OnException(actionExecutedContext);
        }
    }
}
