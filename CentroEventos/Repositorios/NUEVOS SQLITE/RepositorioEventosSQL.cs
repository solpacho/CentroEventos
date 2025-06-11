using CentroEventos.Aplicacion;
using Microsoft.EntityFrameworkCore;

namespace Repositorios;

public class RepositorioEventosSQL : IRepositorioEvento
{
    private readonly RepositorioContext _context;

    public RepositorioEventosSQL(RepositorioContext context)
    {
        _context = context; // inyección de dependencias, preguntar
    }

    public void AgregarEvento(EventoDeportivo evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }

    public List<EventoDeportivo> ListarEventos()
    {
        return _context.Eventos.ToList();
    }

    public void EliminarEvento(int id)
    {
        var evento = _context.Eventos.Find(id);
        if (evento != null)
        {
            _context.Eventos.Remove(evento);
            _context.SaveChanges();
        }
    }

    public int ObtenerNuevoId() // habría que borrarlo?
    {
        // Ya no lo necesitás porque EF lo genera automáticamente.
        return -1; // o podés tirar excepción si querés evitar el uso.
    }

    public bool ExisteEvento(int id)
    {
        return _context.Eventos.Any(e => e.Id == id);
    }

    public EventoDeportivo? ObtenerPorId(int id)
    {
        return _context.Eventos.Find(id);
    }

    public bool EsResponsable(int id)
    {
        return _context.Eventos.Any(e => e.ResponsableId == id);
    }

    public void Modificar(EventoDeportivo evento)
    {
        var eventoExistente = _context.Eventos.Find(evento.Id);
        if (eventoExistente != null)
        {
            eventoExistente.Nombre = evento.Nombre;
            eventoExistente.CupoMaximo = evento.CupoMaximo;
            eventoExistente.Descripcion = evento.Descripcion;
            eventoExistente.DuracionHoras = evento.DuracionHoras;
            eventoExistente.FechaHoraInicio = evento.FechaHoraInicio;
            eventoExistente.ResponsableId = evento.ResponsableId;
            // id no lo modifico ??
            // preguntar si se puede usar directamente _context.Eventos.Update(evento);
            _context.SaveChanges();
        }
    }
}
