using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.WriteModel.Authorization.Entities;
using TaskoMask.Domain.WriteModel.Membership.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Services;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Services;

namespace TaskoMask.Infrastructure.Data.Common.DataProviders
{
    public static class WriteModelDataGenerator
    {

        /// <summary>
        /// 
        /// </summary>
        public static User GetSuperUser(IConfiguration configuration, IEncryptionService encryptionService)
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
        public static Operator GetAdminOperator(string userId, IConfiguration configuration)
        {
            return new Operator(userId)
            {
                DisplayName = configuration["SuperUser:DisplayName"],
                Email = configuration["SuperUser:Email"],
            };

        }



        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<User> GenerateUser(string prefix)
        {
            var items = new List<User>();

            for (int i = 1; i <= 3; i++)
            {
                items.Add(new User
                {
                    IsActive = true,
                    UserName = $"{prefix}_{i}@email.com",
                    PasswordSalt = "test",
                    PasswordHash = "test"
                });
            }

            return items;
        }


        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Permission> GeneratePermission()
        {
            var items = new List<Permission>();

            for (int i = 1; i <= 10; i++)
            {
                var groupNumber = i > 5 ? 1 : 0;
                items.Add(new Permission
                {
                    DisplayName = $"Permission_{i}",
                    SystemName = $"SystemName_{i}",
                    GroupName = $"Group_{groupNumber}",
                });
            }

            return items;
        }




        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Role> GenerateRole(IEnumerable<Permission> permissions)
        {
            var items = new List<Role>();

            for (int i = 1; i <= 5; i++)
            {
                var permissionsId = permissions.Select(p => p.Id).ToArray();
                var permissionsCount = permissions.Count();
                var permissionTakeCount = i < permissionsCount ? i : permissionsCount;

                items.Add(new Role
                {
                    Name = $"Role Name {i}",
                    Description = $"Test Description {i}",
                    PermissionsId = permissionsId.Take(permissionTakeCount).ToArray(),
                });
            }

            return items;
        }



        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Operator> GenerateOperator(IEnumerable<User> users, IEnumerable<Role> roles)
        {
            var items = new List<Operator>();
            var i = 1;
            foreach (var user in users)
            {
                var rolesId = roles.Select(p => p.Id).ToArray();
                var rolesCount = roles.Count();
                var roleTakeCount = i < rolesCount ? i : rolesCount;

                items.Add(new Operator(user.Id)
                {
                    DisplayName = $"Operator {i}",
                    Email = user.UserName,
                    RolesId = rolesId.Take(roleTakeCount).ToArray(),
                });

                i++;
            }

            return items;
        }




        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Owner> GenerateOwner(IEnumerable<User> users)
        {
            var items = new List<Owner>();
            var owners = ReadModelDataGenerator.GenerateOwner(users);

            foreach (var owner in owners)
            {
                var ownerAggregate = Owner.CreateOwner(owner.Id, owner.DisplayName, owner.Email);

                var organizations = ReadModelDataGenerator.GenerateOrganization();

                foreach (var organization in organizations)
                {
                    var createdOrganization = Organization.CreateOrganization(organization.Name, organization.Description);
                    ownerAggregate.CreateOrganization(createdOrganization);

                    var projects = ReadModelDataGenerator.GenerateProject();
                    foreach (var project in projects)
                        ownerAggregate.CreateProject(createdOrganization.Id, Project.Create(project.Name, project.Description));

                }


                items.Add(ownerAggregate);
            }

            return items;
        }






        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Board> GenerateBoard(IEnumerable<Owner> owners, IBoardValidatorService boardValidatorService)
        {
            var items = new List<Board>();

            foreach (var owner in owners)
                foreach (var organization in owner.Organizations)
                    foreach (var project in organization.Projects)
                    {
                        var boards = ReadModelDataGenerator.GenerateBoard();
                        foreach (var board in boards)
                        {
                            var boardAggregate = Board.CreateBoard(board.Name, board.Description, project.Id, boardValidatorService);

                            var cards = ReadModelDataGenerator.GenerateCard();
                            foreach (var card in cards)
                                boardAggregate.CreateCard(Card.Create(card.Name, card.Type));


                            boardAggregate.CreateMember(Member.Create(owner.Id, BoardMemberAccessLevel.Writer));

                            items.Add(boardAggregate);
                        }


                    }

            return items;
        }




        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Task> GenerateTasks(IEnumerable<Board> boards, ITaskValidatorService taskValidatorService)
        {
            var items = new List<Task>();

            foreach (var board in boards)
                foreach (var card in board.Cards)
                {
                    var tasks = ReadModelDataGenerator.GenerateTasks();
                    foreach (var task in tasks)
                    {
                        var taskAggregate = Task.CreateTask(task.Title, task.Description, card.Id, board.Id, taskValidatorService);
                        items.Add(taskAggregate);
                    }
                }

            return items;
        }

    }
}
