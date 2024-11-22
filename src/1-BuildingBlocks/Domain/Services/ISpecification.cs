namespace TaskoMask.BuildingBlocks.Domain.Services;

public interface ISpecification<TEntity>
{
    /// <summary>
    /// Checks if a given entity satisfies the specification's criteria.
    /// </summary>
    /// <param name="entity">The entity to evaluate.</param>
    /// <returns>True if the entity satisfies the specification; otherwise, false.</returns>
    bool IsSatisfiedBy(TEntity entity);
}
