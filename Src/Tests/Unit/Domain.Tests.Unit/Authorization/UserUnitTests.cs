using FluentAssertions;
using MongoDB.Bson;
using System;
using TaskoMask.Domain.Tests.Unit.DataBuilders;
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
            var user = new User
            {
                UserName = userName,
                IsActive = true,
            };


            //Assert
            user.Id.Should().NotBeNullOrEmpty();
            user.UserName.Should().Be(userName);
            user.IsActive.Should().Be(true);

        }


        [Fact]
        public void User_Is_Updated_Properly()
        {
            //Arrange
            var userName = "TestUserName";


            //Act
            var user = new User
            {
                UserName = userName,
            };

            var specifiedModifiedDateTime = user.CreationTime.ModifiedDateTime;

            user.SetAsUpdated();

            //Assert
            user.CreationTime.ModifiedDateTime.Should().BeAfter(specifiedModifiedDateTime);

        }



        [Fact]
        public void User_Is_Deleted_Properly()
        {
            //Arrange
            var userName = "TestUserName";


            //Act
            var user = new User
            {
                UserName = userName,
            };

            user.SetAsDeleted();

            //Assert
            user.IsDeleted.Should().Be(true);

        }




    }
}
