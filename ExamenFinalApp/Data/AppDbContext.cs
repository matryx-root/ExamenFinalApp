using ExamenFinalApp.Shared.Models;
using Microsoft.EntityFrameworkCore;


/// <summary>
/// 
///Migraciones fallidas
///** Error**:  
///`dotnet ef database update` no aplica cambios.  

///**Solución**:  
///```bash
///# Eliminar migraciones previas y recrear
/// dotnet ef migrations remove --project ExamenFinalApp.Server
/// dotnet ef migrations add InitialCreate --project ExamenFinalApp.Server
/// dotnet ef database update --project ExamenFinalApp.Server

/// </summary>

namespace ExamenFinalApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Libro> Libros => Set<Libro>(); // ✅ Cambiado de Registro a Libro
    }
}
