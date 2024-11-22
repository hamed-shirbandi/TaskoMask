using System.Linq;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Entities;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Specifications;

internal class OrganizationMaxProjectsSpecification : ISpecification<Owner>
{
    /// <summary>
    ///
    /// </summary>
    public bool IsSatisfiedBy(Owner owner)
    {
        foreach (var organization in owner.Organizations)
        {
            if (organization.Projects.Count() > DomainConstValues.ORGANIZATION_MAX_PROJECTS_COUNT)
                return false;
        }

        return true;
    }
}
