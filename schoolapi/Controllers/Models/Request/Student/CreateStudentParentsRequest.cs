using schoolapi.Controllers.Models.Request.Student;
using System.ComponentModel;

namespace schoolapi.Controllers.Models.Request
{
    [DisplayName("CreateStudentParents")]
    public class CreateStudentParentsRequest
    {
        internal int Id { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public IEnumerable<CreateParentsContactRequest> Contacts { get; set; }

        public string? Email { get; set; }
    }
}