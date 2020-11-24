using System;

namespace OTripleS.Portal.Web.Models.Exceptions
{
    public class StudentServiceException : Exception
    {
        public StudentServiceException(Exception innerException)
            : base("Student service error occurred, contact support.", innerException) { }
    }
}
