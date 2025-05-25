using System.ComponentModel.DataAnnotations;

namespace gamehub_API.Infrastructure.Models
{
    public class Comments
    {
        [Required(ErrorMessage = "El ID de usuario es obligatorio.")]
        public string? userId { get; set; } // Usuario que hace el comentario

        [Required(ErrorMessage = "El ID del comentario es obligatorio.")]
        public string? commentId { get; set; } // ID único del comentario

        [Required(ErrorMessage = "El ID del videojuego es obligatorio.")]
        public string? gameId { get; set; } // ID del videojuego comentado

        [Required(ErrorMessage = "El contenido del comentario es obligatorio.")]
        [StringLength(1000, ErrorMessage = "El comentario no puede superar los 1000 caracteres.")]
        public string? content { get; set; } // Texto del comentario

        [Required(ErrorMessage = "La puntuación es obligatoria.")]
        [Range(0, 10, ErrorMessage = "La puntuación debe estar entre 0 y 10.")]
        public string? score { get; set; } // Puntuación del comentario (considera cambiar a int si es numérico)

        [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
        public string? createdAt { get; set; } // Fecha de creación

        public string? updatedAt { get; set; } // Fecha de actualización

        public bool? isEdited { get; set; }

        public bool? isDeleted { get; set; }
    }
}
