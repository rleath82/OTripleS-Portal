using KellermanSoftware.CompareNetObjects;
using Moq;
using OTripleS.Portal.Web.Brokers.DateTimes;
using OTripleS.Portal.Web.Brokers.Logging;
using OTripleS.Portal.Web.Models.Students;
using OTripleS.Portal.Web.Models.StudentViews;
using OTripleS.Portal.Web.Services.Students;
using OTripleS.Portal.Web.Services.StudentViews;
using OTripleS.Portal.Web.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace OTripleS.Portal.Web.Tests.Unit.Services.StudentViews
{
    public partial class StudentViewServiceTests
    {
        private readonly Mock<IStudentService> studentServiceMock;
        private readonly Mock<IUserService> userServiceMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IStudentViewService studentViewService;

        public StudentViewServiceTests()
        {
            this.studentServiceMock = new Mock<IStudentService>();
            this.userServiceMock = new Mock<IUserService>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            var compareConfig = new ComparisonConfig();
            compareConfig.IgnoreProperty<Student>(student => student.Id);
            compareConfig.IgnoreProperty<Student>(student => student.UserId);
            this.compareLogic = new CompareLogic(compareConfig);

            this.studentViewService = new StudentViewService(
                studentService: this.studentServiceMock.Object,
                userService: this.userServiceMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static dynamic CreateRandomStudentViewProperties(DateTimeOffset auditDates, Guid auditIds)
        {
            StudentGender randomStudentGender = GetRandomGender();

            return new
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid().ToString(),
                IdentityNumber = GetRandomString(),
                FirstName = GetRandomName(),
                MiddleName = GetRandomName(),
                LastName = GetRandomName(),
                BirthDate = GetRandomDate(),
                Gender = randomStudentGender,
                GenderView = (StudentViewGender)randomStudentGender,
                CreatedDate = auditDates,
                UpdatedDate = auditDates,
                CreatedBy = auditIds,
                UpdatedBy = auditIds
            };
        }

        private Expression<Func<Student, bool>> SameStudentAs(Student expectedStudent)
        {
            return actualStudent => this.compareLogic.Compare(expectedStudent, actualStudent)
                    .AreEqual;
        }

        private static string GetRandomName() =>
            new RealNames(NameStyle.FirstName).GetValue();

        private static DateTimeOffset GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static StudentGender GetRandomGender()
        {
            int studentGenderCount = Enum.GetValues(typeof(StudentGender)).Length;

            int randomStudentGenderValue = new IntRange(min: 0, max: studentGenderCount).GetValue();

            return (StudentGender)randomStudentGenderValue;
        }
    }
}
