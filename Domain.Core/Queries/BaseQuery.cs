using MediatR;

namespace TaskoMask.Domain.Core.Queries
{
    public abstract class BaseQuery<T> : IRequest<T> 
    {

    }
}