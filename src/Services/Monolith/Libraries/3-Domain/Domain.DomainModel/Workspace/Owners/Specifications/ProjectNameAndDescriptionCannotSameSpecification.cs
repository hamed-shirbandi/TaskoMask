using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.DomainModel.Workspace.Owners.Specifications
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
