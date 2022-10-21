using TaskoMask.BuildingBlocks.Application.Commands;
using System;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using AutoMapper;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Application.Bus;

namespace TaskoMask.BuildingBlocks.Application.Services
{
    public abstract class ApplicationService : IApplicationService
    {
        #region Fields


        private readonly IInMemoryBus _inMemoryBus;
        protected readonly IMapper _mapper;
        protected readonly INotificationHandler _notifications;


        #endregion

        #region Ctors


        public ApplicationService(IInMemoryBus inMemoryBus, IMapper mapper, INotificationHandler notifications)
        {
            _inMemoryBus = inMemoryBus;
            _mapper = mapper;
            _notifications = notifications;

        }



        public ApplicationService(IMapper mapper, INotificationHandler notifications)
        {
            _mapper = mapper;
            _notifications = notifications;
        }



        #endregion


        #region Protected Methods




        /// <summary>
        /// 
        /// </summary>
        protected async Task<Result<CommandResult>> SendCommandAsync<TCommand>(TCommand cmd) where TCommand : BaseCommand
        {
            var result = await _inMemoryBus.SendCommand(cmd);

            //get notification errors
            var errors = _notifications.GetErrors();

            //result is null when throw application or domain exception 
            if (result == null)
                return Result.Failure<CommandResult>(errors);

            //if there is any notification error so result is failed
            if (errors.Count > 0)
                return Result.Failure<CommandResult>(errors, result.Message);

            return Result.Success(result, result.Message);
        }




        /// <summary>
        /// 
        /// </summary>
        protected async Task<Result<TQuery>> SendQueryAsync<TQuery>(BaseQuery<TQuery> query)
        {
            var result = await _inMemoryBus.SendQuery(query);
            if (_notifications.HasAny())
                return Result.Failure<TQuery>(_notifications.GetErrors());

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