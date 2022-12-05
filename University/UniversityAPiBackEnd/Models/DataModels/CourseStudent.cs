namespace UniversityAPiBackEnd.Models.DataModels
{
    public class CourseStudent : BaseEntity
    {
        public int IdCourse { get; set; }
        public Course Course { get; set; }
        public int IdStudent { get; set; }
        public Student Student { get; set; }
    }
}
