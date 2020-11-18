using System;

namespace OTripleS.Portal.Web.Models.Exceptions
{
    public class StudentValidationException : Exception
    {
        public StudentValidationException(Exception innerException)
            : base("Student validation error occurred, try again.", innerException)
        {

        }
    }
}
