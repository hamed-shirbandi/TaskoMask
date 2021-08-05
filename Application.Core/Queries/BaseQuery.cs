using MediatR;

namespace TaskoMask.Application.Core.Queries
{
    public abstract class BaseQuery<T> : IRequest<T> 
    {

    }
}