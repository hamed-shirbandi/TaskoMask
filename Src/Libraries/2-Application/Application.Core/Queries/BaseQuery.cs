using MediatR;

namespace TaskoMask.Application.Core.Queries
{

    /// <summary>
    /// Mark BaseQuery with ICacheableQuery to catche the queries by CachingBehavior.
    /// If you need to cache a query just set the EnableCache to true beafore sending the query to bus
    /// </summary>
    public abstract class BaseQuery<T> : ICacheableQuery, IRequest<T>
    {
        protected BaseQuery()
        {
            //By default cache is disabled
            EnableCache = false;
        }

        public bool EnableCache { get; set; }
    }
}