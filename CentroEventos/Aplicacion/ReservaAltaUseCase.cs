using CentroEventos.Aplicacion;

namespace Aplicacion;

public class ReservaAltaUseCase(IRepositorioReserva repoReserva, IRepositorioEvento repoEvento,
IRepositorioPersona repoPersona, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Reserva datosReserva, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaAlta)) {
            throw new FalloAutorizacionException("No tienes permisos para realizar esta acción. \n");
        }

        if (repoPersona.existePersona(datosReserva.PersonaId)) {
            throw new EntidadNotFound("No existe persona con ese ID. \n");
        }
        
        if (repoEvento.existeEvento(datosReserva.EventoDeportivoId)) {
            throw new EntidadNotFound("No existe evento con ese ID. \n");
        }

        if (repoReserva.ReservaExistente(datosReserva.PersonaId, datosReserva.EventoDeportivoId)) {
            throw new DuplicadoExcepcion("Ya se ha reservado a esta persona para este evento. \n");
        }

        //hacer segun reglas, hagan asi cada if de las excepciones es mas legible

        //asigno id
        datosReserva.Id=repoReserva.ObtenerNuevoId();

        repoReserva.AgregarReserva(datosReserva);
    }
}