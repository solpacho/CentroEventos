
namespace CentroEventos.Aplicacion;

public class ValidadorUsuario()
{
    public bool Validar(Usuario u, out string MensajeError)
    {
        MensajeError = "";
        if (string.IsNullOrEmpty(u.Nombre))
        {
            MensajeError = "El nombre no puede estar vacío. \n";
        }
        if (string.IsNullOrEmpty(u.Apellido))
        {
            MensajeError = "El apellido no puede estar vacío. \n";
        }
        
       if (string.IsNullOrEmpty(u.PasswordHash))
        {
            MensajeError = "La contraseña no puede estar vacío. \n";
        }
        
        return (MensajeError == "");
    }
 }