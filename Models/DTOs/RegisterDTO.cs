using System.ComponentModel.DataAnnotations;

public class RegisterDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
    public string RepeatPassword { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public string DateOfBirth { get; set; }
    public string ProfilePictureUrl { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Role { get; set; } = "User";
    public string CreatedAt { get; set; } = DateTime.UtcNow.ToString("o");
}
