using System;

namespace CentroDeportivo;

public interface IRepositorioEvento
{
    void AgregarEvento(EventoDeportivo evento);
    List<EventoDeportivo> ListarEventos();
    void EliminarEvento(int id);
}
