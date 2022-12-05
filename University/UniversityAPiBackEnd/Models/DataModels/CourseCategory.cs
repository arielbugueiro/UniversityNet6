namespace UniversityAPiBackEnd.Models.DataModels
{
    public class CourseCategory : BaseEntity
    {
        public int IdCourse { get; set; }

        public Course Course { get; set; }

        public int IdCategory { get; set; }

        public Category Category { get; set; }

    }
}
