using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Entities;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Specifications;

internal class ProjectNameAndDescriptionCannotSameSpecification : ISpecification<Project>
{
    /// <summary>
    ///
    /// </summary>
    public bool IsSatisfiedBy(Project project)
    {
        return project.Name.Value.ToLower() != project.Description.Value?.ToLower();
    }
}
