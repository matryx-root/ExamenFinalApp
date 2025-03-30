using ExamenFinalApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenFinalApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Libro> Libros => Set<Libro>(); // ✅ Cambiado de Registro a Libro
    }
}
