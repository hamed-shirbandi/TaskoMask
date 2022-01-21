using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Specifications
{
    internal class ProjectNameAndDescriptionCannotSameSpecification : ISpecification<Project>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Project project)
        {
            return project.Name.Value.ToLower() != project.Description.Value.ToLower();
        }
    }
}
