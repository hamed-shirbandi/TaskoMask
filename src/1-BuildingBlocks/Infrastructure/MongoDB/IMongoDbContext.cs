using MongoDB.Driver;

namespace TaskoMask.BuildingBlocks.Infrastructure.MongoDB
{
    ///TODO delete this interface after removing monolith service
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
