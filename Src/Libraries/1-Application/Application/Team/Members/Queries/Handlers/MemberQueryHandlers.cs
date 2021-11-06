using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Team.Members.Queries.Models;
using TaskoMask.Application.Core.Dtos.Team.Members;
using TaskoMask.Domain.Team.Data;

namespace TaskoMask.Application.Team.Members.Queries.Handlers
{
    public class MemberQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetMemberByIdQuery, MemberBasicInfoDto>
    {
        #region Fields

        private readonly IMemberRepository _memberRepository;

        #endregion

        #region Ctors

        public MemberQueryHandlers(IMemberRepository memberRepository, IDomainNotificationHandler notifications, IMapper mapper ) : base(mapper, notifications)
        {
            _memberRepository = memberRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<MemberBasicInfoDto> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetByIdAsync(request.Id);
            if (member == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Member);

            return _mapper.Map<MemberBasicInfoDto>(member);
        }

        #endregion


        #region Private Methods




        #endregion
    }
}
