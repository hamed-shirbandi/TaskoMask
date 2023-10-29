using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.ValueObjects;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Boards.ValueObjects.Boards;

public class BoardDescription : BaseValueObject
{
    #region Properties

    public string Value { get; private set; }

    #endregion

    #region Ctors

    public BoardDescription(string value)
    {
        Value = value;

        CheckPolicies();
    }

    #endregion

    #region  Methods



    /// <summary>
    /// Factory method for creating new object
    /// </summary>
    public static BoardDescription Create(string value)
    {
        return new BoardDescription(value);
    }

    /// <summary>
    ///
    /// </summary>
    protected override void CheckPolicies()
    {
        if (string.IsNullOrEmpty(Value))
            return;

        if (Value.Length > DomainConstValues.BOARD_DESCRIPTION_MAX_LENGTH)
        {
            throw new DomainException(
                string.Format(ContractsMetadata.Max_Length_Error, nameof(BoardDescription), DomainConstValues.BOARD_DESCRIPTION_MAX_LENGTH)
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
