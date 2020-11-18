using OTripleS.Portal.Web.Models.Students;
using System.Threading.Tasks;

namespace OTripleS.Portal.Web.Brokers.API
{
    public partial class ApiBroker
    {
        private const string RelativeUrl = "api/students";

        public async ValueTask<Student> PostStudentAsync(Student student) =>
            await this.PostAsync(RelativeUrl, student);
    }
}
