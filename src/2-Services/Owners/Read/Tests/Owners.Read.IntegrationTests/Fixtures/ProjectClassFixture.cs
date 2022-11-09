using TaskoMask.Services.Owners.Read.Api.Domain;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.Fixtures
{

    /// <summary>
    /// 
    /// </summary>
    public class ProjectClassFixture : TestsBaseFixture
    {

        public ProjectClassFixture() : base(dbNameSuffix: nameof(ProjectClassFixture))
        {
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task SeedProjectAsync(Project project)
        {
            await DbContext.Projects.InsertOneAsync(project);
        }

    }
}