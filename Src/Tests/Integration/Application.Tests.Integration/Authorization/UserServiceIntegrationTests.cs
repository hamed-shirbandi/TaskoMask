using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Authorization.Users.Services;
using TaskoMask.Application.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Application.Tests.Integration.Workspace
{
    public class UserServiceIntegrationTests : TestsBase
    {
        private readonly IUserService _userService;
        
        //Run before each test method
        public UserServiceIntegrationTests()
        {
            _userService = ServiceProvider.GetRequiredService<IUserService>();
        }


        [Fact]
        public async Task User_Is_Created_Properly()
        {
            var result = await _userService.CreateAsync("TestUserName", "TestPass");
            result.IsSuccess.Should().BeTrue();
            result.Value.EntityId.Should().NotBeNull();
        }


    }
}
