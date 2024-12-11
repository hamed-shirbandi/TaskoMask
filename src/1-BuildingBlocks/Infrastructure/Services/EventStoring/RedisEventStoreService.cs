using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Domain.Events;

namespace TaskoMask.BuildingBlocks.Infrastructure.Services.EventStoring;

/// <summary>
///
/// </summary>
public class RedisEventStoreService : IEventStoreService
{
    #region Fields

    private readonly IConnectionMultiplexer _redisConnection;
    private readonly IConfiguration _configuration;
    private readonly IDatabase _redisDb;
    private readonly ICurrentUser _currentUser;

    private readonly ConfigurationOptions _options;

    #endregion

    #region Ctors


    public RedisEventStoreService(IConfiguration configuration, ICurrentUser currentUser)
    {
        _configuration = configuration;
        _options = GetRedisConfigurationOptions();
        _redisConnection = ConnectionMultiplexer.Connect(_options);
        _redisDb = _redisConnection.GetDatabase();
        _currentUser = currentUser;
    }

    #endregion

    #region Public Methods



    /// <summary>
    ///
    /// </summary>
    public void Save<TDomainEvent>(TDomainEvent @event)
        where TDomainEvent : DomainEvent
    {
        var storedEvent = GetEventDataToStore(@event);
        string jsonData = ConvertDataToJson(storedEvent);
        _redisDb.ListLeftPush(MakeKey(@event.EntityId, @event.EntityType), jsonData);
    }

    /// <summary>
    ///
    /// </summary>
    public async Task SaveAsync<TDomainEvent>(TDomainEvent @event)
        where TDomainEvent : DomainEvent
    {
        var storedEvent = GetEventDataToStore(@event);
        string jsonData = ConvertDataToJson(storedEvent);
        await _redisDb.ListLeftPushAsync(MakeKey(@event.EntityId, @event.EntityType), jsonData);
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<List<TStoredEvent>> GetListAsync<TStoredEvent>(string entityId, string entityType)
        where TStoredEvent : StoredEvent
    {
        var data = new List<TStoredEvent>();
        var jsonList = await _redisDb.ListRangeAsync(MakeKey(entityId, entityType));
        foreach (var item in jsonList)
            data.Add(JsonConvert.DeserializeObject<TStoredEvent>(item));

        return data;
    }

    #endregion

    #region Private Methods



    /// <summary>
    ///
    /// </summary>
    private string MakeKey(string entityId, string entityType)
    {
        var keyNamespace = _configuration["Redis:KeyNamespace"];

        ////Key is already prefixed with namespace
        if (!entityId.StartsWith(keyNamespace))
            entityId = keyNamespace + ":" + entityType + ":" + entityId;

        return entityId;
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
            Ssl = false,
        };
    }

    /// <summary>
    ///
    /// </summary>
    private StoredEvent GetEventDataToStore<TDomainEvent>(TDomainEvent @event)
        where TDomainEvent : DomainEvent
    {
        var userId = _currentUser.GetUserId();
        return new StoredEvent(entityId: @event.EntityId, entityType: @event.EntityType, eventType: @event.EventType, data: @event, userId: userId);
    }

    #endregion
}
