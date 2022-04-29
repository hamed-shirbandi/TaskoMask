using FluentAssertions;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Tests.Integration.TestData;
using TaskoMask.Application.Workspace.Owners.Services;
using Xunit;
using Xunit.Priority;

namespace TaskoMask.Application.Tests.Integration.Workspace
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class OwnerServiceIntegrationTests: IClassFixture<TestsBaseFixture>
    {
        #region Fields

        private readonly IOwnerService _ownerService;
        private readonly TestsBaseFixture _fixture;

        #endregion

        #region Ctor

        public OwnerServiceIntegrationTests(TestsBaseFixture fixture)
        {
            _fixture = fixture;
            _ownerService = _fixture.GetRequiredService<IOwnerService>();
        }

        #endregion

        #region Test Mthods



        [Fact, Priority(3)]
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

            _fixture.SaveToMemeory(MagicKey.Owner.Created_Owner_Id, result.Value.EntityId);
        }



        #endregion

    }
}
