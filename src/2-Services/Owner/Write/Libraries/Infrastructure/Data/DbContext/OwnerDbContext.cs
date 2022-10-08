using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TaskoMask.Services.Owner.Infrastructure.Data.DbContext
{
    public class OwnerDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IConfiguration _configuration;

        public OwnerDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = _configuration.GetValue<string>("ConnectionString:Connection");
            var databaseName = _configuration.GetValue<string>("ConnectionString:DatabaseName");

            optionsBuilder.UseSqlServer(connection.Replace("[DatabaseName]", databaseName));
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
