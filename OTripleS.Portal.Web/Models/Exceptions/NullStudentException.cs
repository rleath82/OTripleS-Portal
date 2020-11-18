using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTripleS.Portal.Web.Models.Exceptions
{
    public class NullStudentException : Exception
    {
        public NullStudentException() : base("Null student error occurred.")
        {

        }
    }
}
