using TaskoMask.Application.Core.Commands;
using System;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Helpers;
using AutoMapper;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Core.Bus;

namespace TaskoMask.Application.Core.Services
{
    public abstract class BaseApplicationService : IBaseApplicationService
    {
        #region Fields


        private readonly IInMemoryBus _inMemoryBus;
        protected readonly IMapper _mapper;
        protected readonly IDomainNotificationHandler _notifications;


        #endregion

        #region Ctors


        public BaseApplicationService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications)
        {
            _inMemoryBus = inMemoryBus;
            _mapper = mapper;
            _notifications = notifications;

        }


        #endregion

        #region Protected Methods



        /// <summary>
        /// 
        /// </summary>
        protected async Task<Result<CommandResult>> SendCommandAsync<T>(T cmd) where T : BaseCommand
        {
            var result = await _inMemoryBus.Send(cmd);

            //get notification errors
            var errors = _notifications.GetErrors();

            //result is null when throw application or domain exception 
            if (result == null)
                return Result.Failure<CommandResult>(errors);

            //if there is any notification error so result is failed
            if (errors.Count>0)
                return Result.Failure<CommandResult>(errors, result.Message);

            return Result.Success(result, result.Message);
        }




        /// <summary>
        /// 
        /// </summary>
        protected async Task<Result<T>> SendQueryAsync<T>(BaseQuery<T> query)
        {
            var result = await _inMemoryBus.Send(query);
            if (_notifications.HasAny())
                return Result.Failure<T>(_notifications.GetErrors());

            return Result.Success(result);
        }






        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        #endregion
    }
}