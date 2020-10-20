using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace TaskoMask.Infrastructure.Data.DbContext
{
    public class MainDbContext : IMainDbContext
    {
        #region Fields

        private readonly string _dbName;
        private readonly string _connectionString;
        private readonly IMongoDatabase _database;
        private readonly IMongoClient _client;

        #endregion

        #region Ctor


        public MainDbContext(IConfiguration configuration)
        {
            _dbName = configuration["Mongo:Database"];
            _connectionString = configuration["Mongo:Connection"];
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



        #endregion

    }
}
