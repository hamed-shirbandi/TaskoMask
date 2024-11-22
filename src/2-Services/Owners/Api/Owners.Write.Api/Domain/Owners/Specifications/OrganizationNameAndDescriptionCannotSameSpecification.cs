using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Entities;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Specifications;

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
