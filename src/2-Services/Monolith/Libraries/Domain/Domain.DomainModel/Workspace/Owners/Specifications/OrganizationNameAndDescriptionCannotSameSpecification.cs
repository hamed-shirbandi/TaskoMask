using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Specifications
{
    internal class OrganizationNameAndDescriptionCannotSameSpecification : ISpecification<Organization>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Organization organization)
        {
            return organization.Name.Value.ToLower() != organization.Description.Value?.ToLower();
        }
    }
}
