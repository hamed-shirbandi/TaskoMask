using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.ValueObjects;

namespace TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.ValueObjects.Tasks;

public class TaskDescription : BaseValueObject
{
    #region Properties

    public string Value { get; private set; }

    #endregion

    #region Ctors

    public TaskDescription(string value)
    {
        Value = value;

        CheckPolicies();
    }

    #endregion

    #region  Methods



    /// <summary>
    /// Factory method for creating new object
    /// </summary>
    public static TaskDescription Create(string value)
    {
        return new TaskDescription(value);
    }

    /// <summary>
    ///
    /// </summary>
    protected override void CheckPolicies()
    {
        if (string.IsNullOrEmpty(Value))
            return;

        if (Value.Length > DomainConstValues.TASK_DESCRIPTION_MAX_LENGTH)
        {
            throw new DomainException(
                string.Format(ContractsMetadata.Max_Length_Error, nameof(TaskDescription), DomainConstValues.TASK_DESCRIPTION_MAX_LENGTH)
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
