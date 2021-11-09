using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Common.Users;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Common.Users.Services;
using TaskoMask.Application.Team.Members.Commands.Models;
using TaskoMask.Application.Team.Members.Queries.Models;
using TaskoMask.Application.Core.Dtos.Team.Members;
using TaskoMask.Domain.Team.Entities;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Team.Data;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Application.Team.Organizations.Queries.Models;

namespace TaskoMask.Application.Team.Members.Services
{
    public class MemberService : UserService<Member>, IMemberService
    {
        #region Fields


        #endregion

        #region Ctors

        public MemberService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications, IMemberRepository memberRepository, IEncryptionService encryptionService) : base(inMemoryBus, mapper, notifications, memberRepository, encryptionService)
        { }


        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(MemberRegisterDto input)
        {
            var cmd = new CreateMemberCommand(displayName: input.DisplayName, email: input.Email, password: input.Password);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(UserUpsertDto input)
        {
            var cmd = new UpdateMemberCommand(id: input.Id, displayName: input.DisplayName, email: input.Email);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<MemberBasicInfoDto>> GetByIdAsync(string id)
        {
            return await SendQueryAsync(new GetMemberByIdQuery(id));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<PublicPaginatedListReturnType<MemberOutputDto>>> SearchAsync(int page, int recordsPerPage, string term)
        {
            return await SendQueryAsync(new SearchMembersQuery(page, recordsPerPage, term));

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<MemberDetailsViewModel>> GetDetailsAsync(string id)
        {
            var memberQueryResult = await SendQueryAsync(new GetMemberByIdQuery(id));
            if (!memberQueryResult.IsSuccess)
                return Result.Failure<MemberDetailsViewModel>(memberQueryResult.Errors);


            var organizationQueryResult = await SendQueryAsync(new GetOrganizationsByOwnerMemberIdQuery(memberQueryResult.Value.Id));
            if (!organizationQueryResult.IsSuccess)
                return Result.Failure<MemberDetailsViewModel>(organizationQueryResult.Errors);


            var projectDetail = new MemberDetailsViewModel
            {
                Member = memberQueryResult.Value,
                Organizations = organizationQueryResult.Value,
            };

            return Result.Success(projectDetail);
        }


        #endregion
    }
}
