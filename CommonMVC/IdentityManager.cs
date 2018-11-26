using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYW.DTO;
using ZYW.IServices;
using ZYW.Services;
using ZYW.Services.Entities;

namespace ZYW.CommonMVC
{
    public class IdentityManager
    {

        private static IUserService userService { get; set; }
        private static CacheManager _cache = new CacheManager();
        public static UserDTO GetByToken(string token)
        {
            var identity = _cache.Get<DTO.UserDTO>(token);

            if (identity == null)
            {
                identity = GetByDbToken(token, false);

                if (identity != null)
                {
                    identity.AccessToken = token;
                    _cache.Set(identity.AccessToken, identity, 300);
                }
            }

            return identity;
        }

        private static UserDTO GetByDbToken(string token, bool updateToken)
        {
            UserDTO identity = userService.GetByToken(token);
            if (identity == null)
                return null;
            if (updateToken)
            {
                var newToken = Guid.NewGuid().ToString("N");
                identity.AccessToken = newToken;
                using (MyDbContext db = new MyDbContext())
                {
                    UserEntity user = db.Users.Where(m => m.Id == identity.Id).FirstOrDefault();
                    user.AccessToken = newToken;
                    db.SaveChanges();
                }
            }
            return identity;
        }

        private static UserDTO GetByDbId(Guid userId, bool updateToken)
        {
            UserDTO identity = userService.GetByDbId(userId);
            if (identity == null)
                return null;
            if (updateToken)
            {
                var newToken = Guid.NewGuid().ToString("N");
                identity.AccessToken = newToken;
                using (MyDbContext db = new MyDbContext())
                {
                    UserEntity user = db.Users.Where(m => m.Id == identity.Id).FirstOrDefault();
                    user.AccessToken = newToken;
                    db.SaveChanges();
                }
            }
            return identity;
        }

        public static UserDTO Login(string loginName, string password)
        {
            string userId = userService.CheckLogin(loginName, password);

            if (!string.IsNullOrEmpty(userId) && userId.Length > 20)
            {
                Guid userguid = Guid.Parse(userId);
                var identity = GetByDbId(userguid, true);

                if (identity != null)
                {
                    ///用户登录后凭证信息缓存，600分钟内无访问就过期
                    _cache.Set(identity.AccessToken, identity, 600, CacheExpiration.Sliding);
                }

                return identity;
            }

            return null;
        }
        public static void Logout(UserDTO identity)
        {
            _cache.Remove(identity.AccessToken);
        }
    }
}
