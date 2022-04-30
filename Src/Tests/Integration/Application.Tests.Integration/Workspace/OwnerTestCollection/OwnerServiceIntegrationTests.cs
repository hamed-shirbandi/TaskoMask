using FluentAssertions;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Tests.Integration.TestData;
using TaskoMask.Application.Tests.Integration.TestData.Fixtures;
using TaskoMask.Application.Workspace.Owners.Services;
using Xunit;


namespace TaskoMask.Application.Tests.Integration.Workspace.OwnerTestCollection
{
    
    [Collection("Owner Collection Fixture")]
    public class OTC1_OwnerServiceIntegrationTests 
    {
        #region Fields

        private readonly IOwnerService _ownerService;
        private readonly OwnerCollectionFixture _fixture;

        #endregion

        #region Ctor

        public OTC1_OwnerServiceIntegrationTests(OwnerCollectionFixture fixture)
        {
            _fixture = fixture;
            _ownerService = _fixture.GetRequiredService<IOwnerService>();
        }

        #endregion

        #region Test Mthods



        [Fact]
        public async Task Owner_Is_Created_Properly()
        {
            //Arrange
            var dto = new OwnerRegisterDto
            {
                DisplayName= "Test DisplayName",
                Email="TestOwner@email.com",
                Password="TestPass"
            };

            //Act
            var result = await _ownerService.CreateAsync(dto);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.EntityId.Should().NotBeNull();
        }



        #endregion

    }
}
