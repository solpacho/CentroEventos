using CentroEventos.Aplicacion;

namespace Aplicacion;

public class PersonaBajaUseCase(IRepositorioPersona repositorioP, IServicioAutorizacion autorizacion, IRepositorioEvento repositorioEV, IRepositorioReserva repositorioR, ValidadorPersona validador)
{
    public void Ejecutar(int idPersona, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja)) {
            throw new FalloAutorizacionException("No posee permisos para realizar esta acción. \n");
        }

        if (!repositorioP.existePersona(idPersona))
        {
            throw new EntidadNotFoundException("No se ha encontrado la persona. \n");
        }

        Persona p = repositorioP.ObtenerPorId(idPersona); //hago esto unicamente si la persona existe
        if (!validador.Validar(p, out string mensajeError)){ //no se como resolver la warning
            throw new ValidacionException(mensajeError);
        }
        
        // reglas

        if (repositorioEV.esResponsable(idPersona))
        {
            throw new OperacionInvalidaException("No puede eliminarse esta persona.");
        }

        if (repositorioR.tieneReserva(idPersona))
        { 
            throw new OperacionInvalidaException("No puede eliminarse esta persona.");
        }

        repositorioP.Eliminar(idPersona);
    }
}
