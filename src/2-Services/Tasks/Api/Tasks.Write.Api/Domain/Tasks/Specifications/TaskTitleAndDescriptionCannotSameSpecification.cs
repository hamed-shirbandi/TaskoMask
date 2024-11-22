using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Entities;

namespace TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Specifications;

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
