using AutoMapper;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Authorization.Users.Services;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.WriteModel.Authorization.Data;
using TaskoMask.Domain.WriteModel.Authorization.Entities;
using Xunit;

namespace TaskoMask.Application.Tests.Unit.Authorization
{
    public class UserServiceUnitTests
    {
        public UserServiceUnitTests()
        {

        }

        [Fact]
        public async void User_Is_Created_Properly()
        {
            //Arrange
            var dummyInMemoryBus = Substitute.For<IInMemoryBus>();
            var dummyIMapper = Substitute.For<IMapper>();
            var dummyDomainNotificationHandler = Substitute.For<IDomainNotificationHandler>();
            var dummyEncryptionService = Substitute.For<IEncryptionService>();
            var userRepositoryStub = Substitute.For<IUserRepository>();
            userRepositoryStub.CreateAsync(Arg.Any<User>()).Returns(Task.CompletedTask);
            var userService = new UserService(dummyInMemoryBus, dummyIMapper, dummyDomainNotificationHandler, userRepositoryStub, dummyEncryptionService);


            //Act
            var result = await userService.CreateAsync("TestUserName", "TestPassword");


            //Asserrt
            result.IsSuccess.Should().Be(true);
            result.Value.EntityId.Should().NotBeNullOrEmpty();
        }

    }
}
