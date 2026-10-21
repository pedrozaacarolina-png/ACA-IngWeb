namespace AcademicEnrollmentService.Services.Interfaces
{
    public interface IMatriculaService
    {
        Task<MatriculaResponseDto> ProcesarMatricula(CreateMatriculaDto createMatriculaDto);
        Task<IEnumerable<MatriculaResponseDto>> ObtenerMatriculas();
    }
}