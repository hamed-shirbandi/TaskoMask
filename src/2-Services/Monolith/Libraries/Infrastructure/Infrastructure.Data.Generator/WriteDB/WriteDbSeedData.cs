using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;
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

        }

    }
}
