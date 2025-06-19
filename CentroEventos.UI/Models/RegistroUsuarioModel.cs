using System.ComponentModel.DataAnnotations;

public class RegistroUsuarioModel
{
    [Required(ErrorMessage = "El nombre no puede estar vacío.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El apellido no puede estar vacío.")]
    public string? Apellido { get; set; }

    [Required(ErrorMessage = "El mail no puede estar vacío.")]
    [EmailAddress(ErrorMessage = "El mail no es válido.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "La contraseña no puede estar vacía.")]
    public string? Contrasenia { get; set; }
}
