using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Base.Queries.Models;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Application.Core.Notifications;

namespace TaskoMask.Application.Base.Queries.Handlers
{
    public class BaseEntityQueryHandlers<TEntity> : BaseQueryHandler,
        IRequestHandler<GetCountQuery<TEntity>, long>
        where TEntity : BaseEntity
    {
        #region Fields


        private readonly IBaseRepository<TEntity> _baseRepository;


        #endregion

        #region Ctors


        public BaseEntityQueryHandlers(IBaseRepository<TEntity> baseRepository, IDomainNotificationHandler notifications, IMapper mapper) : base(mapper, notifications)
        {
            _baseRepository = baseRepository;
        }


        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async Task<long> Handle(GetCountQuery<TEntity> request, CancellationToken cancellationToken)
        {
            return await _baseRepository.CountAsync();
        }


        #endregion
    }
}