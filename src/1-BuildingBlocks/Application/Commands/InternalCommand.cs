using MediatR;

namespace TaskoMask.BuildingBlocks.Application.Commands
{
    public abstract class InternalCommand<TCommandResult> : IRequest<TCommandResult>
    {
    }
}