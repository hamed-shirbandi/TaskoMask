using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Services;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Specifications
{
    internal class OrganizationNameMustUniqueSpecification : ISpecification<Organization>
    {
        private readonly IOrganizationValidatorService _organizationValidatorService;
        public OrganizationNameMustUniqueSpecification(IOrganizationValidatorService organizationValidatorService)
        {
            _organizationValidatorService = organizationValidatorService;
        }


        public bool IsSatisfiedBy(Organization organization)
        {
            return _organizationValidatorService.OrganizationHasUniqueName(organization.Id, organization.OwnerOwnerId.Value,organization.Name.Value);
        }
    }
}
