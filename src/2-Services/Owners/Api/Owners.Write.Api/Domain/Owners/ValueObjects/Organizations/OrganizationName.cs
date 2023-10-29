using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.ValueObjects;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.ValueObjects.Organizations;

public class OrganizationName : BaseValueObject
{
    #region Properties

    public string Value { get; private set; }

    #endregion

    #region Ctors

    public OrganizationName(string value)
    {
        Value = value;

        CheckPolicies();
    }

    #endregion

    #region  Methods



    /// <summary>
    /// Factory method for creating new object
    /// </summary>
    public static OrganizationName Create(string value)
    {
        return new OrganizationName(value);
    }

    /// <summary>
    ///
    /// </summary>
    protected override void CheckPolicies()
    {
        if (string.IsNullOrEmpty(Value))
            throw new DomainException(string.Format(ContractsMetadata.Required, nameof(OrganizationName)));

        if (Value.Length < DomainConstValues.ORGANIZATION_NAME_MIN_LENGTH)
        {
            throw new DomainException(
                string.Format(
                    ContractsMetadata.Length_Error,
                    nameof(OrganizationName),
                    DomainConstValues.ORGANIZATION_NAME_MIN_LENGTH,
                    DomainConstValues.ORGANIZATION_NAME_MAX_LENGTH
                )
            );
        }

        if (Value.Length > DomainConstValues.ORGANIZATION_NAME_MAX_LENGTH)
        {
            throw new DomainException(
                string.Format(
                    ContractsMetadata.Length_Error,
                    nameof(OrganizationName),
                    DomainConstValues.ORGANIZATION_NAME_MIN_LENGTH,
                    DomainConstValues.ORGANIZATION_NAME_MAX_LENGTH
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
