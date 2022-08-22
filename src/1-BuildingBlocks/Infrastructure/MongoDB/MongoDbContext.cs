using System.Collections.Generic;
using MongoDB.Driver;
using System.Linq;
using Microsoft.Extensions.Options;

namespace TaskoMask.BuildingBlocks.Infrastructure.MongoDB
{

    /// <summary>
    /// 
    /// </summary>
    public abstract class MongoDbContext : IMongoDbContext
    {
        #region Fields

        protected readonly MongoDbOptions _mongoDbOptions;
        protected readonly IMongoDatabase _database;
        protected readonly IMongoClient _client;

        #endregion

        #region Ctors


        public MongoDbContext(IOptions<MongoDbOptions> mongoDbOptions)
        {
            _mongoDbOptions = mongoDbOptions.Value;
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(_mongoDbOptions.Connection));
            _client = new MongoClient(settings);
            _database = _client.GetDatabase(_mongoDbOptions.DatabaseName);
        }



        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public IMongoCollection<TEntity> GetCollection<TEntity>(string name = "")
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(TEntity).Name + "s";

            // if collection not exist, it will be created by mongo
            return _database.GetCollection<TEntity>(name);
        }



        /// <summary>
        /// 
        /// </summary>
        public void CreateCollection<TEntity>(string name = "")
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(TEntity).Name + "s";

            _database.CreateCollection(name);
        }



        /// <summary>
        /// 
        /// </summary>
        public IList<string> Collections()
        {
            var collections = _database.ListCollections().ToList();
            return collections.Select(c => c["name"].ToString()).ToList();
        }



        /// <summary>
        /// 
        /// </summary>
        public void DropDatabase()
        {
            _client.DropDatabase(_mongoDbOptions.DatabaseName);
        }



        /// <summary>
        /// 
        /// </summary>
        public void DropCollection<TEntity>(string name = "")
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(TEntity).Name + "s";

            _database.DropCollection(name);
        }



        #endregion

    }
}
