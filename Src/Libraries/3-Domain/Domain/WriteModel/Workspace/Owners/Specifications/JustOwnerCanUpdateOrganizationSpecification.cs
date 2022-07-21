using System.Linq;
using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Specifications
{
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
