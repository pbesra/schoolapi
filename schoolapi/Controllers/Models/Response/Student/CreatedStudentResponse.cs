using schoolapi.Controllers.ApiMetaData;
using schoolapi.Controllers.Models.Request;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace schoolapi.Controllers.Models.Response.Student
{
    public class CreatedStudentResponse
    {
        public int Id { get; set; }
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

        [DisplayName("MetaData")]
        public IEnumerable<ResourceLink> _MetaData { get; set; }
    }
}
