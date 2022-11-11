using Microsoft.EntityFrameworkCore;
using UniversityAPiBackEnd.Models.DataModels;

namespace UniversityAPiBackEnd.DataAccess
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base (options)
        {

        }

        //Add DbSets (Tables of our Data Base)

        public DbSet<User> Users { get; set; }
        public DbSet<Curso> Cursos { get; set; }
    }
}
