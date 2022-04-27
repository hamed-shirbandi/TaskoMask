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
        private List<User> _Users;

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
            var createdUser = _Users.FirstOrDefault(u => u.Id == result.Value.EntityId);
            createdUser.UserName.Should().Be(expectedUserName);
        }




        #region Private Methods

        private void ImplicitFixtureSetup()
        {
            _dummyInMemoryBus = Substitute.For<IInMemoryBus>();
            _dummyIMapper = Substitute.For<IMapper>();
            _dummyDomainNotificationHandler = Substitute.For<IDomainNotificationHandler>();
            _dummyEncryptionService = Substitute.For<IEncryptionService>();
            _userRepositoryStub = Substitute.For<IUserRepository>();

            _Users = GetUsersList();

            _userRepositoryStub.GetByUserNameAsync(Arg.Is<string>(x => _Users.Select(u => u.UserName).Contains(x))).Returns(args => _Users.First(u => u.UserName == (string)args[0]));
            _userRepositoryStub.ExistByUserNameAsync(Arg.Is<string>(x => _Users.Select(u => u.UserName).Contains(x))).Returns(args => _Users.Any(u => u.UserName == (string)args[0]));
            _userRepositoryStub.GetByIdAsync(Arg.Is<string>(x => _Users.Any(u => u.Id == x))).Returns(args => _Users.First(u => u.Id == (string)args[0]));


            _userRepositoryStub.CreateAsync(Arg.Any<User>()).Returns(args => AddNewUser((User)args[0]));



            _userRepositoryStub.UpdateAsync(Arg.Is<User>(x => _Users.Any(u => u.Id == x.Id))).Returns(args => UpdateUser((User)args[0]));

            _userService = new UserService(_dummyInMemoryBus, _dummyIMapper, _dummyDomainNotificationHandler, _userRepositoryStub, _dummyEncryptionService);
        }



        private async Task AddNewUser(User user)
        {
            _Users.Add(user);
        }



        private async Task UpdateUser(User user)
        {
            var existUser = _Users.FirstOrDefault(u => u.Id == user.Id);
            if (existUser != null)
            {
                _Users.Remove(existUser);
                _Users.Add(user);
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
