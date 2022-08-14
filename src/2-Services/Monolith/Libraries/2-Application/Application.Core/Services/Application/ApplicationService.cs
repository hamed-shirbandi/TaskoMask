using TaskoMask.Services.Monolith.Application.Core.Commands;
using System;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using AutoMapper;
using TaskoMask.Services.Monolith.Application.Core.Notifications;
using TaskoMask.Services.Monolith.Application.Core.Queries;
using TaskoMask.Services.Monolith.Application.Core.Bus;

namespace TaskoMask.Services.Monolith.Application.Core.Services.Application
{
    public abstract class ApplicationService : IApplicationService
    {
        #region Fields


        private readonly IInMemoryBus _inMemoryBus;
        protected readonly IMapper _mapper;
        protected readonly IDomainNotificationHandler _notifications;


        #endregion

        #region Ctors


        public ApplicationService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications)
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
        protected async Task<Result<CommandResult>> SendCommandAsync<TCommand>(TCommand cmd) where TCommand : BaseCommand
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
        protected async Task<Result<TQuery>> SendQueryAsync<TQuery>(BaseQuery<TQuery> query)
        {
            var result = await _inMemoryBus.Send(query);
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