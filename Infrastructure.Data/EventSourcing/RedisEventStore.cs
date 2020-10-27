using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Core.Events;

namespace TaskoMask.Infrastructure.Data.EventSourcing
{
    public class RedisEventStore : IEventStore
    {
        private readonly IConnectionMultiplexer _redisConnection;
        private readonly IConfiguration _configuration;
        private readonly IDatabase _redisDb;
        private readonly ConfigurationOptions _options;


        /// <summary>
        /// 
        /// </summary>
        public RedisEventStore(IConfiguration configuration)
        {
            _configuration = configuration;
            _options = GetRedisConfigurationOptions();
            _redisConnection = ConnectionMultiplexer.Connect(_options);
            _redisDb = _redisConnection.GetDatabase();
        }




        /// <summary>
        /// 
        /// </summary>
        public void Save<T>(T eventData) where T : StoredEvent
        {
            string jsonData = ConvertDataToJson(eventData);
            _redisDb.StringSet(MakeKey(eventData.Id), jsonData);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task SaveAsync<T>(T eventData) where T : StoredEvent
        {
            string jsonData = ConvertDataToJson(eventData);
            await _redisDb.ListLeftPushAsync(MakeKey(eventData.Id), jsonData);
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<List<T>> GetListAsync<T>(string key) where T : StoredEvent
        {
            var data = new List<T>();
            var jsonList = await _redisDb.ListRangeAsync(MakeKey(key));
            foreach (var item in jsonList)
            {
                var itemData = JsonConvert.DeserializeObject<T>(item);
                data.Add(itemData);
            }
             
            return data;
        }


        /// <summary>
        /// 
        /// </summary>
        private string MakeKey(string id)
        {
            var keyNamespace = _configuration["Redis:KeyNamespace"];
            if (!id.StartsWith(keyNamespace))
            {
                ////Key is already prefixed with namespace
                id = keyNamespace + ":" + id;
            }

            return id;
        }

        /// <summary>
        /// 
        /// </summary>
        private string ConvertDataToJson(object eventData)
        {
            return JsonConvert.SerializeObject(eventData);
        }


        /// <summary>
        /// 
        /// </summary>
        private ConfigurationOptions GetRedisConfigurationOptions()
        {
            return new ConfigurationOptions
            {
                EndPoints = { _configuration["Redis:Connection"] },
                Password = _configuration["Redis:Password"],
                Ssl = false
            };
        }


    }
}
