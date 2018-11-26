using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ZYW.Services.Entities;

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

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CreditCardEntity> CreditCards { get; set; }
    }
}
