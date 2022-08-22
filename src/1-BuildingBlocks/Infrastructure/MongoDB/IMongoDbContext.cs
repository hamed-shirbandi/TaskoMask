using MongoDB.Driver;
using System.Collections.Generic;

namespace TaskoMask.BuildingBlocks.Infrastructure.MongoDB
{
    public interface IMongoDbContext
    {
        /// <summary>
        /// get collection
        /// </summary>
        IMongoCollection<TEntity> GetCollection<TEntity>(string name = "");




        /// <summary>
        /// remove the database
        /// </summary>
        void DropDatabase();


    }
}
