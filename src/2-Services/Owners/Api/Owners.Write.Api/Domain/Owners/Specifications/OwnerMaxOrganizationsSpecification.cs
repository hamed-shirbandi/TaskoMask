using System.Linq;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Entities;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Specifications;

internal class OwnerMaxOrganizationsSpecification : ISpecification<Owner>
{
    /// <summary>
    ///
    /// </summary>
    public bool IsSatisfiedBy(Owner owner)
    {
        return owner.Organizations.Count() <= DomainConstValues.OWNER_MAX_ORGANIZATIONS_COUNT;
    }
}
