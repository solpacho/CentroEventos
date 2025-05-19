using CentroEventos.Aplicacion;

namespace Aplicacion;

public class ListarEventosConCupoDisponibleUseCase(IRepositorioEvento repoEventos, IRepositorioReserva repoReserva) {
    public List<EventoDeportivo> Ejecutar()
    {
        var lista = new List<EventoDeportivo>();

        var listaeventos = repoEventos.ListarEventos();

        foreach (EventoDeportivo evento in listaeventos)
        {
            if (evento.FechaHoraInicio >= DateTime.Now)
            {
                int reservasevento = repoReserva.CantidadReservasEvento(evento.Id);

                if (evento.CupoMaximo > reservasevento)
                {
                    listaeventos.Add(evento);
                }
            }
        }

        return listaeventos;
    }
}
