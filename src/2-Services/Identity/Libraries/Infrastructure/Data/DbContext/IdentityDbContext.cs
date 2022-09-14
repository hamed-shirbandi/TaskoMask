using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TaskoMask.Services.Identity.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace TaskoMask.Services.Identity.Infrastructure.Data.DbContext
{
    public class IdentityDbContext : IdentityDbContext<User, IdentityRole<string>, string, IdentityUserClaim<string>, IdentityUserRole<string>, UserLogin, IdentityRoleClaim<string>, UserToken>
    {
        private readonly IConfiguration _configuration;

        public IdentityDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlConnection"));
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole<long>>().ToTable("Roles");
            builder.Entity<IdentityUserToken<long>>().ToTable("UserTokens");
            builder.Entity<IdentityUserRole<long>>().ToTable("UserRoles");
            builder.Entity<IdentityRoleClaim<long>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserClaim<long>>().ToTable("UserClaims");
            builder.Entity<UserLogin>().ToTable("UserLogins");
        }
    }
}
