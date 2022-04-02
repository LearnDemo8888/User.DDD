using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.DDD.Domain.Entities;

namespace User.DDD.Intrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Domain.Entities.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.User> builder)
        {

            builder.HasKey("Id");
            builder.OwnsOne(o => o.PhoneNumber, nb =>
            {
                nb.Property(b => b.RegionCode);
                nb.Property(b => b.Number).HasMaxLength(20).IsUnicode();
            });
            builder.HasOne(o => o.Access).WithOne(f=>f.User).HasForeignKey<UserAccessFail>(x=>x.UserId) ;
            builder.Property("password").HasMaxLength(150).HasColumnName("Password").IsUnicode(false);

            builder.ToTable("T_Users");
        }
    }
}
