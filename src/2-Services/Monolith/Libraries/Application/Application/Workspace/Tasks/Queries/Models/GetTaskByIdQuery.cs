using MediatR;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Application.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Queries.Models
{
   
    public class GetTaskByIdQuery : BaseQuery<GetTaskDto>
    {
        public GetTaskByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
