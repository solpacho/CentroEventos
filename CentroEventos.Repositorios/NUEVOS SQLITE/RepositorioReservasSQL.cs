
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioReservaSQL : IRepositorioReserva
{

    public void AgregarReserva(Reserva reserva)
    {
        using (var _context = new RepositorioContext())
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
        }
    }

    public List<Reserva> ListarReservas()
    {   using (var _context = new RepositorioContext()){
           return _context.Reservas.ToList();
        }
    }

    public Reserva? ObtenerPorId(int id)
    {   using (var _context = new RepositorioContext()){
            return _context.Reservas.Find(id);
        }
    }

    public void Modificar(Reserva reserva)
    {   using (var _context = new RepositorioContext()){
            var resExistente = _context.Reservas.Find(reserva.Id);
            if (resExistente != null)
            {
                resExistente.PersonaId=reserva.PersonaId;
                resExistente.EventoDeportivoId = reserva.EventoDeportivoId;
                resExistente.FechaAltaReserva=reserva.FechaAltaReserva;
                resExistente.Estado=reserva.Estado;
                _context.SaveChanges();
            }
        }
    }

    public void Eliminar(int id)
    {   using (var _context = new RepositorioContext()){
            var resExistente = _context.Reservas.Find(id);

            if (resExistente!=null){
                _context.Reservas.Remove(resExistente);
                _context.SaveChanges();
            }
        }
    }

    public bool ExisteReserva(int id)
      {
        using (var _context = new RepositorioContext()){
             return _context.Reservas.Any(r => r.Id == id);

        }
      }
    

    public bool ReservaExistente(int personaId, int eventoId)
    {
        using (var ctx = new RepositorioContext())
        {
            return ctx.Reservas.Any(r =>
                r.PersonaId == personaId && r.EventoDeportivoId == eventoId
            );
        }
    }
    public bool TieneReservasEvento(int idEvento)
    {
        using (var _context = new RepositorioContext())
        {
            return _context.Reservas.Any(r => r.EventoDeportivoId == idEvento);
        }
    }

    public int CantidadReservasEvento(int eventoId)
    {
        using (var ctx = new RepositorioContext())
        {
        return ctx.Reservas.Count(r => r.EventoDeportivoId == eventoId);
        }
    }


    public bool TieneReserva(int personaId) // reglas de uso: la ultima
    {   
        using (var ctx = new RepositorioContext())
        {
            return ctx.Reservas.Any(r => r.PersonaId == personaId);
        }
    }
     
}
