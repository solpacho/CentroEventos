using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioReserva : IRepositorioReserva
{
    readonly string _archivo = "reservas.txt";

    public void AgregarReserva(Reserva reserva)
    {
        reserva.Id = ObtenerNuevoId();
        using var sw = new StreamWriter(_archivo, true);
        sw.WriteLine(reserva.Id);
        sw.WriteLine(reserva.PersonaId);
        sw.WriteLine(reserva.EventoDeportivoId);
        sw.WriteLine(reserva.FechaAltaReserva);
        sw.WriteLine((int)reserva.EstadoAsistencia); // guardar enum como número
    }

    public List<Reserva> ListarReservas()
    {
        var lista = new List<Reserva>();
        if (!File.Exists(_archivo))
            return lista;

        using var sr = new StreamReader(_archivo);
        while (!sr.EndOfStream)
        {
            var reserva = new Reserva();
            reserva.Id = int.Parse(sr.ReadLine() ?? "0");
            reserva.PersonaId = int.Parse(sr.ReadLine() ?? "0");
            reserva.EventoDeportivoId = int.Parse(sr.ReadLine() ?? "0");
            reserva.FechaAltaReserva = DateTime.Parse(sr.ReadLine() ?? "");
            reserva.EstadoAsistencia = (EstadoAsistencia)int.Parse(sr.ReadLine() ?? "0");
            lista.Add(reserva);
        }
        return lista;
    }

    public Reserva? ObtenerPorId(int id)
    {
        return ListarReservas().FirstOrDefault(r => r.Id == id);
    }

    public void Modificar(Reserva reserva)
    {
        var lista = ListarReservas();
        int indice = lista.FindIndex(r => r.Id == reserva.Id);
        if (indice == -1)
            return;

        lista[indice] = reserva;
        GuardarTodo(lista);
    }

    public void Eliminar(int id)
    {
        var lista = ListarReservas();
        var nuevaLista = lista.Where(r => r.Id != id).ToList();
        GuardarTodo(nuevaLista);
    }

    private void GuardarTodo(List<Reserva> lista)
    {
        using var sw = new StreamWriter(_archivo, false);
        foreach (var r in lista)
        {
            sw.WriteLine(r.Id);
            sw.WriteLine(r.PersonaId);
            sw.WriteLine(r.EventoDeportivoId);
            sw.WriteLine(r.FechaAltaReserva);
            sw.WriteLine((int)r.EstadoAsistencia);
        }
    }

    private int ObtenerNuevoId()
    {
        var lista = ListarReservas();
        return lista.Any() ? lista.Max(r => r.Id) + 1 : 1;
    }

    public bool ReservaExistente(int personaId, int eventoId)
    {
        var lista = ListarReservas();
        return lista.Any(r => r.PersonaId == personaId && r.EventoDeportivoId == eventoId);
    }

    public int CantidadReservasEvento(int eventoId)
    {
        var lista = ListarReservas();
        return lista.Count(r => r.EventoDeportivoId == eventoId);
    }
}
