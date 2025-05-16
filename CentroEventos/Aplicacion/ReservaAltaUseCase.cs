namespace Aplicacion;

public class ReservaAltaUseCase(IRepositorioReserva repoReserva, IRepositorioEventoDeportivo repoEvento,
IRepositorioPersona repoPersona, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Reserva datosReserva, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaAlta))
            throw new Exception(FalloAutorizacionException);
        if ((repoPersona.ObtenerPorId(datosReserva.PersonaId) == null)) //|| (repoEvento.ObtenerPorId(datosReserva.EventoDeportivoId)==null))
            throw new Exception(EntidadNotFoundException);
        //Validar si hay cupo disponible
        if (repoReserva.ReservaExistente(datosReserva.PersonaId, datosReserva.EventoDeportivoId))
            throw new Exception(DuplicadoException);
        repoReserva.AgregarReserva(datosReserva);
    }
}