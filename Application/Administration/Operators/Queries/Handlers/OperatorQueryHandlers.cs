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
using System.Collections.Generic;

namespace TaskoMask.Application.Administration.Operators.Queries.Handlers
{
    public class OperatorQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetOperatorByIdQuery, OperatorBasicInfoDto>,
        IRequestHandler<GetOperatorsByRoleIdQuery, IEnumerable<OperatorBasicInfoDto>>,
        IRequestHandler<GetOperatorsListQuery, IEnumerable<OperatorBasicInfoDto>>
        

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



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<OperatorBasicInfoDto>> Handle(GetOperatorsByRoleIdQuery request, CancellationToken cancellationToken)
        {
            var @operators = await _operatorRepository.GetListByRoleIdAsync(request.RoleId);
            return _mapper.Map<IEnumerable<OperatorBasicInfoDto>>(@operators);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<OperatorBasicInfoDto>> Handle(GetOperatorsListQuery request, CancellationToken cancellationToken)
        {
            var @operators = await _operatorRepository.GetListAsync();
            return _mapper.Map<IEnumerable<OperatorBasicInfoDto>>(@operators);
        }


        #endregion


        #region Private Methods




        #endregion
    }
}
