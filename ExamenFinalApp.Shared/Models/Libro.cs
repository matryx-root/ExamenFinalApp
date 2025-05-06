using System;
using System.ComponentModel.DataAnnotations;

namespace ExamenFinalApp.Shared.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El autor es obligatorio")]
        public string Autor { get; set; } = string.Empty;

        [Range(1, 2000, ErrorMessage = "El número de páginas debe ser mayor que 0")]
        public int Paginas { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Publicación")]
        public DateTime FechaPublicacion { get; set; } = DateTime.Now;

        public bool Disponible { get; set; }

    }
}
