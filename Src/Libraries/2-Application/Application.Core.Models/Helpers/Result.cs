using System.Collections.Generic;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Share.Helpers
{

    /// <summary>
    /// 
    /// </summary>
    public interface IResult
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// global message if success or fail
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        ///
        /// </summary>
        public List<string> Errors { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public struct Result : IResult
    {
        #region Properties


        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<string> Errors { get; set; }


        #endregion

        #region Ctors


        public Result(bool isSuccess, string message, List<string> errors)
        {
            if (message == "")
                message = isSuccess?DomainMessages.Operation_Success: DomainMessages.Operation_Failed;

            IsSuccess = isSuccess;
            Message = message;
            Errors = errors ?? new List<string>();
        }


        #endregion

        #region Public Methods


        public static Result Success(string message = "")
        {
            return new Result(true, message, default);
        }



        public static Result Failure( List<string> errors = default, string message = "")
        {
            return new Result(false, message, errors);
        }



        public static Result<T> Success<T>(T value = default,string message = "" )
        {
            return new Result<T>(true, message, value, default);
        }



        public static Result<T> Failure<T>(List<string> errors= default, string message= "")
        {
            return new Result<T>(false, message, default, errors);
        }



        #endregion
    }



    /// <summary>
    /// 
    /// </summary>
    public struct Result<T> : IResult
    {
        #region Properties


        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Value { get; set; }


        #endregion

        #region Ctors


        public Result(bool isSuccess, string message, T value, List<string> errors)
        {
            if (message == "")
                message = isSuccess ? DomainMessages.Operation_Success : DomainMessages.Operation_Failed;

            IsSuccess = isSuccess;
            Message = message;
            Value = value;
            Errors = errors ?? new List<string>();
        }


        #endregion
    }
}