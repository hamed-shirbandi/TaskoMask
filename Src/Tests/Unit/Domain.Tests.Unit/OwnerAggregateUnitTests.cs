using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using System;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Events.Owners;
using Xunit;

namespace TaskoMask.Domain.Tests.Unit
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
            var id = ObjectId.GenerateNewId().ToString();
            var email = "Test@email.com";
            var displayName = "Test Name";

            //Act
            var owner = Owner.CreateOwner(id, displayName, email);


            //Assert
            owner.Id.Should().NotBeNullOrEmpty().And.Be(id);
            owner.Email.Value.Should().NotBeNull().And.Be(email);
            owner.DisplayName.Value.Should().NotBeNull().And.Be(displayName);
            owner.Organizations.Should().HaveCount(0);

        }



        [Fact]
        public void Owner_Created_Event_Is_Raised_When_Owner_Is_Constructed_Properly()
        {
            //Arrange
            var id = ObjectId.GenerateNewId().ToString();
            var email = "Test@email.com";
            var displayName = "Test Name";
            var expectedEvent = new OwnerCreatedEvent(id, displayName, email);

            //Act
            var owner = Owner.CreateOwner(id, displayName, email);

            owner.Id.Should().NotBeNullOrEmpty().And.Be(id);

            //Assert
            owner.DomainEvents.Should().Contain(de=>de.EntityId==id && de.EntityType== nameof(Owner));
 
        }



        [Fact]
        public void Owner_Is_Not_Constructed_When_Id_Is_Null()
        {
            //Arrange
            var id = "";
            var email = "Test@email.com";
            var displayName = "Test Name";

            //Act
            Action act = () => Owner.CreateOwner(id, displayName, email);


            //Assert
            act.Should().Throw<DomainException>()
                .Where(e=>e.Message.Equals(string.Format(DomainMessages.Null_Reference_Error, nameof(id))));
        }

    }
}
