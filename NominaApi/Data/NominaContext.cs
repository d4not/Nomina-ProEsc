using Microsoft.EntityFrameworkCore;
using NominaApi.Models;

namespace NominaApi.Data;

// El "puente" entre C# y la base de datos SQLite (nomina.db).
// Cada DbSet es una tabla.
public class NominaContext : DbContext
{
    public NominaContext(DbContextOptions<NominaContext> options) : base(options) { }

    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Puesto> Puestos { get; set; }
    public DbSet<Nivel> Niveles { get; set; }
    public DbSet<Unidad> Unidades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Nombres de las tablas en la base de datos
        modelBuilder.Entity<Empleado>().ToTable("Empleado");
        modelBuilder.Entity<Categoria>().ToTable("Categoria");
        modelBuilder.Entity<Departamento>().ToTable("Departamento");
        modelBuilder.Entity<Puesto>().ToTable("Puesto");
        modelBuilder.Entity<Nivel>().ToTable("Nivel");
        modelBuilder.Entity<Unidad>().ToTable("Unidad");
    }
}
