using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.ValueObjects;

namespace TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.ValueObjects.Tasks;

public class TaskTitle : BaseValueObject
{
    #region Properties

    public string Value { get; private set; }

    #endregion

    #region Ctors

    public TaskTitle(string value)
    {
        Value = value;

        CheckPolicies();
    }

    #endregion

    #region  Methods



    /// <summary>
    /// Factory method for creating new object
    /// </summary>
    public static TaskTitle Create(string value)
    {
        return new TaskTitle(value);
    }

    /// <summary>
    ///
    /// </summary>
    protected override void CheckPolicies()
    {
        if (string.IsNullOrEmpty(Value))
            throw new DomainException(string.Format(ContractsMetadata.Required, nameof(TaskTitle)));

        if (Value.Length < DomainConstValues.TASK_TITLE_MIN_LENGTH)
        {
            throw new DomainException(
                string.Format(
                    ContractsMetadata.Length_Error,
                    nameof(TaskTitle),
                    DomainConstValues.TASK_TITLE_MIN_LENGTH,
                    DomainConstValues.TASK_TITLE_MAX_LENGTH
                )
            );
        }

        if (Value.Length > DomainConstValues.TASK_TITLE_MAX_LENGTH)
        {
            throw new DomainException(
                string.Format(
                    ContractsMetadata.Length_Error,
                    nameof(TaskTitle),
                    DomainConstValues.TASK_TITLE_MIN_LENGTH,
                    DomainConstValues.TASK_TITLE_MAX_LENGTH
                )
            );
        }
    }

    /// <summary>
    ///
    /// </summary>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion
}
