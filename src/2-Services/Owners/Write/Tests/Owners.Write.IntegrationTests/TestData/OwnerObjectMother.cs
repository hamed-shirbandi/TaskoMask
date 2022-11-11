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
            return Owner.RegisterOwner("Test DisplayName", "Test@TaskoMask.ir", ownerValidatorService);
        }



        /// <summary>
        /// 
        /// </summary>

        public static Organization GetAnOrganization()
        {
            return Organization.CreateOrganization("Test Name", "Test Description");
        }



        /// <summary>
        /// 
        /// </summary>

        public static Project GetAProject()
        {
            return Project.Create("Test Name", "Test Description");
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
    }
}
