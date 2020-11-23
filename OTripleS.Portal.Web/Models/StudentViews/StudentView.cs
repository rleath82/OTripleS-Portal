using System;

namespace OTripleS.Portal.Web.Models.StudentViews
{
    public class StudentView
    {
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public StudentViewGender Gender { get; set; }
    }
}
