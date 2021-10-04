using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Administration.Operators.Queries.Models;
using TaskoMask.Application.Core.Dtos.Operators;
using TaskoMask.Domain.Administration.Data;

namespace TaskoMask.Application.Administration.Operators.Queries.Handlers
{
    public class OperatorQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetOperatorByIdQuery, OperatorBasicInfoDto>
    {
        #region Fields

        private readonly IOperatorRepository _operatorRepository;

        #endregion

        #region Ctors

        public OperatorQueryHandlers(IOperatorRepository operatorRepository, IDomainNotificationHandler notifications, IMapper mapper ) : base(mapper, notifications)
        {
            _operatorRepository = operatorRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<OperatorBasicInfoDto> Handle(GetOperatorByIdQuery request, CancellationToken cancellationToken)
        {
            var @operator = await _operatorRepository.GetByIdAsync(request.Id);
            if (@operator == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Operator);

            return _mapper.Map<OperatorBasicInfoDto>(@operator);
        }

        #endregion


        #region Private Methods




        #endregion
    }
}
