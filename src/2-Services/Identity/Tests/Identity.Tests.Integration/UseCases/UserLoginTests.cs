using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Identity.Application.UseCases.UserLogin;
using TaskoMask.Services.Identity.Tests.Integration.Fixtures;
using TaskoMask.Services.Identity.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Services.Identity.Tests.Integration.UseCases
{
    [Collection(nameof(UserCollectionFixture))]
    public class UserLoginTests
    {

        #region Fields

        private readonly UserCollectionFixture _fixture;

        #endregion

        #region Ctor

        public UserLoginTests(UserCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task User_is_logged_in()
        {
            //Arrange
            var password = "TestPass";
            var email = "test@taskomask.ir";
            var user = UserObjectMother.GetActiveUserWithEmail(email);

            await _fixture.SeedUserAsync(user, password);

            var userLoginUseCase = new UserLoginUseCase(_fixture.UserManager, _fixture.SignInManager, _fixture.Mapper);
            var userLoginRequest = new UserLoginRequest(email, password, true);

            //Act
            var result = await userLoginUseCase.Handle(userLoginRequest, CancellationToken.None);

            //Assert
            result.Message.Should().Be(ContractsMessages.Operation_Success);
        }


        #endregion
    }
}
