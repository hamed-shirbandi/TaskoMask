using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskoMask.BuildingBlocks.Application.Queries
{
    /// <summary>
    /// to mark queries that we want to cache
    /// </summary>
    public interface ICacheableQuery
    {
        /// <summary>
        /// To enable caching for a query, call EnableCaching() beafor sending the query:
        /// var query=new GetSomeQuery()
        /// query.EnableCaching();
        /// _inMemoryBus.SendQuery(query)
        /// </summary>
        void EnableCaching();
        bool CachingIsEnabled();
    }
}
