using MediatR;

namespace TaskoMask.BuildingBlocks.Application.Queries
{

    /// <summary>
    /// Mark BaseQuery with ICacheableQuery to catche the queries by CachingBehavior.
    /// If you need to cache a query just set the EnableCache to true beafore sending the query to bus
    /// </summary>
    public abstract class BaseQuery<TQueryResult> : ICacheableQuery, IRequest<TQueryResult>
    {
        protected BaseQuery()
        {
            //By default cache is disabled
            EnableCache = false;
        }


        public bool EnableCache { get; set; }
    }
}