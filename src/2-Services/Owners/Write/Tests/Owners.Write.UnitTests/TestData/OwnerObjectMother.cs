using System.Collections.Generic;
using TaskoMask.Services.Owners.Write.Domain.Entities;
using TaskoMask.Services.Owners.Write.Domain.Services;

namespace TaskoMask.Services.Owners.Write.UnitTests.TestData
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



        /// <summary>
        /// 
        /// </summary>
        public static List<Owner> GenerateOwnerList(IOwnerValidatorService ownerValidatorService,int number = 3)
        {
            var list = new List<Owner>();

            for (int i = 1; i <= number; i++)
            {
                var owner = Owner.RegisterOwner($"DisplayName_{i}", $"Email_{i}@mail.com", ownerValidatorService);
                owner.ClearDomainEvents();
                list.Add(owner);
            }

            return list;
        }



        /// <summary>
        /// 
        /// </summary>
        public static Owner GetAnOwnerWithMaxOrganizations(IOwnerValidatorService ownerValidatorService,int expectedMaxOrganizationsCount)
        {
            var owner = GetAnOwner(ownerValidatorService);
            for (int i = 1; i <= expectedMaxOrganizationsCount; i++)
            {
                var organization = Organization.CreateOrganization($"Test_Name_{i}", $"Test_Description_{i}");
                owner.AddOrganization(organization);
            }

            return owner;
        }
    }
}
