using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskoMask.Domain.Core.Enums;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Models;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.DataProviders
{
    public static class DbSeedData
    {

        public static void MongoDbSeedData(this IServiceScopeFactory scopeFactory)
        {
            using (var serviceScope = scopeFactory.CreateScope())
            {
                string adminRoleName = "admin";
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<ApplicationRole>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();

                #region Add some Roles

                if (!roleManager.Roles.Any())
                {
                    var role = new ApplicationRole
                    {
                        Name = adminRoleName,
                    };
                    var result = roleManager.CreateAsync(role).Result;
                }

                #endregion

                #region Add some Users

                if (!userManager.Users.Any())
                {
                    var user = new User
                    {
                        DisplayName="Super User",
                        UserName = configuration["Identity:SuperUser:UserName"],
                        Email = configuration["Identity:SuperUser:Email"],
                        PhoneNumber = configuration["Identity:SuperUser:PhoneNumber"],
                    };
                    var result = userManager.CreateAsync(user, configuration["Identity:SuperUser:Password"]).Result;

                    //add user to admin role
                    if (result.Succeeded)
                        result = userManager.AddToRoleAsync(user, adminRoleName).Result;
                }

                #endregion
            }
        }
    }
}
