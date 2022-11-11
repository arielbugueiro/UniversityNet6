using System.ComponentModel.DataAnnotations;

namespace UniversityAPiBackEnd.Models.DataModels
{
    public class Curso : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        public string LongDescription { get; set; } = string.Empty;
        public string ObjectivePublic { get; set; } = string.Empty;
        public string Objective { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;
        public enum Level { Basic, Intermediate, Advanced };
    }
}
