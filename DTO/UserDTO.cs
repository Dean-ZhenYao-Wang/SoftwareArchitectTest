using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.DTO
{
    public class UserDTO:BaseDTO
    {
        public String AccessToken { get; set; }
        public String LoginName { get; set; }
    }

    public class LoginUserDTO
    {
        public string LoginName { get; set; }

        public string PassWord { get; set; }
    }
}
