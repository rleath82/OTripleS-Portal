using FluentAssertions;
using Moq;
using OTripleS.Portal.Web.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OTripleS.Portal.Web.Tests.Unit.Services.Students
{
    public partial class StudentServiceTests
    {
        [Fact]
        public async Task ShouldRegisterStudentAsync()
        {
            //given
            Student randomStudent = CreateRandomStudent();
            Student inputStudent = randomStudent;
            Student retrievedStudent = inputStudent;
            Student expectedStudent = retrievedStudent;

            this.apiBrokerMock.Setup(broker =>
                broker.PostStudentAsync(inputStudent))
                    .ReturnsAsync(retrievedStudent);

            //when
            Student actualStudent = await this.studentService.RegisterStudentAsync(inputStudent);

            //then
            actualStudent.Should().BeEquivalentTo(expectedStudent);

            this.apiBrokerMock.Verify(broker =>
                broker.PostStudentAsync(inputStudent),
                    Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
