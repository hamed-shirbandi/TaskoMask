using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Core.Queries;


namespace TaskoMask.Application.Workspace.Owners.Queries.Models
{
    public class GetOwnerByIdQuery : BaseQuery<OwnerBasicInfoDto>
    {
        public GetOwnerByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
