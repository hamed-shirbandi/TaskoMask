using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.Services.Owners.Write.Api.Domain.Entities;
using TaskoMask.Services.Owners.Write.Api.Domain.Services;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Specifications
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
