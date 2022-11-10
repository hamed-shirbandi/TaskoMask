using TaskoMask.Services.Owners.Write.IntegrationTests.TestData.DataBuilders;
using TaskoMask.Services.Owners.Write.Domain.Entities;
using TaskoMask.Services.Owners.Write.Domain.Services;

namespace TaskoMask.Services.Owners.Write.IntegrationTests.TestData.ObjectMothers
{
    internal static class OwnerObjectMother
    {

        private const string _email = "Test@TaskoMask.ir";
        private const string _displayName= "Test DisplayName";

        
        public static Owner RegisterAnOwner(IOwnerValidatorService ownerValidatorService)
        {
            var owner= OwnerBuilder.Init(ownerValidatorService)
                   .WithEmail(_email)
                   .WithDisplayName(_displayName)
                   .RegisterOwner();

            owner.ClearDomainEvents();

            return owner;
        }
    }
}
