using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.Workspace.Organizations.Entities;

namespace TaskoMask.Domain.Workspace.Organizations.Specifications
{
    internal class ProjectNameAndDescriptionCannotBeSameSpecification : ISpecification<Project>
    {
        public bool IsSatisfiedBy(Project project)
        {
            return project.Name.Value.ToLower() != project.Description.Value.ToLower();
        }
    }
}
