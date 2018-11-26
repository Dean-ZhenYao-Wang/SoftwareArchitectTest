using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYW.Services.Entities;

namespace ZYW.Services.Service
{
    /// <summary>
    /// This class is called CommonService.
    /// </summary>
    class BaseService<T> where T:BaseEntity
    {
        private MyDbContext db;
        public BaseService(MyDbContext db)
        {
            this.db = db;
        }
        /// <summary>
        /// Get all data without soft deletion
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return db.Set<T>().Where(e => e.IsDeleted == false);
        }
        /// <summary>
        /// Get the total number of data bars
        /// </summary>
        /// <returns></returns>
        public long GetTotalCount()
        {
            return GetAll().LongCount();
        }
        /// <summary>
        /// Find the data with id = ID and return null if not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(Guid id)
        {
            return GetAll().Where(m => m.Id == id).SingleOrDefault();
        }
    }
}
