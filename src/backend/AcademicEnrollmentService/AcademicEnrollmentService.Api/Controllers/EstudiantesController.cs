using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademicEnrollmentService.Infrastructure.Data;
using AcademicEnrollmentService.Core.Entities;

namespace AcademicEnrollmentService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstudiantesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/estudiantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        // POST: api/v1/estudiantes
        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstudiantes), new { id = estudiante.Id }, estudiante);
        }

        // PUT: api/v1/estudiantes/{id}/confirmar-pago (EL PASO 1 NUEVO)
        [HttpPut("{id}/confirmar-pago")]
        public async Task<IActionResult> ConfirmarPago(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound(new { mensaje = "Estudiante no encontrado" });
            }

            estudiante.EstadoMatricula = true;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Matrícula confirmada en la base de datos SQLite", estudiante });
        }
    }
}