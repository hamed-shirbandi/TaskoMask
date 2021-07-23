using MediatR;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.BaseEntities.Queries.Models
{
    public class GetEntitiesCountQuery<TEntity> : IRequest<long> where TEntity : BaseEntity
    {
        public GetEntitiesCountQuery()
        {
        }
    }
}