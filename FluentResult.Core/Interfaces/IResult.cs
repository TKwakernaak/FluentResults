using System;
using System.Collections.Generic;
using System.Text;

namespace FluentResult.Core.Tests.Interfaces
{
  public interface IResult
  {
    bool IsFailure { get; }
    bool IsSuccess { get; }
  }
}
