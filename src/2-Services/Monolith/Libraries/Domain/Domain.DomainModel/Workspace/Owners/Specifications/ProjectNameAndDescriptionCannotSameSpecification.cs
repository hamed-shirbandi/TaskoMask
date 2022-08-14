using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Specifications
{
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
}
