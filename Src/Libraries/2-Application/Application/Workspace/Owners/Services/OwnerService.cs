using AutoMapper;
using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Workspace.Owners.Commands.Models;
using TaskoMask.Application.Workspace.Owners.Queries.Models;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Application.Workspace.Organizations.Queries.Models;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Data;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Authorization.Users.Services;

namespace TaskoMask.Application.Workspace.Owners.Services
{
    public class OwnerService : ApplicationService, IOwnerService
    {
        #region Fields

        private readonly IUserService _userService;

        #endregion

        #region Ctors

        public OwnerService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications, IOwnerAggregateRepository ownerRepository , IUserService userService)
             : base(inMemoryBus, mapper, notifications)
        {
            _userService = userService;
        }


        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(OwnerRegisterDto input)
        {
            //create authentication user info
            var CreateUserCommandResult = await _userService.CreateAsync(input.Email, input.Password);
            if (!CreateUserCommandResult.IsSuccess)
                return CreateUserCommandResult;

            var cmd = new CreateOwnerCommand(id: CreateUserCommandResult.Value.EntityId, displayName: input.DisplayName, email: input.Email, password: input.Password);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(OwnerUpdateDto input)
        {
            //update authentication user UserName
            var updateUserCommandResult = await _userService.UpdateUserNameAsync(input.Id, input.Email);
            if (!updateUserCommandResult.IsSuccess)
                return updateUserCommandResult;

            var cmd = new UpdateOwnerCommand(id: input.Id, displayName: input.DisplayName, email: input.Email);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OwnerBasicInfoDto>> GetByIdAsync(string id)
        {
            return await SendQueryAsync(new GetOwnerByIdQuery(id));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<PaginatedListReturnType<OwnerOutputDto>>> SearchAsync(int page, int recordsPerPage, string term)
        {
            return await SendQueryAsync(new SearchOwnersQuery(page, recordsPerPage, term));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OwnerDetailsViewModel>> GetDetailsAsync(string id)
        {
            var ownerQueryResult = await SendQueryAsync(new GetOwnerByIdQuery(id));
            if (!ownerQueryResult.IsSuccess)
                return Result.Failure<OwnerDetailsViewModel>(ownerQueryResult.Errors);


            var organizationQueryResult = await SendQueryAsync(new GetOrganizationsByOwnerIdQuery(ownerQueryResult.Value.Id));
            if (!organizationQueryResult.IsSuccess)
                return Result.Failure<OwnerDetailsViewModel>(organizationQueryResult.Errors);


            var projectDetail = new OwnerDetailsViewModel
            {
                Owner = ownerQueryResult.Value,
                Organizations = organizationQueryResult.Value,
            };

            return Result.Success(projectDetail);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<long>> CountAsync()
        {
            return await SendQueryAsync(new GetOwnersCountQuery());
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var cmd = new DeleteOwnerCommand(id);
            var result= await SendCommandAsync(cmd);

            //delete associated user
            if (result.IsSuccess)
                await _userService.DeleteAsync(id);

            return result;
        }



        #endregion
    }
}
