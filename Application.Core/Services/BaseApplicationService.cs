using TaskoMask.Application.Core.Commands;
using MediatR;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Helpers;
using AutoMapper;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Services
{
    public abstract class BaseApplicationService : IBaseApplicationService
    {
        #region Fields


        private readonly IMediator _mediator;
        protected readonly IMapper _mapper;
        protected readonly DomainNotificationHandler _notifications;


        #endregion


        #region Ctor


        public BaseApplicationService(IMediator mediator, IMapper mapper, INotificationHandler<DomainNotification> notifications)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notifications = (DomainNotificationHandler)notifications;

        }


        #endregion


        #region Protected Methods



        /// <summary>
        /// 
        /// </summary>
        protected async Task<Result<CommandResult>> SendCommandAsync<T>(T cmd) where T : BaseCommand
        {
            var result = await _mediator.Send(cmd);
            var errors = _notifications.GetListAndReset().Select(n => n.Value).ToList();

            //when throw application or domain Exception
            if (result == null)
                return Result.Failure<CommandResult>(ApplicationMessages.Operation_Failed, errors);


            if (_notifications.HasAny())
                return Result.Failure<CommandResult>(result.Message, errors);
           
            return Result.Success(result.Message, result);
        }




        /// <summary>
        /// 
        /// </summary>
        protected async Task<Result<U>> SendQueryAsync<T, U>(T query) where T : IBaseRequest
        {
            var result = (U)await _mediator.Send(query);
            if (_notifications.HasAny())
                return Result.Failure<U>(ApplicationMessages.Operation_Failed, _notifications.GetListAndReset().Select(n => n.Value).ToList());
            return Result.Success(ApplicationMessages.Operation_Success, result);

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