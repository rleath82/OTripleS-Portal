using System;

namespace OTripleS.Portal.Web.Models.Exceptions
{
    public class InvalidStudentException : Exception
    {
        public InvalidStudentException(string parameterName, object parameterValue)
            : base($"Invalid Student error occured, parameter name: {parameterName}, parameter value: {parameterValue}")
        {

        }
    }
}
