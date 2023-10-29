using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Data;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Services;

namespace TaskoMask.Services.Owners.Write.Api.Infrastructure.Data.Services;

/// <summary>
///
/// </summary>
public class OwnerValidatorService : IOwnerValidatorService
{
    private readonly IOwnerAggregateRepository _ownerRepository;

    public OwnerValidatorService(IOwnerAggregateRepository ownerRepository)
    {
        _ownerRepository = ownerRepository;
    }

    /// <summary>
    ///
    /// </summary>
    public bool OwnerHasUniqueEmail(string ownerId, string email)
    {
        return !_ownerRepository.ExistOwnerByEmail(ownerId, email);
    }
}
