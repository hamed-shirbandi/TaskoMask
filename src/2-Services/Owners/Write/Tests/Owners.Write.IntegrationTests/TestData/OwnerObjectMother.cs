using TaskoMask.Services.Owners.Write.Domain.Entities;
using TaskoMask.Services.Owners.Write.Domain.Services;

namespace TaskoMask.Services.Owners.Write.IntegrationTests.TestData
{
    internal static class OwnerObjectMother
    {

        private const string _email = "Test@TaskoMask.ir";
        private const string _displayName = "Test DisplayName";



        /// <summary>
        /// 
        /// </summary>

        public static Owner GetAnOwner(IOwnerValidatorService ownerValidatorService)
        {
            return OwnerBuilder.Init(ownerValidatorService)
                   .WithEmail(_email)
                   .WithDisplayName(_displayName)
                   .RegisterOwner();
        }



        /// <summary>
        /// 
        /// </summary>
        public static Owner GetAnOwnerWithAnOrganization(IOwnerValidatorService ownerValidatorService)
        {
            var owner = GetAnOwner(ownerValidatorService);
            var organization = Organization.CreateOrganization("Test Name", "Test Description");
            owner.AddOrganization(organization);
            return owner;
        }


        /// <summary>
        /// 
        /// </summary>
        public static Owner GetAnOwnerWithAnOrganizationAndProject(IOwnerValidatorService ownerValidatorService)
        {
            var owner = GetAnOwnerWithAnOrganization(ownerValidatorService);
            var organization = owner.Organizations.FirstOrDefault();
            var project = Project.Create("Test Name", "Test Description");
            organization.AddProject(project);
            return owner;
        }
    }
}
