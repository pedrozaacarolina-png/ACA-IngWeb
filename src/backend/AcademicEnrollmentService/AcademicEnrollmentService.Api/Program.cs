using Microsoft.EntityFrameworkCore;
using AcademicEnrollmentService.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración de puerto dinámico para hosting en la nube (Render / Railway)
var port = Environment.GetEnvironmentVariable("PORT") ?? "5179";
builder.WebHost.UseUrls($"http://*:{port}");

// 1. Agregar Controladores y OpenAPI
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// 2. Configurar CORS (Permite peticiones desde GitHub Pages)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy => 
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// 3. Conexión a SQLite
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();

// 4. Creación e inicialización automática de Base de Datos
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

app.UseCors("AllowAll");
app.MapOpenApi();
app.MapControllers();

app.Run();