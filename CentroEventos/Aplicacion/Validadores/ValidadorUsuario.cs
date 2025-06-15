using Aplicacion;
namespace CentroEventos.Aplicacion;

public class ValidadorUsuario(Usuario u, out string MensajeError)
{
    {
        mensajeError = "";
        if (string.IsNullOrEmpty(u.Nombre))
        {
            mensajeError = "El nombre no puede estar vacío. \n";
        }
        if (string.IsNullOrEmpty(u.Apellido))
        {
            mensajeError = "El apellido no puede estar vacío. \n";
        }
        
        if (string.IsNullOrEmpty(u.Password))
        {
            mensajeError = "La contraseña no puede estar vacío. \n";
        }
        
        return (mensajeError == "");
    }
 }