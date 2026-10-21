using Microsoft.AspNetCore.Mvc;

namespace AcademicEnrollmentService.Api.Controllers
{
    // Modelo DTO explícito para evitar fallos de serialización en Swagger
    public class LoginDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto request)
        {
            if (request == null)
            {
                return BadRequest(new { mensaje = "Datos de inicio de sesión requeridos" });
            }

            if (request.Username == "admin" && request.Password == "123456")
            {
                return Ok(new 
                { 
                    token = "jwt-academica-elite-token-2026", 
                    username = request.Username, 
                    rol = "Admin",
                    mensaje = "Inicio de sesión exitoso"
                });
            }

            if (request.Username == "sofia" && request.Password == "123456")
            {
                return Ok(new 
                { 
                    token = "jwt-academica-elite-token-2026", 
                    username = request.Username, 
                    rol = "Estudiante",
                    mensaje = "Inicio de sesión exitoso"
                });
            }

            return Unauthorized(new { mensaje = "Usuario o contraseña incorrectos" });
        }
    }
}