using TaskoMask.Application.Core.Dtos.Managers;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Managers.Queries.Models
{
   
    public class GetManagerByIdQuery : BaseQuery<ManagerBasicInfoDto>
    {
        public GetManagerByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
