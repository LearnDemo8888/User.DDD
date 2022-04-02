using Microsoft.EntityFrameworkCore;
using System.Reflection;
using User.DDD.Domain.Entities;

namespace User.DDD.Intrastructure
{
    public class UserDbContext: DbContext
    {


        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        { 
        
        }

        public DbSet<Domain.Entities.User> Users { get;  set; }

        public DbSet<UserLoginHistory> UserLoginHistories { get;  set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
     
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
