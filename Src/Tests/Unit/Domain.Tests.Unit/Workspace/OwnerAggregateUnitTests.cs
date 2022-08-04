using FluentAssertions;
using MongoDB.Bson;
using System;
using System.Linq;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Tests.Unit.TestData;
using TaskoMask.Domain.Tests.Unit.TestData.DataBuilders;
using TaskoMask.Domain.Tests.Unit.TestData.ObjectMothers;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Entities;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Events.Owners;
using TaskoMask.Domain.DomainModel.Workspace.Owners.ValueObjects.Owners;
using Xunit;

namespace TaskoMask.Domain.Tests.Unit.Workspace
{
    public class OwnerAggregateUnitTests : TestsBase
    {

        [Fact]
        public void Owner_Is_Registered()
        {
            //Arrange
            var ownerBuilder = OwnerBuilder.Init()
                  .WithId(ObjectId.GenerateNewId().ToString())
                  .WithEmail("Test@email.com")
                  .WithDisplayName("Test Name");

            //Act
            var owner = ownerBuilder.RegisterOwner();


            //Assert
            owner.Id.Should().NotBeNullOrEmpty().And.Be(ownerBuilder.Id);
            owner.Email.Value.Should().NotBeNull().And.Be(ownerBuilder.Email);
            owner.DisplayName.Value.Should().NotBeNull().And.Be(ownerBuilder.DisplayName);
            owner.Organizations.Should().HaveCount(0);

        }



        [Fact]
        public void Event_is_Published_When_Owner_Is_Registered()
        {

            //Arrange
            var expectedEventType = nameof(OwnerRegisteredEvent);
            var ownerBuilder = OwnerBuilder.Init()
                              .WithId(ObjectId.GenerateNewId().ToString())
                              .WithEmail("Test@email.com")
                              .WithDisplayName("Test Name");
            //Act
            var owner = ownerBuilder.RegisterOwner();

            //Assert
            owner.DomainEvents.Should().HaveCount(1);
            var domainEvent = owner.DomainEvents.First();
            domainEvent.EventType.Should().Be(expectedEventType);
            domainEvent.EntityId.Should().Be(owner.Id);

        }



        [Fact]
        public void Owner_Is_Not_Registered_When_Id_Is_Null()
        {
            //Arrange
            var expectedMessage = string.Format(DomainMessages.Null_Reference_Error, nameof(Owner.Id));

            //Act
            Action act = () => OwnerObjectMother.RegisterOwnerWithId(null);

            //Assert
            act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));
        }



        [Fact]
        public void Owner_Is_Not_Registered_When_DisplayName_Is_Null()
        {
            //Arrange
            var expectedMessage = string.Format(DomainMessages.Required, nameof(OwnerDisplayName));

            //Act
            Action act = () => OwnerObjectMother.RegisterOwnerWithDisplayName(null);

            //Assert
            act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));
        }



        [InlineData("H")]
        [InlineData("Ha")]
        [Theory]
        public void Owner_Is_Not_Registered_When_DisplayName_Lenght_Is_Less_Than_Min_Length(string displayName)
        {
            //Arrange
            var expectedMessage = string.Format(DomainMessages.Length_Error, nameof(OwnerDisplayName), DomainConstValues.Owner_DisplayName_Min_Length, DomainConstValues.Owner_DisplayName_Max_Length);

            //Act
            Action act = () => OwnerObjectMother.RegisterOwnerWithDisplayName(displayName);


            //Assert
            act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage ));
        }



        [InlineData("Hamed@taskomask")]
        [InlineData("Ha.Taskomask.ir")]
        [InlineData("Ha.Taskomask")]
        [Theory]
        public void Owner_Is_Not_Registered_When_Email_Is_Not_Valid(string email)
        {
            //Arrange
            var expectedMessage = DomainMessages.Invalid_Email_Address;

            //Act
            Action act = () => OwnerObjectMother.RegisterOwnerWithEmail(email);

            //Assert
            act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));
        }


        
        [Fact]
        public void Event_is_Published_When_Owner_Profile_Is_Updated()
        {

            //Arrange
            var owner = OwnerObjectMother.RegisterOwner();
            var expectedEventType = nameof(OwnerProfileUpdatedEvent);

            //Act
            owner.UpdateOwnerProfile(
                OwnerDisplayName.Create("New Name"),
                OwnerEmail.Create("New@email.com"));

            //Assert
            owner.DomainEvents.Should().HaveCount(1);
            var domainEvent = owner.DomainEvents.Last();
            domainEvent.EventType.Should().Be(expectedEventType);
            domainEvent.EntityId.Should().Be(owner.Id);
        }



        [Fact]
        public void Organization_Is_Added()
        {

            //Arrange
            var owner = OwnerObjectMother.RegisterOwner();
            var expectedOrganization = Organization.CreateOrganization("Test Organization Name", "Test Organization Description");


            //Act
            owner.AddOrganization(expectedOrganization);

            //Assert
            owner.Organizations.Should().HaveCount(1);
            var organization = owner.Organizations.First();
            organization.Name.Should().Be(expectedOrganization.Name);
            organization.Id.Should().Be(expectedOrganization.Id);
        }



        [Fact]
        public void Project_Is_Added()
        {
            //Arrange
            var owner = OwnerObjectMother.RegisterOwnerWithAnOrganization();
            var expectedOrganizationId = owner.Organizations.First().Id;
            var expectedProject = Project.Create("Test Project Name", "Test Project Description");


            //Act
            owner.AddProject(expectedOrganizationId, expectedProject);

            //Assert
            owner.Organizations.First().Projects.Should().HaveCount(1);
            var project = owner.Organizations.First().Projects.First();
            project.Name.Should().Be(expectedProject.Name);
            project.Id.Should().Be(expectedProject.Id);
        }



        /// <summary>
        /// Manage Test Fixture
        /// </summary>
        protected override void FixtureSetup()
        {

        }

    }
}
