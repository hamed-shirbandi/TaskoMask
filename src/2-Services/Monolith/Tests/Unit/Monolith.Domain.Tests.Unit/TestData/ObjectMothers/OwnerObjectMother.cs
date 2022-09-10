using MongoDB.Bson;
using TaskoMask.Services.Monolith.Domain.Tests.Unit.TestData.DataBuilders;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Services.Monolith.Domain.Tests.Unit.TestData.ObjectMothers
{
    internal static class OwnerObjectMother
    {

        private const string _email = "Test@TaskoMask.ir";
        private const string _displayName= "Test DisplayName";
        private static string _id = ObjectId.GenerateNewId().ToString();

        
        public static Owner RegisterOwner()
        {
            var owner= OwnerBuilder.Init()
                   .WithEmail(_email)
                   .WithDisplayName(_displayName)
                   .RegisterOwner();

            owner.ClearDomainEvents();

            return owner;
        }



        public static Owner RegisterOwnerWithId(string id)
        {
            var owner = OwnerBuilder.Init()
                   .WithEmail(_email)
                   .WithDisplayName(_displayName)
                   .RegisterOwner();

            owner.ClearDomainEvents();

            return owner;
        }



        public static Owner RegisterOwnerWithDisplayName(string displayName)
        {
            var owner = OwnerBuilder.Init()
                   .WithEmail(_email)
                   .WithDisplayName(displayName)
                   .RegisterOwner();

            owner.ClearDomainEvents();

            return owner;
        }



        public static Owner RegisterOwnerWithEmail(string email)
        {
            var owner = OwnerBuilder.Init()
                   .WithEmail(email)
                   .WithDisplayName(_displayName)
                   .RegisterOwner();

            owner.ClearDomainEvents();

            return owner;
        }



        public static Owner RegisterOwnerWithAnOrganization()
        {
            var owner = RegisterOwner();
            var organization = Organization.CreateOrganization("Test Organization Name", "Test Organization Description");

            owner.ClearDomainEvents();

            owner.AddOrganization(organization);
            return owner;
        }
    }
}
