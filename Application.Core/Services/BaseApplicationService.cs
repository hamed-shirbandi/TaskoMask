using TaskoMask.Application.Core.Commands;
using MediatR;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Helpers;
using AutoMapper;

namespace TaskoMask.Application.Core.Services
{
    public abstract class BaseApplicationService
    {
        #region Fields


        private readonly IMediator _mediator;
        protected readonly IMapper _mapper;


        #endregion


        #region Ctor


        public BaseApplicationService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        #endregion


        #region Protected Methods



        /// <summary>
        /// 
        /// </summary>
        protected async Task<CommandResult> SendCommandAsync<T>(T cmd) where T : BaseCommand
        {
            return await _mediator.Send(cmd);
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