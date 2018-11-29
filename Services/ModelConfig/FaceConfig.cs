using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYW.Services.Entities;

namespace ZYW.Services.ModelConfig
{
    public class FaceConfig: EntityTypeConfiguration<FaceEntity>
    {
        public FaceConfig()
        {
            ToTable("T_Face");
        }
    }
}
