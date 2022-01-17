using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.Workspace.Organizations.Entities;
using TaskoMask.Domain.Workspace.Organizations.Services;

namespace TaskoMask.Domain.Workspace.Organizations.Specifications
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
