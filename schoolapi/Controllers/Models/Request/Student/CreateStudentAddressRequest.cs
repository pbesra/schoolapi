using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace schoolapi.Controllers.Models.Request
{
    [DisplayName("CreateStudentAddress")]
    public class CreateStudentAddressRequest
    {
        internal int Id { get; set; }
        public string AddressName { get; set; }

        [Required]
        public string PinCode { get; set; }

        public string Type { get; set; }
    }
}