using Microsoft.AspNetCore.Mvc;
using AcademicEnrollmentService.Domain.DTOs;
using AcademicEnrollmentService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicEnrollmentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculasController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculasController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatriculaResponseDto>>> GetAllMatriculas()
        {
            var matriculas = await _matriculaService.GetAllMatriculasAsync();
            return Ok(matriculas);
        }

        [HttpPost]
        public async Task<ActionResult<MatriculaResponseDto>> CreateMatricula(CreateMatriculaDto createMatriculaDto)
        {
            var matriculaResponse = await _matriculaService.ProcesarMatriculaAsync(createMatriculaDto);
            return CreatedAtAction(nameof(GetAllMatriculas), new { id = matriculaResponse.Id }, matriculaResponse);
        }
    }
}