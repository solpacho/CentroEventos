using System.ComponentModel.DataAnnotations;
public class LoginModel
{

    [Required]
    [EmailAddress(ErrorMessage = "Por favor, ingrese su mail")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Por favor, inrese su cotraseña")]
    public string? Contrasenia { get; set; }
        
}