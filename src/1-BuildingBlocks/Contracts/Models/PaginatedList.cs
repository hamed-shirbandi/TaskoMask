
using System.Collections.Generic;

namespace TaskoMask.BuildingBlocks.Contracts.Models
{
    public class PaginatedList<TItem>
    {
        public PaginatedList()
        {

        }

        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<TItem> Items { get; set; }
    }
}
