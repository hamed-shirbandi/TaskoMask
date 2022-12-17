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
            var connection = _configuration.GetValue<string>("SQL:Connection");
            var databaseName = _configuration.GetValue<string>("SQL:DatabaseName");

            optionsBuilder.UseSqlServer(connection.Replace("[DatabaseName]", databaseName));
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole<string>>().ToTable("Roles");
            builder.Entity<UserToken>().ToTable("UserTokens");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<UserLogin>().ToTable("UserLogins");

            new UserMapping(builder.Entity<User>());
        }
    }
}
