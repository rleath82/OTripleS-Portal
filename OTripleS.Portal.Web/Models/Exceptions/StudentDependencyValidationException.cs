using System;

namespace OTripleS.Portal.Web.Models.Exceptions
{
    public class StudentDependencyValidationException : Exception
    {
        public StudentDependencyValidationException(Exception innerException)
            : base("Student dependency validation error occurred, try again.", innerException) { }
    }
}
