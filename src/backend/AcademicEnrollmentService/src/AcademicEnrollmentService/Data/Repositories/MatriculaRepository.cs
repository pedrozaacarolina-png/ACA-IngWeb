using System.Collections.Generic;
using System.Linq;
using AcademicEnrollmentService.Domain.Entities;
using AcademicEnrollmentService.Data.Interfaces;

namespace AcademicEnrollmentService.Data.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly List<Matricula> _matriculas;

        public MatriculaRepository()
        {
            // Sample data for demonstration purposes
            _matriculas = new List<Matricula>
            {
                new Matricula { Id = 1, EstudianteId = 101, ProgramaAcademico = "Ingeniería de Sistemas", Tarifa = 500, Estado = "Activo", FechaCreacion = DateTime.Now },
                new Matricula { Id = 2, EstudianteId = 102, ProgramaAcademico = "Ingeniería Industrial", Tarifa = 450, Estado = "Activo", FechaCreacion = DateTime.Now }
            };
        }

        public IEnumerable<Matricula> GetAllMatriculas()
        {
            return _matriculas;
        }

        public void AddMatricula(Matricula matricula)
        {
            matricula.Id = _matriculas.Max(m => m.Id) + 1; // Simple ID generation
            _matriculas.Add(matricula);
        }
    }
}