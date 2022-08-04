using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.DomainModel.Authorization.Entities;
using TaskoMask.Domain.DomainModel.Membership.Entities;
using TaskoMask.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.Domain.DomainModel.Workspace.Boards.Services;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Entities;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Services;
using TaskoMask.Infrastructure.Data.Generator.ReadDB;

namespace TaskoMask.Infrastructure.Data.Generator.WriteDB
{
    internal static class WriteDbDataGenerator
    {


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
            var owners = ReadDbDataGenerator.GenerateOwner(users);

            foreach (var owner in owners)
            {
                var ownerAggregate = Owner.RegisterOwner(owner.Id, owner.DisplayName, owner.Email);

                var organizations = ReadDbDataGenerator.GenerateOrganization();

                foreach (var organization in organizations)
                {
                    var createdOrganization = Organization.CreateOrganization(organization.Name, organization.Description);
                    ownerAggregate.AddOrganization(createdOrganization);

                    var projects = ReadDbDataGenerator.GenerateProject();
                    foreach (var project in projects)
                        ownerAggregate.AddProject(createdOrganization.Id, Project.Create(project.Name, project.Description));

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
                        var boards = ReadDbDataGenerator.GenerateBoard();
                        foreach (var board in boards)
                        {
                            var boardAggregate = Board.CreateBoard(board.Name, board.Description, project.Id, boardValidatorService);

                            var cards = ReadDbDataGenerator.GenerateCard();
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
        public static IEnumerable<Domain.DomainModel.Workspace.Tasks.Entities.Task> GenerateTasks(IEnumerable<Board> boards, ITaskValidatorService taskValidatorService)
        {
            var items = new List<Domain.DomainModel.Workspace.Tasks.Entities.Task>();

            foreach (var board in boards)
                foreach (var card in board.Cards)
                {
                    var tasks = ReadDbDataGenerator.GenerateTasks();
                    foreach (var task in tasks)
                    {
                        var taskAggregate = Domain.DomainModel.Workspace.Tasks.Entities.Task.CreateTask(task.Title, task.Description, card.Id, board.Id, taskValidatorService);
                        items.Add(taskAggregate);
                    }
                }

            return items;
        }

    }
}
