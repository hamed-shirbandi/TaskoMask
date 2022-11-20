using TaskoMask.Services.Owners.Write.Domain.Entities;
using TaskoMask.Services.Owners.Write.Domain.Services;

namespace TaskoMask.Services.Owners.Write.IntegrationTests.TestData
{
    internal static class OwnerObjectMother
    {

        /// <summary>
        /// 
        /// </summary>

        public static Owner GetAnOwner(IOwnerValidatorService ownerValidatorService)
        {
            var randomName = GetRandomString(30);
            return Owner.RegisterOwner(randomName, $"{randomName}@TaskoMask.ir", ownerValidatorService);
        }



        /// <summary>
        /// 
        /// </summary>

        public static Organization GetAnOrganization()
        {
            var randomName = GetRandomString(30);
            return Organization.CreateOrganization(randomName, "Test Description");
        }



        /// <summary>
        /// 
        /// </summary>

        public static Project GetAProject()
        {
            var randomName = GetRandomString(30);
            return Project.Create(randomName, "Test Description");
        }



        /// <summary>
        /// 
        /// </summary>
        public static Owner GetAnOwnerWithAnOrganization(IOwnerValidatorService ownerValidatorService)
        {
            var owner = GetAnOwner(ownerValidatorService);
            owner.AddOrganization(GetAnOrganization());
            return owner;
        }



        /// <summary>
        /// 
        /// </summary>
        public static Owner GetAnOwnerWithAnOrganizationAndProject(IOwnerValidatorService ownerValidatorService)
        {
            var owner = GetAnOwnerWithAnOrganization(ownerValidatorService);
            var organization = owner.Organizations.FirstOrDefault();
            owner.AddProject(organization.Id,GetAProject());
            return owner;
        }


        /// <summary>
        /// 
        /// </summary>
        private static string GetRandomString(int length)
        {
            return Guid.NewGuid().ToString().Substring(length);
        }

    }
}
