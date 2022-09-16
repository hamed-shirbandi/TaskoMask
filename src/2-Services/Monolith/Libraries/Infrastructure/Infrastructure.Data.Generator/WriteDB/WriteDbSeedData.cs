using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DbContext;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Services;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Generator.WriteDB
{

    /// <summary>
    /// 
    /// </summary>
    internal static class WriteDbSeedData
    {

        /// <summary>
        /// Seed some sample data
        /// </summary>
        public static void SeedSampleData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var _writeDbContext = serviceScope.ServiceProvider.GetService<IWriteDbContext>();
                var _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
                var _boardValidatorService = serviceScope.ServiceProvider.GetService<IBoardValidatorService>();
                var _taskValidatorService = serviceScope.ServiceProvider.GetService<ITaskValidatorService>();

                #region  collections

                var _ownerAggregate = _writeDbContext.GetCollection<Owner>();
                var _boardAggregate = _writeDbContext.GetCollection<Board>();
                var _taskAggregate = _writeDbContext.GetCollection<Domain.DomainModel.Workspace.Tasks.Entities.Task>();

                #endregion

                //if database is empty
                if (!_ownerAggregate.AsQueryable().Any())
                {

                    //var usersAsOwner= WriteDbDataGenerator.GenerateUser("Owner");
                    //_users.InsertMany(usersAsOwner);

                    //var owners = WriteDbDataGenerator.GenerateOwner(usersAsOwner);
                    //_ownerAggregate.InsertMany(owners);


                    //var boards = WriteDbDataGenerator.GenerateBoard(owners, _boardValidatorService);
                    //_boardAggregate.InsertMany(boards);


                    //var tasks = WriteDbDataGenerator.GenerateTasks(boards,_taskValidatorService);
                    //_taskAggregate.InsertMany(tasks);


                }

            }

        }

    }
}
