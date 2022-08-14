using MediatR;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Tasks;
using TaskoMask.Services.Monolith.Application.Core.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Queries.Models
{
   
    public class GetTaskByIdQuery : BaseQuery<TaskBasicInfoDto>
    {
        public GetTaskByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
