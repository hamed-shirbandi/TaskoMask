using AutoMapper;
using System.Threading.Tasks;
using TaskoMask.Application.Common.Base.Commands.Models;
using TaskoMask.Application.Common.Base.Queries.Models;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.Common.Base.Services
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
            var query = new GetCountQuery<TEntity>();
            return await SendQueryAsync(query);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var cmd = new DeleteCommand<TEntity>(id);
            return await SendCommandAsync(cmd);
        }


        #endregion
    }
}
