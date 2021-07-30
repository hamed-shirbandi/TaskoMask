using System;
using TaskoMask.Domain.Core.Extensions;

namespace TaskoMask.Domain.Core.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message): base(message)
        {
        }

    }
}