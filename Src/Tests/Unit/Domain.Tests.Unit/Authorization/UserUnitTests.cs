using FluentAssertions;
using TaskoMask.Domain.Tests.Unit.TestData;
using TaskoMask.Domain.Tests.Unit.TestData.ObjectMothers;
using Xunit;

namespace TaskoMask.Domain.Tests.Unit.Authorization
{
    public class UserUnitTests :TestsBase
    {

        [Fact]
        public void User_Is_Constructed()
        {
            //Arrange
            var expectedUserName = "TestUserName";

            //Act
            var user = UserObjectMother.CreateNewUser(expectedUserName,isActive: true);

            //Assert
            user.Id.Should().NotBeNullOrEmpty();
            user.UserName.Should().Be(expectedUserName);
            user.IsActive.Should().Be(true);

        }


        [Fact]
        public void User_Is_Updated()
        {
            //Arrange
            var user = UserObjectMother.CreateNewUser();
            var specifiedModifiedDateTime = user.CreationTime.ModifiedDateTime;

            //Act
            user.SetAsUpdated();

            //Assert
            user.CreationTime.ModifiedDateTime.Should().BeAfter(specifiedModifiedDateTime);

        }



        /// <summary>
        /// Manage Test Fixture
        /// </summary>
        protected override void FixtureSetup()
        {

        }
    }
}
