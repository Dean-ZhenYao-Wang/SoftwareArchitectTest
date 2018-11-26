using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYW.IServices;
using ZYW.Services.Entities;

namespace ZYW.Services.Service
{
    public class EventExecutionErrorLogService : IEventExecutionErrorLogService
    {
        public void ExecutionError(string businessModule, string functionName, string errorDescription)
        {
            EventExecutionErrorLogEntity log = new EventExecutionErrorLogEntity();
            log.LogID = Guid.NewGuid();
            log.OccurrenceTime = DateTime.Now;
            log.BusinessModule = businessModule;
            log.FunctionName = functionName;
            log.ErrorDescription = errorDescription;
            using (MyDbContext db=new MyDbContext())
            {
                db.errorLogEntities.Add(log);
                db.SaveChanges();
            }
        }
    }
}
