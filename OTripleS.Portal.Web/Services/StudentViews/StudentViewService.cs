using OTripleS.Portal.Web.Brokers.DateTimes;
using OTripleS.Portal.Web.Brokers.Logging;
using OTripleS.Portal.Web.Models.StudentViews;
using OTripleS.Portal.Web.Services.Students;
using OTripleS.Portal.Web.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ValueTask<StudentView> AddStudentViewAsync(StudentView studentView)
        {
            throw new NotImplementedException();
        }
    }
}
