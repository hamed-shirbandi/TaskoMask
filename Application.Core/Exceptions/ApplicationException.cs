using System;
using TaskoMask.Application.Core.Extensions;
using TaskoMask.Domain.Core.Exceptions;

namespace TaskoMask.Application.Core.Exceptions
{
    public class ApplicationException : DomainException
    {
 
        public ApplicationException(string message): base(message)
        {
        }


        public ApplicationException(string message, Type objectType): base(string.Format(message, objectType.GetDisplayName()))
        {
        }
    }
}