using System.ComponentModel.DataAnnotations;

namespace AWS_gamehub_front.Models
{
    public class Videogame
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string title { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(1000, ErrorMessage = "La descripción no puede superar los 1000 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "La URL de la portada es obligatoria.")]
        [Url(ErrorMessage = "La URL de la portada no es válida.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "El género es obligatorio.")]
        [StringLength(50, ErrorMessage = "El género no puede superar los 50 caracteres.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "La plataforma es obligatoria.")]
        [StringLength(50, ErrorMessage = "La plataforma no puede superar los 50 caracteres.")]
        public string Platform { get; set; }
    }
}
