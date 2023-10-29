using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.ValueObjects;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.ValueObjects.Organizations;

public class OrganizationDescription : BaseValueObject
{
    #region Properties

    public string Value { get; private set; }

    #endregion

    #region Ctors

    public OrganizationDescription(string value)
    {
        Value = value;

        CheckPolicies();
    }

    #endregion

    #region  Methods



    /// <summary>
    /// Factory method for creating new object
    /// </summary>
    public static OrganizationDescription Create(string value)
    {
        return new OrganizationDescription(value);
    }

    /// <summary>
    ///
    /// </summary>
    protected override void CheckPolicies()
    {
        if (string.IsNullOrEmpty(Value))
            return;

        if (Value.Length > DomainConstValues.ORGANIZATION_DESCRIPTION_MAX_LENGTH)
        {
            throw new DomainException(
                string.Format(
                    ContractsMetadata.Max_Length_Error,
                    nameof(OrganizationDescription),
                    DomainConstValues.ORGANIZATION_DESCRIPTION_MAX_LENGTH
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
