using System;


namespace CentroEventos.Aplicacion;
public class EventoDeportivoAltaUseCase(IRepositorioEvento repositorio, ValidadorEventos validador, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(EventoDeportivo evento, int idUsuario)
    {

        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.EventoAlta))
        {
            throw new FalloAutorizacionException("No posee permisos para esta acción.");
        }

        if (!validador.Validar(evento, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        repositorio.AgregarEvento(evento);
    }
}
   
