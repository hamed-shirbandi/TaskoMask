
namespace TaskoMask.Application.Share.Helpers
{
    public class PaginatedListReturnType<T>
    {
        public PaginatedListReturnType()
        {

        }

        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
