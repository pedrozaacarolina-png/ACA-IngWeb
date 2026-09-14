using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademicEnrollmentService.Domain.DTOs;
using AcademicEnrollmentService.Domain.Entities;
using AcademicEnrollmentService.Data.Interfaces;

namespace AcademicEnrollmentService.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepository;

        public MatriculaService(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public async Task<MatriculaResponseDto> ProcesarMatricula(CreateMatriculaDto createMatriculaDto)
        {
            // Validate the incoming DTO
            if (createMatriculaDto == null)
            {
                throw new ArgumentNullException(nameof(createMatriculaDto));
            }

            // Create a new Matricula entity
            var matricula = new Matricula
            {
                EstudianteId = createMatriculaDto.EstudianteId,
                ProgramaAcademico = createMatriculaDto.ProgramaAcademico,
                Tarifa = createMatriculaDto.Tarifa,
                Estado = "Activo",
                FechaCreacion = DateTime.UtcNow
            };

            // Add the new Matricula to the repository
            await _matriculaRepository.AddMatricula(matricula);

            // Map the Matricula entity to the response DTO
            var responseDto = new MatriculaResponseDto
            {
                Id = matricula.Id,
                EstudianteId = matricula.EstudianteId,
                ProgramaAcademico = matricula.ProgramaAcademico,
                Tarifa = matricula.Tarifa,
                Estado = matricula.Estado,
                FechaCreacion = matricula.FechaCreacion
            };

            return responseDto;
        }

        public async Task<IEnumerable<MatriculaResponseDto>> ObtenerMatriculas()
        {
            var matriculas = await _matriculaRepository.GetAllMatriculas();
            var responseDtos = new List<MatriculaResponseDto>();

            foreach (var matricula in matriculas)
            {
                responseDtos.Add(new MatriculaResponseDto
                {
                    Id = matricula.Id,
                    EstudianteId = matricula.EstudianteId,
                    ProgramaAcademico = matricula.ProgramaAcademico,
                    Tarifa = matricula.Tarifa,
                    Estado = matricula.Estado,
                    FechaCreacion = matricula.FechaCreacion
                });
            }

            return responseDtos;
        }
    }
}