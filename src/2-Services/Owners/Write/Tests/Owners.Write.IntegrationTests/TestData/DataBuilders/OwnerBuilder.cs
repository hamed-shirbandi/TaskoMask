
using TaskoMask.Services.Owners.Write.Domain.Entities;
using TaskoMask.Services.Owners.Write.Domain.Services;

namespace TaskoMask.Services.Owners.Write.IntegrationTests.TestData.DataBuilders
{
    internal class OwnerBuilder
    {
        private readonly IOwnerValidatorService _ownerValidatorService;

        public string Email { get; private set; }
        public string DisplayName { get; private set; }


        private OwnerBuilder(IOwnerValidatorService ownerValidatorService)
        {
            _ownerValidatorService = ownerValidatorService;
        }


        public static OwnerBuilder Init(IOwnerValidatorService ownerValidatorService)
        {
            return new OwnerBuilder(ownerValidatorService);
        }



        public OwnerBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }


        public OwnerBuilder WithDisplayName(string displayName)
        {
            DisplayName = displayName;
            return this;
        }



        public Owner RegisterOwner()
        {
            return Owner.RegisterOwner(DisplayName, Email,_ownerValidatorService);
        }


    }
}
