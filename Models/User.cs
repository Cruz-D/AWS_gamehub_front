using System.ComponentModel.DataAnnotations;

public class User
{
    //==================================================

    [Required(ErrorMessage = "El ID de usuario es obligatorio.")]
    public string? userId { get; set; }

    //==================================================

    [Required]
    public SystemInfo? systemInfo { get; set; }

    [Required]
    public PersonalInfo? personalInfo { get; set; }

    public Verification? verification { get; set; }

    public Authentication? authentication { get; set; }

    public Location? location { get; set; }

    public Timestamps? timestamps { get; set; }

    //==================================================
}

public class SystemInfo
{
    [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre de usuario no puede superar los 50 caracteres.")]
    public string? username { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
    public string? password { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
    public string? email { get; set; }

    [Required(ErrorMessage = "El rol es obligatorio.")]
    public string? role { get; set; } = "User"; // Default role is "User"
}

public class PersonalInfo
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
    public string? firstName { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [StringLength(50, ErrorMessage = "El apellido no puede superar los 50 caracteres.")]
    public string? lastName { get; set; }

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
    [DataType(DataType.Date, ErrorMessage = "La fecha de nacimiento no es válida.")]
    public string? dateOfBirth { get; set; }

    [Url(ErrorMessage = "La URL de la foto de perfil no es válida.")]
    public string? profilePictureUrl { get; set; }
}

public class Verification
{
    public bool? isVerified { get; set; }

    [DataType(DataType.Date, ErrorMessage = "La fecha de verificación no es válida.")]
    public string? verifiedDate { get; set; }
}

public class Authentication
{
    public bool? isAuthenticated { get; set; }

    public bool? isLoggedIn { get; set; }

    public bool? isBanned { get; set; }

    public string? refreshToken { get; set; }

    public string? accessToken { get; set; }

    public string? tokenExpiry { get; set; }

    public string? tokenCreatedAt { get; set; }
}

public class Location
{
    [StringLength(50, ErrorMessage = "El país no puede superar los 50 caracteres.")]
    public string? country { get; set; }

    [StringLength(50, ErrorMessage = "La ciudad no puede superar los 50 caracteres.")]
    public string? city { get; set; }
}

public class Timestamps
{
    public string? createdAt { get; set; } = DateTime.UtcNow.ToString("o"); // Default to current UTC time

    public string? updatedAt { get; set; }

    public string? lastLogin { get; set; }
}
