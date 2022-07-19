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
using TaskoMask.Application.Workspace.Organizations.Services;
using TaskoMask.Application.Workspace.Projects.Services;
using TaskoMask.Application.Workspace.Boards.Services;
using TaskoMask.Application.Workspace.Cards.Services;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Domain.Share.Enums;

namespace TaskoMask.Application.Workspace.Owners.Services
{
    public class OwnerService : ApplicationService, IOwnerService
    {
        #region Fields

        private readonly IUserService _userService;
        private readonly IOrganizationService _organizationService;
        private readonly IProjectService _projectService;
        private readonly IBoardService _boardService;
        private readonly ICardService _cardService;

        #endregion

        #region Ctors

        public OwnerService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications, IOwnerAggregateRepository ownerRepository, IUserService userService, IOrganizationService organizationService, IProjectService projectService, IBoardService boardService, ICardService cardService)
             : base(inMemoryBus, mapper, notifications)
        {
            _userService = userService;
            _organizationService = organizationService;
            _projectService = projectService;
            _boardService = boardService;
            _cardService = cardService;
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
        public async Task CreateDefaultWorkspaceAsync(string ownerId)
        {
            #region create default organization


            var organizationDto = new OrganizationUpsertDto
            {
                OwnerId = ownerId,
                Name = "Your Workspace",
            };

            var CreateOrganizationCommandResult = await _organizationService.CreateAsync(organizationDto);
            if (!CreateOrganizationCommandResult.IsSuccess)
                return;

            #endregion

            #region create default project


            var projectDto = new ProjectCreateDto
            {
                OrganizationId = CreateOrganizationCommandResult.Value.EntityId,
                Name = "Default Project",
            };

            var CreateProjectCommandResult = await _projectService.CreateAsync(projectDto);
            if (!CreateProjectCommandResult.IsSuccess)
                return;

            #endregion

            #region create default board


            var boardDto = new BoardCreateDto
            {
                ProjectId = CreateProjectCommandResult.Value.EntityId,
                Name = "Default Board",
            };

            var CreateBoardCommandResult = await _boardService.CreateAsync(boardDto);
            if (!CreateBoardCommandResult.IsSuccess)
                return;


            #endregion

            #region create default cards


            var cardDto = new CardUpsertDto
            {
                BoardId = CreateBoardCommandResult.Value.EntityId,
            };


            cardDto.Name = "To Do Tasks";
            cardDto.Type = BoardCardType.ToDo;
            await _cardService.CreateAsync(cardDto);


            cardDto.Name = "Doing Tasks";
            cardDto.Type = BoardCardType.Doing;
            await _cardService.CreateAsync(cardDto);


            cardDto.Name = "Done Tasks";
            cardDto.Type = BoardCardType.Done;
            await _cardService.CreateAsync(cardDto);



            #endregion
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
            var result = await SendCommandAsync(cmd);

            //delete associated user
            if (result.IsSuccess)
                await _userService.DeleteAsync(id);

            return result;
        }



        #endregion
    }
}
