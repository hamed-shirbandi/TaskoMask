﻿using MongoDB.Driver;
using System.Collections.Generic;

namespace TaskoMask.Infrastructure.Data.Core.DbContext
{
    public interface IMongoDbContext
    {
        /// <summary>
        /// get collection by entity type or by its name when the name of collection not "{entity name}"+s
        /// </summary>
        IMongoCollection<TEntity> GetCollection<TEntity>(string name = "");



        /// <summary>
        /// create new collection
        /// </summary>
        void CreateCollection<TEntity>(string name = "");



        /// <summary>
        /// get list of all collections
        /// </summary>
        IList<string> Collections();



        /// <summary>
        /// remove the database
        /// </summary>
        void DropDatabase();



        /// <summary>
        /// remove a collection
        /// </summary>
        void DropCollection<TEntity>(string name = "");
    }
}
