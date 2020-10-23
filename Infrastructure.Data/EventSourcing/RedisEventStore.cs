using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Core.Events;

namespace TaskoMask.Infrastructure.Data.EventSourcing
{
    public class RedisEventStore : IEventStore
    {
        private readonly IConnectionMultiplexer _redisConnection;
        private readonly IDatabase _redisDb;
        private readonly ConfigurationOptions _options;


        /// <summary>
        /// 
        /// </summary>
        public RedisEventStore(IConfiguration configuration)
        {
            _options = new ConfigurationOptions
            {
                EndPoints = { configuration["Redis:Connection"] },
                Password = configuration["Redis:Password"],
                Ssl = false
            };
            _redisConnection = ConnectionMultiplexer.Connect(_options);
            _redisDb = _redisConnection.GetDatabase();
        }



        /// <summary>
        /// 
        /// </summary>
        public void Save<T>(T eventData) where T : StoredEvent
        {
            string jsonData = JsonConvert.SerializeObject(eventData);
            var database = _redisConnection.GetDatabase();
            database.StringSet(MakeKey(eventData.Type), jsonData);
        }



        /// <summary>
        /// 
        /// </summary>
        private string MakeKey(string eventType)
        {
            ////Key is already prefixed with eventType as namespace
            return eventType + Guid.NewGuid().ToString();
        }
    }
}
