using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using System;
using System.Linq;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Tests.Unit.DataBuilders;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Events.Owners;
using Xunit;

namespace TaskoMask.Domain.Tests.Unit.Workspace
{
    public class OwnerAggregateUnitTests
    {
        public OwnerAggregateUnitTests()
        {

        }


        [Fact]
        public void Owner_Is_Constructed_Properly()
        {
            //Arrange
            var ownerBuilder = OwnerBuilder.Init()
                  .WithId(ObjectId.GenerateNewId().ToString())
                  .WithEmail("Test@email.com")
                  .WithDisplayName("Test Name");

            //Act
            var owner = ownerBuilder.Build();


            //Assert
            owner.Id.Should().NotBeNullOrEmpty().And.Be(ownerBuilder.Id);
            owner.Email.Value.Should().NotBeNull().And.Be(ownerBuilder.Email);
            owner.DisplayName.Value.Should().NotBeNull().And.Be(ownerBuilder.DisplayName);
            owner.Organizations.Should().HaveCount(0);

        }



        [Fact]
        public void Owner_Created_Event_Is_Raised_When_Owner_Is_Constructed_Properly()
        {

            //Arrange
            var ownerBuilder = OwnerBuilder.Init()
                  .WithId(ObjectId.GenerateNewId().ToString())
                  .WithEmail("Test@email.com")
                  .WithDisplayName("Test Name");

            var expectedEventType = nameof(OwnerCreatedEvent);

            //Act
            var owner = ownerBuilder.Build();

            //Assert
            owner.DomainEvents.Should().HaveCount(1);
            var domainEvent = owner.DomainEvents.First();
            domainEvent.EventType.Should().Be(expectedEventType);
            domainEvent.EntityId.Should().Be(owner.Id);

        }



        [Fact]
        public void Owner_Is_Not_Constructed_When_Id_Is_Null()
        {
            //Arrange
            var ownerBuilder = OwnerBuilder.Init()
                  .WithId(null)
                  .WithEmail("Test@email.com")
                  .WithDisplayName("Test Name");


            //Act
            Action act = () => ownerBuilder.Build();


            //Assert
            act.Should().Throw<DomainException>()
                .Where(e => e.Message.Equals(string.Format(DomainMessages.Null_Reference_Error, nameof(ownerBuilder.Id).ToLower())));
        }

    }
}
