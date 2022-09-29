using System.ComponentModel;

namespace schoolapi.Controllers.Models.Request
{
    [DisplayName("CreateStudentGuardian")]
    public class CreateStudentGuardianRequest
    {
        internal int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string? Email { get; set; }
    }
}