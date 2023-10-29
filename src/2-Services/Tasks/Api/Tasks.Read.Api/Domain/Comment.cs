using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Entities;
using TaskoMask.BuildingBlocks.Domain.Exceptions;

namespace TaskoMask.Services.Tasks.Read.Api.Domain;

/// <summary>
/// Every board's member can leave comment on tasks
/// </summary>
public class Comment : BaseEntity
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="id">Id Must sync with write side DB</param>
    public Comment(string id)
    {
        if (string.IsNullOrEmpty(id))
            throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(id)));

        SetId(id);
    }

    public string Content { get; set; }
    public string TaskId { get; set; }

    #region Update private properties

    public void SetAsUpdated()
    {
        UpdateModifiedDateTime();
    }

    #endregion
}
