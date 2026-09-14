using Microsoft.EntityFrameworkCore;
using AcademicEnrollmentService.Domain.Entities;

namespace AcademicEnrollmentService.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matricula>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Matricula>()
                .Property(m => m.Estado)
                .IsRequired();

            modelBuilder.Entity<Matricula>()
                .Property(m => m.FechaCreacion)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}