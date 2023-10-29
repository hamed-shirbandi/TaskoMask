using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Entities;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.ValueObjects.Cards;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Boards.Entities;

public class Card : BaseEntity
{
    #region Fields


    #endregion

    #region Ctors

    private Card(string name, BoardCardType type)
    {
        SetId(ObjectId.GenerateNewId().ToString());

        Name = CardName.Create(name);
        Type = CardType.Create(type);

        CheckPolicies();
    }

    #endregion

    #region Properties


    public CardName Name { get; private set; }
    public CardType Type { get; private set; }

    #endregion

    #region Public Methods


    /// <summary>
    ///
    /// </summary>
    public static Card Create(string name, BoardCardType type)
    {
        return new Card(name, type);
    }

    /// <summary>
    ///
    /// </summary>
    public void Update(string name, BoardCardType type)
    {
        Name = CardName.Create(name);
        Type = CardType.Create(type);
        UpdateModifiedDateTime();

        CheckPolicies();
    }

    #endregion

    #region Private Methods



    /// <summary>
    ///
    /// </summary>
    private void CheckPolicies()
    {
        if (Name == null)
            throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(Name)));

        if (Type == null)
            throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(Type)));
    }

    #endregion
}
