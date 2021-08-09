using AutoMapper;
using System.Threading.Tasks;
using TaskoMask.Application.BaseEntities.Queries.Models;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Domain.Core.Helpers;
using TaskoMask.Application.Core.Services;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Application.Core.Notifications;

namespace TaskoMask.Application.BaseEntities.Services
{
    public abstract class BaseEntityService<TEntity> : BaseApplicationService, IBaseEntityService where TEntity : BaseEntity
    {
        #region Fields


        #endregion


        #region Ctor


        public BaseEntityService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        {
        }


        #endregion


        #region Command Services



        #endregion


        #region Query Services


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<long>> CountAsync()
        {
            return await SendQueryAsync(new GetEntitiesCountQuery<TEntity>());
        }



        #endregion
    }
}