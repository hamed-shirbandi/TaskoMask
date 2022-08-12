using System;
namespace TaskoMask.Domain.Core.Exceptions
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