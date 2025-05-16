using CentroEventos.Aplicacion;

namespace Aplicacion;

public class PersonaBajaUseCase(IRepositorioPersona repositorioP, IServicioAutorizacion autorizacion, IRepositorioEventoDeportivo repositorioEV, IRepositorioReserva repositorioR)
{
    public void Ejecutar(int idPersona, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja)) {
            throw new FalloAutorizacionException("No posee permisos para realizar esta acción. \n");
        }

        if (!repositorioP.existePersona(idPersona)) {
            throw new EntidadNotFoundException("No se ha encontrado la persona. \n");
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