using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.ValueObjects;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.ValueObjects.Owners;

/// <summary>
///
/// </summary>
public class OwnerDisplayName : BaseValueObject
{
    #region Properties

    public string Value { get; private set; }

    #endregion

    #region Ctors

    private OwnerDisplayName(string value)
    {
        Value = value;

        CheckPolicies();
    }

    #endregion

    #region  Methods



    /// <summary>
    /// Factory method for creating new object
    /// </summary>
    public static OwnerDisplayName Create(string value)
    {
        return new OwnerDisplayName(value);
    }

    /// <summary>
    ///
    /// </summary>
    protected override void CheckPolicies()
    {
        if (string.IsNullOrEmpty(Value))
            throw new DomainException(string.Format(ContractsMetadata.Required, nameof(OwnerDisplayName)));

        if (Value.Length < DomainConstValues.OWNER_DISPLAYNAME_MIN_LENGTH)
        {
            throw new DomainException(
                string.Format(
                    ContractsMetadata.Length_Error,
                    nameof(OwnerDisplayName),
                    DomainConstValues.OWNER_DISPLAYNAME_MIN_LENGTH,
                    DomainConstValues.OWNER_DISPLAYNAME_MAX_LENGTH
                )
            );
        }

        if (Value.Length > DomainConstValues.OWNER_DISPLAYNAME_MAX_LENGTH)
        {
            throw new DomainException(
                string.Format(
                    ContractsMetadata.Length_Error,
                    nameof(OwnerDisplayName),
                    DomainConstValues.OWNER_DISPLAYNAME_MIN_LENGTH,
                    DomainConstValues.OWNER_DISPLAYNAME_MAX_LENGTH
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
