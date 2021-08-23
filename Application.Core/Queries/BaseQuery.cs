using MediatR;

namespace TaskoMask.Application.Core.Queries
{

    /// <summary>
    /// Mark BaseQuery with ICacheableQuery to catche all queries.
    /// if need to prevent caching a query just set the BypassCache to true beafore send query to bus
    /// </summary>
    public abstract class BaseQuery<T> : ICacheableQuery, IRequest<T>
    {
        protected BaseQuery()
        {
            BypassCache = false;
        }

        public bool BypassCache { get; set; }
    }
}