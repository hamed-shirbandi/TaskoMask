using System;
using TaskoMask.Application.Core.Extensions;
using TaskoMask.Domain.Core.Exceptions;

namespace TaskoMask.Application.Core.Exceptions
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