using AutoMapper;
using MediatR;
using System;
using System.Threading.Tasks;
using TaskoMask.Application.BaseEntities.Queries.Models;
using TaskoMask.Application.Core.Services;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.BaseEntities.Services
{
    public abstract class BaseEntityService<TEntity> : BaseApplicationService, IBaseEntityService where TEntity : BaseEntity
    {
        #region Fields


        #endregion


        #region Ctor


        public BaseEntityService(IMediator mediator, IMapper mapper): base(mediator, mapper)
        {
        }


        #endregion


        #region Command Services



        #endregion


        #region Query Services


        /// <summary>
        /// 
        /// </summary>
        public async Task<long> CountAsync()
        {
            return await SendQueryAsync<GetEntitiesCountQuery<TEntity>, long>(new ());
        }



        #endregion
    }
}