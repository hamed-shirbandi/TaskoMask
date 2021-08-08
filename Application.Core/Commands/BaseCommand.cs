using MediatR;

namespace TaskoMask.Application.Core.Commands
{
    public abstract class BaseCommand : IRequest<CommandResult>
    {
    }
}