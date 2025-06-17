using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioEvento
{

    void AgregarEvento(EventoDeportivo evento);
    List<EventoDeportivo> ListarEventos();
    void EliminarEvento(int id);

    bool EsResponsable(int id);
    bool ExisteEvento(int id);
    void Modificar(EventoDeportivo evento);
    EventoDeportivo? ObtenerPorId(int id);
}
