using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DbContext;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DbContext;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Generator.ReadDB
{

    /// <summary>
    /// 
    /// </summary>
    internal static class ReadDbSeedData
    {

        /// <summary>
        /// Sync sample data that is inserted from WriteDbSeedData.SeedSampleData
        /// </summary>
        public static void SyncSampleDataWithWriteDB(IServiceProvider serviceProvider)
        {
        }

    }
}
