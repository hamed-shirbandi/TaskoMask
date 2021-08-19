using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.BaseEntities.Queries.Models;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Application.Core.Notifications;

namespace TaskoMask.Application.BaseEntities.Queries.Handlers
{
    public class BaseEntitiesQueryHandlers<TEntity> : BaseQueryHandler,
        IRequestHandler<GetEntitiesCountQuery<TEntity>, long>
        where TEntity : BaseEntity
    {
        #region Fields


        private readonly IBaseRepository<TEntity> _baseRepository;


        #endregion

        #region Ctors


        public BaseEntitiesQueryHandlers(IBaseRepository<TEntity>baseRepository, IDomainNotificationHandler notifications, IMapper mapper): base(mapper,notifications)
        {
            _baseRepository = baseRepository;
        }


        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async Task<long> Handle(GetEntitiesCountQuery<TEntity> request, CancellationToken cancellationToken)
        {
          return  await _baseRepository.CountAsync();
        }


        #endregion
    }
}