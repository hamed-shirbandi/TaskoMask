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
         IRequestHandler<GetRolesListQuery, IEnumerable<RoleBasicInfoDto>>
    {
        #region Fields

        private readonly IRoleRepository _roleRepository;

        #endregion

        #region Ctors

        public RoleQueryHandlers(IRoleRepository roleRepository, IDomainNotificationHandler notifications, IMapper mapper ) : base(mapper, notifications)
        {
            _roleRepository = roleRepository;
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
        public async Task<IEnumerable<RoleBasicInfoDto>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetListAsync();
            return _mapper.Map<IEnumerable<RoleBasicInfoDto>>(roles);
        }



        #endregion


        #region Private Methods




        #endregion
    }
}
