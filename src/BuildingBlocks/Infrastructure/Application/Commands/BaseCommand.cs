using MediatR;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Application.Core.Commands
{
    public abstract class BaseCommand : IRequest<CommandResult>
    {
    }
}