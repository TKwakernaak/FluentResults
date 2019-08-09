using System;
using System.Diagnostics;

namespace FluentResult.Core
{
  public partial struct Result
  {
    private static readonly Result OkResult = new Result(false, null);

    public bool IsSuccess => !IsFailure;

    public bool IsFailure { get; }

    public string Error;

    [DebuggerStepThrough]
    private Result(bool isFailure, string error)
    {
      this.IsFailure = isFailure;
      this.Error     = error;
    }


    [DebuggerStepThrough]
    public static Result Ok()
    {
      return OkResult;
    }


    [DebuggerStepThrough]
    public static Result<T> Ok<T>(T value)
    {
      return new Result<T>(false, value, null);
    }

    [DebuggerStepThrough]
    public static Result Fail(string error)
    {
      return new Result(true, error);
    }

    [DebuggerStepThrough]
    public static Result<T> Fail<T>(string error)
    {
      return new Result<T>(true, default(T), error);
    }



    public static Result Create(bool isSuccess, string error)
    {
      return isSuccess
          ? Ok()
          : Fail(error);
    }


  }
}
