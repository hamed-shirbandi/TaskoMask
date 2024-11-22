using System.Linq;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Entities;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Specifications;

internal class OrganizationNameMustUniqueSpecification : ISpecification<Owner>
{
    /// <summary>
    ///
    /// </summary>
    public bool IsSatisfiedBy(Owner owner)
    {
        var organizations = owner.Organizations.ToList();

        var organizationsCount = organizations.Count;
        if (organizationsCount < 2)
            return true;

        var distincOrganizationsCount = organizations.Select(p => p.Name).Distinct().Count();
        return organizationsCount == distincOrganizationsCount;
    }
}
