using AutoMapper;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Authorization.Users.Services;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.WriteModel.Authorization.Data;
using TaskoMask.Domain.WriteModel.Authorization.Entities;
using Xunit;

namespace TaskoMask.Application.Tests.Unit.Authorization
{
    public class UserServiceUnitTests
    {
        #region Fields

        private IInMemoryBus _dummyInMemoryBus;
        private IMapper _dummyIMapper;
        private IDomainNotificationHandler _dummyDomainNotificationHandler;
        private IEncryptionService _dummyEncryptionService;
        private IUserRepository _userRepositoryStub;
        private IUserService _userService;
        private List<User> _users;

        #endregion

        public UserServiceUnitTests()
        {
            ImplicitFixtureSetup();
        }



        [Fact]
        public async void User_Is_Created_Properly()
        {
            //Arrange
            var expectedUserName = "TestUserName";

            //Act
            var result = await _userService.CreateAsync(expectedUserName, "TestPassword");

            //Asserrt
            result.IsSuccess.Should().Be(true);
            var createdUser = _users.FirstOrDefault(u => u.Id == result.Value.EntityId);
            createdUser.UserName.Should().Be(expectedUserName);
        }





        [InlineData("NewUserName")]
        [InlineData("TestUserName")]
        [Theory]
        public async void UserName_Is_Updated_Properly(string expectedUserName)
        {
            //Arrange
            var user = _users.First();

            //Act
            var result = await _userService.UpdateUserNameAsync(user.Id, expectedUserName);

            //Asserrt
            result.IsSuccess.Should().Be(true);
            result.Value.EntityId.Should().Be(user.Id);
            user.UserName.Should().Be(expectedUserName);
        }



        [Fact]
        public async void User_Is_Not_Created_When_UserName_Is_Already_Exist()
        {
            //Arrange
            var existUserName = _users.First().UserName;

            //Act
            var result = await _userService.CreateAsync(existUserName, "TestPassword");

            //Asserrt
            result.IsSuccess.Should().Be(false);
            result.Message.Should().Be(ApplicationMessages.User_Email_Already_Exist);
        }




        #region Private Methods

        private void ImplicitFixtureSetup()
        {
            _dummyInMemoryBus = Substitute.For<IInMemoryBus>();
            _dummyIMapper = Substitute.For<IMapper>();
            _dummyDomainNotificationHandler = Substitute.For<IDomainNotificationHandler>();
            _dummyEncryptionService = Substitute.For<IEncryptionService>();
            _userRepositoryStub = Substitute.For<IUserRepository>();

            _users = GetUsersList();

            _userRepositoryStub.GetByUserNameAsync(Arg.Is<string>(x => _users.Select(u => u.UserName).Contains(x))).Returns(args => _users.First(u => u.UserName == (string)args[0]));
            _userRepositoryStub.ExistByUserNameAsync(Arg.Is<string>(x => _users.Select(u => u.UserName).Contains(x))).Returns(args => _users.Any(u => u.UserName == (string)args[0]));
            _userRepositoryStub.GetByIdAsync(Arg.Is<string>(x => _users.Any(u => u.Id == x))).Returns(args => _users.First(u => u.Id == (string)args[0]));
            _userRepositoryStub.CreateAsync(Arg.Any<User>()).Returns(args => AddNewUser((User)args[0]));
            _userRepositoryStub.UpdateAsync(Arg.Is<User>(x => _users.Any(u => u.Id == x.Id))).Returns(args => UpdateUser((User)args[0]));
            _userService = new UserService(_dummyInMemoryBus, _dummyIMapper, _dummyDomainNotificationHandler, _userRepositoryStub, _dummyEncryptionService);
        }



        private async Task AddNewUser(User user)
        {
            _users.Add(user);
        }



        private async Task UpdateUser(User user)
        {
            var existUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existUser != null)
            {
                _users.Remove(existUser);
                _users.Add(user);
            }
        }


        private List<User> GetUsersList()
        {
            return new List<User>
            {
                new User
                {
                    UserName="UserName1",
                },
                 new User
                {
                    UserName="UserName2",
                },
                  new User
                {
                    UserName="UserName3",
                }
            };
        }



        #endregion

    }
}
