using System;
using TaskoMask.Services.Monolith.Application.Core.Extensions;
using TaskoMask.Services.Monolith.Domain.Core.Exceptions;

namespace TaskoMask.Services.Monolith.Application.Core.Exceptions
{

    /// <summary>
    /// 
    /// </summary>
    public class ApplicationException : DomainException
    {
        #region Ctors


        /// <summary>
        /// 
        /// </summary>
        public ApplicationException(string message) : base(message)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        public ApplicationException(string message, string metadata) : base(string.Format(message, metadata))
        {
        }


        #endregion
    }
}