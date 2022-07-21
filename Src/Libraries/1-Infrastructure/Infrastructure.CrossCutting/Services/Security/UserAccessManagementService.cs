using System.Threading.Tasks;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.ReadModel.Data;

namespace TaskoMask.Infrastructure.CrossCutting.Services.Security
{
    public class UserAccessManagementService : IUserAccessManagementService
    {
        #region Fields

        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly string currentUserId;

        #endregion

        #region Ctors

        public UserAccessManagementService(IAuthenticatedUserService authenticatedUserService, IOrganizationRepository organizationRepository)
        {
            _authenticatedUserService = authenticatedUserService;
            _organizationRepository = organizationRepository;
            currentUserId = _authenticatedUserService.GetUserId();

        }


        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> CanGetOrganizationAsync(string organizationId)
        {
            //TODO check user type (operator/owner)
            // if user is an operator then check his permissions
            var organization = await _organizationRepository.GetByIdAsync(organizationId);
            if (organization!=null)
                return organization.OwnerId == currentUserId;
            return true;
        }


        #endregion

        #region Private Methods



        #endregion
    }
}
