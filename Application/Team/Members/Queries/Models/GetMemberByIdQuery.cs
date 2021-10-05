using TaskoMask.Application.Core.Dtos.Members;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Queries;


namespace TaskoMask.Application.Team.Members.Queries.Models
{
   
    public class GetMemberByIdQuery : BaseQuery<MemberBasicInfoDto>
    {
        public GetMemberByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
