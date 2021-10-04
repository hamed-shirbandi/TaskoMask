using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Team.Managers.Queries.Models;
using TaskoMask.Application.Core.Dtos.Managers;
using TaskoMask.Domain.Team.Data;

namespace TaskoMask.Application.Team.Managers.Queries.Handlers
{
    public class ManagerQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetManagerByIdQuery, ManagerBasicInfoDto>
    {
        #region Fields

        private readonly IManagerRepository _managerRepository;

        #endregion

        #region Ctors

        public ManagerQueryHandlers(IManagerRepository managerRepository, IDomainNotificationHandler notifications, IMapper mapper ) : base(mapper, notifications)
        {
            _managerRepository = managerRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<ManagerBasicInfoDto> Handle(GetManagerByIdQuery request, CancellationToken cancellationToken)
        {
            var manager = await _managerRepository.GetByIdAsync(request.Id);
            if (manager == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Manager);

            return _mapper.Map<ManagerBasicInfoDto>(manager);
        }

        #endregion


        #region Private Methods




        #endregion
    }
}
