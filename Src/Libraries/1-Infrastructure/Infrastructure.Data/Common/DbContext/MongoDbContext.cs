using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace TaskoMask.Infrastructure.Data.Common.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public abstract class MongoDbContext : IMongoDbContext
    {
        #region Fields

        protected readonly string _dbName;
        protected readonly string _connectionString;
        protected readonly IMongoDatabase _database;
        protected readonly IMongoClient _client;

        #endregion

        #region Ctors


        public MongoDbContext(string dbName , string connectionString)
        {
            _dbName = dbName;
            _connectionString = connectionString;
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(_connectionString));
            _client = new MongoClient(settings);
            _database = _client.GetDatabase(_dbName);
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
           var collections= _database.ListCollections().ToList();
           return  collections.Select(c => c["name"].ToString()).ToList();
        }



        /// <summary>
        /// 
        /// </summary>
        public void DropDatabase()
        {
            _client.DropDatabase(_dbName);
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
