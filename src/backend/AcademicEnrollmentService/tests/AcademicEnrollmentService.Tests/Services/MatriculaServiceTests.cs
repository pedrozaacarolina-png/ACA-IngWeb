using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademicEnrollmentService.Domain.DTOs;
using AcademicEnrollmentService.Domain.Entities;
using AcademicEnrollmentService.Services.Interfaces;
using Moq;
using Xunit;

namespace AcademicEnrollmentService.Tests.Services
{
    public class MatriculaServiceTests
    {
        private readonly Mock<IMatriculaRepository> _matriculaRepositoryMock;
        private readonly IMatriculaService _matriculaService;

        public MatriculaServiceTests()
        {
            _matriculaRepositoryMock = new Mock<IMatriculaRepository>();
            _matriculaService = new MatriculaService(_matriculaRepositoryMock.Object);
        }

        [Fact]
        public async Task ProcesarMatricula_ShouldAddMatricula_WhenValidDtoIsProvided()
        {
            // Arrange
            var createDto = new CreateMatriculaDto
            {
                EstudianteId = Guid.NewGuid(),
                ProgramaAcademico = "Ingeniería de Sistemas",
                Tarifa = 1000
            };

            // Act
            var result = await _matriculaService.ProcesarMatricula(createDto);

            // Assert
            _matriculaRepositoryMock.Verify(repo => repo.AddMatricula(It.IsAny<Matricula>()), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(createDto.EstudianteId, result.EstudianteId);
            Assert.Equal(createDto.ProgramaAcademico, result.ProgramaAcademico);
            Assert.Equal(createDto.Tarifa, result.Tarifa);
            Assert.Equal("Activo", result.Estado);
            Assert.True(result.FechaCreacion <= DateTime.UtcNow);
        }

        [Fact]
        public async Task GetAllMatriculas_ShouldReturnListOfMatriculas()
        {
            // Arrange
            var matriculas = new List<Matricula>
            {
                new Matricula { Id = Guid.NewGuid(), EstudianteId = Guid.NewGuid(), ProgramaAcademico = "Ingeniería de Sistemas", Tarifa = 1000, Estado = "Activo", FechaCreacion = DateTime.UtcNow },
                new Matricula { Id = Guid.NewGuid(), EstudianteId = Guid.NewGuid(), ProgramaAcademico = "Ingeniería Industrial", Tarifa = 1200, Estado = "Activo", FechaCreacion = DateTime.UtcNow }
            };

            _matriculaRepositoryMock.Setup(repo => repo.GetAllMatriculas()).ReturnsAsync(matriculas);

            // Act
            var result = await _matriculaService.GetAllMatriculas();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}