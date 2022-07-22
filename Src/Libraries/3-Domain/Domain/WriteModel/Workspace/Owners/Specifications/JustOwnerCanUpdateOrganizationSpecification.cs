using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Specifications
{

    /// <summary>
    /// To manage user access security, the main strategy in this architecture is
    /// handling it by using IUserAccessManagementService on Application (not in domain)
    /// But, here is just an example if you like to do it through the Domain model
    /// </summary>
    internal class JustOwnerCanUpdateOrganizationSpecification : ISpecification<Owner>
    {
        private readonly IAuthenticatedUserService _authenticatedUserService;
        public JustOwnerCanUpdateOrganizationSpecification(IAuthenticatedUserService authenticatedUserService)
        {
            _authenticatedUserService = authenticatedUserService;
        }


        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Owner owner)
        {
            return owner.Id == _authenticatedUserService.GetUserId();
        }
    }
}
