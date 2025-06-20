

namespace CentroEventos.Aplicacion;

public class ReservaModificacionUseCase(IRepositorioReserva repositorioReserva, IRepositorioEvento repositorioEvento, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Reserva reserva, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion)){
            throw new FalloAutorizacionException("No posee permisos para realizar esta acción. \n");
        }

        if (!repositorioReserva.ExisteReserva(reserva.Id)){
            throw new EntidadNotFoundException("No se ha encontrado la reserva \n");
        }

        
        if (!repositorioEvento.ExisteEvento(reserva.EventoDeportivoId)){
            throw new EntidadNotFoundException("No se ha encontrado el evento deportivo \n");
        }

        
        var reservaOriginal = repositorioReserva.ObtenerPorId(reserva.Id);
        if (reservaOriginal == null){
            throw new EntidadNotFoundException("No se ha encontrado la reserva \n");
        }

        
        reserva.PersonaId = reservaOriginal.PersonaId; 
        reserva.FechaAltaReserva = reservaOriginal.FechaAltaReserva; 
 
        repositorioReserva.Modificar(reserva);
    }
}
