using Moq;
using OTripleS.Portal.Web.Brokers.API;
using OTripleS.Portal.Web.Brokers.Logging;
using OTripleS.Portal.Web.Models.Students;
using OTripleS.Portal.Web.Services.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace OTripleS.Portal.Web.Tests.Unit.Services.Students
{
    public partial class StudentServiceTests
    {
        private readonly Mock<IApiBroker> apiBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IStudentService studentService;

        public StudentServiceTests()
        {
            this.apiBrokerMock = new Mock<IApiBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            this.studentService = new StudentService(apiBroker: this.apiBrokerMock.Object, loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Student CreateRandomStudent() =>
            CreateStudentFiller().Create();

        private Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException => actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message;
        }

        private static Filler<Student> CreateStudentFiller()
        {
            var filler = new Filler<Student>();

            filler.Setup().OnType<DateTimeOffset>().Use(DateTimeOffset.UtcNow);

            return filler;
        }
    }
}
