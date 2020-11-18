using OTripleS.Portal.Web.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTripleS.Portal.Web.Services.Students
{
    public interface IStudentService
    {
        ValueTask<Student> RegisterStudentAsync(Student student);
    }
}
