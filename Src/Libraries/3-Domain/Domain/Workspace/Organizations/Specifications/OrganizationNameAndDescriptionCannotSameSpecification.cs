using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.Workspace.Organizations.Entities;

namespace TaskoMask.Domain.Workspace.Organizations.Specifications
{
    internal class OrganizationNameAndDescriptionCannotSameSpecification : ISpecification<Organization>
    {
        public bool IsSatisfiedBy(Organization organization)
        {
            return organization.Name.Value.ToLower() != organization.Description.Value.ToLower();
        }
    }
}
