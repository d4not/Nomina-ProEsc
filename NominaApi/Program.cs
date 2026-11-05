using Microsoft.EntityFrameworkCore;
using NominaApi.Data;
using NominaApi.Utilidades;

var builder = WebApplication.CreateBuilder(args);

// 1. Controllers (EmpleadoController, CategoriaController, ...)
builder.Services.AddControllers().AddJsonOptions(o =>
{
    // aceptar números escritos como texto desde las cajas de Angular
    o.JsonSerializerOptions.Converters.Add(new EnteroFlexible());
    o.JsonSerializerOptions.Converters.Add(new NumeroFlexible<int>());
    o.JsonSerializerOptions.Converters.Add(new NumeroFlexible<double>());
    o.JsonSerializerOptions.Converters.Add(new TextoFlexible());
});

// 2. Base de datos SQLite (archivo nomina.db, ver appsettings.json)
builder.Services.AddDbContext<NominaContext>(o =>
    o.UseSqlite(builder.Configuration.GetConnectionString("Nomina")));

// 3. CORS: permitir que Angular (localhost:4200) llame a esta API
builder.Services.AddCors(o => o.AddPolicy("Angular", p =>
    p.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

// 4. Swagger: página para probar la API en http://localhost:5000/swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Crear la base de datos y datos de ejemplo la primera vez
using (var scope = app.Services.CreateScope())
{
    DatosEjemplo.Cargar(scope.ServiceProvider.GetRequiredService<NominaContext>());
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("Angular");
app.MapControllers();

app.Run();
