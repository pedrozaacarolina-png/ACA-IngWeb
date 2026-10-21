using Microsoft.EntityFrameworkCore;
using AcademicEnrollmentService.Core.Entities;

namespace AcademicEnrollmentService.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Estudiante> Estudiantes { get; set; } = null!;
    }
}