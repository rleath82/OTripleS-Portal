using OTripleS.Portal.Web.Models.StudentViews;
using System.Threading.Tasks;

namespace OTripleS.Portal.Web.Services.StudentViews
{
    public interface IStudentViewService
    {
        ValueTask<StudentView> AddStudentViewAsync(StudentView studentView);
    }
}
