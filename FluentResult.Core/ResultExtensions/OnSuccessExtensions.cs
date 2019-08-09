using FluentResult.Core.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentResult.Core
{
  public static class OnSuccessExtensions
  {

    #region Func inputs
    public static Result<TValue> OnSuccess<TValue>(this Result<TValue> result, Func<TValue> func)
    {
      if (result.IsFailure)
        return Result.Fail<TValue>(result.Error);

      return Result.Ok(func());
    }


    public static Result<KResult> OnSuccess<TValue, KResult>(this Result<TValue> result, Func<TValue, KResult> func)
    {
      if (result.IsFailure)
        return Result.Fail<KResult>(result.Error);

      return Result.Ok(func(result.Value));
    }

    public static Result OnSuccess<T>(this Result<T> result, Func<T, Result> func)
    {
      if (result.IsFailure)
        return Result.Fail(result.Error);

      return func(result.Value);
    }

    #endregion Func inputs



    #region action inputs
    public static Result<T> OnSuccess<T>(this Result<T> result, Action<T> action)
    {
      if (result.IsSuccess)
      {
        action(result.Value);
      }

      return result;
    }

    public static Result<T> OnSuccess<T>(this Result<T> result, Action action)
    {
      if (result.IsSuccess)
      {
        action();
      }

      return result;
    }







    #endregion action inputs

  }
}
