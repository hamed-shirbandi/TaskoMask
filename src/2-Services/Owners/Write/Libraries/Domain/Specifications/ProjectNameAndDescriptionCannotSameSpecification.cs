using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.Services.Owners.Write.Domain.Entities;

namespace TaskoMask.Services.Owners.Write.Domain.Specifications
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
