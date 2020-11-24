using OTripleS.Portal.Web.Brokers.DateTimes;
using OTripleS.Portal.Web.Brokers.Logging;
using OTripleS.Portal.Web.Models.Students;
using OTripleS.Portal.Web.Models.StudentViews;
using OTripleS.Portal.Web.Services.Students;
using OTripleS.Portal.Web.Services.Users;
using System;
using System.Threading.Tasks;

namespace OTripleS.Portal.Web.Services.StudentViews
{
    public class StudentViewService : IStudentViewService
    {
        private readonly IStudentService studentService;
        private readonly IUserService userService;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public StudentViewService(IStudentService studentService, IUserService userService, IDateTimeBroker dateTimeBroker, ILoggingBroker loggingBroker)
        {
            this.studentService = studentService;
            this.userService = userService;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<StudentView> AddStudentViewAsync(StudentView studentView)
        {
            Student student = MapToStudent(studentView);
            await this.studentService.RegisterStudentAsync(student);

            return studentView;
        }

        private Student MapToStudent(StudentView studentView)
        {
            Guid currentLoggedInUserId = this.userService.GetCurrentlyLoggedInUser();
            DateTimeOffset currentDateTime = this.dateTimeBroker.GetCurrentDateTime();

            return new Student
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid().ToString(),
                IdentityNumber = studentView.IdentityNumber,
                FirstName = studentView.FirstName,
                MiddleName = studentView.MiddleName,
                LastName = studentView.LastName,
                Gender = (StudentGender)studentView.Gender,
                BirthDate = studentView.BirthDate,
                CreatedBy = currentLoggedInUserId,
                UpdatedBy = currentLoggedInUserId,
                CreatedDate = currentDateTime,
                UpdatedDate = currentDateTime
            };
        }
    }
}
