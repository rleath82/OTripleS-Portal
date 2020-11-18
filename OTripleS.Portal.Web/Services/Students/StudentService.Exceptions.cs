using OTripleS.Portal.Web.Models.Exceptions;
using OTripleS.Portal.Web.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTripleS.Portal.Web.Services.Students
{
    public partial class StudentService
    {
        private delegate ValueTask<Student> ReturningStudentFunction();

        private async ValueTask<Student> TryCatch(ReturningStudentFunction returningStudentFunction)
        {
            try
            {
                return await returningStudentFunction();
            }
            catch (NullStudentException nullStudentException)
            {
                throw CreateAndLogValidationException(nullStudentException);
            }
            catch (InvalidStudentException invalidStudentException)
            {
                throw CreateAndLogValidationException(invalidStudentException);
            }
        }

        private StudentValidationException CreateAndLogValidationException(Exception nullStudentException)
        {
            var studentValidationException = new StudentValidationException(nullStudentException);
            this.loggingBroker.LogError(studentValidationException);

            return studentValidationException;
        }
    }
}
