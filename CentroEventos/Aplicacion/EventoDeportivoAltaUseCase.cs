using System;
using Aplicacion;

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

        evento.Id = repositorio.ObtenerNuevoId();

        repositorio.AgregarEvento(evento);
        Console.WriteLine("Evento Deportivo agregado con éxito");
    }
}
   
