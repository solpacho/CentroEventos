using CentroEventos.Aplicacion;

namespace CentroEventos.Aplicacion;

public class PersonaBajaUseCase(IRepositorioPersona repositorioP, IServicioAutorizacion autorizacion, IRepositorioEvento repositorioEV, IRepositorioReserva repositorioR, ValidadorPersona validador)
{
    public void Ejecutar(int idPersona, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja)) {
            throw new FalloAutorizacionException("No posee permisos para realizar esta acción. \n");
        }

        if (!repositorioP.ExistePersona(idPersona))
        {
            throw new EntidadNotFoundException("No se ha encontrado la persona. \n");
        }
        
        // reglas

        if (repositorioEV.EsResponsable(idPersona))
        {
            throw new OperacionInvalidaException("No puede eliminarse esta persona.");
        }

        if (repositorioR.TieneReserva(idPersona))
        { 
            throw new OperacionInvalidaException("No puede eliminarse esta persona.");
        }

        repositorioP.Eliminar(idPersona);
    }
}
