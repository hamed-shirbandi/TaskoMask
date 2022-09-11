using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using TaskoMask.BuildingBlocks.Application.Queries;


namespace TaskoMask.Services.Monolith.Application.Workspace.Owners.Queries.Models
{
    public class GetOwnerByEmailQuery : BaseQuery<OwnerBasicInfoDto>
    {
        public GetOwnerByEmailQuery(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }
}
