using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTripleS.Portal.Web.Models.Exceptions
{
    public class StudentDependencyValidationException : Exception
    {
        public StudentDependencyValidationException(Exception innerException)
            : base("Student dependency validation error occurred, try again.", innerException) { }
    }
}
