using System.ComponentModel.DataAnnotations;

public class RegistroUsuarioModel
{
    [Required]
    public string Nombre { get; set; }

    [Required]
    public string Apellido { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "La contraseña no puede estar vacía.")]
    public string PasswordPlano { get; set; }
}
