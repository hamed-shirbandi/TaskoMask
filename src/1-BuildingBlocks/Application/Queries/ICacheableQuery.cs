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
        /// for enable caching set it to true beafor sending the query to bus like below:
        /// var query=new GetSomeQuery()
        /// query.EnableCache = false;
        /// _inMemoryBus.SendQuery(query)
        /// </summary>
        bool EnableCache { get; set; }
    }
}
