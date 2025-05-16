using System;

namespace CentroEventos.Aplicacion;

public class EventoDeportivoAltaUseCase(IRepositorioEvento repositorio, ValidadorEventos validador, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(EventoDeportivo evento, int idUsuario) {
       
        if (!validador.Validar(evento, out string mensajeError)) {
            throw new ValidacionException(mensajeError);
        }

        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.AgregarEvento)) {
            throw new FalloAutorizacionException("No posee permisos para esta acción.");
        }
        
        evento.Id=repositorio.ObtenerNuevoId();

        repositorio.AgregarEvento(evento);
    }
}