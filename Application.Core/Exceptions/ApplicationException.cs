using System;
using TaskoMask.Domain.Core.Extensions;

namespace TaskoMask.Application.Core.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException()
        {
        }


        public ApplicationException(string message): base(message)
        {
        }


        public ApplicationException(string message, Exception inner): base(message, inner)
        {
        }


        public ApplicationException(string message, Type objectType): base(string.Format(message, objectType.GetDisplayName()))
        {
        }


    }
}