using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTripleS.Portal.Web.Models.Exceptions
{
    public class StudentValidationException : Exception
    {
        public StudentValidationException(Exception innerException) 
            : base ("Student validation error occurred, try again.", innerException)
        {

        }
    }
}
