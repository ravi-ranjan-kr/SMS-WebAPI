using Microsoft.EntityFrameworkCore;
using StudentManagementDomainLayer.Models;

namespace StudentManagementRepositoryLayer
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Student> Student { get; set; }

        DbSet<StudentMarks> stuMarks { get; set; }
    }
}
