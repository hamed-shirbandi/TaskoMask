using TaskoMask.Application.Core.Commands;
using MediatR;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Helpers;
using AutoMapper;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Application.Core.Services
{
    public abstract class BaseApplicationService
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
            if (_notifications.HasNotifications())
                return Result.Failure<CommandResult>(result.Message, _notifications.GetNotifications().Select(n => n.Value).ToList());
            return Result.Success(result.Message, result);
        }


        /// <summary>
        /// 
        /// </summary>
        protected async Task<U> SendQueryAsync<T, U>(T query) where T : IBaseRequest
        {
            return (U)await _mediator.Send(query);

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