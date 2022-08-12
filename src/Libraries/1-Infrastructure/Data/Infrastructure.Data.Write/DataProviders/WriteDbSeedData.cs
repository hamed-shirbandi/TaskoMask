using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Linq;
using TaskoMask.Domain.DomainModel.Membership.Entities;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.DomainModel.Authorization.Entities;
using TaskoMask.Infrastructure.Data.Write.DbContext;

namespace TaskoMask.Infrastructure.Data.Write.DataProviders
{

    /// <summary>
    /// 
    /// </summary>
    public static class WriteDbSeedData
    {


        /// <summary>
        /// Seed the necessary data that system needs
        /// </summary>
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var _dbContext = serviceScope.ServiceProvider.GetService<IWriteDbContext>();
                var _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
                var _encryptionService = serviceScope.ServiceProvider.GetService<IEncryptionService>();

                var _users = _dbContext.GetCollection<User>();
                var _operators = _dbContext.GetCollection<Operator>();


                if (!_operators.AsQueryable().Any())
                {
                    var superUser = GetSuperUser(_configuration, _encryptionService);
                    _users.InsertOne(superUser);

                    var adminOperator = GetAdminOperator(superUser.Id, _configuration);
                    _operators.InsertOne(adminOperator);
                }

            }
        }



        /// <summary>
        /// 
        /// </summary>
        private static User GetSuperUser(IConfiguration configuration, IEncryptionService encryptionService)
        {
            var passwordSalt = encryptionService.CreateSaltKey(5);

            return new User
            {
                UserName = configuration["SuperUser:Email"],
                IsActive = true,
                PasswordSalt = passwordSalt,
                PasswordHash = encryptionService.CreatePasswordHash(configuration["SuperUser:Password"], passwordSalt)
            };

        }



        /// <summary>
        /// 
        /// </summary>
        private static Operator GetAdminOperator(string userId, IConfiguration configuration)
        {
            return new Operator(userId)
            {
                DisplayName = configuration["SuperUser:DisplayName"],
                Email = configuration["SuperUser:Email"],
            };

        }

    }
}
