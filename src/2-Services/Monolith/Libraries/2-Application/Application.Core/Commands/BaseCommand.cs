using MediatR;
using TaskoMask.Services.Monolith.Application.Share.Helpers;

namespace TaskoMask.Services.Monolith.Application.Core.Commands
{
    public abstract class BaseCommand : IRequest<CommandResult>
    {
    }
}