using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Tests.Integration.Fixtures;
using Xunit;


namespace TaskoMask.Application.Tests.Integration.Workspace
{

    [Collection(nameof(OwnerCollectionFixture))]
    public class ProjectServiceIntegrationTests
    {
        #region Fields

        private readonly OwnerCollectionFixture _fixture;

        #endregion

        #region Ctor

        public ProjectServiceIntegrationTests(OwnerCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods




        [Fact]
        public async Task Project_Is_Created()
        {
            //Arrange
            var organization = await _fixture.GetSampleOrganizationAsync();
            var dto = new ProjectUpsertDto
            {
                Name = "Test Project Name",
                Description = "Test Project Description",
                OrganizationId = organization.Id,
            };

            //Act
            var result = await _fixture.ProjectService.CreateAsync(dto);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.EntityId.Should().NotBeNull();

        }



        [Fact]
        public async Task Project_List_By_OrganizationId_Is_Fetched()
        {
            //Arrange
            var expectedOrganization = await _fixture.GetSampleOrganizationAsync();

            //Act
            var result = await _fixture.ProjectService.GetListByOrganizationIdAsync(expectedOrganization.Id);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().HaveCountGreaterThan(0);
            var anyNotExpectedOrganizationId = result.Value.Any(o => o.OrganizationId != expectedOrganization.Id);
            anyNotExpectedOrganizationId.Should().BeFalse();
        }



        #endregion

    }
}
