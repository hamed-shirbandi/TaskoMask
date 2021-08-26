using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Base.Queries.Models;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Services;
using TaskoMask.Domain.Core.Helpers;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.Base.Services
{
  public  class BaseService<TEntity>: ApplicationService,IBaseService where TEntity:BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors


        public BaseService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        {

        }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<long>> CountAsync()
        {
            return await SendQueryAsync(new GetCountQuery<TEntity>());
        }


        #endregion
    }
}
