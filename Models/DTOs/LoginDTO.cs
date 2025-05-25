using System.ComponentModel.DataAnnotations;

namespace AWS_gamehub_front.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "El usuario o contraseña es obligatorio")]
        public required string UsernameOrEmail { get; set; } = String.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public required string Password { get; set; } = String.Empty;
    }
}
