using System;
using System.Collections.Generic;
using System.Text;

namespace FluentResult.Core.ResultExtensions
{
  public static class OnFailureExtensions
  {
    public static Result<T, E> OnFailure<T, E>(this Result<T, E> result,
               Action action)
    {
      if (result.IsFailure)
      {
        action();
      }

      return result;
    }

    public static Result<T> OnFailure<T>(this Result<T> result, Action action)
    {
      if (result.IsFailure)
      {
        action();
      }

      return result;
    }

    public static Result OnFailure(this Result result, Action action)
    {
      if (result.IsFailure)
      {
        action();
      }

      return result;
    }

    public static Result<T, E> OnFailure<T, E>(this Result<T, E> result,
        Action<E> action)
    {
      if (result.IsFailure)
      {
        action(result.Error);
      }

      return result;
    }

    public static Result<T> OnFailure<T>(this Result<T> result, Action<string> action)
    {
      if (result.IsFailure)
      {
        action(result.Error);
      }

      return result;
    }

    public static Result OnFailure(this Result result, Action<string> action)
    {
      if (result.IsFailure)
      {
        action(result.Error);
      }

      return result;
    }
  }
}
