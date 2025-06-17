using System;

namespace CentroEventos.Aplicacion;

public class EventoDeportivoModificacionUseCase(IRepositorioEvento repositorio, ValidadorEventos validador, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(EventoDeportivo evento, int IdUsuario)
    {
        if (!autorizacion.PoseeElPermiso(IdUsuario, Permiso.EventoModificacion)) {
            throw new FalloAutorizacionException("No posee el permiso para realizar esta acción \n");
        }

        if (!validador.Validar(evento, out string mensajeError)) {
                throw new ValidacionException(mensajeError);
            }

        if (!repositorio.ExisteEvento(evento.Id)){
            throw new EntidadNotFoundException("No se ha encontrado el evento. \n");
        }
        
        repositorio.Modificar(evento);
    }
}
