using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAPiBackEnd.Models.DataModels
{
    [Table("chapter")]
    public class Chapter : BaseEntity
    {
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = new Course();

        public List<string> ListChapters = new List<string>();
    }
}
