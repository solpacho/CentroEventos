using System;
using CentroEventos.Aplicacion;
namespace Aplicacion;

public class ListarAsistenciaAEventoUseCase(IRepositorioEvento repositorioE, IRepositorioReserva repositorioR, IRepositorioPersona repositorioP, ValidadorEventos validador)
{
    public List<Persona> Ejecutar(EventoDeportivo evento)
    {
        var listaPresentes = new List<Persona>();
        
        if (!repositorioE.ExisteEvento(evento.Id))
        {

            throw new EntidadNotFoundException("No se ha encontrado el evento. \n");
        }

        if (!validador.Validar(evento, out string mensajeError)){
                 
            throw new ValidacionException(mensajeError);
        }

        if (!(evento.FechaHoraInicio < DateTime.Now)){ //si no es un evento pasado
                 
            throw new OperacionInvalidaException("Este evento no es un evento pasado");
        }

        List<Reserva> reservas = repositorioR.ListarReservas(); //obtengo todas las reservas
        foreach (Reserva r in reservas)
        {
            if ((r.EventoDeportivoId == evento.Id) && (r.Estado == EstadoAsistencia.Presente)) //si la reserva es de este evento y se asistió
            {
                Persona? p = repositorioP.ObtenerPorId(r.PersonaId);
                listaPresentes.Add(p);
            }
        }
        return listaPresentes;
        
    }
}
