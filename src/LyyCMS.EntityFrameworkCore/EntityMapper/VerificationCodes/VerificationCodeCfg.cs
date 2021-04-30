

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LyyCMS.Members;

namespace LyyCMS.EntityMapper.VerificationCodes
{
    public class VerificationCodeCfg : IEntityTypeConfiguration<VerificationCode>
    {
        public void Configure(EntityTypeBuilder<VerificationCode> builder)
        {

			 
      //   builder.ToTable("VerificationCodes", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("VerificationCodes");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


