using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.Services.Entities
{
    public class EventExecutionErrorLogEntity:BaseEntity
    {
        public Guid LogID { get; set; }

        public string FunctionName { get; set; }
        public string ErrorDescription { get; set; }

        public DateTime OccurrenceTime { get; set; }

        public string Remark { get; set; }
    }
}
