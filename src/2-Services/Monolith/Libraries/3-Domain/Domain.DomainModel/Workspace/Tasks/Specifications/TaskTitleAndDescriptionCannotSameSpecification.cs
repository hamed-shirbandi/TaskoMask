using TaskoMask.Services.Monolith.Domain.Core.Specifications;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Specifications
{
    internal class TaskTitleAndDescriptionCannotSameSpecification : ISpecification<Task>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Task task)
        {
            return task.Title.Value.ToLower() != task.Description.Value?.ToLower();
        }
    }
}
