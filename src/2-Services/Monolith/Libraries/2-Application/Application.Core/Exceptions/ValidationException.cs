using System;
using TaskoMask.Services.Monolith.Domain.Core.Exceptions;

namespace TaskoMask.Services.Monolith.Application.Core.Exceptions
{

    /// <summary>
    /// 
    /// </summary>
    public class ValidationException : DomainException
    {
        #region Ctors

        /// <summary>
        /// 
        /// </summary>
        public ValidationException() : base("")
        {
        }


        /// <summary>
        /// 
        /// </summary>
        public ValidationException(string message) : base(message)
        {
        }


        #endregion
    }
}