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
            }            
        }

        private static bool IsInvalid(Guid id) => id == Guid.Empty;

        private static bool IsInvalid(string text) => String.IsNullOrWhiteSpace(text);
    }
}
