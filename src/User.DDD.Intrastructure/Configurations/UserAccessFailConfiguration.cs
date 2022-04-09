using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using User.DDD.Domain.Entities;

namespace User.DDD.Intrastructure.Configurations
{
    public class UserAccessFailConfiguration : IEntityTypeConfiguration<UserAccessFail>
    {
        public void Configure(EntityTypeBuilder<UserAccessFail> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property("isLockOut").HasColumnName("IsLockOut");
            builder.ToTable("T_UserAccessFails");

        }
    }
}
