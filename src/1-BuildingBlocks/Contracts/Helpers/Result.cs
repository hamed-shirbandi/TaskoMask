using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Helpers;

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
            message = isSuccess ? ContractsMessages.Operation_Success : ContractsMessages.Operation_Failed;

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

    public static Result Failure(List<string> errors = default, string message = "")
    {
        return new Result(false, message, errors);
    }

    public static Result<TValue> Success<TValue>(TValue value = default, string message = "")
    {
        return new Result<TValue>(true, message, value, default);
    }

    public static Result<TValue> Failure<TValue>(List<string> errors = default, string message = "")
    {
        return new Result<TValue>(false, message, default, errors);
    }

    #endregion
}

/// <summary>
///
/// </summary>
public struct Result<TValue> : IResult
{
    #region Properties


    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    public TValue Value { get; set; }

    #endregion

    #region Ctors


    public Result(bool isSuccess, string message, TValue value, List<string> errors)
    {
        if (message == "")
            message = isSuccess ? ContractsMessages.Operation_Success : ContractsMessages.Operation_Failed;

        IsSuccess = isSuccess;
        Message = message;
        Value = value;
        Errors = errors ?? new List<string>();
    }

    #endregion
}
