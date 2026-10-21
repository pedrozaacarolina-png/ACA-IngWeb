namespace AcademicEnrollmentService.Core.Entities
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string ProgramaAcademico { get; set; } = string.Empty;
        public bool EstadoMatricula { get; set; }
    }
}