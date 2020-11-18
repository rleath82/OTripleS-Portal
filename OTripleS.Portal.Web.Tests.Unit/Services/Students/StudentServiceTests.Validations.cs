﻿using Moq;
using OTripleS.Portal.Web.Models.Exceptions;
using OTripleS.Portal.Web.Models.Students;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OTripleS.Portal.Web.Tests.Unit.Services.Students
{
    public partial class StudentServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnRegisterIfStudentIsNullAndLogItAsync()
        {
            //given
            Student invalidStudent = null;
            var nullStudentException = new NullStudentException();

            var expectedStudentValidationException = new StudentValidationException(nullStudentException);

            //when
            ValueTask<Student> submitStudentTask = this.studentService.RegisterStudentAsync(invalidStudent);

            //then
            await Assert.ThrowsAsync<StudentValidationException>(() =>
                submitStudentTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedStudentValidationException))),
                    Times.Once);

            this.apiBrokerMock.Verify(broker =>
                broker.PostStudentAsync(It.IsAny<Student>()),
                    Times.Never);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnRegisterIfStudentIdIsInvalidAndLogItAsync()
        {
            //given
            Guid invalidId = Guid.Empty;
            Student randomStudent = CreateRandomStudent();
            Student invalidStudent = randomStudent;
            invalidStudent.Id = invalidId;

            var invalidStudentException = new InvalidStudentException(parameterName: nameof(Student.Id), parameterValue: invalidStudent.Id);

            var expectedStudentValidationException = new StudentValidationException(invalidStudentException);

            //when
            ValueTask<Student> registerStudentTask = this.studentService.RegisterStudentAsync(invalidStudent);

            //then
            await Assert.ThrowsAsync<StudentValidationException>(() =>
                registerStudentTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>            
                broker.LogError(It.Is(SameExceptionAs(expectedStudentValidationException))),
                    Times.Once);

            this.apiBrokerMock.Verify(broker =>
                broker.PostStudentAsync(It.IsAny<Student>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.apiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
