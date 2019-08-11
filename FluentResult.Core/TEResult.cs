using FluentResult.Core.Tests.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FluentResult.Core
{
  public partial struct Result<TValue, EError> : IResult
  {
    public bool IsFailure { get; }

    public bool IsSuccess => !IsFailure;

    public EError Error;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly TValue _value;

    public TValue Value
    {
      [DebuggerStepThrough]
      get
      {
        if (!IsSuccess)
          throw new ArgumentException("Cannot access value when operation has state 'failure'");

        return _value;
      }
    }

    [DebuggerStepThrough]
    internal Result(bool isFailure, TValue value, EError error)
    {
      IsFailure  = isFailure;
      _value     = value;
      this.Error = error;
    }

    public static implicit operator Result(Result<TValue, EError> result)
    {
      if (result.IsSuccess)
        return Result.Ok();
      else
        return Result.Fail(result.Error.ToString());
    }

    //public static implicit operator Result<TValue>(Result<TValue, EError> result)
    //{
    //  if (result.IsSuccess)
    //    return Result.Ok(result.Value);
    //  else
    //    return Result.Fail<TValue>(result.Error.ToString());
    //}
  }
}
