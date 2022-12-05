using System.Linq;
using UniversityAPiBackEnd.DataAccess;
using UniversityAPiBackEnd.Models.DataModels;

namespace UniversityAPiBackEnd.Services
{
    public class Services
    {
        private readonly UniversityDbContext _context;
        public Services(UniversityDbContext context) 
        {
            _context = context;
        }

        //Buscar usuarios por email
        public void UserByEmail()
        {
            var UserEmail = from userEmail in _context.Users where userEmail.Email != null select userEmail;

            foreach (var emailUser in UserEmail)
            {
                Console.WriteLine(emailUser);
            }
        }

        //Buscar alumnos que tengan al menos un curso

        public void StudentCourse()
        {
            var StudentCourse = from student in _context.Students
                                join course in _context.Courses
                                on student.Id equals course.Id
                                select new { student, course };

            foreach (var studentInCourse in StudentCourse)
            {
                Console.WriteLine(studentInCourse);
            }
        }

        //Buscar cursos de un nivel determinado que al menos tengan un alumno inscrito

        public void CourseStudent()
        {
            var StudentCourseBasic = from student in _context.Students
                                join course in _context.Courses
                                on student.Id equals course.Id
                                where course.LevelType.Equals("Basic")
                                select new { student, course };

            foreach (var studentInCourse in StudentCourseBasic)
            {
                Console.WriteLine(studentInCourse);
            }
        }

        //Buscar cursos de un nivel determinado que sean de una categoría determinada
        public void CourseBasicCategory()
        {
            var CourseBasicCategory = from category in _context.Categories
                                     join course in _context.Courses
                                     on category.Id equals course.Id
                                     where course.LevelType.Equals("Basic")
                                     select new { category, course };

            foreach (var courseBasicCategory in CourseBasicCategory)
            {
                Console.WriteLine(courseBasicCategory);
            }
        }

        //Buscar cursos sin alumnos
        public void CourseWithoutStudents()
        {
            var courseWithoutStudents = from students in _context.Students
                                        join course in _context.Courses
                                        on students.Id equals course.Id
                                        where students.Id.Equals(null)
                                        select new { students, course };

            foreach (var courseNoStudent in courseWithoutStudents)
            {
                Console.WriteLine(courseNoStudent);
            }
        }
    }
}
