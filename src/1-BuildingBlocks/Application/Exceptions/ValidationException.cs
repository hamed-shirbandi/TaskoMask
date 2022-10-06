using TaskoMask.BuildingBlocks.Domain.Exceptions;

namespace TaskoMask.BuildingBlocks.Application.Exceptions
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