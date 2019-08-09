using FluentResult.Core.ResultExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FluentResult.Core.Tests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void SomeTestMethod_Succes()
    {
      var result = Result.Ok(new testType());

      result.Ensure(e => e.intValue == 5, "String must be 1")
            .OnSuccess(e => e.intValue = 2)
            .OnSuccess(() => Console.WriteLine("Success"))
            .OnFailure(() => Console.WriteLine("Failure"))
            .OnFailure(e => Console.WriteLine(result.Error));

      Console.WriteLine("end of test");
    }


    [TestMethod]
    public void SomeTestMethod_Failure()
    {
      var result = Result.Fail<testType>("yo men, what the fuck happened?");

      result.Ensure(e => e.intValue == 5, "String must be 1")
            .OnSuccess(e => e.intValue = 2)
            .OnSuccess(() => Console.WriteLine("Success"))
            .OnFailure(() => Console.WriteLine("Failure"))
            .OnFailure(e => Console.WriteLine(result.Error));

      string error = result.Error;

      Assert.AreEqual(result.Error, "yo men, what the fuck happened?");

    }


  }

  public class testType
  {
    public int intValue { get; set; } = 1;

    public string stringValue { get; set; } = "Test";


  }

}

