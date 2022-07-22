using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Core.Queries;


namespace TaskoMask.Application.Workspace.Owners.Queries.Models
{
    public class GetOwnerByUserNameQuery : BaseQuery<OwnerBasicInfoDto>
    {
        public GetOwnerByUserNameQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; }
    }
}
