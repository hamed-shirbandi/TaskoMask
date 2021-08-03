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
        public async Task<Result<CommandResult>> SendCommandAsync<T>(T cmd) where T : BaseCommand
        {
            var result = await _mediator.Send(cmd);
            var errors = _notifications.GetListAndReset().Select(n => n.Value).ToList();

            //when throw application or domain Exception
            if (result == null)
                return Result.Failure<CommandResult>(errors);

            if (_notifications.HasAny())
                return Result.Failure<CommandResult>(errors,result.Message);
           
            return Result.Success(result,result.Message);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<T>> SendQueryAsync<T>(IRequest<T> query)
        {
            if (query.GetType() == typeof(BaseCommand))
                return Result.Failure<T>();

            var result =await _mediator.Send(query);
            if (_notifications.HasAny())
                return Result.Failure<T>(_notifications.GetListAndReset().Select(n => n.Value).ToList());
          
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