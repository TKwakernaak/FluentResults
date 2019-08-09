using FluentResult.Core.Tests.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FluentResult.Core
{
  public partial struct Result<T> : IResult
  {
    public bool IsFailure { get; }

    public bool IsSuccess => !IsFailure;

    public string Error { get; }

    private readonly T _value;

    public T Value
    {
      get
      {
        if (!IsSuccess)
          throw new ArgumentException("Cannot access 'Value' for a failed result. It has no value!");

        return _value;
      }
    }

    [DebuggerStepThrough]
    internal Result(bool isFailure, T value, string error)
    {
      this.IsFailure = isFailure; 
      _value = value;
      this.Error = error;
    }


    public static implicit operator Result(Result<T> result)
    {
      if (result.IsSuccess)
        return Result.Ok();
      else
        return Result.Fail(result.Error);
    }
  }

}
