namespace TaskoMask.BuildingBlocks.Domain.Entities;

/// <summary>
///
/// </summary>
public abstract class Entity
{
    public Entity() { }

    public string Id { get; private set; }

    /// <summary>
    ///
    /// </summary>
    protected void SetId(string id)
    {
        Id = id;
    }
}
