using FluentResult.Core.Tests.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FluentResult.Core
{
  public partial struct Result<TValue, EError> : IResult
  {
    public bool IsFailure => throw new NotImplementedException();

    public bool IsSuccess => throw new NotImplementedException();

    public EError Error;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly TValue _value;

    public TValue Value
    {
      [DebuggerStepThrough]
      get
      {
        if (!IsSuccess)
          throw new ArgumentException("item is not a failure");

        return _value;
      }
    }

    [DebuggerStepThrough]
    internal Result(bool isFailure, TValue value, EError error)
    {
      _value = value;
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
