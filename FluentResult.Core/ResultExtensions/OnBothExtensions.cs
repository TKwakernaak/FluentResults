﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FluentResult.Core.ResultExtensions
{
  public static class OnBothExtensions
  {
    public static T OnBoth<T>(this Result result, Func<Result, T> func)
    {
      return func(result);
    }

    public static K OnBoth<T, K>(this Result<T> result, Func<Result<T>, K> func)
    {
      return func(result);
    }

    public static K OnBoth<T, K, E>(this Result<T, E> result, Func<Result<T, E>, K> func)
    {
      return func(result);
    }

    public static T OnBoth<T, E>(this Result<T, E> result,
        Func<Result<T, E>, T> func)
    {
      return func(result);
    }
  }
}
