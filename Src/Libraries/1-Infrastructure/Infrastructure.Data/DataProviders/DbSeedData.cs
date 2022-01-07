using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Linq;
using TaskoMask.Domain.Administration.Entities;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Core.ValueObjects;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Team.Entities;
using TaskoMask.Domain.Team.Entities.Members;
using TaskoMask.Domain.Team.Entities.Organizations.ValueObjects;
using TaskoMask.Domain.Workspace.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.DataProviders
{

    /// <summary>
    /// 
    /// </summary>
    public static class DbSeedData
    {


        /// <summary>
        /// 
        /// </summary>
        public static void SeedEssentialData(this IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var _dbContext = serviceScope.ServiceProvider.GetService<IMongoDbContext>();
                var _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
                var _encryptionService = serviceScope.ServiceProvider.GetService<IEncryptionService>();
                var _operators = _dbContext.GetCollection<Operator>();

                if (!_operators.AsQueryable().Any())
                {
                    var identity = UserIdentity.Create(UserDisplayName.Create(_configuration["SuperUser:DisplayName"]), UserEmail.Create(_configuration["SuperUser:Email"]), UserPhoneNumber.Create(_configuration["SuperUser:PhoneNumber"]));
                    var authentication = UserAuthentication.Create(UserName.Create(_configuration["SuperUser:Email"]));

                    var @operator = new Operator(identity, authentication);
                    @operator.SetPassword(_configuration["SuperUser:Password"], _encryptionService);


                    _operators.InsertOne(@operator);
                }

            }
        }



        /// <summary>
        /// 
        /// </summary>
        public static void SeedAdminPanelTempData(this IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var _dbContext = serviceScope.ServiceProvider.GetService<IMongoDbContext>();
                var _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
                var _encryptionService = serviceScope.ServiceProvider.GetService<IEncryptionService>();

                var _operators = _dbContext.GetCollection<Operator>();
                var _roles = _dbContext.GetCollection<Role>();
                var _permissions = _dbContext.GetCollection<Permission>();


                var _members = _dbContext.GetCollection<Member>();
                var _organizations = _dbContext.GetCollection<Organization>();
                var _Projects = _dbContext.GetCollection<Project>();

                var _boards = _dbContext.GetCollection<Board>();
                var _cards = _dbContext.GetCollection<Card>();
                var _tasks = _dbContext.GetCollection<Task>();


                if (!_tasks.AsQueryable().Any())
                {
                    #region Permissions

                    for (int i = 1; i <= 10; i++)
                    {
                        var groupNumber = i > 5 ? 1 : 0;
                        var permission = new Permission
                        {
                            DisplayName = $"Permission Name {i}",
                            SystemName = $"SystemName{i}",
                            GroupName = $"Group Name {groupNumber}",
                        };
                        _permissions.InsertOne(permission);
                    }

                    #endregion

                    #region Roles

                    for (int i = 1; i <= 10; i++)
                    {
                        var permissionsId = _permissions.Find(p => true).ToList().Select(p => p.Id).ToArray();
                        var role = new Role
                        {
                            Name = $"Role Name {i}",
                            Description = $"Test Description {i}",
                            PermissionsId = permissionsId.Take(i).ToArray(),
                        };
                        _roles.InsertOne(role);
                    }

                    #endregion

                    #region Operators

                    for (int i = 1; i <= 10; i++)
                    {
                        var rolesId = _roles.Find(p => true).ToList().Select(p => p.Id).ToArray();
                        var identity = UserIdentity.Create(
                             UserDisplayName.Create($"Operator Name {i}"),
                             UserEmail.Create($"Email{i}@example.com"),
                             UserPhoneNumber.Create($"093000000{(i - 1)}"));
                        var authentication = UserAuthentication.Create(UserName.Create($"Email{i}@example.com"));

                        var @operator = new Operator(identity, authentication);
                        @operator.SetPassword("123456789", _encryptionService);

                        @operator.UpdateRoles(rolesId.Take(i).ToArray());

                        _operators.InsertOne(@operator);
                    }

                    #endregion

                    #region Members => Organizations => Projects => Boards => Cards => Tasks

                    for (int i = 1; i <= 3; i++)
                    {
                        var identity = UserIdentity.Create(
                              UserDisplayName.Create($"Operator Name {i}"),
                              UserEmail.Create($"Email{i}@example.com"),
                              UserPhoneNumber.Create(""));
                        var authentication = UserAuthentication.Create(UserName.Create($"Email{i}@example.com"));

                        var member = new Member(identity, authentication);
                        member.SetPassword("123456789", _encryptionService);

                        _members.InsertOne(member);

                        #region Organizations

                        for (int j = 1; j <= 3; j++)
                        {
                            var organization = new Organization(
                                OrganizationName.Create($"Organization Name {j}"),
                                OrganizationDescription.Create($"Description {j}"),
                                OrganizationOwnerMemberId.Create(member.Id));

                            _organizations.InsertOne(organization);

                            #region Projects

                            for (int k = 1; k <= 3; k++)
                            {
                                var project = new Project(
                                    $" ProjectName {k}",
                                    $"Description {k}",
                                    organization.Id);

                                _Projects.InsertOne(project);


                                #region Boards

                                for (int l = 1; l <= 3; l++)
                                {
                                    var board = new Board(
                                        $"Board Name {l}",
                                        $"Description {l}",
                                        project.Id,
                                        organization.Id);

                                    _boards.InsertOne(board);


                                    #region Cards

                                    for (int m = 1; m <= 3; m++)
                                    {
                                        var card = new Card(
                                            $"Card Name {m}",
                                            $"Description {m}",
                                            board.Id,
                                            CardType.ToDo,
                                            organization.Id,
                                            project.Id);

                                        _cards.InsertOne(card);

                                        #region Tasks

                                        for (int n = 1; n <= 3; n++)
                                        {
                                            var task = new Task(
                                                $"Task Title {n}",
                                                $"Description {n}",
                                                card.Id,
                                                board.Id,
                                                organization.Id,
                                                project.Id);

                                            _tasks.InsertOne(task);
                                        }

                                        #endregion
                                    }

                                    #endregion
                                }



                                #endregion
                            }

                            #endregion
                        }

                        #endregion
                    }

                    #endregion

                }

            }
        }

    }
}
