using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.IServices
{
     public interface IEventExecutionErrorLogService: IServiceSupport
    {
        void ExecutionError(string businessModule,string functionName,string errorDescription);
    }
}
