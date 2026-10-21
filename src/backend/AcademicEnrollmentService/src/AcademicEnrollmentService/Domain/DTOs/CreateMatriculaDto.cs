namespace AcademicEnrollmentService.Domain.DTOs
{
    public class CreateMatriculaDto
    {
        public int EstudianteId { get; set; }
        public string ProgramaAcademico { get; set; }
        public decimal Tarifa { get; set; }
    }
}