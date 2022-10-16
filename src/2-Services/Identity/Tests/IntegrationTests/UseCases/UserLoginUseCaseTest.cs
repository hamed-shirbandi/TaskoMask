using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Identity.Application.UseCases.UserLogin;
using TaskoMask.Services.Identity.IntegrationTests.Fixtures;
using TaskoMask.Services.Identity.IntegrationTests.TestData;
using Xunit;

namespace TaskoMask.Services.Identity.IntegrationTests.UseCases
{
    public class UserLoginUseCaseTest : IClassFixture<UserClassFixture>
    {

        #region Fields

        private readonly UserClassFixture _fixture;

        #endregion

        #region Ctor

        public UserLoginUseCaseTest(UserClassFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion


        #region Test Methods


        [Fact]
        public async Task User_Is_Logged_In()
        {
            //Arrange
            var password = "TestPass";
            var email = "test@taskomask.ir";
            var user = UserObjectMother.GetActiveUserWithEmail(email);

            await _fixture.SeedUserAsync(user, password);

            var useCase = new UserLoginUseCase(_fixture.UserManager, _fixture.SignInManager, _fixture.Mapper);
            var userLoginRequest = new UserLoginRequest
            {
                UserName = email,
                Password = password,
            };

            //Act
            var result = await useCase.Handle(userLoginRequest, CancellationToken.None);

            //Assert
            result.Message.Should().Be(ContractsMessages.Operation_Success);
        }


        #endregion
    }
}
