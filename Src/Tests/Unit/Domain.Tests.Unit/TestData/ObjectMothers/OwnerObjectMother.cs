using MongoDB.Bson;
using TaskoMask.Domain.Tests.Unit.TestData.DataBuilders;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.Tests.Unit.TestData.ObjectMothers
{
    internal static class OwnerObjectMother
    {

        private const string _email = "Test@TaskoMask.ir";
        private const string _displayName= "Test DisplayName";
        private static string _id = ObjectId.GenerateNewId().ToString();

        
        public static Owner CreateNewOwner()
        {
            return OwnerBuilder.Init()
                   .WithId(_id)
                   .WithEmail(_email)
                   .WithDisplayName(_displayName)
                   .Build();
        }



        public static Owner CreateNewOwnerWithId(string id)
        {
            return OwnerBuilder.Init()
                   .WithId(id)
                   .WithEmail(_email)
                   .WithDisplayName(_displayName)
                   .Build();
        }



        public static Owner CreateNewOwnerWithDisplayName(string displayName)
        {
            return OwnerBuilder.Init()
                   .WithId(_id)
                   .WithEmail(_email)
                   .WithDisplayName(displayName)
                   .Build();
        }


        public static Owner CreateNewOwnerWithEmail(string email)
        {
            return OwnerBuilder.Init()
                   .WithId(_id)
                   .WithEmail(email)
                   .WithDisplayName(_displayName)
                   .Build();
        }

        public static Owner CreateNewOwnerWithAnOrganization()
        {
            var owner = CreateNewOwner();
            var organization = Organization.CreateOrganization("Test Organization Name", "Test Organization Description");
            owner.CreateOrganization(organization);
            return owner;
        }
    }
}
