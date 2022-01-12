

namespace TaskoMask.Domain.Core.Specifications
{
    public interface ISpecification<T> 
    {
        bool IsSatisfiedBy(T entity);
    }
}
