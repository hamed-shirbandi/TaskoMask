using MediatR;
using TaskoMask.Application.Core.Dtos.Tasks;

namespace TaskoMask.Application.Tasks.Queries.Models
{
   
    public class GetTaskByIdQuery : IRequest<TaskBasicInfoDto>
    {
        public GetTaskByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
