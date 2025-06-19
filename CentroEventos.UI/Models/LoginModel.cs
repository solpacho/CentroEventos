using System.ComponentModel.DataAnnotations;
public class LoginModel
{

    [Required(ErrorMessage = "Por favor, ingrese su mail.")]
    [EmailAddress(ErrorMessage = "El mail no es válido.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Por favor, ingrese su contraseña.")]
    public string? Contrasenia { get; set; }
        
}
