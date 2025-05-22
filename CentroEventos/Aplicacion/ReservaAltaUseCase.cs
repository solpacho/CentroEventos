using CentroEventos.Aplicacion;

namespace CentroEventos.Aplicacion;

public class ReservaAltaUseCase(IRepositorioReserva repoReserva, IRepositorioEvento repoEvento,
IRepositorioPersona repoPersona, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Reserva datosReserva, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaAlta))
        {
            throw new FalloAutorizacionException("No tienes permisos para realizar esta acción. \n");
        }

        if (!repoPersona.ExistePersona(datosReserva.PersonaId))
        {
            throw new EntidadNotFoundException("No existe persona con ese ID. \n");
        }

        if (repoEvento.ExisteEvento(datosReserva.EventoDeportivoId))
        {
            throw new EntidadNotFoundException("No existe evento con ese ID. \n");
        }

        if (repoReserva.ReservaExistente(datosReserva.PersonaId, datosReserva.EventoDeportivoId))
        {
            throw new DuplicadoException("Ya se ha reservado a esta persona para este evento. \n");
        }

        //Un EventoDeportivo no puede tener más Reservas que su CupoMaximo.
        EventoDeportivo? evento = repoEvento.ObtenerPorId(datosReserva.EventoDeportivoId); //faltaria esto en el repo de eventos
        if (!(repoReserva.CantidadReservasEvento(datosReserva.Id) < evento.CupoMaximo))
        {
            throw new CupoExcedidoException("El cupo de reservas de ese evento deportivo está lleno \n");
        }

        //asigno id
        datosReserva.Id = repoReserva.ObtenerNuevoId();

        repoReserva.AgregarReserva(datosReserva);
    }
}
