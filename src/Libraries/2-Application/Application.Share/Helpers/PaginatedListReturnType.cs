
namespace TaskoMask.Application.Share.Helpers
{
    public class PaginatedListReturnType<TItem>
    {
        public PaginatedListReturnType()
        {

        }

        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<TItem> Items { get; set; }
    }
}
