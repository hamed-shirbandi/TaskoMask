using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Services.Monolith.Application.Core.Queries;


namespace TaskoMask.Services.Monolith.Application.Workspace.Owners.Queries.Models
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
