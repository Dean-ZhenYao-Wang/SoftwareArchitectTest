using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace ZYW.Services
{
    public class MyDbContext:DbContext
    {
        public static ILog log = LogManager.GetLogger(typeof(MyDbContext));

        public MyDbContext():base("name=connstr")
        {
            Database.SetInitializer<MyDbContext>(null);
            this.Database.Log = (sql) =>
            {
                log.DebugFormat("EF Implement SQL:{0}", sql);
            };
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
