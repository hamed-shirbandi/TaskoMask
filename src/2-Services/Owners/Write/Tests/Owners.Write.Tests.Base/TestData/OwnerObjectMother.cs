using System;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Test.TestData;
using TaskoMask.Services.Owners.Write.Domain.Entities;
using TaskoMask.Services.Owners.Write.Domain.Services;

namespace TaskoMask.Services.Owners.Write.Tests.Base.TestData
{
    public static class OwnerObjectMother
    {

        /// <summary>
        /// 
        /// </summary>
        public static Owner CreateOwner(IOwnerValidatorService ownerValidatorService)
        {
            return OwnerBuilder.Init()
                .WithValidatorService(ownerValidatorService)
                .WithDisplayName(TestDataGenerator.GetRandomName(10))
                .WithEmail(TestDataGenerator.GetRandomEmail())
                .Build();
        }



        /// <summary>
        /// 
        /// </summary>
        public static Organization CreateOrganization()
        {
            return Organization.CreateOrganization(name: TestDataGenerator.GetRandomName(10),description: TestDataGenerator.GetRandomString(20));
        }



        /// <summary>
        /// 
        /// </summary>
        public static Project CreateProject()
        {
            return Project.Create(name: TestDataGenerator.GetRandomName(10), description: TestDataGenerator.GetRandomString(20));
        }



        /// <summary>
        /// 
        /// </summary>
        public static List<Owner> GenerateOwnersList(IOwnerValidatorService ownerValidatorService, int number = 3)
        {
            var list = new List<Owner>();

            while (number-- > 0)
                list.Add(CreateOwner(ownerValidatorService));

            return list;
        }



        /// <summary>
        /// 
        /// </summary>
        public static Owner CreateOwnerWithMaxOrganizations(IOwnerValidatorService ownerValidatorService, int expectedMaxOrganizationsCount)
        {
            var owner = CreateOwner(ownerValidatorService);

            while (expectedMaxOrganizationsCount-- > 0)
                owner.AddOrganization(CreateOrganization());

            owner.ClearDomainEvents();

            return owner;
        }



        /// <summary>
        /// 
        /// </summary>
        public static Owner CreateOwnerWithOneOrganization(IOwnerValidatorService ownerValidatorService)
        {
            var owner = CreateOwner(ownerValidatorService);
            owner.AddOrganization(CreateOrganization());
            owner.ClearDomainEvents();
            return owner;
        }



        /// <summary>
        /// 
        /// </summary>
        public static Owner CreateOwnerWithOneOrganizationAndOneProject(IOwnerValidatorService ownerValidatorService)
        {
            var owner = CreateOwner(ownerValidatorService);
            var organization = CreateOrganization();
            owner.AddOrganization(organization);
            owner.AddProject(organization.Id,CreateProject());
            owner.ClearDomainEvents();
            return owner;
        }
    }
}
