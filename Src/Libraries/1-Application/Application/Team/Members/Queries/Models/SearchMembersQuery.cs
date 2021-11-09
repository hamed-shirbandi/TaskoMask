using TaskoMask.Application.Core.Dtos.Team.Members;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Team.Members.Queries.Models
{
   public class SearchMembersQuery:BaseQuery<PublicPaginatedListReturnType<MemberOutputDto>>
    {
        public SearchMembersQuery(int page, int recordsPerPage, string term)
        {
            Page = page;
            RecordsPerPage = recordsPerPage;
            Term = term;
        }

        public int Page { get; set; }
        public int RecordsPerPage { get; set; }
        public string Term { get; set; }
    }
}
