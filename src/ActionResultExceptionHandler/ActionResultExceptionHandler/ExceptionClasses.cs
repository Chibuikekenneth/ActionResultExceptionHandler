using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace ActionResultExceptionHandler
{
    public class ExceptionClasses
    {
    }

    /// <summary>
    /// Handles Identity Exception
    /// </summary>
    /// <value></value>
    public class IdentityException : Exception
    {
        public string Code { get; set; }

        public IdentityException(string code, string message) : base(message)
        {
            Code = code;
        }
    }

    /// <summary>
    /// Handles Conflict Exceptions
    /// </summary>
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Handles Unauthorized Exceptions
    /// </summary>
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
        {

        }
        public UnauthorizedException(string message) : base(message)
        {

        }
    }

    /// <summary>
    /// Handles ModelState Exceptions
    /// </summary>
    public class ModelStateException : Exception
    {
        private ModelStateDictionary _ModelState;
        public ModelStateException()
        {

        }

        public ModelStateException(ModelStateDictionary ModelState)
        {
            _ModelState = ModelState;
        }
    }
}
