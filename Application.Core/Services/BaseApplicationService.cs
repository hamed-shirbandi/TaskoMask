using TaskoMask.Application.Core.Commands;
using MediatR;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Helpers;
using AutoMapper;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Core.Commands;
using TaskoMask.Domain.Core.Queries;

namespace TaskoMask.Application.Core.Services
{
    public class BaseApplicationService : IBaseApplicationService
    {
        #region Fields


        private readonly IMediator _mediator;
        protected readonly IMapper _mapper;
        protected readonly IDomainNotificationHandler _notifications;


        #endregion


        #region Ctor


        public BaseApplicationService(IMediator mediator, IMapper mapper, IDomainNotificationHandler notifications)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notifications = notifications;

        }


        #endregion


        #region Protected Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> SendCommandAsync<T>(T cmd) where T : BaseCommand
        {
            var result = await _mediator.Send(cmd);

            //get and reset notifications for each command
            var errors = _notifications.GetErrors();

            //when throw application or domain Exception
            if (result == null)
                return Result.Failure<CommandResult>(errors);

            if (errors.Count>0)
                return Result.Failure<CommandResult>(errors, result.Message);

            return Result.Success(result, result.Message);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<T>> SendQueryAsync<T>(BaseQuery<T> query)
        {
            var result = await _mediator.Send(query);
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