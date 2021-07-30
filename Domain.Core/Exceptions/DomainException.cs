using System;
using TaskoMask.Domain.Core.Extensions;

namespace TaskoMask.Domain.Core.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException()
        {
        }


        public DomainException(string message): base(message)
        {
        }


        public DomainException(string message, Exception inner): base(message, inner)
        {
        }


        public DomainException(string message, Type objectType): base(string.Format(message, objectType.GetDisplayName()))
        {
        }


    }
}