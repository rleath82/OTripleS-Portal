﻿using OTripleS.Portal.Web.Models.Exceptions;
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
                case { } when IsInvalid(student.UserId):
                    throw new InvalidStudentException(parameterName: nameof(Student.UserId), parameterValue: student.UserId);
                case { } when IsInvalid(student.IdentityNumber):
                    throw new InvalidStudentException(parameterName: nameof(Student.IdentityNumber), parameterValue: student.IdentityNumber);
                case { } when IsInvalid(student.FirstName):
                    throw new InvalidStudentException(parameterName: nameof(Student.FirstName), parameterValue: student.FirstName);
                case { } when IsInvalid(student.BirthDate):
                    throw new InvalidStudentException(parameterName: nameof(Student.BirthDate), parameterValue: student.BirthDate);
                case { } when IsInvalid(student.CreatedBy):
                    throw new InvalidStudentException(parameterName: nameof(Student.CreatedBy), parameterValue: student.CreatedBy);
                case { } when IsInvalid(student.UpdatedBy):
                    throw new InvalidStudentException(parameterName: nameof(Student.UpdatedBy), parameterValue: student.UpdatedBy);
            }            
        }

        private static bool IsInvalid(Guid id) => id == Guid.Empty;
        private static bool IsInvalid(string text) => String.IsNullOrWhiteSpace(text);
        private static bool IsInvalid(DateTimeOffset date) => date == default;
    }
}
