using TaskoMask.Application.Share.Dtos.Team.Members;
using TaskoMask.Application.Share.Dtos.Common.Users;
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
