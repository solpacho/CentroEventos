using System;
using CentroEventos.Aplicacion;
namespace Aplicacion;

public class ListarAsistenciaAEventoUseCase(IRepositorioEvento repositorioE, IRepositorioReserva repositorioR, IRepositorioPersona repositorioP)
{
    public List<Persona> Ejecutar(EventoDeportivo evento)
    {
        var listaPresentes = new List<Persona>();
        
        if (!repositorioE.ExisteEvento(evento.Id))
        {

            throw new EntidadNotFoundException("No se ha encontrado el evento. \n");
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
                if(p==null) throw new EntidadNotFoundException("No se encontró a la prsona");
                listaPresentes.Add(p);
            }
        }
        return listaPresentes;
        
    }
}
