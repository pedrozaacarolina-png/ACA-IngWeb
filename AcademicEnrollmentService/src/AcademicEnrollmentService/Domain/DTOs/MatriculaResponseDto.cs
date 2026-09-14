namespace AcademicEnrollmentService.Domain.DTOs
{
    public class MatriculaResponseDto
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public string ProgramaAcademico { get; set; }
        public decimal Tarifa { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}