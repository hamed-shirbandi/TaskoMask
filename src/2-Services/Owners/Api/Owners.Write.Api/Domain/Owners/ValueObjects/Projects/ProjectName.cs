using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.ValueObjects;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.ValueObjects.Projects;

public class ProjectName : BaseValueObject
{
    #region Properties

    public string Value { get; private set; }

    #endregion

    #region Ctors

    public ProjectName(string value)
    {
        Value = value;

        CheckPolicies();
    }

    #endregion

    #region  Methods



    /// <summary>
    /// Factory method for creating new object
    /// </summary>
    public static ProjectName Create(string value)
    {
        return new ProjectName(value);
    }

    /// <summary>
    ///
    /// </summary>
    protected override void CheckPolicies()
    {
        if (string.IsNullOrEmpty(Value))
            throw new DomainException(string.Format(ContractsMetadata.Required, nameof(ProjectName)));

        if (Value.Length < DomainConstValues.PROJECT_NAME_MIN_LENGTH)
        {
            throw new DomainException(
                string.Format(
                    ContractsMetadata.Length_Error,
                    nameof(ProjectName),
                    DomainConstValues.PROJECT_NAME_MIN_LENGTH,
                    DomainConstValues.PROJECT_NAME_MAX_LENGTH
                )
            );
        }

        if (Value.Length > DomainConstValues.PROJECT_NAME_MAX_LENGTH)
        {
            throw new DomainException(
                string.Format(
                    ContractsMetadata.Length_Error,
                    nameof(ProjectName),
                    DomainConstValues.PROJECT_NAME_MIN_LENGTH,
                    DomainConstValues.PROJECT_NAME_MAX_LENGTH
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
