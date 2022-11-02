using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;

namespace TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectById
{
    public class GetProjectByIdRequest : BaseQuery<ProjectBasicInfoDto>
    {
        public GetProjectByIdRequest(string id)
        {
            Id = id;
        }


        public string Id { get; }


    }
}
