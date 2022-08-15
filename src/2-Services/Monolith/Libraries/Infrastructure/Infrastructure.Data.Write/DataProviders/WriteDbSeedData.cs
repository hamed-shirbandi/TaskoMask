using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Linq;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Entities;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DbContext;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Write.DataProviders
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

                var _users = _dbContext.GetCollection<User>();
                var _operators = _dbContext.GetCollection<Operator>();


                if (!_operators.AsQueryable().Any())
                {
                    var superUser = GetSuperUser(_configuration);
                    _users.InsertOne(superUser);

                    var adminOperator = GetAdminOperator(superUser.Id, _configuration);
                    _operators.InsertOne(adminOperator);
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
