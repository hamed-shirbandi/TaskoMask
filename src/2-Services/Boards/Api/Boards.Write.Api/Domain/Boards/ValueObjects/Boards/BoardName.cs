using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.ValueObjects;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Boards.ValueObjects.Boards;

public class BoardName : BaseValueObject
{
    #region Properties

    public string Value { get; private set; }

    #endregion

    #region Ctors

    public BoardName(string value)
    {
        Value = value;

        CheckPolicies();
    }

    #endregion

    #region  Methods



    /// <summary>
    /// Factory method for creating new object
    /// </summary>
    public static BoardName Create(string value)
    {
        return new BoardName(value);
    }

    /// <summary>
    ///
    /// </summary>
    protected override void CheckPolicies()
    {
        if (string.IsNullOrEmpty(Value))
            throw new DomainException(string.Format(ContractsMetadata.Required, nameof(BoardName)));

        if (Value.Length < DomainConstValues.BOARD_NAME_MIN_LENGTH)
        {
            throw new DomainException(
                string.Format(
                    ContractsMetadata.Length_Error,
                    nameof(BoardName),
                    DomainConstValues.BOARD_NAME_MIN_LENGTH,
                    DomainConstValues.BOARD_NAME_MAX_LENGTH
                )
            );
        }

        if (Value.Length > DomainConstValues.BOARD_NAME_MAX_LENGTH)
        {
            throw new DomainException(
                string.Format(
                    ContractsMetadata.Length_Error,
                    nameof(BoardName),
                    DomainConstValues.BOARD_NAME_MIN_LENGTH,
                    DomainConstValues.BOARD_NAME_MAX_LENGTH
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
