﻿using System;
using TaskoMask.Domain.Core.Exceptions;

namespace TaskoMask.Application.Core.Exceptions
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