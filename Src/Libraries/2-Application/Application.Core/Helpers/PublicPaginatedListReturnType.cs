using System.Collections.Generic;

namespace TaskoMask.Application.Core.Helpers
{
    public class PublicPaginatedListReturnType<T>
    {
        public PublicPaginatedListReturnType()
        {

        }

        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
