using MediatR;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.BuildingBlocks.Application.Commands;

public abstract class BaseCommand : IRequest<CommandResult> { }
