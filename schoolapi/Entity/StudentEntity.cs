using System.ComponentModel.DataAnnotations;

namespace schoolapi.Entity
{
    public class StudentEntity
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
        public string Parents { get; set; }
        public string Addresses { get; set; }
        public string Guardian { get; set; }
        
    }
}