using System;

namespace CentroEventos.Aplicacion;

public class ValidadorPersona(IRepositorioPersona repo)
{

    public bool Validar(Persona p, out string mensajeError)
    {
        mensajeError = "";
        if (string.IsNullOrEmpty(p.DNI))
        {
            mensajeError = "El dni no puede estar vacío. \n";
        }
        if (string.IsNullOrEmpty(p.Nombre))
        {
            mensajeError = "El nombre no puede estar vacío. \n";
        }
        if (string.IsNullOrEmpty(p.Apellido))
        {
            mensajeError = "El apellido no puede estar vacío. \n";
        }
        if (string.IsNullOrEmpty(p.Email))
        {
            mensajeError = "El email no puede estar vacío. \n";
        }
        return (mensajeError == "");
    }
}