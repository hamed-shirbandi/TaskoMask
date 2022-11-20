using NSubstitute;
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

        public static Owner GetAnOwner()
        {
            var ownerValidatorService = MockOwnerValidatorService();
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
        public static List<Owner> GenerateOwnerList(int number = 3)
        {
            var list = new List<Owner>();
            var ownerValidatorService = MockOwnerValidatorService();

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
        public static Owner GetAnOwnerWithMaxOrganizations(IOwnerValidatorService ownerValidatorService, int expectedMaxOrganizationsCount)
        {
            var owner = GetAnOwner();
            for (int i = 1; i <= expectedMaxOrganizationsCount; i++)
            {
                var organization = Organization.CreateOrganization($"Test_Name_{i}", $"Test_Description_{i}");
                owner.AddOrganization(organization);
            }

            return owner;
        }


        /// <summary>
        /// 
        /// </summary>
        private static IOwnerValidatorService MockOwnerValidatorService()
        {
            var OwnerValidatorService = Substitute.For<IOwnerValidatorService>();
            OwnerValidatorService.OwnerHasUniqueEmail(ownerId: Arg.Any<string>(), email: Arg.Any<string>()).Returns(args =>
            {
                return true;
            });

            return OwnerValidatorService;
        }
    }
}
