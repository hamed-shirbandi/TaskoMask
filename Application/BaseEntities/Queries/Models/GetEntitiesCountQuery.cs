using MediatR;
using TaskoMask.Application.Core.Queries;using TaskoMask.Domain.Core.Queries;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.BaseEntities.Queries.Models
{
    public class GetEntitiesCountQuery<TEntity> : BaseQuery<long> where TEntity : BaseEntity
    {
        public GetEntitiesCountQuery()
        {
        }
    }
}