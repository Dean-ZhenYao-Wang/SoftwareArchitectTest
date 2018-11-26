using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.Services.Entities
{
    public class UserEntity:BaseEntity
    {
        public string LoginName { get; set; }
        public string PassWord { get; set; }
        public string AccessToken { get; set; }
        public int LoginErrorTimes { get; set; }
        public DateTime? LastLoginErrorDateTime { get; set; }
    }
}
