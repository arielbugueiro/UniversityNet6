using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAPiBackEnd.Models.DataModels
{
    [Table("user")]
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;        
    }
}
