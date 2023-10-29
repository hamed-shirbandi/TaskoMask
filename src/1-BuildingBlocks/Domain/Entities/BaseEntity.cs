using TaskoMask.BuildingBlocks.Domain.ValueObjects;

namespace TaskoMask.BuildingBlocks.Domain.Entities;

/// <summary>
///
/// </summary>
public abstract class BaseEntity : Entity
{
    #region Ctors

    public BaseEntity()
    {
        CreationTime = CreationTime.CreateNowDateTime();
    }

    #endregion

    #region Properties

    public CreationTime CreationTime { get; private set; }

    #endregion

    #region Public Methods





    #endregion


    #region protected Methods


    /// <summary>
    ///
    /// </summary>
    protected void UpdateModifiedDateTime()
    {
        CreationTime = CreationTime.UpdateModifiedDateTime();
    }

    #endregion
}
