using System;
using System.ComponentModel.DataAnnotations;
/// Modelo de dominio para libros. Incluye validaciones automáticas.
namespace ExamenFinalApp.Shared.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(50, ErrorMessage = "El título no puede exceder 50 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El autor es obligatorio")]
        [StringLength(30, ErrorMessage = "El autor no puede exceder 30 caracteres")]
        public string Autor { get; set; } = string.Empty;

        [Range(1, 5000, ErrorMessage = "El número de páginas debe estar entre 1 y 5000")]
        public int Paginas { get; set; }

        [Required(ErrorMessage = "La fecha de publicación es obligatoria")]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        [CustomValidation(typeof(Libro), nameof(ValidateFechaPublicacion))]
        public DateTime FechaPublicacion { get; set; } = DateTime.Today;

        [Required]
        public bool Disponible { get; set; } = true;

        public static ValidationResult ValidateFechaPublicacion(DateTime fecha, ValidationContext context)
        {
            return fecha <= DateTime.Today ? ValidationResult.Success : new ValidationResult("La fecha no puede ser futura");

        }
    }
}
