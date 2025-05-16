using System;
namespace CentroEventos.Aplicacion;

public interface IRepositorioEvento
{
    //id
    int ObtenerNuevoId();
    //

    void AgregarEvento(EventoDeportivo evento);
    List<EventoDeportivo> ListarEventos();
    void EliminarEvento(int id);

    bool esResponsable(int id);

    bool existeEvento(int id);

    bool controlReserva(EventoDeportivo evento)
    
}
