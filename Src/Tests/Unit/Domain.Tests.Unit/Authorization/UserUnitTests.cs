using FluentAssertions;
using MongoDB.Bson;
using System;
using TaskoMask.Domain.Tests.Unit.TestData.DataBuilders;
using TaskoMask.Domain.Tests.Unit.TestData.ObjectMothers;
using TaskoMask.Domain.WriteModel.Authorization.Entities;
using Xunit;

namespace TaskoMask.Domain.Tests.Unit.Authorization
{
    public class UserUnitTests
    {
        public UserUnitTests()
        {

        }


        [Fact]
        public void User_Is_Constructed_Properly()
        {
            //Arrange
            var userName = "TestUserName";


            //Act
            var user = UserObjectMother.CreateNewUser(userName,isActive: true);


            //Assert
            user.Id.Should().NotBeNullOrEmpty();
            user.UserName.Should().Be(userName);
            user.IsActive.Should().Be(true);

        }


        [Fact]
        public void User_Is_Updated_Properly()
        {
            //Arrange
            var user = UserObjectMother.CreateNewUser();
            var specifiedModifiedDateTime = user.CreationTime.ModifiedDateTime;

            //Act
            user.SetAsUpdated();

            //Assert
            user.CreationTime.ModifiedDateTime.Should().BeAfter(specifiedModifiedDateTime);

        }



        [Fact]
        public void User_Is_Deleted_Properly()
        {
            //Arrange
            var user = UserObjectMother.CreateNewUser();

            //Act
            user.SetAsDeleted();

            //Assert
            user.IsDeleted.Should().Be(true);

        }


        [Fact]
        public void User_Is_Recycled_Properly()
        {
            //Arrange
            var user = UserObjectMother.CreateNewUser();

            //Act
            user.SetAsDeleted();
            user.SetAsRecycled();

            //Assert
            user.IsDeleted.Should().Be(false);

        }

    }
}
