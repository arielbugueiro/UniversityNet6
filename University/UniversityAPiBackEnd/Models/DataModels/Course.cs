using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAPiBackEnd.Models.DataModels
{
    [Table("course")]
    public class Course : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string ShortDescription { get; set; } = string.Empty;

        public string LongDescription { get; set; } = string.Empty;
        public enum Level { Basic, Intermediate, Advanced, Expert };
        public Level LevelType { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();

        public ICollection<Student> Students { get; set; } = new List<Student>();

        public Chapter Chapter { get; set; } = new Chapter();

    }
}
