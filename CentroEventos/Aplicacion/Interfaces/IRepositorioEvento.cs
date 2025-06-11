using System;
using Aplicacion;
namespace CentroEventos.Aplicacion;

public interface IRepositorioEvento
{
    //id
    int ObtenerNuevoId();
    //

    void AgregarEvento(EventoDeportivo evento);
    List<EventoDeportivo> ListarEventos();
    void EliminarEvento(int id);

    bool EsResponsable(int id);
    bool ExisteEvento(int id);
    void Modificar(EventoDeportivo evento);
    EventoDeportivo? ObtenerPorId(int id);
}
