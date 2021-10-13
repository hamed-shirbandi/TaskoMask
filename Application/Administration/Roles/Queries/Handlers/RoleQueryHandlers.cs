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
using TaskoMask.Application.Administration.Roles.Queries.Models;
using TaskoMask.Application.Core.Dtos.Roles;
using TaskoMask.Domain.Administration.Data;
using System.Collections.Generic;

namespace TaskoMask.Application.Administration.Roles.Queries.Handlers
{
    public class RoleQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetRoleByIdQuery, RoleBasicInfoDto>,
         IRequestHandler<GetRolesListQuery, IEnumerable<RoleOutputDto>>
    {
        #region Fields

        private readonly IRoleRepository _roleRepository;
        private readonly IOperatorRepository _operatorRepository;

        #endregion

        #region Ctors

        public RoleQueryHandlers(IRoleRepository roleRepository, IDomainNotificationHandler notifications, IMapper mapper, IOperatorRepository operatorRepository) : base(mapper, notifications)
        {
            _roleRepository = roleRepository;
            _operatorRepository = operatorRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<RoleBasicInfoDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByIdAsync(request.Id);
            if (role == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Role);

            return _mapper.Map<RoleBasicInfoDto>(role);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<RoleOutputDto>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetListAsync();
            var rolesDto = _mapper.Map<IEnumerable<RoleOutputDto>>(roles);

            foreach (var item in rolesDto)
                item.OperatorsCount = await _operatorRepository.CountByRoleIdAsync(item.Id);

            return rolesDto;
        }



        #endregion


        #region Private Methods




        #endregion
    }
}
