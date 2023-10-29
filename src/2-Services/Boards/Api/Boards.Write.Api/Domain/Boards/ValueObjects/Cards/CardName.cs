using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.ValueObjects;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Boards.ValueObjects.Cards;

public class CardName : BaseValueObject
{
    #region Properties

    public string Value { get; private set; }

    #endregion

    #region Ctors

    public CardName(string value)
    {
        Value = value;

        CheckPolicies();
    }

    #endregion

    #region  Methods



    /// <summary>
    /// Factory method for creating new object
    /// </summary>
    public static CardName Create(string value)
    {
        return new CardName(value);
    }

    /// <summary>
    ///
    /// </summary>
    protected override void CheckPolicies()
    {
        if (string.IsNullOrEmpty(Value))
            throw new DomainException(string.Format(ContractsMetadata.Required, nameof(CardName)));

        if (Value.Length < DomainConstValues.CARD_NAME_MIN_LENGTH)
        {
            throw new DomainException(
                string.Format(
                    ContractsMetadata.Length_Error,
                    nameof(CardName),
                    DomainConstValues.CARD_NAME_MIN_LENGTH,
                    DomainConstValues.CARD_NAME_MAX_LENGTH
                )
            );
        }

        if (Value.Length > DomainConstValues.CARD_NAME_MAX_LENGTH)
        {
            throw new DomainException(
                string.Format(
                    ContractsMetadata.Length_Error,
                    nameof(CardName),
                    DomainConstValues.CARD_NAME_MIN_LENGTH,
                    DomainConstValues.CARD_NAME_MAX_LENGTH
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
