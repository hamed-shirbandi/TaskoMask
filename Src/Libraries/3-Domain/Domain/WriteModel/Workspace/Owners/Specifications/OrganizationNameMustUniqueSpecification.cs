using System.Linq;
using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Specifications
{
    internal class OrganizationNameMustUniqueSpecification : ISpecification<Owner>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Owner owner)
        {
            var organizations = owner.Organizations.Where(p => p.IsDeleted == false).ToList();

            var organizationsCount = organizations.Count;
            if (organizationsCount < 2)
                return true;

            var distincOrganizationsCount = organizations.Select(p => p.Name).Distinct().Count();
            return organizationsCount == distincOrganizationsCount;
        }
    }
}
