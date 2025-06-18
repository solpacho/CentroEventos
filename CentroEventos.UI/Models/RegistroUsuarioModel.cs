using System.ComponentModel.DataAnnotations;

public class RegistroUsuarioModel
{
    [Required]
    public string? Nombre { get; set; }

    [Required]
    public string? Apellido { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "El mail no puede estar vacío.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "La contraseña no puede estar vacía.")]
    public string? Contrasenia { get; set; }
}
