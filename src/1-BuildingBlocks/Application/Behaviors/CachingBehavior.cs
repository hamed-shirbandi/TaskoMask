using EasyCaching.Core;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Queries;

namespace TaskoMask.BuildingBlocks.Application.Behaviors;

/// <summary>
/// Caching response for queries that are mareked by ICacheableQuery
/// </summary>
public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : BaseQuery<TResponse>
{
    #region Fields

    private readonly IEasyCachingProvider _cachingProvider;
    private readonly IConfiguration _configuration;

    #endregion

    #region Ctors


    public CachingBehavior(IEasyCachingProvider cachingProvider, IConfiguration configuration)
    {
        _cachingProvider = cachingProvider;
        _configuration = configuration;
    }

    #endregion

    #region Public Methods

    /// <summary>
    ///
    /// </summary>
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        // ignore command requests
        if (request is not ICacheableQuery cacheableQuery)
            return await next();

        //ignore caching if it is not enabled globaly from configurations
        var configurationCachingEnabled = bool.Parse(_configuration["Caching:Enabled"]);
        if (!configurationCachingEnabled)
            return await next();

        //ignore caching for this request if caching is not enabled
        if (!cacheableQuery.CachingIsEnabled())
            return await next();

        var cacheKey = GenerateKeyFromRequest(request);
        var cachedResponse = await _cachingProvider.GetAsync<TResponse>(cacheKey);

        if (cachedResponse.Value != null)
            return cachedResponse.Value;

        var response = await next();

        var cacheTimeInMinutes = int.Parse(_configuration["Caching:CacheTimeInMinutes"]);
        var expirationTime = DateTime.Now.AddMinutes(cacheTimeInMinutes);
        await _cachingProvider.SetAsync(cacheKey, response, expirationTime.TimeOfDay);

        return response;
    }

    #endregion

    #region Private Methods


    /// <summary>
    ///
    /// </summary>
    private string GenerateKeyFromRequest(TRequest request)
    {
        var properties = new List<PropertyInfo>(request.GetType().GetProperties());
        var key = request.GetType().Name;

        foreach (PropertyInfo property in properties)
        {
            object propValue = property.GetValue(request, property.GetIndexParameters());

            string name = property.Name;
            string value = propValue != null ? propValue.ToString() : "";
            key += $"_{name}:{value}";
        }

        return key;
    }

    #endregion
}
