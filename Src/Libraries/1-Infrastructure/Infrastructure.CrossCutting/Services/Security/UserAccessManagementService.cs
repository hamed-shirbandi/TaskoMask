using System.Threading.Tasks;
using TaskoMask.Application.Core.Services;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.Share.Models;

namespace TaskoMask.Infrastructure.CrossCutting.Services.Security
{
    /// <summary>
    /// In this service we just focus on owner users (UserPanel users) and check their access permissions
    /// For operators (AdminPanle users) we check their access permissions in admin panel controllers through HasPermissionFilterAttribute
    /// 
    /// </summary>
    public class UserAccessManagementService : IUserAccessManagementService
    {
        #region Fields

        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly AuthenticatedUser currentUser;

        #endregion

        #region Ctors

        public UserAccessManagementService(IAuthenticatedUserService authenticatedUserService, IOrganizationRepository organizationRepository)
        {
            _authenticatedUserService = authenticatedUserService;
            _organizationRepository = organizationRepository;
            currentUser = _authenticatedUserService.GetAuthenticatedUser();
        }


        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> CanAccessToOrganizationAsync(string organizationId)
        {
            if (!currentUser.IsOperator())
                return true;

            var organization = await _organizationRepository.GetByIdAsync(organizationId);
           
            // handling null reference is not this class's business
            if (organization == null)
                return true;

            return organization.OwnerId == currentUser.Id;
        }


        #endregion

        #region Private Methods



        #endregion
    }
}
