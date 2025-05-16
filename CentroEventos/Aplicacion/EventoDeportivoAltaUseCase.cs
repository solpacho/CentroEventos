using System;

namespace CentroEventos.Aplicacion;

public class EventoDeportivoAltaUseCase(IRepositorioEvento repositorio, ValidadorEventos validador, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(EventoDeportivo evento, int idUsuario) {
        if (!validador.Validar(evento, out string mensajeError)) {
            throw new Exception(mensajeError);
        }
        if (repositorio.ObtenerPorId(evento.id) != null)
            throw new Exception(DuplicadoException);
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.AgregarEvento))
            throw new Exception(FalloAutorizacionException);
        repositorio.AgregarEvento(evento);
    }
}