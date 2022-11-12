using TaskoMask.Services.Owners.Write.Domain.Entities;
using TaskoMask.Services.Owners.Write.Domain.Services;

namespace TaskoMask.Services.Owners.Write.UnitTests.TestData
{
    internal class OwnerBuilder
    {
        public IOwnerValidatorService ValidatorService { get; private set; }
        public string Email { get; private set; }
        public string DisplayName { get; private set; }


        private OwnerBuilder()
        {
        }


        public static OwnerBuilder Init()
        {
            return new OwnerBuilder();
        }


        public OwnerBuilder WithEmail(IOwnerValidatorService validatorService)
        {
            ValidatorService = validatorService;
            return this;
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
            return Owner.RegisterOwner(DisplayName, Email, ValidatorService);
        }


    }
}
