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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnRegisterIfStudentUserIdIsInvalidAndLogItAsync(string invalidUserId)
        {
            //given
            Student randomStudent = CreateRandomStudent();
            Student invalidStudent = randomStudent;
            invalidStudent.UserId = invalidUserId;

            var invalidStudentException = new InvalidStudentException(parameterName: nameof(Student.UserId), parameterValue: invalidStudent.UserId);

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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnRegisterIfStudentUserIdentityIsInvalidAndLogItAsync(string invalidIdentity)
        {
            //given
            Student randomStudent = CreateRandomStudent();
            Student invalidStudent = randomStudent;
            invalidStudent.IdentityNumber = invalidIdentity;

            var invalidStudentException = new InvalidStudentException(parameterName: nameof(Student.IdentityNumber), parameterValue: invalidStudent.IdentityNumber);

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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnRegisterIfStudentFirstNameIsInvalidAndLogItAsync(string invalidFirstName)
        {
            //given
            Student randomStudent = CreateRandomStudent();
            Student invalidStudent = randomStudent;
            invalidStudent.FirstName = invalidFirstName;

            var invalidStudentException = new InvalidStudentException(parameterName: nameof(Student.FirstName), parameterValue: invalidStudent.FirstName);

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

        [Fact]
        public async Task ShouldThrowValidationExceptionOnRegisterIfBirthDateIsInvalidAndLogItAsync()
        {
            //given
            DateTimeOffset invalidDate = default;
            Student randomStudent = CreateRandomStudent();
            Student invalidStudent = randomStudent;
            invalidStudent.BirthDate = invalidDate;

            var invalidStudentException = new InvalidStudentException(parameterName: nameof(Student.BirthDate), parameterValue: invalidStudent.BirthDate);

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

        [Fact]
        public async Task ShouldThrowValidationExceptionOnRegisterIfCreatedByIdIsInvalidAndLogItAsync()
        {
            //given
            Guid invalidId = Guid.Empty;
            Student randomStudent = CreateRandomStudent();
            Student invalidStudent = randomStudent;
            invalidStudent.CreatedBy = invalidId;

            var invalidStudentException = new InvalidStudentException(parameterName: nameof(Student.CreatedBy), parameterValue: invalidStudent.CreatedBy);

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

        [Fact]
        public async Task ShouldThrowValidationExceptionOnRegisterIfUpdatedByIdIsInvalidAndLogItAsync()
        {
            //given
            Guid invalidId = Guid.Empty;
            Student randomStudent = CreateRandomStudent();
            Student invalidStudent = randomStudent;
            invalidStudent.UpdatedBy = invalidId;

            var invalidStudentException = new InvalidStudentException(parameterName: nameof(Student.UpdatedBy), parameterValue: invalidStudent.UpdatedBy);

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
