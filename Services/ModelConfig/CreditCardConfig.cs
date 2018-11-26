using ZYW.Services.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.Services.ModelConfig
{
    public class CreditCardConfig:EntityTypeConfiguration<CreditCardEntity>
    {
        public CreditCardConfig()
        {
            ToTable("T_CreditCard");
            Property(p => p.CardNumber).IsRequired().HasMaxLength(16);
        }
    }
}
