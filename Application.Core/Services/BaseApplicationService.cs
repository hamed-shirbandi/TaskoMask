using TaskoMask.Application.Core.Commands;
using MediatR;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Resources;
using CSharpFunctionalExtensions;
using AutoMapper;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Application.Core.Services
{
    public class BaseApplicationService : IBaseApplicationService
    {
        #region Fields


        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;


        #endregion


        #region Ctor


        public BaseApplicationService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        #endregion


        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> RunCommandAsync<T>(T cmd) where T : BaseCommand
        {
            return await _mediator.Send(cmd);
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<U>> RunQueryAsync<T, U>(T query) where T : IBaseRequest
        {
            return (U)await _mediator.Send(query);

        }


     
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