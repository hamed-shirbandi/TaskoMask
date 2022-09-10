using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.Services.Monolith.Application.Workspace.Owners.Commands.Models;
using TaskoMask.Services.Monolith.Application.Workspace.Owners.Queries.Models;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.Services.Monolith.Application.Workspace.Organizations.Queries.Models;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Data;
using TaskoMask.Services.Monolith.Application.Workspace.Organizations.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Projects.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Cards.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Projects;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Cards;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using Microsoft.Extensions.Configuration;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.Services.Monolith.Application.Workspace.Owners.Services
{
    public class OwnerService : ApplicationService, IOwnerService
    {
        #region Fields

        private readonly IOrganizationService _organizationService;
        private readonly IProjectService _projectService;
        private readonly IBoardService _boardService;
        private readonly ICardService _cardService;
        private readonly IConfiguration _configuration;

        #endregion

        #region Ctors

        public OwnerService(IInMemoryBus inMemoryBus, IMapper mapper, INotificationHandler notifications, IOwnerAggregateRepository ownerRepository, IOrganizationService organizationService, IProjectService projectService, IBoardService boardService, ICardService cardService, IConfiguration configuration)
             : base(inMemoryBus, mapper, notifications)
        {
            _organizationService = organizationService;
            _projectService = projectService;
            _boardService = boardService;
            _cardService = cardService;
            _configuration = configuration;
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> RegisterAndSeedDefaultWorkspaceAsync(RegisterOwnerDto input)
        {
            var createUserCommandResult = await RegisterAsync(input);
            if (!createUserCommandResult.IsSuccess)
                return createUserCommandResult;

            await SeedDefaultWorkspaceAsync(createUserCommandResult.Value.EntityId);

            return createUserCommandResult;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> RegisterAsync(RegisterOwnerDto input)
        {
            //TODO publish OwnerRegisteredEvent (to be handled by Identity service)

            var cmd = new RegisterOwnerCommand( displayName: input.DisplayName, email: input.Email, password: input.Password);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateProfileAsync(UpdateOwnerProfileDto input)
        {
            //TODO publish OwnerUpdatedEvent (to be handled by Identity service)

            var cmd = new UpdateOwnerProfileCommand(id: input.Id, displayName: input.DisplayName, email: input.Email);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        private async Task SeedDefaultWorkspaceAsync(string ownerId)
        {
            #region create default organization


            var organizationDto = new AddOrganizationDto
            {
                OwnerId = ownerId,
                Name = _configuration["Default:Workspace:OrganizationName"],
            };

            var CreateOrganizationCommandResult = await _organizationService.AddAsync(organizationDto);
            if (!CreateOrganizationCommandResult.IsSuccess)
                return;

            #endregion

            #region create default project


            var projectDto = new AddProjectDto
            {
                OrganizationId = CreateOrganizationCommandResult.Value.EntityId,
                Name = _configuration["Default:Workspace:ProjectName"],
                Description= _configuration["Default:Workspace:ProjectDescription"],
            };

            var CreateProjectCommandResult = await _projectService.AddAsync(projectDto);
            if (!CreateProjectCommandResult.IsSuccess)
                return;

            #endregion

            #region create default board


            var boardDto = new AddBoardDto
            {
                ProjectId = CreateProjectCommandResult.Value.EntityId,
                Name = _configuration["Default:Workspace:BoardName"],
                Description = _configuration["Default:Workspace:BoardDescription"],
            };

            var CreateBoardCommandResult = await _boardService.AddAsync(boardDto);
            if (!CreateBoardCommandResult.IsSuccess)
                return;


            #endregion

            #region create default cards


            var cardDto = new AddCardDto
            {
                BoardId = CreateBoardCommandResult.Value.EntityId,
            };


            cardDto.Name = _configuration["Default:Workspace:ToDoCardName"];
            cardDto.Type = BoardCardType.ToDo;
            await _cardService.AddAsync(cardDto);


            cardDto.Name = _configuration["Default:Workspace:DoingCardName"];
            cardDto.Type = BoardCardType.Doing;
            await _cardService.AddAsync(cardDto);


            cardDto.Name = _configuration["Default:Workspace:DoneCardName"];
            cardDto.Type = BoardCardType.Done;
            await _cardService.AddAsync(cardDto);



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
        public async Task<Result<OwnerBasicInfoDto>> GetByEmailAsync(string email)
        {
            return await SendQueryAsync(new GetOwnerByEmailQuery(email));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<PaginatedList<OwnerOutputDto>>> SearchAsync(int page, int recordsPerPage, string term)
        {
            return await SendQueryAsync(new SearchOwnersQuery(page, recordsPerPage, term));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OwnerDetailsViewModel>> GetDetailsAsync(string id)
        {
            var ownerQueryResult = await GetByIdAsync(id);
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



        #endregion
    }
}
