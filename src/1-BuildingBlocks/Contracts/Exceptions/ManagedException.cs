using System;

namespace TaskoMask.BuildingBlocks.Contracts.Exceptions;

/// <summary>
///
/// </summary>
public class ManagedException : Exception
{
    public ManagedException(string message)
        : base(message) { }
}
