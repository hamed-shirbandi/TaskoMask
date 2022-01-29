

namespace TaskoMask.Domain.Core.Specifications
{
    public interface ISpecification<TEntity> 
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}
