using System;
using System.Collections.Generic;
using System.Text;

namespace FluentResult.Core
{
  public static class EnsureExtensions
  {

    public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, string errorMessage)
    {
      if (result.IsFailure)
        return result;

      if (!predicate(result.Value))
        return Result.Fail<T>(errorMessage);

      return result;
    }

    public static Result Ensure(this Result result, Func<bool> predicate, string errorMessage)
    {
      if (result.IsFailure)
        return result;

      if (!predicate())
        return Result.Fail(errorMessage);

      return result;
    }


  }
}
