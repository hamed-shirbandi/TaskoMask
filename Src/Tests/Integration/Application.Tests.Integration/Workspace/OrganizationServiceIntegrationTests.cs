using FluentAssertions;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Tests.Integration.TestData;
using TaskoMask.Application.Workspace.Organizations.Services;
using Xunit;
using Xunit.Priority;

namespace TaskoMask.Application.Tests.Integration.Workspace
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [Collection("TestsBaseFixture collection")]
    public class OrganizationServiceIntegrationTests
    {
        #region Fields

        private readonly IOrganizationService _organizationService;
        private readonly TestsBaseFixture _fixture;

        #endregion

        #region Ctor

        public OrganizationServiceIntegrationTests(TestsBaseFixture fixture)
        {
            _fixture = fixture;
            _organizationService = _fixture.GetRequiredService<IOrganizationService>();
        }

        #endregion

        #region Test Mthods


        [Fact, Priority(200)]
        public async Task Organization_Is_Created_Properly()
        {
            //Arrange
            var dto = new OrganizationUpsertDto
            {
                Name = "Test Organization Name",
                Description = "Test Organization Description",
                OwnerId = _fixture.GetFromMemeory(MagicKey.Owner.Created_Owner_Id),
            };

            //Act
            var result = await _organizationService.CreateAsync(dto);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.EntityId.Should().NotBeNull();

            _fixture.SaveToMemeory(MagicKey.Organization.Created_Organization_Id, result.Value.EntityId);
        }





        #endregion

    }
}
