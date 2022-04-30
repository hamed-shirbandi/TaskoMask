using FluentAssertions;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Tests.Integration.TestData;
using TaskoMask.Application.Tests.Integration.TestData.Fixtures;
using TaskoMask.Application.Workspace.Organizations.Services;
using Xunit;


namespace TaskoMask.Application.Tests.Integration.Workspace.OwnerTestCollection
{
   
    [Collection("Owner Collection Fixture")]
    public class OTC2_OrganizationServiceIntegrationTests
    {
        #region Fields

        private readonly IOrganizationService _organizationService;
        private readonly OwnerCollectionFixture _fixture;

        #endregion

        #region Ctor

        public OTC2_OrganizationServiceIntegrationTests(OwnerCollectionFixture fixture)
        {
            _fixture = fixture;
            _organizationService = _fixture.GetRequiredService<IOrganizationService>();
        }

        #endregion

        #region Test Mthods


        [Fact]
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
