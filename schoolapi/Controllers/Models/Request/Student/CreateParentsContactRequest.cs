using System.ComponentModel;

namespace schoolapi.Controllers.Models.Request.Student
{
    [DisplayName("CreateParentsContact")]
    public class CreateParentsContactRequest
    {
        public string Contact { get; set; }
        public string Name { get; set; }
    }
}
