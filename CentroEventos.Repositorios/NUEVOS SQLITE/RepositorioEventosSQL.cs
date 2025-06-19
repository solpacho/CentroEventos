using CentroEventos.Aplicacion;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios;

public class RepositorioEventosSQL : IRepositorioEvento
{

    public void AgregarEvento(EventoDeportivo evento)
    {using (var _context = new RepositorioContext())
        {
            _context.Eventos.Add(evento);
            _context.SaveChanges();
        }
    }

    public List<EventoDeportivo> ListarEventos()
    {   using (var _context = new RepositorioContext())
        {
            return _context.Eventos.ToList();
        }
    }

    public void EliminarEvento(int id)
    {   using (var _context = new RepositorioContext())
        {
            var evento = _context.Eventos.Find(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
                _context.SaveChanges();
            }
        }
    }

    public bool ExisteEvento(int id)
    {
        using (var _context = new RepositorioContext())
        {
            return _context.Eventos.Any(e => e.Id == id);

        }
    }
    public EventoDeportivo? ObtenerPorId(int id)
    {
        using (var _context = new RepositorioContext())
        {
            return _context.Eventos.Find(id);
        }
    }

    public bool EsResponsable(int id)
    {
        using (var _context = new RepositorioContext())
        {
            return _context.Eventos.Any(e => e.ResponsableId == id);
        }
    }
    public bool TieneReservasEvento(int idEvento)
    {
        using (var _context = new RepositorioContext())
        {
            return _context.Reservas.Any(r => r.EventoDeportivoId == idEvento);
        }
    }
    public void Modificar(EventoDeportivo evento)
    {   using (var _context = new RepositorioContext())
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
                _context.SaveChanges();
            }
        }
    }
}
