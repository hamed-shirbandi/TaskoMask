using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;
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
            var userId = ObjectId.GenerateNewId().ToString();
            var email = "Test@email.com";
            var displayName = "Test Name";

            //Act
            var owner = Owner.CreateOwner(userId, displayName, email);


            //Assert
            owner.Id.Should().NotBeNullOrEmpty().And.Be(userId);
            owner.Email.Value.Should().NotBeNull().And.Be(email);
            owner.DisplayName.Value.Should().NotBeNull().And.Be(displayName);
            owner.Organizations.Should().HaveCount(0);

        }

    }
}
