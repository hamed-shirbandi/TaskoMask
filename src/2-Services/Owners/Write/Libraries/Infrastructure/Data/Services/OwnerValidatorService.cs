
using TaskoMask.Services.Owners.Write.Domain.Data;
using TaskoMask.Services.Owners.Write.Domain.Services;

namespace TaskoMask.Services.Owners.Write.Infrastructure.Data.Services
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
