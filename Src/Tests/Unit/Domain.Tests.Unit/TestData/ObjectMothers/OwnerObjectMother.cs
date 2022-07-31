using MongoDB.Bson;
using TaskoMask.Domain.Tests.Unit.TestData.DataBuilders;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.Tests.Unit.TestData.ObjectMothers
{
    internal static class OwnerObjectMother
    {

        private const string _email = "Test@TaskoMask.ir";
        private const string _displayName= "Test DisplayName";
        private static string _id = ObjectId.GenerateNewId().ToString();

        
        public static Owner CreateNewOwner()
        {
            var owner= OwnerBuilder.Init()
                   .WithId(_id)
                   .WithEmail(_email)
                   .WithDisplayName(_displayName)
                   .Build();

            owner.ClearDomainEvents();

            return owner;
        }



        public static Owner CreateNewOwnerWithId(string id)
        {
            var owner = OwnerBuilder.Init()
                   .WithId(id)
                   .WithEmail(_email)
                   .WithDisplayName(_displayName)
                   .Build();

            owner.ClearDomainEvents();

            return owner;
        }



        public static Owner CreateNewOwnerWithDisplayName(string displayName)
        {
            var owner = OwnerBuilder.Init()
                   .WithId(_id)
                   .WithEmail(_email)
                   .WithDisplayName(displayName)
                   .Build();

            owner.ClearDomainEvents();

            return owner;
        }



        public static Owner CreateNewOwnerWithEmail(string email)
        {
            var owner = OwnerBuilder.Init()
                   .WithId(_id)
                   .WithEmail(email)
                   .WithDisplayName(_displayName)
                   .Build();

            owner.ClearDomainEvents();

            return owner;
        }



        public static Owner CreateNewOwnerWithAnOrganization()
        {
            var owner = CreateNewOwner();
            var organization = Organization.CreateOrganization("Test Organization Name", "Test Organization Description");

            owner.ClearDomainEvents();

            owner.CreateOrganization(organization);
            return owner;
        }
    }
}
