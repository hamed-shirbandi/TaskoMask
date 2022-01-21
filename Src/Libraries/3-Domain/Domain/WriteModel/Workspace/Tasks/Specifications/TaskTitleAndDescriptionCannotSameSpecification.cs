using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Tasks.Specifications
{
    internal class TaskTitleAndDescriptionCannotSameSpecification : ISpecification<Task>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Task task)
        {
            return task.Title.Value.ToLower() != task.Description.Value.ToLower();
        }
    }
}
