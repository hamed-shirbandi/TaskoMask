using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.Services.Owners.Write.Domain.Entities;
using TaskoMask.Services.Owners.Write.Domain.Services;

namespace TaskoMask.Services.Owners.Write.Domain.Specifications
{
    internal class OwnerEmailMustUniqueSpecification : ISpecification<Owner>
    {
        private readonly IOwnerValidatorService _ownerValidatorService;
        public OwnerEmailMustUniqueSpecification(IOwnerValidatorService ownerValidatorService)
        {
            _ownerValidatorService = ownerValidatorService;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Owner owner)
        {
            return _ownerValidatorService.OwnerHasUniqueEmail(owner.Id,owner.Email.Value);
        }
    }
}
