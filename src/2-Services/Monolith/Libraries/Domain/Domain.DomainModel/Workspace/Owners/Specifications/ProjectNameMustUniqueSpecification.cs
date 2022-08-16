using System.Linq;
using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Specifications
{

    internal class ProjectNameMustUniqueSpecification : ISpecification<Owner>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Owner owner)
        {
            foreach (var organization in owner.Organizations)
            {
                var projects = organization.Projects.ToList();
                var projectsCount = projects.Count;
                if (projectsCount < 2)
                    continue;

                var distincprojectsCount = projects.Select(p => p.Name).Distinct().Count();
                if (distincprojectsCount != projectsCount)
                    return false;
            }

            return true;
        }
    }
}
