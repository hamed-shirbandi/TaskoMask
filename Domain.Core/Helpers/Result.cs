using System.Collections.Generic;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Domain.Core.Helpers
{
    public interface IResult
    {
        public bool IsSuccess { get; }

        /// <summary>
        /// global message if success or fail
        /// </summary>
        public string Message { get; }

        public List<string> Errors { get; }
    }


    public struct Result : IResult
    {
        #region Properties


        public bool IsSuccess { get; }
        public string Message { get; }

        public List<string> Errors { get; private set; }


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




        public static Result AddError(Result result, string error)
        {
            result.Errors.Add(error);
            return result;
        }


        public static Result<T> AddError<T>(Result<T> result, string error)
        {
            result.Errors.Add(error);
            return result;
        }


        public static Result AddErrors(Result result, List<string> error)
        {
            result.Errors.AddRange(error);
            return result;
        }


        public static Result<T> AddErrors<T>(Result<T> result, List<string> error)
        {
            result.Errors.AddRange(error);
            return result;
        }


        #endregion
    }


    public struct Result<T> : IResult
    {
        #region Properties


        public bool IsSuccess { get; }
        public string Message { get; }
        public List<string> Errors { get; }
        public T Value { get; }


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