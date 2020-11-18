using OTripleS.Portal.Web.Models.Students;
using System.Threading.Tasks;

namespace OTripleS.Portal.Web.Brokers.API
{
    public partial interface IApiBroker
    {
        ValueTask<Student> PostStudentAsync(Student student);
    }
}
