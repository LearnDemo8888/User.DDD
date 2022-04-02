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
    public class UserLoginHistoryConfiguration : IEntityTypeConfiguration<UserLoginHistory>
    {
        public void Configure(EntityTypeBuilder<UserLoginHistory> builder)
        {
            builder.HasKey("Id");
         

            builder.ToTable("T_UserLoginHistorys");
        }
    }
}
