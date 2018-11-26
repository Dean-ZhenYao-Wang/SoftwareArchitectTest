using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYW.DTO;
using ZYW.IServices;
using ZYW.Services.Entities;

namespace ZYW.Services.Service
{
    public class UserService : IUserService
    {
        public bool CheckLogin(string loginName, string passWord)
        {
            using (MyDbContext db=new MyDbContext())
            {
                BaseService<UserEntity> service = new BaseService<UserEntity>(db);
                var user = service.GetAll().SingleOrDefault(m => m.LoginName == loginName && m.PassWord == passWord);
                if(user==null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public UserDTO ToDTO(UserEntity user)
        {
            UserDTO dto = new UserDTO();
            dto.AccessToken = user.AccessToken;
            dto.Id = user.Id;
            dto.LoginName = user.LoginName;
            dto.LoginErrorTimes = user.LoginErrorTimes;
            dto.LastLoginErrorDateTime = user.LastLoginErrorDateTime;
            return dto;
        }
        public UserDTO GetById(Guid id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                BaseService<UserEntity> bs = new BaseService<UserEntity>(db);
                var user = bs.GetById(id);
                return user == null ? null : ToDTO(user);
            }
        }

        public void IncrLoginError(Guid id)
        {
            using (MyDbContext db=new MyDbContext())
            {
                BaseService<UserEntity> baseService = new BaseService<UserEntity>(db);
                var user = baseService.GetById(id);
                if(user==null)
                {
                    throw new ArgumentException("user does not exist " + id);
                }
                user.LoginErrorTimes++;
                user.LastLoginErrorDateTime = DateTime.Now;
                db.SaveChanges();
            }
        }

        public bool IsLocked(Guid id)
        {
            var user = GetById(id);
            //Error logon times >= 5, last logon error time within 30 minutes
            return (user.LoginErrorTimes >= 5 && user.LastLoginErrorDateTime > DateTime.Now.AddMinutes(30));
        }
    }
}
