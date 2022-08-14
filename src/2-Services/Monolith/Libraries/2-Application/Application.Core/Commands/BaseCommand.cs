using MediatR;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.Services.Monolith.Application.Core.Commands
{
    public abstract class BaseCommand : IRequest<CommandResult>
    {
    }
}