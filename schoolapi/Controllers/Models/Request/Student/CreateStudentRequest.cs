using System.ComponentModel;

namespace schoolapi.Controllers.Models.Request
{
    [DisplayName("CreateStudent")]
    public class CreateStudentRequest
    {
        public string Gender { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }
        public bool HasGuardian { get; set; }
        public CreateStudentParentsRequest Parents { get; set; }
        public IEnumerable<CreateStudentAddressRequest> Addresses { get; set; }
        public CreateStudentGuardianRequest? Guardian { get; set; }
    }
}