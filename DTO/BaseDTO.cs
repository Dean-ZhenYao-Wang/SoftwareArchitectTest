using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Serializable]
    public abstract class BaseDTO
    {
        public Guid Id { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
