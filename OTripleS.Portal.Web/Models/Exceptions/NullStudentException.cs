using System;

namespace OTripleS.Portal.Web.Models.Exceptions
{
    public class NullStudentException : Exception
    {
        public NullStudentException() : base("Null student error occurred.")
        {

        }
    }
}
