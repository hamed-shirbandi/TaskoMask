using System.Linq;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Entities;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Specifications;

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
