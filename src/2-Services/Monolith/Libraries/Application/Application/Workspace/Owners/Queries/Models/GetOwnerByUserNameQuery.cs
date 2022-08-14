using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.BuildingBlocks.Application.Queries;


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
