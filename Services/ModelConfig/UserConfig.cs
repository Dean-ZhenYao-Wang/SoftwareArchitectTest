using ZYW.Services.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.Services.ModelConfig
{
    public class UserConfig:EntityTypeConfiguration<UserEntity>
    {
        public UserConfig()
        {
            ToTable("T_Users");
            Property(p => p.LoginName).IsRequired().HasMaxLength(50);
            Property(p => p.PassWord).IsRequired().HasMaxLength(20);
        }
    }
}
