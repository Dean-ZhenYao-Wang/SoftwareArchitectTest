using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYW.DTO;

namespace ZYW.IServices
{
    public interface IUserService:IServiceSupport
    {
        /// <summary>
        /// Check that the username password is correct
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        string CheckLogin(string loginName, string passWord);
        /// <summary>
        /// Record a login failure
        /// </summary>
        /// <param name="id">userId</param>
        void IncrLoginError(Guid id);
        /// <summary>
        /// Determine whether the user has been locked
        /// </summary>
        /// <param name="id">userId</param>
        /// <returns></returns>
        bool IsLocked(Guid id);

        UserDTO GetByToken(string token);

        UserDTO GetByDbId(Guid userId);
    }
}
