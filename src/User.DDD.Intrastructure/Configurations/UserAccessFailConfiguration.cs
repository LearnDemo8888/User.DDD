using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.DDD.Domain.Entities;

namespace User.DDD.Intrastructure.Configurations
{
    public class UserAccessFailConfiguration : IEntityTypeConfiguration<UserAccessFail>
    {
        public void Configure(EntityTypeBuilder<UserAccessFail> builder)
        {

            builder.HasKey("Id");
            builder.Property("isLockOut").HasColumnName("IsLockOut");
            builder.ToTable("T_UserAccessFails");

        }
    }
}
