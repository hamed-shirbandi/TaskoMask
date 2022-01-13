using TaskoMask.Application.Share.Dtos.Workspace.Members;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Core.Queries;


namespace TaskoMask.Application.Workspace.Members.Queries.Models
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
