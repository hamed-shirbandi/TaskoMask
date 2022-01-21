using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Specifications
{
    internal class OrganizationNameAndDescriptionCannotSameSpecification : ISpecification<Organization>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Organization organization)
        {
            return organization.Name.Value.ToLower() != organization.Description.Value.ToLower();
        }
    }
}
