using MediatR;

namespace TaskoMask.Domain.Core.Commands
{
    public abstract class BaseCommand : IRequest<CommandResult>
    {
    }
}