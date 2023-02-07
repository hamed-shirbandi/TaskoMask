
using TaskoMask.Services.Owners.Write.Api.Domain.Data;
using TaskoMask.Services.Owners.Write.Api.Domain.Services;

namespace TaskoMask.Services.Owners.Write.Api.Infrastructure.Data.Services
{

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
}
