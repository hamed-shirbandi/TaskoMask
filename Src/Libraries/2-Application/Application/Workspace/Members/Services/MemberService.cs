using AutoMapper;
using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Workspace.Members.Commands.Models;
using TaskoMask.Application.Workspace.Members.Queries.Models;
using TaskoMask.Application.Share.Dtos.Workspace.Members;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Application.Workspace.Organizations.Queries.Models;
using TaskoMask.Domain.Workspace.Members.Entities;
using TaskoMask.Domain.Workspace.Members.Data;
using TaskoMask.Application.Common.Services;
using TaskoMask.Application.Authorization.Users.Services;

namespace TaskoMask.Application.Workspace.Members.Services
{
    public class MemberService : BaseService<Member>, IMemberService
    {
        #region Fields

        private readonly IUserService _userService;

        #endregion

        #region Ctors

        public MemberService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications, IMemberRepository memberRepository , IUserService userService)
             : base(inMemoryBus, mapper, notifications)
        {
            _userService = userService;
        }


        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(MemberRegisterDto input)
        {
            //create authentication user info
            var CreateUserCommandResult = await _userService.CreateAsync(input.Email, input.Password);
            if (!CreateUserCommandResult.IsSuccess)
                return CreateUserCommandResult;

            var cmd = new CreateMemberCommand(id: CreateUserCommandResult.Value.EntityId, displayName: input.DisplayName, email: input.Email, password: input.Password);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(MemberUpdateDto input)
        {
            //update authentication user UserName
            var updateUserCommandResult = await _userService.UpdateUserNameAsync(input.Id, input.Email);
            if (!updateUserCommandResult.IsSuccess)
                return updateUserCommandResult;

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
        public async Task<Result<PaginatedListReturnType<MemberOutputDto>>> SearchAsync(int page, int recordsPerPage, string term)
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
