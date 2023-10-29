using TaskoMask.BuildingBlocks.Contracts.Exceptions;

namespace TaskoMask.BuildingBlocks.Domain.Exceptions;

/// <summary>
///
/// </summary>
public class DomainException : ManagedException
{
    public DomainException(string message)
        : base(message) { }
}
