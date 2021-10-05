using MediatR;
using Microsoft.Extensions.Configuration;
using RedisCache.Core;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Core.Behaviors
{

    /// <summary>
    /// Caching response of queries mareked with ICacheableQuery
    /// </summary>
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest :BaseQuery<TResponse>
    {
        #region Fields

        private readonly IRedisCacheService _redisCacheService;
        private readonly IConfiguration _configuration;

        #endregion

        #region Ctors


        public CachingBehavior(IRedisCacheService redisCacheService, IConfiguration configuration)
        {
            _redisCacheService = redisCacheService;
            _configuration = configuration;
        }


        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is not ICacheableQuery cacheableQuery)
                return await next();

            var configurationCacheEnabled = bool.Parse(_configuration["RedisCache:Enabled"]);
            if (!configurationCacheEnabled)
                return await next();

            if (!cacheableQuery.EnableCache)
                return await next();


            var cacheKey = GenerateKeyFromRequest(request);
            if (!_redisCacheService.TryGetValue(key: cacheKey, result: out TResponse response))
            {
                response = await next();
                var cacheTimeInMinutes = int.Parse(_configuration["RedisCache:CacheTimeInMinutes"]);
                await _redisCacheService.SetAsync(key: cacheKey, data: response, cacheTimeInMinutes: cacheTimeInMinutes);
            }

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
}
