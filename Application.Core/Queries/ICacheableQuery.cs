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
        /// set it true to bypass the cache
        /// </summary>
        bool BypassCache { get; }
    }
}
