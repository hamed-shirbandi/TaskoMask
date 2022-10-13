using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.Services.Tasks.Write.Domain.Entities;

namespace TaskoMask.Services.Tasks.Write.Domain.Specifications
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
