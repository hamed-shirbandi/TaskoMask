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
                var dbContext = serviceScope.ServiceProvider.GetService<IMainDbContext>();
                var organizations = dbContext.GetCollection<Organization>();
                var projects = dbContext.GetCollection<Project>();
                var boards = dbContext.GetCollection<Board>();
                var tasks = dbContext.GetCollection<Task>();
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

                #region Add some Organizations

                if (!organizations.AsQueryable().Any())
                {
                    var user = userManager.Users.FirstOrDefault();
                    var organization = new Organization
                    {
                        UserId = user.Id.ToString(),
                        Name = "Organization number 1",
                        Description = "Organization number 1 Description"
                    };
                    organizations.InsertOne(organization);
                }

                #endregion

                #region Add some Projects

                if (!projects.AsQueryable().Any())
                {
                    var organization = organizations.AsQueryable().FirstOrDefault();
                    var project = new Project
                    {
                        OrganizationId = organization.Id,
                        Name = "Project number 1",
                        Description = "Project number 1 Description"
                    };
                    projects.InsertOne(project);
                }

                #endregion

                #region Add some Boards

                if (!boards.AsQueryable().Any())
                {
                    var project = projects.AsQueryable().FirstOrDefault();
                    var board = new Board
                    {
                        ProjectId = project.Id,
                        Name = "Board number 1",
                        Description = "Board number 1 Description"
                    };
                    boards.InsertOne(board);
                }

                #endregion

                #region Add some Tasks

                if (!tasks.AsQueryable().Any())
                {
                    var board = boards.AsQueryable().FirstOrDefault();
                    var task = new Task
                    {
                        BoardId = board.Id,
                        Title = "Task number 1",
                        Description = "Task number 1 Description"
                    };
                    tasks.InsertOne(task);
                }



                #endregion

            }
        }
    }
}
