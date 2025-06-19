using System.ComponentModel.DataAnnotations;
using CentroEventos.Aplicacion;
namespace CentroEventos.UI;

public class PersonaModificacionModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El DNI es requerido")]
    public string DNI { get; set; } = "";
    
    [Required(ErrorMessage = "El nombre es requerido")]
    public string Nombre { get; set; } = "";
    
    [Required(ErrorMessage = "El apellido es requerido")]
    public string Apellido { get; set; } = "";
    
    [Required(ErrorMessage = "El email es requerido")]
    [EmailAddress(ErrorMessage = "El formato del email no es válido")]
    public string Email { get; set; } = "";
    
    [Required(ErrorMessage = "El teléfono es requerido")]
    public string Telefono { get; set; } = "";

    public PersonaModificacionModel() { }

    public PersonaModificacionModel(Persona persona)
    {
        Id = persona.Id;
        DNI = persona.DNI;
        Nombre = persona.Nombre;
        Apellido = persona.Apellido;
        Email = persona.Email;
        Telefono = persona.Telefono;
    }
}
