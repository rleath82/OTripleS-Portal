using Moq;
using OTripleS.Portal.Web.Models.Exceptions;
using OTripleS.Portal.Web.Models.Students;
using RESTFulSense.Exceptions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace OTripleS.Portal.Web.Tests.Unit.Services.Students
{
    public partial class StudentServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRegisterIfBadRequestErrorOccursAndLogItAsync()
        {
            // given
            Student someStudent = CreateRandomStudent();
            string exceptionMessage = GetRandomString();
            var responseMessage = new HttpResponseMessage();

            var httpResponseBadRequestException = new HttpResponseBadRequestException(responseMessage: responseMessage, message: exceptionMessage);

            var expectedDependencyValidationException = new StudentDependencyValidationException(httpResponseBadRequestException);

            this.apiBrokerMock.Setup(broker =>
                broker.PostStudentAsync(It.IsAny<Student>()))
                    .ThrowsAsync(httpResponseBadRequestException);
            // when
            ValueTask<Student> registerStudentTask = this.studentService.RegisterStudentAsync(someStudent);

            // then
            await Assert.ThrowsAsync<StudentDependencyValidationException>(() =>
                registerStudentTask.AsTask());

            this.apiBrokerMock.Verify(broker =>
                broker.PostStudentAsync(It.IsAny<Student>()),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedDependencyValidationException))),
                    Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();            
        }
    }
}
