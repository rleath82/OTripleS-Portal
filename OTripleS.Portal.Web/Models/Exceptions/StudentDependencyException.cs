using System;

namespace OTripleS.Portal.Web.Models.Exceptions
{
    public class StudentDependencyException : Exception
    {
        public StudentDependencyException(Exception innerException)
            : base("student dependency error occurred, contact support.", innerException) { }
    }
}
