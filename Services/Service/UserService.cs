using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYW.CommonMVC;
using ZYW.DTO;
using ZYW.IServices;
using ZYW.Services.Entities;

namespace ZYW.Services.Service
{
    public class UserService : IUserService
    {
        private static CommonMVC.CacheManager _cache = new CommonMVC.CacheManager();
        public string CheckLogin(string loginName, string passWord)
        {
            using (MyDbContext db = new MyDbContext())
            {
                BaseService<Entities.UserEntity> service = new BaseService<Entities.UserEntity>(db);
                var user = service.GetAll().SingleOrDefault(m => m.LoginName == loginName && m.PassWord == passWord);
                if (user == null)
                {
                    return "";
                }
                else
                {
                    return user.Id.ToString();
                }
            }
        }
        private UserDTO ToDTO(Entities.UserEntity user)
        {
            DTO.UserDTO dto = new DTO.UserDTO();
            dto.AccessToken = user.AccessToken;
            dto.Id = user.Id;
            dto.LoginName = user.LoginName;
            dto.LoginErrorTimes = user.LoginErrorTimes;
            dto.LastLoginErrorDateTime = user.LastLoginErrorDateTime;
            return dto;
        }

        public void IncrLoginError(Guid id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                BaseService<Entities.UserEntity> baseService = new BaseService<Entities.UserEntity>(db);
                var user = baseService.GetById(id);
                if (user == null)
                {
                    throw new ArgumentException("user does not exist " + id);
                }
                user.LoginErrorTimes++;
                user.LastLoginErrorDateTime = DateTime.Now;
                db.SaveChanges();
            }
        }
        private UserEntity GetById(Guid id)
        {
            UserEntity user = null;
            using (MyDbContext db = new MyDbContext())
            {
                user = db.Users.Where(m => m.Id == id).SingleOrDefault();
            }
            return user;
        }
        public bool IsLocked(Guid id)
        {
            var user = GetById(id);
            //Error logon times >= 5, last logon error time within 30 minutes
            return (user.LoginErrorTimes >= 5 && user.LastLoginErrorDateTime > DateTime.Now.AddMinutes(30));
        }

        public UserDTO GetByToken(string token)
        {
            using (MyDbContext db = new MyDbContext())
            {
                BaseService<Entities.UserEntity> bs = new BaseService<Entities.UserEntity>(db);
                var user = bs.GetAll().Where(m => m.AccessToken == token).SingleOrDefault();
                return user == null ? null : ToDTO(user);
            }
        }
        public UserDTO GetByDbId(Guid userId, bool updateToken)
        {
            using (MyDbContext db = new MyDbContext())
            {
                BaseService<Entities.UserEntity> bs = new BaseService<Entities.UserEntity>(db);
                var user = bs.GetAll().Where(m => m.Id == userId).SingleOrDefault();
                var identity = user == null ? null : ToDTO(user);
                if (identity == null)
                    return null;
                if (updateToken)
                {
                    var newToken = Guid.NewGuid().ToString("N");
                    identity.AccessToken = newToken;
                    UserEntity userEntity = db.Users.Where(m => m.Id == identity.Id).FirstOrDefault();
                    userEntity.AccessToken = newToken;
                    db.SaveChanges();
                }
                return identity;
            }
        }

        public UserDTO Login(string loginName, string passWord)
        {
            string userId = CheckLogin(loginName, passWord);

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

        public UserDTO GetByDbToken(string token, bool updateToken)
        {
            UserDTO identity = GetByToken(token);
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
    }
}
