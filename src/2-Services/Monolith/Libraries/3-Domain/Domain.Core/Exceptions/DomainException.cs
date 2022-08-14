using System;
namespace TaskoMask.Services.Monolith.Domain.Core.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException(string message): base(message)
        {
        }

    }
}