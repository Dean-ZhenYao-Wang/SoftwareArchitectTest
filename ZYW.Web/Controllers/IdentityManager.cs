using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYW.CommonMVC;
using ZYW.DTO;
using ZYW.IServices;
using ZYW.Services;
using ZYW.Services.Entities;

namespace ZYW.Web.Controllers
{
    public class IdentityManager
    {
        private static CommonMVC.CacheManager _cache = new CommonMVC.CacheManager();
        public static void Logout(UserDTO identity)
        {
            _cache.Remove(identity.AccessToken);
        }
    }
}
