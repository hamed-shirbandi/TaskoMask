using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Domain.ValueObjects;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Boards.ValueObjects.Cards;

public class CardType : BaseValueObject
{
    #region Properties

    public BoardCardType Value { get; private set; }

    #endregion

    #region Ctors

    public CardType(BoardCardType value)
    {
        Value = value;

        CheckPolicies();
    }

    #endregion

    #region  Methods



    /// <summary>
    /// Factory method for creating new object
    /// </summary>
    public static CardType Create(BoardCardType value)
    {
        return new CardType(value);
    }

    /// <summary>
    ///
    /// </summary>
    protected override void CheckPolicies() { }

    /// <summary>
    ///
    /// </summary>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion
}
