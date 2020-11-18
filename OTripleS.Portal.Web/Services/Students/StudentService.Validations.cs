using OTripleS.Portal.Web.Models.Exceptions;
using OTripleS.Portal.Web.Models.Students;
using System;

namespace OTripleS.Portal.Web.Services.Students
{
    public partial class StudentService
    {
        private void ValidateStudent(Student student)
        {
            switch(student)
            {
                case null: 
                    throw new NullStudentException();
                case { } when IsInvalid(student.Id):
                    throw new InvalidStudentException(parameterName: nameof(Student.Id), parameterValue: student.Id);
            }            
        }

        private static bool IsInvalid(Guid id) => id == Guid.Empty;
    }
}
