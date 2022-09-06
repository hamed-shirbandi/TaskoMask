using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Identity.Domain.Entities;
using TaskoMask.Services.Identity.Infrastructure.DbContext;

namespace TaskoMask.Services.Identity.Infrastructure.DataProviders
{

    /// <summary>
    /// 
    /// </summary>
    public static class DbSeedData
    {


        /// <summary>
        /// Seed the necessary data that system needs
        /// </summary>
        public static void SeedEssentialData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var _identityDbContext = serviceScope.ServiceProvider.GetService<IIdentityDbContext>();
                var _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();

                var _users = _identityDbContext.GetCollection<User>();


                if (!_users.AsQueryable().Any())
                {
                    var superUser = GetSuperUser(_configuration);
                    _users.InsertOne(superUser);
                }

            }
        }



        /// <summary>
        /// 
        /// </summary>
        private static User GetSuperUser(IConfiguration configuration)
        {
            var passwordSalt = EncryptionHelper.CreateSaltKey(5);

            return new User
            {
                UserName = configuration["SuperUser:Email"],
                IsActive = true,
                PasswordSalt = passwordSalt,
                PasswordHash = EncryptionHelper.CreatePasswordHash(configuration["SuperUser:Password"], passwordSalt)
            };

        }
    }
}
