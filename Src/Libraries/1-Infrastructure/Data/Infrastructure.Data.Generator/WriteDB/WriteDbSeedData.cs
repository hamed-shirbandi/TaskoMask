using MongoDB.Driver;
using TaskoMask.Domain.DomainModel.Membership.Entities;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Entities;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Entities;
using TaskoMask.Domain.DomainModel.Authorization.Entities;
using TaskoMask.Infrastructure.Data.Write.DbContext;
using TaskoMask.Domain.DomainModel.Workspace.Boards.Services;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace TaskoMask.Infrastructure.Data.Generator.WriteDB
{

    /// <summary>
    /// 
    /// </summary>
    public static class WriteDbSeedData
    {


        /// <summary>
        /// Seed the necessary data that system needs
        /// </summary>
        public static void SeedEssentialData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var _dbContext = serviceScope.ServiceProvider.GetService<IWriteDbContext>();
                var _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
                var _encryptionService = serviceScope.ServiceProvider.GetService<IEncryptionService>();


                var _users = _dbContext.GetCollection<User>();
                var _operators = _dbContext.GetCollection<Operator>();


                //if write database is empty
                if (!_operators.AsQueryable().Any())
                {
                    var superUser = WriteDbDataGenerator.GetSuperUser(_configuration, _encryptionService);
                    _users.InsertOne(superUser);

                    var adminOperator = WriteDbDataGenerator.GetAdminOperator(superUser.Id, _configuration);
                    _operators.InsertOne(adminOperator);
                }

            }
        }



        /// <summary>
        /// Seed some sample data
        /// </summary>
        public static void SeedSampleData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var _writeDbContext = serviceScope.ServiceProvider.GetService<IWriteDbContext>();
                var _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
                var _encryptionService = serviceScope.ServiceProvider.GetService<IEncryptionService>();
                var _boardValidatorService = serviceScope.ServiceProvider.GetService<IBoardValidatorService>();
                var _taskValidatorService = serviceScope.ServiceProvider.GetService<ITaskValidatorService>();

                #region  collections

                var _users = _writeDbContext.GetCollection<User>();
                var _operators = _writeDbContext.GetCollection<Operator>();
                var _roles = _writeDbContext.GetCollection<Role>();
                var _permissions = _writeDbContext.GetCollection<Permission>();

                var _ownerAggregate = _writeDbContext.GetCollection<Owner>();
                var _boardAggregate = _writeDbContext.GetCollection<Board>();
                var _taskAggregate = _writeDbContext.GetCollection<Domain.DomainModel.Workspace.Tasks.Entities.Task>();

                #endregion

                //if database is empty
                if (!_ownerAggregate.AsQueryable().Any())
                {
                    var permissions = WriteDbDataGenerator.GeneratePermission();
                    _permissions.InsertMany(permissions);

                    var roles = WriteDbDataGenerator.GenerateRole(permissions);
                    _roles.InsertMany(roles);

                    var usersAsOperator = WriteDbDataGenerator.GenerateUser("Operator");
                    _users.InsertMany(usersAsOperator);


                    var operators = WriteDbDataGenerator.GenerateOperator(usersAsOperator, roles);
                    _operators.InsertMany(operators);


                    var usersAsOwner= WriteDbDataGenerator.GenerateUser("Owner");
                    _users.InsertMany(usersAsOwner);

                    var owners = WriteDbDataGenerator.GenerateOwner(usersAsOwner);
                    _ownerAggregate.InsertMany(owners);


                    var boards = WriteDbDataGenerator.GenerateBoard(owners, _boardValidatorService);
                    _boardAggregate.InsertMany(boards);


                    var tasks = WriteDbDataGenerator.GenerateTasks(boards,_taskValidatorService);
                    _taskAggregate.InsertMany(tasks);


                }

            }

        }

    }
}
