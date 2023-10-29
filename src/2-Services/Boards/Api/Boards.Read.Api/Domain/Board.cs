using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Entities;
using TaskoMask.BuildingBlocks.Domain.Exceptions;

namespace TaskoMask.Services.Boards.Read.Api.Domain;

public class Board : BaseEntity
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="id">Id Must sync with write side DB</param>
    public Board(string id)
    {
        if (string.IsNullOrEmpty(id))
            throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(id)));

        SetId(id);
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string ProjectId { get; set; }
    public string OrganizationId { get; set; }
    public string OwnerId { get; set; }
    public string ProjectName { get; set; }
    public string OrganizationName { get; set; }

    #region Update private properties


    public void SetAsUpdated()
    {
        UpdateModifiedDateTime();
    }

    #endregion
}
