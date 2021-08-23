using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskoMask.Application.Core.Queries
{
    /// <summary>
    /// to mark queries that we want to cache
    /// </summary>
    public interface ICacheableQuery
    {
        /// <summary>
        ///for prevent caching set it true beafor send query to bus as below:
        /// var query=new GetSomeQuery()
        /// query.BypassCache = true;
        /// _inMemoryBus.Send(query)
        /// </summary>
        bool BypassCache { get; set; }
    }
}
