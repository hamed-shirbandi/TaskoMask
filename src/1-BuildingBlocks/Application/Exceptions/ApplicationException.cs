using System;
using TaskoMask.BuildingBlocks.Application.Extensions;
using TaskoMask.BuildingBlocks.Domain.Exceptions;

namespace TaskoMask.BuildingBlocks.Application.Exceptions
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