using System.Linq;
using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Specifications
{
    internal class OrganizationNameMustUniqueSpecification : ISpecification<Owner>
    {
        public OrganizationNameMustUniqueSpecification()
        {
        }


        public bool IsSatisfiedBy(Owner owner)
        {
            var organizationsCount = owner.Organizations.Count;
            if (organizationsCount < 2)
                return true;

            var distincOrganizationsCount = owner.Organizations.Select(p => p.Name).Distinct().Count();

            return organizationsCount == distincOrganizationsCount;
        }
    }
}
