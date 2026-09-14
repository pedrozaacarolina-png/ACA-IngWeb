namespace AcademicEnrollmentService.Data.Interfaces
{
    public interface IMatriculaRepository
    {
        IEnumerable<Matricula> GetAllMatriculas();
        Matricula GetMatriculaById(int id);
        void AddMatricula(Matricula matricula);
        void UpdateMatricula(Matricula matricula);
        void DeleteMatricula(int id);
    }
}