using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.DDD.Domain.Entities;

namespace User.DDD.Intrastructure.Configurations
{
    public class UserLoginHistoryConfiguration : IEntityTypeConfiguration<UserLoginHistory>
    {
        public void Configure(EntityTypeBuilder<UserLoginHistory> builder)
        {
            builder.HasKey(x => x.Id);
            //.IsClustered(false);//对于Guid主键，不要建聚集索引，否则插入性能很差;

            builder.ToTable("T_UserLoginHistorys");
        }
    }
}
