using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Core.Services;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Data;
using TaskoMask.BuildingBlocks.Contracts.Services;

namespace TaskoMask.Services.Monolith.Infrastructure.Services.Security
{
    /// <summary>
    /// In this service we just focus on owner users (UserPanel users) and check their access permissions (for example, to prevent an owner to access another owners data)
    /// For operators (AdminPanle users) we check their access permissions in admin panel controllers through HasPermissionFilterAttribute
    /// </summary>
    public class UserAccessManagementService : IUserAccessManagementService
    {
        #region Fields

        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IBoardRepository _boardRepository;
        private readonly ICardRepository _cardRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly AuthenticatedUserModel currentUser;

        #endregion

        #region Ctors

        public UserAccessManagementService(IAuthenticatedUserService authenticatedUserService, IOrganizationRepository organizationRepository, IProjectRepository projectRepository, ICardRepository cardRepository, ITaskRepository taskRepository, IUserRepository userRepository, IBoardRepository boardRepository)
        {
            _authenticatedUserService = authenticatedUserService;
            _organizationRepository = organizationRepository;
            currentUser = _authenticatedUserService.GetAuthenticatedUser();
            _projectRepository = projectRepository;
            _cardRepository = cardRepository;
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _boardRepository = boardRepository;
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> CanAccessToOrganizationAsync(string organizationId)
        {
            if (await CurrentUserIsNotAnOowner())
                return true;

            var organization = await _organizationRepository.GetByIdAsync(organizationId);

            // handling null reference is not this class's business
            if (organization == null)
                return true;

            return organization.OwnerId == currentUser.Id;

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> CanAccessToProjectAsync(string projectId)
        {
            if (await CurrentUserIsNotAnOowner())
                return true;

            var project = await _projectRepository.GetByIdAsync(projectId);

            // handling null reference is not this class's business
            if (project == null)
                return true;

            return project.OwnerId == currentUser.Id;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> CanAccessToBoardAsync(string boardId)
        {
            if (await CurrentUserIsNotAnOowner())
                return true;

            var board = await _boardRepository.GetByIdAsync(boardId);

            // handling null reference is not this class's business
            if (board == null)
                return true;

            return board.OwnerId == currentUser.Id;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> CanAccessToCardAsync(string cardId)
        {
            if (await CurrentUserIsNotAnOowner())
                return true;

            var card = await _cardRepository.GetByIdAsync(cardId);

            // handling null reference is not this class's business
            if (card == null)
                return true;

            return card.OwnerId == currentUser.Id;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> CanAccessToTaskAsync(string taskId)
        {
            if (await CurrentUserIsNotAnOowner())
                return true;

            var task = await _taskRepository.GetByIdAsync(taskId);

            // handling null reference is not this class's business
            if (task == null)
                return true;

            return task.OwnerId == currentUser.Id;
        }


        #endregion

        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        private async Task<bool> CurrentUserIsNotAnOowner()
        {
            var user = await _userRepository.GetByIdAsync(currentUser.Id);
            return user.Type != UserType.Owner;
        }



        #endregion
    }
}
