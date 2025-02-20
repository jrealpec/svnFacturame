using System;
using System.Collections.Generic;

using FluentValidation.Results;

namespace com.svnFacturame.cloud.domain.Exceptions.Core.Validation
{
  public class ValidateException : Exception
  {
    public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
    public ValidateException(IReadOnlyDictionary<string, string[]> errorDictionary) :
      base("One or more validation errors occurred") => ErrorsDictionary = errorDictionary;
  }
}
